﻿using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using INTEREST.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace INTEREST.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }
        private IEmailService emailService { get; set; }
        public UserService(IUnitOfWork uow, IEmailService _emailService)
        {
            Database = uow;
            emailService = _emailService;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDTO)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                // Add User
                user = await Database.UserManager.FindByNameAsync(userDTO.UserName);
                if (user != null)
                    return new OperationDetails(false, "Username is being use", "");
                user = Database.UserManager.Users.FirstOrDefault(x => x.PhoneNumber == userDTO.Phone);
                if (user != null)
                    return new OperationDetails(false, "Phone number is being use", "");
                user = new User
                {
                    Email = userDTO.Email,
                    UserName = userDTO.UserName,
                    PhoneNumber = userDTO.Phone
                };
                var result = await Database.UserManager.CreateAsync(user, userDTO.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().Description, "");
                // Add Role
                await Database.UserManager.AddToRoleAsync(user, userDTO.Role);
                // Create location
                Location location = Database.LocationRepository.FindClone(userDTO.Location);
                if (location == null)
                {
                    location = userDTO.Location;
                    Database.LocationRepository.Create(userDTO.Location);
                }
                // Create Default Avatar
                Database.PhotoRepository.Create(userDTO.Avatar);

                UserProfile userProfile = new UserProfile
                {
                    UserId = user.Id,
                    Birthday = userDTO.Birthday,
                    Gender = userDTO.Gender,
                    Location = location,
                    Avatar = userDTO.Avatar,
                };
                Database.UserProfileRepository.Create(userProfile);

                user.ProfileId = userProfile.Id;
                result = await Database.UserManager.UpdateAsync(user);


                var code = await Database.UserManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = "https://localhost:44330/Account/ConfirmEmail?code=" + code + "&id=" + user.Id;
                await emailService.SendEmailAsync(user.Email, "Confirm your account",
                    $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");



                await Database.SaveAsync();
                return new OperationDetails(true, "Registration is sucsessfuly complited", "");
            }
            else
            {
                return new OperationDetails(false, "User with such login is exist", "Email");
            }
        }

        public async Task<bool> SignInAsync(UserDTO userDto)
        {    
            var userName = userDto.Email;
            if (userName.IndexOf('@') > -1)
            {
                var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
                userName = user.UserName;
            }
            var auth = await Database.SignInManager.PasswordSignInAsync(
                userName,
                userDto.Password,
                false,
                lockoutOnFailure: false);
            return auth.Succeeded;
        }

        public async Task AdminCreateAsync(UserDTO adminDto)
        {
            if (!Database.UserManager.Users.Any())
            {
                await CreateAsync(adminDto);
            }
        }

        public async Task<User> GetCurrentUserAsync(HttpContext context)
        {
            return await Database.UserManager.GetUserAsync(context.User);
        }

        public async Task SignOutAsync()
        {
            await Database.SignInManager.SignOutAsync();
        }

        public async Task DeleteUser(string name)
        {
            User user = await Database.UserManager.FindByNameAsync(name);
            if (user != null)
            {
                await Database.UserManager.DeleteAsync(user);
            }
            await Database.SaveAsync();
        }

    }
}

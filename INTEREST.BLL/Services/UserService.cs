using INTEREST.BLL.DTO;
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
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        //CREATE USER
        public async Task<OperationDetails> CreateAsync(UserDTO userDTO)
        {
            if (await Database.UserManager.FindByEmailAsync(userDTO.Email) != null)
            {
                return new OperationDetails(false, "User with this e-mail already exists", "Email");
            }
            User user = new User
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                PhoneNumber = userDTO.Phone
            };
            var result = await Database.UserManager.CreateAsync(user, userDTO.Password);

            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }
            // Add role
            await Database.UserManager.AddToRoleAsync(user, userDTO.Role);
            // Create UserProfile
            Location location = Database.LocationRepository.FindClone(userDTO.Location);
            if (location == null)
            {
                location = userDTO.Location;
                Database.LocationRepository.Create(userDTO.Location);
            }
            UserProfile userProfile = new UserProfile
            {
                UserId = user.Id,
                Birthday = userDTO.Birthday,
                Gender = userDTO.Gender,
                Location = location
            };
            Database.UserProfileRepository.Create(userProfile);
            user.ProfileId = userProfile.Id;

            result = await Database.UserManager.UpdateAsync(user);
            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }

            await Database.SaveAsync();
            return new OperationDetails(true, "Registration successfully completed", "");
        }

        //AUTENTIFICATION
        public async Task<bool> SignInAsync(UserDTO userDto)
        {
            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            var auth = await Database.SignInManager.PasswordSignInAsync(user.UserName, userDto.Password, false, lockoutOnFailure: false);
            return auth.Succeeded;
        }

        // DATABASE INITIALIZATION
        public async Task AdminCreateAsync(UserDTO adminDto)
        {
            if (!Database.UserManager.Users.Any())
            {
                await CreateAsync(adminDto);
            }
        }

        //GET CURRENT USER
        public async Task<User> GetCurrentUserAsync(HttpContext context)
        {
            return await Database.UserManager.GetUserAsync(context.User);
        }

        // SIGN OUT
        public async Task SignOutAsync()
        {
            await Database.SignInManager.SignOutAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}

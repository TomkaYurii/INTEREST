using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using INTERESTS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                // create User
                user = new User { Email = userDto.Email, UserName = userDto.UserName, PhoneNumber = userDto.Phone };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
                // create Role
                await Database.UserManager.AddToRoleAsync(user, userDto.Role);
                // create UserProfile
                UserProfile clientProfile = new UserProfile { Id = user.Id, Birthday = userDto.Birthday, Gender = userDto.Gender, Location = userDto.Location };
                Database.UserProfileRepository.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<bool> SignIn(UserDTO userDto)
        {
            // Find User    
            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            var username = user.UserName;
            var auth = await Database.SignInManager.PasswordSignInAsync(username, userDto.Password, false, lockoutOnFailure: false);
            // Auteentification 
            return auth.Succeeded;
        }

        // DataBase Initialization
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public async Task SignOut()
        {
            await Database.SignInManager.SignOutAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}

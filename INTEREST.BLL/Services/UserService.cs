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
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.UserName, PhoneNumber = userDto.Phone };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user, userDto.Role);
                // создаем профиль клиента
                UserProfile clientProfile = new UserProfile { Id = user.Id, Birthday = userDto.Birthday, Gender = userDto.Gender };
                Database.UserProfileManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<bool> Authenticate(UserDTO userDto)
        {
            // находим пользователя    
            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            var username = user.UserName;
            var auth = await Database.SignInManager.PasswordSignInAsync(username, userDto.Password, false, lockoutOnFailure: false);
            // авторизуем его 
            return auth.Succeeded;
        }

        // начальная инициализация бд
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

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}

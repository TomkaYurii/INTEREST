using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<bool> SignInAsync(UserDTO userDto);
        Task AdminCreateAsync(UserDTO adminDto);
        Task<User> GetCurrentUserAsync(HttpContext context);
        Task DeleteUser(string name);
        Task SignOutAsync();
    }
}

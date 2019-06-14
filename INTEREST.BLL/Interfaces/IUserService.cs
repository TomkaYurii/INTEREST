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
        Task<OperationDetails> Create(UserDTO userDto);
        Task<bool> SignIn(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        Task<User> GetCurrentUserAsync(HttpContext context);
        Task SignOut();
    }
}

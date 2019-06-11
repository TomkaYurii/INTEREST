using INTERESTS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> UserManager { get; }
        IUserProfileManager UserProfileManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        Task SaveAsync();
    }
}

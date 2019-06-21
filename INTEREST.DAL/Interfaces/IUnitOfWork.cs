using INTEREST.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace INTEREST.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ILocationRepository LocationRepository { get; }
        IEventRepository EventRepository { get; }
        ICategoryEventRepository CategoryEventRepository { get; }
        IUserProfileCategoryRepository UserProfileCategoryRepository { get; }
        IMessageRepository MessageRepository { get; }
        Task SaveAsync();
    }
}

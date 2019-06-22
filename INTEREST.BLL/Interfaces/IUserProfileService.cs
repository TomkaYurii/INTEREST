using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IUserProfileService : IDisposable
    {
        List<UserProfileDTO> GetUsers();
        UserProfileDTO GetProfile(string u);
        Task AddAvatar(string url, UserProfile userProfile);

        User GetUserByName(string user);
        Task<User> GetUserById(string id);
        Task<OperationDetails> EditProfile(UserProfileDTO model);
        Task<OperationDetails> DeleteUser(string id);
    }
}

using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IUserProfileService
    {
        Task<OperationDetails> EditProfile(UserProfileDTO model);
        Task DeleteUser(string id);
        Task AddAvatar(string url, UserProfile userProfile);


        List<UserProfileDTO> GetUsersAsync();
        UserProfileDTO GetProfile(string u);
        User GetUserByName(string user);
    }
}

using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IUserProfileService : IDisposable
    {
        List<UserProfileDTO> GetUsers();
        UserProfileDTO GetProfile(User u);
        Task AddAvatar(string url, UserProfile userProfile);


        UserProfile GetProfileByName(User user);

        //UserProfile FindById(string id);
        //UserProfileDTO FindProfileByUserName(string UserName);
    }
}

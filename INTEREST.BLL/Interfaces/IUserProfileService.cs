using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IUserProfileService : IDisposable
    {
        //Task<UserProfileDTO> FindUserProfileByUserName(string UserName);
        //List<UserProfileDTO> GetUsers();
        UserProfileDTO GetProfile(User u);
    }
}

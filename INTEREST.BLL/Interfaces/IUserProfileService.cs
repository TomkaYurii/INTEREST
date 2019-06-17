using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;

namespace INTEREST.BLL.Interfaces
{
    public interface IUserProfileService : IDisposable
    {
        List<UserProfileDTO> GetUsers();
        UserProfileDTO GetProfile(User u);
    }
}

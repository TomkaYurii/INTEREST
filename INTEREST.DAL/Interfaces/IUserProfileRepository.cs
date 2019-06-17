using INTEREST.DAL.Entities;
using System;

namespace INTEREST.DAL.Interfaces
{
    public interface IUserProfileRepository : IBaseRepository<UserProfile>
    {
        //void Create(UserProfile profile);
        UserProfile FindByUserId(string id);
        User FindByUserName(string UserName);
    }
}

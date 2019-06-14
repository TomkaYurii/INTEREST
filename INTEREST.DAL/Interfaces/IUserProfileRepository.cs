using INTEREST.DAL.Entities;
using System;

namespace INTEREST.DAL.Interfaces
{
    public interface IUserProfileRepository : IDisposable
    {
        void Create(UserProfile profile);
        UserProfile FindById(string id);
        User FindByUserName(string UserName);
    }
}

using INTERESTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Interfaces
{
    public interface IUserProfileRepository : IDisposable
    {
        void Create(UserProfile profile);
        UserProfile FindById(string id);
        User FindByUserName(string UserName);
    }
}

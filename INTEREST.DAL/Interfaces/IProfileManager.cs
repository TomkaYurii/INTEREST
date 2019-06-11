using INTERESTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Interfaces
{
    public interface IUserProfileManager : IDisposable
    {
        void Create(UserProfile profile);
    }
}

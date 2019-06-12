using INTEREST.DAL.Interfaces;
using INTERESTS.DAL.EF;
using INTERESTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDBContext Database;

        public UserProfileRepository(AppDBContext db)
        {
            Database = db;
        }

        public void Create(UserProfile userprofile)
        {
            Database.UserProfiles.Add(userprofile);
            Database.SaveChanges();
        }

        public UserProfile FindById(string id)
        {
            return Database.UserProfiles.FirstOrDefault(x => x.Id == id);
        }

        public User FindByUserName(string UserName)
        {
            User user = Database.Users.FirstOrDefault(x => x.UserName == UserName);
            user.UserProfile = Database.UserProfiles.FirstOrDefault(x => x.Id == user.Id);
            return user;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using System.Linq;

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

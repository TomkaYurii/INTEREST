using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDBContext db;

        public UserProfileRepository(AppDBContext context)
        {
            db = context;
        }

        public void Create(UserProfile userprofile)
        {
            db.UserProfiles.Add(userprofile);
            db.SaveChanges();
        }

        public UserProfile FindById(string id)
        {
            return db.UserProfiles.FirstOrDefault(x => x.Id == id);
        }

        public User FindByUserName(string UserName)
        {
            User user = db.Users.FirstOrDefault(x => x.UserName == UserName);
            user.UserProfile = db.UserProfiles.FirstOrDefault(x => x.Id == user.Id);
            return user;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

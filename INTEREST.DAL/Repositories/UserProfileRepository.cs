using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDBContext context) : base(context)
        {
        }

        //public void Create(UserProfile userProfile)
        //{
        //    _context.UserProfiles.Add(userProfile);
        //    _context.SaveChanges();
        //}

        public UserProfile FindByUserId(string id)
        {
            return _context.UserProfiles.FirstOrDefault(x => x.UserId == id);
        }
        public User FindByUserName(string UserName)
        {
            User user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            user.UserProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == user.Id);
            user.UserProfile.Location = _context.Locations.FirstOrDefault(x => x.UserProfileId == user.ProfileId);
            return user;
        }
    }
}

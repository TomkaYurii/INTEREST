using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDBContext context) : base(context)
        {
           
        }

        public User FindByUserProfileId(int UserProfileId)
        {
            return context.Users.FirstOrDefault(x => x.ProfileId == UserProfileId);
        }

        public User FindByUserName(string UserName)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == UserName);
            user.UserProfile = context.UserProfiles.FirstOrDefault(x => x.UserId == user.Id);
            user.UserProfile = context.UserProfiles.FirstOrDefault(x => x.UserId == user.Id);
            user.UserProfile.Avatar = context.Photos.FirstOrDefault(x => x.Id == user.UserProfile.PhotoId);
            user.UserProfile.Location = context.Locations.FirstOrDefault(x => x.Id == user.UserProfile.LocationId);
            return user;
        }
    }
}

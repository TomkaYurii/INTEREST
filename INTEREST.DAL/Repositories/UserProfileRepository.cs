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
    }
}

using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileCategoryRepository : BaseRepository<UserProfileCategory>, IUserProfileCategoryRepository
    {
        public UserProfileCategoryRepository(AppDBContext context) : base(context)
        {
        }
    }
}

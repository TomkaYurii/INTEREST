using INTEREST.DAL.Entities;

namespace INTEREST.DAL.Interfaces
{
    public interface IUserProfileRepository : IBaseRepository<UserProfile>
    {
        User FindByUserName(string UserName);
        User FindByUserProfileId(int UserProfileId);
    }
}

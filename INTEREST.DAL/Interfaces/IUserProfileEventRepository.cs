using INTEREST.DAL.Entities;
using System.Linq;

namespace INTEREST.DAL.Interfaces
{
    public interface IUserProfileEventRepository : IBaseRepository<UserProfileEvent>
    {
        IQueryable<UserProfileEvent> GetProfilesByEventId(int event_id);
        int CountSubscribers(int event_id);
    }
}

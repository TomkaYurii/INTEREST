using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileEventRepository : BaseRepository<UserProfileEvent>, IUserProfileEventRepository
    {
        public UserProfileEventRepository(AppDBContext context) : base(context)
        {
        }

        public IQueryable<UserProfileEvent> GetProfilesByEventId(int event_id)
        {
            return context.UserProfileEvents.Where(x => x.EventId == event_id)
                .Include(x => x.UserProfile)
                    .ThenInclude(u=>u.User);
        }

        public int CountSubscribers(int event_id)
        {
            return context.UserProfileEvents.Where(x => x.EventId == event_id).Count();
        }

    }
}

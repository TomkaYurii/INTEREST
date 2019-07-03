using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(AppDBContext context) : base(context)
        {
        }

        public IEnumerable<Event> GetEventsByDate(int number)
        {
            var evnts = context.Events.OrderByDescending(e => e.DateFrom).Take(number)
                .Include(l => l.Location)
                .Include(u => u.UserProfile)
                    .ThenInclude(u => u.User)
                .Include(p => p.Photo);
            return evnts;
        }

        public IQueryable<Event> GetAllEventsInfo()
        {
            var evnt = context.Events
                .Include(l => l.Location)
                .Include(u => u.UserProfile)
                    .ThenInclude(u => u.User)
                .Include(p => p.Photo);
            return evnt;
        }

        public Event GetOneEventInfo(int id)
        {
            Event evnt = context.Events
                .Include (l => l.Location)
                .Include (u => u.UserProfile)
                .Include (p => p.Photo)
                .FirstOrDefault(e => e.Id == id);
            return evnt;
        }

        public List<Event> UserEvents(int userProfile_id)
        {
            return context.Events.Where(x => x.UserProfileId == userProfile_id).ToList();
        }
    }
}

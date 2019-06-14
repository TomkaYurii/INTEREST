using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDBContext db;

        public EventRepository(AppDBContext context)
        {
            this.db = context;
        }

        public void CreateEvent(Event _event)
        {
            db.Events.Add(_event);
            db.Entry(_event).State = EntityState.Added;
            db.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            Event eventCurrent = db.Events.FirstOrDefault(x => x.Id == id);
            if (eventCurrent != null)
            {
                db.Events.Remove(eventCurrent);
                db.Entry(eventCurrent).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INTEREST.DAL.Interfaces
{
    public interface IEventRepository :  IBaseRepository<Event>
    {

        IQueryable<Event> GetAllEventsInfo();


        Event GetEverythingAboutEvent(int id);
        List<Event> UserEvents(int userProfile_id);
    }
}

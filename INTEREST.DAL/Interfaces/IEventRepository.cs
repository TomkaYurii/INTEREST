using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;

namespace INTEREST.DAL.Interfaces
{
    public interface IEventRepository :  IBaseRepository<Event>
    {
        Event GetEverythingAboutEvent(int id);
        List<Event> UserEvents(int userProfile_id);
    }
}

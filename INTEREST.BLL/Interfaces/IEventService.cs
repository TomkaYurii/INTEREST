using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IEventService
    {
        Task<OperationDetails> CreateEvent(EventDTO eventDTO);
        Task<OperationDetails> UpdateEvent(EventDTO evntDTO);

        EventInfoDTO GetEventInformation(int event_id);

        List<SubscribersDTO> AllInfoAboutSubscribers(int event_id);


        IQueryable<Event> GetAllEvents();
        List<EventInfoDTO> GetEventsByDate(int number);
        int CountSubscribers(int event_id);


        List<EventInfoDTO> GetUserEvents(int user_id);

        void DeleteEvent(int event_id);
        void UserSubscribeOnEvent(int user_prof_id, int event_id);
    }
}

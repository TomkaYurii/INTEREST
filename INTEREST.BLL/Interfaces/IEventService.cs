using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IEventService : IDisposable
    {
        Task<OperationDetails> CreateEvent(EventDTO eventDTO);
        Task<OperationDetails> UpdateEvent(EventDTO evntDTO);
        EventInfoDTO GetEventInformation(int event_id);
        List<EventInfoDTO> GetAllEvents();
        List<EventInfoDTO> GetUserEvents(int user_id);
        void DeleteEvent(int event_id);

        void UserSubscribeOnEvent(int user_prof_id, int event_id);
    }
}

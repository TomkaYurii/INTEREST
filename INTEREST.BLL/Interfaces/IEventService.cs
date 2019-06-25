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
        EventInfoDTO GetEventInformation(int event_id);
        List<EventInfoDTO> GetAllEvents();
    }
}

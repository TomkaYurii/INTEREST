using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using System;

using System.Threading.Tasks;

namespace INTEREST.BLL.Interfaces
{
    public interface IEventService : IDisposable
    {
        Task<OperationDetails> CreateEvent(EventDTO eventDTO);
    }
}

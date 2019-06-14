using INTEREST.DAL.Entities;
using System;

namespace INTEREST.DAL.Interfaces
{
    public interface IEventRepository : IDisposable
    {
        void CreateEvent(Event _event);

        void DeleteEvent(int id);
    }
}

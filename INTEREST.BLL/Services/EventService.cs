using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.Services
{
    public class EventService : IEventService
    {
        IUnitOfWork Database { get; set; }

        public EventService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateEvent(CreateEventDTO createEventDTO)
        {
            var Event = Mapper.Map<Event>(createEventDTO);
            Database.EventRepository.CreateEvent(Event);
        }
    }
}

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
        private readonly IMapper _mapper;


        public EventService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        //public IEnumerable<DTOThemeViewModel> GetAllThemes()
        //{
        //    return Mapper.Map<IEnumerable<Theme>, IEnumerable<DTOThemeViewModel>>(Database.Themes.GetAllThemes());
        //}

        public void CreateEvent(CreateEventDTO createEventDTO)
        {
            var Event = _mapper.Map<Event>(createEventDTO);
            Database.EventRepository.CreateEvent(Event);
        }

        public void DeleteEvent(int id)
        {
            Database.EventRepository.DeleteEvent(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

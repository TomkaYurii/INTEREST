using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.MappingProfile
{
    public class MappingProfileBLL : Profile
    {
        public MappingProfileBLL()
        {
            CreateMap<CreateEventDTO,Event>();
            CreateMap<CreateMessageDTO, Message>();
            CreateMap<DeleteMessageDTO, Message>();
            CreateMap<EditMessageDTO, Message>();
            CreateMap<MessageDTO, Message>();
            CreateMap<EventDTO, Event>();
        }
    }
}

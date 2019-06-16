using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.MappingProfiles
{
    public class MappingProfileWEB : Profile
    {
        public MappingProfileWEB()
        {
            //message
            CreateMap<CreateMessageViewModel, CreateMessageDTO>();
            CreateMap<DeleteMessageViewModel, DeleteMessageDTO>();
            CreateMap<EditMessageViewModel, EditMessageDTO>();
            CreateMap<MessageViewModel, MessageDTO>();
            //event
            CreateMap<CreateEventViewModel, CreateEventDTO>();
        }
    }
}

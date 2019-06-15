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
            CreateMap<CreateEventViewModel, CreateEventDTO>();
            CreateMap<CreateMessageViewModel, CreateMessageDTO>();
            CreateMap<DeleteMessageViewModel, DeleteMessageDTO>();
            CreateMap<EditMessageViewModel, EditMessageDTO>();
            CreateMap<MessageViewModel, MessageDTO>();
        }
    }
}

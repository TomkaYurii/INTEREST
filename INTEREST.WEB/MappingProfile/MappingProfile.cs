using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using INTEREST.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //WEB
            // Message / CreateMessage.
            CreateMap<CreateMessageViewModel, CreateMessageDTO>()
                .ForMember(dest => dest.ProfileId, opts => opts.MapFrom(x => x.ProdileId));
            CreateMap<CreateMessageDTO, CreateMessageViewModel>();


            //BLL
            // MessageService / CreateMessage
            CreateMap<CreateMessageDTO, Message>()
                .ForMember(dest => dest.UserProfileId, opts => opts.MapFrom(x =>x.ProfileId))
                .ForMember(dest => dest.MessageTime, opts => opts.MapFrom(x => DateTime.Now));
            // MessageService / CreateMessage
            CreateMap<Message, MessageDTO>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(x => x.UserProfile.User.UserName));



            //event
            //CreateMap<CreateEventViewModel, CreateEventDTO>();
        }
    }
}

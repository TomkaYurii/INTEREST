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
            // -- WEB --
            //Message
            CreateMap<CreateMessageViewModel, CreateMessageDTO>()
                .ForMember(dest => dest.ProfileId, opts => opts.MapFrom(x => x.ProdileId));

            CreateMap<CreateMessageDTO, CreateMessageViewModel>();
            CreateMap<SubscribersDTO, SubscribersViewModel>();
            CreateMap<MessageDTO, MessageViewModel>()
                .ForMember(dest => dest.AvatarUrl, opts => opts.MapFrom(x => x.Avatar));

            //UserProfile
            CreateMap<EditUserProfileViewModel, UserProfileDTO>()
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(x => x.Phone));

            //Event
            CreateMap<EventViewModel, EventDTO>()
                .ForMember(dest => dest.EventName, opts => opts.MapFrom(x => x.Title))
                .ForMember(dest => dest.EventText, opts => opts.MapFrom(x => x.Description))
                .ForMember(dest => dest.City, opts => opts.MapFrom(x => x.city_state))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(x => x.country))
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(x => x.SelectedCategories))
                .ForMember(dest => dest.Photo, opts => opts.MapFrom(x => x.formFile));
            CreateMap<EventInfoDTO, EventViewModel>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(x => x.EventName))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(x => x.EventText))
                .ForMember(dest => dest.city_state, opts => opts.MapFrom(x => x.City))
                .ForMember(dest => dest.country, opts => opts.MapFrom(x => x.Country));

            // -- BLL --
            //Message
            CreateMap<CreateMessageDTO, Message>()
                .ForMember(dest => dest.UserProfileId, opts => opts.MapFrom(x =>x.ProfileId))
                .ForMember(dest => dest.MessageTime, opts => opts.MapFrom(x => DateTime.Now));

            CreateMap<Message, MessageDTO>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(x => x.UserProfile.User.UserName));              
        }
    }
}

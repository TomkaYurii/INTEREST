using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class EventService : IEventService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IHostingEnvironment _appEnvironment;

        public EventService(IUnitOfWork uow,
            IHostingEnvironment hostingEnvironment)
        {
            Database = uow;
            _appEnvironment = hostingEnvironment;
        }

        public async Task<OperationDetails> CreateEvent(EventDTO eventDTO)
        {
            //add base info about evnt
            Event evnt = new Event
            {
                EventName = eventDTO.EventName,
                EventText = eventDTO.EventText,
                DateFrom = eventDTO.DateFrom,
                DateTo = eventDTO.DateTo,
            };
            //add location
            Location location = new Location {
                City = eventDTO.City,
                Country = eventDTO.Country
            };
            Location loc = Database.LocationRepository.FindClone(location);
            if (loc == null)
            {
                loc = Database.LocationRepository.Create(location);
                evnt.Location = loc;
            }
            else
            {
                evnt.Location = location;
            }
            //add profile
            var user = await Database.UserManager.FindByIdAsync(eventDTO.UserId);
            evnt.UserProfile = Database.UserProfileRepository.GetById(user.ProfileId);

            evnt = Database.EventRepository.Create(evnt);
            //add categories
            foreach (var item in eventDTO.Categories)
            {
                Database.CategoryEventRepository.Create(new CategoryEvent
                {
                    Event = evnt,
                    Category = Database.CategoryRepository.GetByTitle(item)
                });
            }
            //add photo
            if (eventDTO.Photo != null)
            {
                string path = "/files/" + eventDTO.Photo.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await eventDTO.Photo.CopyToAsync(fileStream);
                }

                Photo photo = Database.PhotoRepository.Create(new Photo { URL = path });
                evnt.Photo = photo;
                Database.EventRepository.Update(evnt);
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public async Task<OperationDetails> UpdateEvent(EventDTO evntDTO)
        {
            var evnt = Database.EventRepository.GetById(evntDTO.EventId);
            evnt.EventName = evntDTO.EventName;
            evnt.EventText = evntDTO.EventText;
            evnt.DateFrom = evntDTO.DateFrom;
            evnt.DateTo = evntDTO.DateTo;

            Location location = new Location
            {
                City = evntDTO.City,
                Country = evntDTO.Country
            };
            Location loc = Database.LocationRepository.FindClone(location);
            if (loc == null)
            {
                loc = Database.LocationRepository.Create(location);
                evnt.Location = loc;
            }
            else
            {
                evnt.Location = location;
            }

            //foreach (var item in evntDTO.Categories)
            //{
            //    Database.CategoryEventRepository.Create(new CategoryEvent
            //    {
            //        Event = evnt,
            //        Category = Database.CategoryRepository.GetByTitle(item)
            //    });
            //}

            Database.EventRepository.Update(evnt);

            //add photo
            //if (evntDTO.Photo != null)
            //{
            //    string path = "/files/" + evntDTO.Photo.FileName;
            //    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //    {
            //        await evntDTO.Photo.CopyToAsync(fileStream);
            //    }

            //    Photo photo = Database.PhotoRepository.Create(new Photo { URL = path });
            //    evnt.Photo = photo;
            //    Database.EventRepository.Update(evnt);
            //}


            await Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public EventInfoDTO GetEventInformation (int event_id)
        {
            var evnt = Database.EventRepository.GetOneEventInfo(event_id);
            var usr = Database.UserProfileRepository.FindByUserProfileId(evnt.UserProfileId.Value);

            List<string> selected_categories = new List<string>();
            foreach (var x in Database.CategoryRepository.EventCategories(event_id))
            {
                selected_categories.Add(x.Name);
            }

            EventInfoDTO evntInfoDTO = new EventInfoDTO
            {
                EventId = evnt.Id,
                OwnerId = evnt.UserProfileId.Value,
                UserName = usr.UserName,
                EventName = evnt.EventName,
                EventText = evnt.EventText,
                DateFrom = evnt.DateFrom,
                DateTo = evnt.DateTo,
                Country = evnt.Location.Country,
                City = evnt.Location.City,
                URL = evnt.Photo.URL,
                SelectedCategories = selected_categories
            };
            return evntInfoDTO;
        }

        public List<EventInfoDTO> GetEventsByDate(int number)
        {
            List<EventInfoDTO> last_events = new List<EventInfoDTO>();
            foreach (var x in Database.EventRepository.GetEventsByDate(number))
            {
                last_events.Add(GetEventInformation(x.Id));
            }
            return last_events;
        }

        public IQueryable<Event> GetAllEvents()
        {
            return Database.EventRepository.GetAllEventsInfo();
        }

        public List<EventInfoDTO> GetUserEvents(int user_id)
        {
            List<EventInfoDTO> UserEvents = new List<EventInfoDTO>();
            foreach (var x in Database.EventRepository.UserEvents(user_id))
            {
                UserEvents.Add(GetEventInformation(x.Id));
            }
            return UserEvents;
        }
        
        public void DeleteEvent(int event_id)
        {
            Database.EventRepository.Delete(Database.EventRepository.GetById(event_id));
            Database.SaveAsync();
        }

        public void UserSubscribeOnEvent(int user_prof_id, int event_id)
        {

            foreach (var item in Database.UserProfileEventRepository.GetAll())
            {
                if (item.UserProfileId == user_prof_id && item.EventId == event_id )
                    Database.UserProfileEventRepository.Delete(item);
            }

            Database.UserProfileEventRepository.Create(new UserProfileEvent
                {
                    EventId = event_id,
                    UserProfileId = user_prof_id
            });
            Database.SaveAsync();
        }

        public List<SubscribersDTO> AllInfoAboutSubscribers(int event_id)
        {
            List<SubscribersDTO> subscribers_info = new List<SubscribersDTO>();
            foreach (var info in Database.UserProfileEventRepository.GetProfilesByEventId(event_id))
            {
                var photo = Database.PhotoRepository.GetById(info.UserProfile.PhotoId.Value);
                var location = Database.LocationRepository.GetById(info.UserProfile.LocationId.Value);
                SubscribersDTO subscriber = new SubscribersDTO
                {
                    UserName = info.UserProfile.User.UserName,
                    PhoneNumber = info.UserProfile.User.PhoneNumber,
                    Url = photo.URL,
                    City = location.City
                };
                subscribers_info.Add(subscriber);
            }
            return subscribers_info;
        }

        public int CountSubscribers(int event_id)
        {
            return Database.UserProfileEventRepository.CountSubscribers(event_id);
        }
    }
}

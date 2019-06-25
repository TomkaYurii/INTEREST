using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class EventService : IEventService
    {
        IUnitOfWork Database { get; set; }
        private readonly IHostingEnvironment _appEnvironment;

        public EventService(IUnitOfWork uow,
            IHostingEnvironment hostingEnvironment)
        {
            Database = uow;
            _appEnvironment = hostingEnvironment;
        }

        // Create event
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

        // Get information about event
        public EventInfoDTO GetEventInformation (int event_id)
        {
            var evnt = Database.EventRepository.GetEverythingAboutEvent(event_id);
            var usr = Database.UserProfileRepository.FindByUserProfileId(evnt.UserProfileId);

            List<string> selected_categories = new List<string>();
            foreach (var x in Database.CategoryRepository.EventCategories(event_id))
            {
                selected_categories.Add(x.Name);
            }

            EventInfoDTO evntInfoDTO = new EventInfoDTO
            {
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

        // List of Events
        public List<EventInfoDTO> GetAllEvents()
        {
            List<EventInfoDTO> AllEvents = new List<EventInfoDTO>();
            foreach (var x in Database.EventRepository.GetAll())
            {
                AllEvents.Add(GetEventInformation(x.Id));
            }

            return AllEvents;
        }

        //Delete Event
        public void DeleteEvent(int event_id)
        {
            Database.EventRepository.Delete(Database.EventRepository.GetById(event_id));
            Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

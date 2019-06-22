using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
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
        }



        public async Task<OperationDetails> CreateEvent(EventDTO eventDTO)
        {
            //add info about evnt
            Event evnt = new Event
            {
                EventName = eventDTO.EventName,
                EventText = eventDTO.EventText,
                DateFrom = eventDTO.DateFrom,
                DateTo = eventDTO.DateTo,
            };
            //add location
            Location location = new Location
            {
                City = eventDTO.City,
                Country = eventDTO.Country
            };
            Location loc = Database.LocationRepository.FindClone(location);
            if (loc == null)
            {
                loc = Database.LocationRepository.Create(location);
            }
            evnt.Location = location;    
            //add profile
            var user = await Database.UserManager.FindByIdAsync(eventDTO.UserId);
            evnt.UserProfile = Database.UserProfileRepository.GetById(user.ProfileId);
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
            //if (eventDTO.Photo != null)
            //{
            //string path = "/files/" + eventDTO.Photo.FileName;
            //using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //{
            //    await eventDTO.Photo.CopyToAsync(fileStream);
            //}

            //Photo photo = Database.PhotoRepository.Create(new Photo { URL = path });
            //    //evnt.PhotoId = 1;// photo.Id;
            //}

            Database.EventRepository.Create(evnt);
            await Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

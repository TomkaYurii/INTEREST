using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.BLL.Services;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IUserProfileService _userProfileService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        public EventController(IEventService eventService, 
                                IUserProfileService userProfileService,
                                ICategoryService categoryService,
                                IMapper mapper)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Events(string title, 
            string author, 
            string country,
            string city,
            int page=1, 
            EventSortState sortOrder = EventSortState.TitleAsc)
        {
            int pageSize = 2;

            var events = _eventService.GetAllEvents();
   

            if (!String.IsNullOrEmpty(title))
            {
                events = events.Where(p => p.EventName.Contains(title));
            }
            if (!String.IsNullOrEmpty(author))
            {
                events = events.Where(p => p.UserProfile.User.UserName.Contains(author));
            }
            if (!String.IsNullOrEmpty(country))
            {
                events = events.Where(p => p.Location.Country.Contains(country));
            }
            if (!String.IsNullOrEmpty(city))
            {
                events = events.Where(p => p.Location.City.Contains(city));
            }

            switch (sortOrder)
            {
                case EventSortState.TitleDesc:
                    events = events.OrderByDescending(s => s.EventName);
                    break;
                case EventSortState.AuthorAsc:
                    events = events.OrderBy(s => s.UserProfile.User.UserName);
                    break;
                case EventSortState.AuthorDesc:
                    events = events.OrderByDescending(s => s.UserProfile.User.UserName);
                    break;
                case EventSortState.CountryAsc:
                    events = events.OrderBy(s => s.Location.Country);
                    break;
                case EventSortState.CountryDesc:
                    events = events.OrderByDescending(s => s.Location.Country);
                    break;
                case EventSortState.CityAsc:
                    events = events.OrderBy(s => s.Location.City);
                    break;
                case EventSortState.CityDesc:
                    events = events.OrderByDescending(s => s.Location.City);
                    break;
                default:
                    events = events.OrderBy(s => s.EventName);
                    break;
            }

            var count = events.Count();
            var items = events.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            List<List<string>> sel_cat = new List<List<string>>();
            List<int> count_subscribers = new List<int>();
            foreach (var x in items)
            {
                List<string> event_category = new List<string>();
                event_category = _categoryService.CategoriesOfEvent(x.Id);
                sel_cat.Add(event_category);
                count_subscribers.Add(_eventService.CountSubscribers(x.Id));
            }
            

            IndexEventsViewModel viewModel = new IndexEventsViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortEventsViewModel = new SortEventsViewModel(sortOrder),
                FilterEventsViewModel = new FilterEventsViewModel(title, author, country, city),
                Events = items,
                Selected_Categories = sel_cat,
                Count_Subscribers = count_subscribers
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateEvent()
        {
            EventViewModel eventVewModel = new EventViewModel
            {
                Categories = _categoryService.Categories(),
                SelectedCategories = new List<string>()
            };
            return View(eventVewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventViewModel model)
        {
            UserProfileDTO userProfileDTO = _userProfileService.GetProfile(User.Identity.Name);
            EventDTO eventDTO = _mapper.Map<EventViewModel, EventDTO>(model);
            eventDTO.UserId = userProfileDTO.UserId;
            await _eventService.CreateEvent(eventDTO);
            return RedirectToAction("UserProfile", "UserProfile");
        }

        [HttpGet]
        public IActionResult UserEvents()
        {
            var user = _userProfileService.GetUserByName(User.Identity.Name);
            var model = _eventService.GetUserEvents(user.ProfileId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditEvent(int event_id)
        {
            EventViewModel eventViewModel = _mapper.Map<EventInfoDTO,EventViewModel>(_eventService.GetEventInformation(event_id));
            eventViewModel.Categories = _categoryService.Categories();
            return View(eventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventViewModel model)
        {
            EventDTO eventDTO = _mapper.Map<EventViewModel, EventDTO>(model);
            await _eventService.UpdateEvent(eventDTO);
            return RedirectToAction("Events", "Event");
        }

        public IActionResult DeleteEvent(int event_id)
        {
            _eventService.DeleteEvent(event_id);
            return RedirectToAction("Events", "Event");
        }

        public IActionResult JoinToEvent(int event_id)
        {
            var p = _userProfileService.GetUserByName(User.Identity.Name);
            _eventService.UserSubscribeOnEvent(p.ProfileId, event_id);
            return RedirectToAction("Events", "Event");
        }
    }
}

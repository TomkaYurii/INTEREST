using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.BLL.Services;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class EventController : Controller
    {
        IEventService _eventService;
        IUserService _userService;
        IUserProfileService _userProfileService;
        ICategoryService _categoryService;
        
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, 
                                IUserService userService,
                                IUserProfileService userProfileService,
                                ICategoryService categoryService)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _userService = userService;
            _userProfileService = userProfileService;
        }


        // List of All Events
        [HttpGet]
        public IActionResult Events()
        {
            var model = _eventService.GetAllEvents();
            return View(model);
        }

        // Create event
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
            EventDTO eventDTO = new EventDTO
            {
                EventName = model.Title,
                EventText = model.Description,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                City = model.city_state,
                Country = model.country,
                Categories = model.SelectedCategories,
                Photo = model.formFile,
                UserId = userProfileDTO.UserId
            };
            await _eventService.CreateEvent(eventDTO);
            return RedirectToAction("UserProfile", "UserProfile");
        }

        //User Events
        [HttpGet]
        public IActionResult UserEvents()
        {
            var user = _userProfileService.GetUserByName(User.Identity.Name);
            var model = _eventService.GetUserEvents(user.ProfileId);
            return View(model);
        }

        // Edit Event
        [HttpGet]
        public async Task<IActionResult> EditEvent(int event_id)
        {
            EventInfoDTO evntDTO = _eventService.GetEventInformation(event_id);
            List<string> selected_categories = new List<string>();

            EventViewModel eventViewModel = new EventViewModel
            {
                EventId = evntDTO.EventId,
                Title = evntDTO.EventName,
                Description = evntDTO.EventText,
                DateFrom = evntDTO.DateFrom,
                DateTo = evntDTO.DateTo,
                country = evntDTO.Country,
                city_state = evntDTO.City,
                URL = evntDTO.URL,
                Categories = _categoryService.Categories(),
                SelectedCategories = evntDTO.SelectedCategories
            };
            return View(eventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventViewModel model)
        {
            EventDTO eventDTO = new EventDTO
            {
                EventId = model.EventId,
                EventName = model.Title,
                EventText = model.Description,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                City = model.city_state,
                Country = model.country,
                Categories = model.SelectedCategories,
                Photo = model.formFile,
            };
            await _eventService.UpdateEvent(eventDTO);
            return RedirectToAction("Events", "Event");
        }

        // Delete Event
        public IActionResult DeleteEvent(int event_id)
        {
            _eventService.DeleteEvent(event_id);
            return RedirectToAction("Events", "Event");
        }

        // Selecte Event
        public async Task<IActionResult> JoinToEvent(int event_id)
        {
            var p = _userProfileService.GetUserByName(User.Identity.Name);
            _eventService.UserSubscribeOnEvent(p.ProfileId, event_id);
            return RedirectToAction("Events", "Event");
        }
    }
}

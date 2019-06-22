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
            return RedirectToAction("Events", "Event");
        }



    }
}

using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.BLL.Services;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace INTEREST.WEB.Controllers
{
    public class EventController : Controller
    {
        IEventService _eventService;
        IUserService _userService;

        public EventController(IUserService userService, IEventService eventService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        //[Authorize]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult CreateEvent(CreateEventViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Regex regex = new Regex(@"\r\n");
        //        model.EventText = regex.Replace(model.EventText, "");
        //        model.EventText = model.EventText.Trim();

        //        var user = _userService.GetCurrentUserAsync(HttpContext);
        //        var userId = user.Id;

        //        model.UserId = Convert.ToString(userId);

        //        var createEventDto = Mapper.Map<CreateEventDTO>(model);
        //        _eventService.CreateEvent(createEventDto);

        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}

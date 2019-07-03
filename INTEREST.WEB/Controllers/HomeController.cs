using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using INTEREST.WEB.Models;
using INTEREST.BLL.Interfaces;

namespace INTEREST.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IUserProfileService _userProfileService;
        private readonly ICategoryService _categoryService;

        public HomeController(IEventService eventService,
                                IUserProfileService userProfileService,
                                ICategoryService categoryService)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _userProfileService = userProfileService;
        }



        [HttpGet]
        public IActionResult Index()
        {
            var model = _eventService.GetEventsByDate(3);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

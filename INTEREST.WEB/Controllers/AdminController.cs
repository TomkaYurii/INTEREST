using INTEREST.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class AdminController : Controller
    {
        public IUserService UserService { get; set; }
        public IUserProfileService ProfileService { get; set; }

        public AdminController(IUserService userService, IUserProfileService userProfileService)
        {
            UserService = userService;
            ProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(ProfileService.GetUsers());
        }            
            
    }
}

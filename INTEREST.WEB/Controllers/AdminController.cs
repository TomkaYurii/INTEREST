using INTEREST.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        public IUserRoleService UserRoleService { get; set; }
        public IUserProfileService ProfileService { get; set; }

        public AdminController(IUserService userService, IUserRoleService userRoleService, IUserProfileService userProfileService)
        {
            UserService = userService;
            UserRoleService = userRoleService;
            ProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //WORK WITH ROLES
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Roles()
        {
            return View(UserRoleService.GetRoles());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(string name)
        {
            await UserRoleService.CreateRole(name);
            return View(name);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await UserRoleService.DeleteRole(id);
            return RedirectToAction("Index");
        }

        // WORK WITH USERS
        public IActionResult Users()
        {
            return View(ProfileService.GetUsers());
        }



    }
}

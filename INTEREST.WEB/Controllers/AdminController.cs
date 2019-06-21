using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
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
        public IRolesService UserRoleService { get; set; }
        public ICategoryService CategoryService { get; set; }
        public IUserProfileService UserProfileService { get; set; }

        public AdminController(IUserService userService, 
            IRolesService userRoleService, 
            ICategoryService categoryService,
            IUserProfileService userProfileService)
        {
            UserService = userService;
            UserRoleService = userRoleService;
            CategoryService = categoryService;
            UserProfileService = userProfileService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> AddRole(string name)
        {
            await UserRoleService.CreateRole(name);
            return RedirectToAction("Roles");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await UserRoleService.DeleteRole(id);
            return RedirectToAction("Roles");
        }

        // WORK WITH USERS
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(UserProfileService.GetUsers());
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public async Task<ActionResult> DeleteUser(string userId)
        //{
        //    await UserProfileService.DeleteUser(userId);
        //    return RedirectToAction("Users", "Admin");
        //}

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public async Task<ActionResult> EditUser(string userId)
        //{
        //    return RedirectToAction("UserProfile", "UserProfile");
        //}

        // WORK WITH CATEGORIES
        [HttpGet]
        public IActionResult Categories()
        {
            return View(CategoryService.Categories());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory(string title)
        {
            CategoryService.AddCategoryAsync(title);
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            CategoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Categories", "Admin");
        }
    }
}

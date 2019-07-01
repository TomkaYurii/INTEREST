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
        private readonly IRolesService _userRoleService;
        private readonly ICategoryService _categoryService;
        private readonly IUserProfileService _userProfileService;

        public AdminController(IRolesService userRoleService, 
            ICategoryService categoryService,
            IUserProfileService userProfileService)
        {
            _userRoleService = userRoleService;
            _categoryService = categoryService;
            _userProfileService = userProfileService;
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
            return View(_userRoleService.GetRoles());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(string name)
        {
            await _userRoleService.CreateRole(name);
            return RedirectToAction("Roles");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await _userRoleService.DeleteRole(id);
            return RedirectToAction("Roles");
        }

        // WORK WITH USERS
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(_userProfileService.GetUsersAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUser(string email)
        {
            await _userProfileService.DeleteUser(email);
            return RedirectToAction("Users", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(string userId)
        {
            return RedirectToAction("UserProfile", "UserProfile");
        }

        // WORK WITH CATEGORIES
        [HttpGet]
        public IActionResult Categories()
        {
            return View(_categoryService.Categories());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory(string title)
        {
            _categoryService.AddCategoryAsync(title);
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Categories", "Admin");
        }
    }
}

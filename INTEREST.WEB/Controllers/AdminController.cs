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
        public IRolesService UserRoleService { get; set; }
        public ICategoryService CategoryService { get; set; }
        public IUserProfileService ProfileService { get; set; }

        public AdminController(IUserService userService, 
            IRolesService userRoleService, 
            ICategoryService categoryService,
            IUserProfileService userProfileService)
        {
            UserService = userService;
            UserRoleService = userRoleService;
            CategoryService = categoryService;
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

        // WORK WITH CATEGORIES
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

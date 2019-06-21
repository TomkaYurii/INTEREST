using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.BLL.Services;
using INTEREST.DAL.Entities;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IUserProfileService userProfileService;
        private readonly IHostingEnvironment appEnvironment;

        public UserProfileController(
            IHostingEnvironment _appEnvironment,
            IUserService _userService,
            ICategoryService _categoryService,
            IUserProfileService _userProfileService)
        {
            appEnvironment = _appEnvironment;
            userService = _userService;
            categoryService = _categoryService;
            userProfileService = _userProfileService;
        }

        public async Task<IActionResult> UserProfile(string userId)
        {
            UserProfileDTO profile = new UserProfileDTO();
            if (User.IsInRole("Admin"))
            {
                //User username = await userProfileService.GetUserById(userId);
                //profile = userProfileService.GetProfile(username.UserName);
            }
            else
            {
                profile = userProfileService.GetProfile(User.Identity.Name);
            }

            var viewModel = new UserProfileViewModel
            {
                UserName = profile.UserName,
                Email = profile.Email,
                Phone = profile.PhoneNumber,
                Country = profile.Country,
                City = profile.City,
                Age = DateTime.Today.Year - profile.Birthday.Year,
                Gender = profile.Gender,
                Avatar = profile.AvatarUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAvatar(IFormFile formFile)
        {
            if (formFile != null)
            {
                string path = "/files/" + formFile.FileName;
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                var profile = userProfileService.GetUserByName(User.Identity.Name);
                await userProfileService.AddAvatar(path, profile.UserProfile);
            }
            return RedirectToAction("UserProfile", "UserProfile");
        }


        [HttpGet]
        public IActionResult SelectCategories(string id)
        {
            List<string> selected_categories = new List<string>();
            foreach (var item in categoryService.CategoriesOfUser(User.Identity.Name))
            {
                selected_categories.Add(item.Name);
            }
            SelectCategoriesViewModel selectCategoriesViewModel = new SelectCategoriesViewModel
            {
                SelectedCategories = selected_categories,
                Categories = categoryService.Categories()
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SelectCategories(SelectCategoriesViewModel model)
        {
            User user = userProfileService.GetUserByName(User.Identity.Name);
            UserCategoryDTO userCategoryDTO = new UserCategoryDTO
            {
                Categories = model.SelectedCategories,
                Id = user.ProfileId
            };
            OperationDetails result = await categoryService.AddCategoriesToUser(userCategoryDTO);

            return RedirectToAction("Index", "Profile");
        }

    }
}

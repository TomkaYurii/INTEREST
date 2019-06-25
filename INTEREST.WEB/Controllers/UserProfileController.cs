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

        //USER PROFILE
        public async Task<IActionResult> UserProfile(string userId)
        {
            //UserProfileDTO profile = new UserProfileDTO();
            //if (User.IsInRole("Admin"))
            //{
            //    User user = await userProfileService.GetUserById(userId);
            //    profile = userProfileService.GetProfile(user.UserName);
            //}
            //else
            //{
                var profile = userProfileService.GetProfile(User.Identity.Name);
            //}

            List<string> user_categories = new List<string>();
            foreach (var item in categoryService.CategoriesOfUser(profile.UserName))
            {
                user_categories.Add(item.Name);
            }

            var userProfileViewModel = new UserProfileViewModel
            {
                UserId = profile.UserId,
                UserName = profile.UserName,
                Email = profile.Email,
                Phone = profile.PhoneNumber,
                Country = profile.Country,
                City = profile.City,
                Age = DateTime.Today.Year - profile.Birthday.Year,
                Gender = profile.Gender,
                Avatar = profile.AvatarUrl,
                UserCategories = user_categories
            };
            return View(userProfileViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string userId)
        {
            var profile = userProfileService.GetProfile(User.Identity.Name);

            var editUserProfileViewModel = new EditUserProfileViewModel
            {
                UserId = profile.UserId,
                UserName = profile.UserName,
                Email = profile.Email,
                Phone = profile.PhoneNumber,
                Country = profile.Country,
                City = profile.City,
                Birthday = profile.Birthday
            };
            return View(editUserProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserProfileViewModel model)
        {
            var user = userProfileService.GetUserByName(User.Identity.Name);
            var userProfileDTO = new UserProfileDTO
            {
                UserId = user.Id,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Country = model.Country,
                City = model.City,
                Birthday = model.Birthday,
            };
            await userProfileService.EditProfile(userProfileDTO);
            return RedirectToAction("UserProfile", "UserProfile");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfile()
        {
            await userService.DeleteUser(User.Identity.Name);
            return RedirectToAction("Logout", "Account");
        }

        // AVATAR
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
        

        //CATEGORIES OF USER
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
            return View(selectCategoriesViewModel);
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
            await categoryService.AddCategoriesToUser(userCategoryDTO);

            return RedirectToAction("UserProfile");
        }
    }
}

using AutoMapper;
using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.BLL.Services;
using INTEREST.DAL.Entities;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IUserProfileService _userProfileService;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IMapper _mapper;

        public UserProfileController(
            IHostingEnvironment appEnvironment,
            IUserService userService,
            ICategoryService categoryService,
            IUserProfileService userProfileService,
            IMapper mapper)
        {
            _appEnvironment = appEnvironment;
            _userService = userService;
            _categoryService = categoryService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        public IActionResult UserProfile(string userId)
        {
            var profile = _userProfileService.GetProfile(User.Identity.Name);

            List<string> user_categories = new List<string>();
            foreach (var item in _categoryService.CategoriesOfUser(profile.UserName))
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
        public IActionResult EditProfile(string userId)
        {
            var profile = _userProfileService.GetProfile(User.Identity.Name);
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
            var user = _userProfileService.GetUserByName(User.Identity.Name);
            var userProfileDTO = _mapper.Map<EditUserProfileViewModel,UserProfileDTO>(model);
            userProfileDTO.UserId = user.Id;
            await _userProfileService.EditProfile(userProfileDTO);
            return RedirectToAction("UserProfile", "UserProfile");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfile()
        {
            await _userService.DeleteUser(User.Identity.Name);
            return RedirectToAction("Logout", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> AddAvatar(IFormFile formFile)
        {
            if (formFile != null)
            {
                string path = "/files/" + formFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                var profile = _userProfileService.GetUserByName(User.Identity.Name);
                await _userProfileService.AddAvatar(path, profile.UserProfile);
            }
            return RedirectToAction("UserProfile", "UserProfile");
        }
        
        [HttpGet]
        public IActionResult SelectCategories(string id)
        {
            List<string> selected_categories = new List<string>();
            foreach (var item in _categoryService.CategoriesOfUser(User.Identity.Name))
            {
                selected_categories.Add(item.Name);
            }
            SelectCategoriesViewModel selectCategoriesViewModel = new SelectCategoriesViewModel
            {
                SelectedCategories = selected_categories,
                Categories = _categoryService.Categories()
            };
            return View(selectCategoriesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCategories(SelectCategoriesViewModel model)
        {
            User user = _userProfileService.GetUserByName(User.Identity.Name);
            UserCategoryDTO userCategoryDTO = new UserCategoryDTO
            {
                Categories = model.SelectedCategories,
                Id = user.ProfileId
            };
            await _categoryService.AddCategoriesToUser(userCategoryDTO);

            return RedirectToAction("UserProfile");
        }
    }
}

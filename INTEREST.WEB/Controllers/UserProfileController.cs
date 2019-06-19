using INTEREST.BLL.DTO;
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
        private readonly IUserProfileService userProfileService;
        private readonly IHostingEnvironment appEnvironment;

        public UserProfileController(
            IHostingEnvironment _appEnvironment,
            IUserService _userService,
            IUserProfileService _userProfileService)
        {
            appEnvironment = _appEnvironment;
            userService = _userService;
            userProfileService = _userProfileService;
        }

        public async Task<IActionResult> UserProfile()
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);
            var profile = userProfileService.GetProfile(currentUser);
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

        //public IActionResult UserProfile()
        //{
        //    UserProfileDTO profile = userProfileService.FindProfileByUserName(User.Identity.Name);
        //    var viewModel = new UserProfileViewModel
        //    {
        //        UserName = profile.GetUser.UserName,
        //        Email = profile.GetUser.Email,
        //        Phone = profile.GetUser.PhoneNumber,
        //        Age = DateTime.Now.Year - profile.GetUser.UserProfile.Birthday.Year,
        //        City = profile.GetUser.UserProfile.Location.City,
        //        Country = profile.GetUser.UserProfile.Location.Country,
        //        Gender = profile.GetUser.UserProfile.Gender,
        //        Avatar = profile.GetUser.UserProfile.Avatar.URL
        //    };
        //    return View(viewModel);
        //}


        [HttpPost]
        public async Task<IActionResult> AddAvatar(IFormFile formFile)
        {
            if (formFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + formFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }

                var currentUser = await userService.GetCurrentUserAsync(HttpContext);

                var profile = userProfileService.GetProfileByName(currentUser);
                //UserProfileDTO userProfile = userProfileService.FindProfileByUserName(User.Identity.Name);
                await userProfileService.AddAvatar(path, profile);
            }
            return RedirectToAction("UserProfile", "UserProfile");
        }


    }
}

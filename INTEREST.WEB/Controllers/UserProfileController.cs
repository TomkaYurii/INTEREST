using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Entities;
using INTEREST.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public UserProfileController(IUserService _userService,
                                  IUserProfileService _userProfileService)
        {
            userService = _userService;
            userProfileService = _userProfileService;
        }


        public async Task<IActionResult> UserProfile()
        {
            UserProfileDTO profile = await userProfileService.FindProfileByUserName(User.Identity.Name);

            UserProfileViewModel viewModel = new UserProfileViewModel
            {
                UserName = profile.GetUser.UserName,
                Email = profile.GetUser.Email,
                Phone = profile.GetUser.PhoneNumber,
                Country = profile.GetUser.UserProfile.Location.Country,
                //City = profile.GetUser.UserProfile.Location.City,
                Age = DateTime.Today.Year - profile.GetUser.UserProfile.Birthday.Year,
                Gender = profile.GetUser.UserProfile.Gender
            };

            return View(viewModel);
        }
    }
}

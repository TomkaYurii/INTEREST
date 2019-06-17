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
                Gender = profile.Gender
            };
            return View(viewModel);
        }
    }
}

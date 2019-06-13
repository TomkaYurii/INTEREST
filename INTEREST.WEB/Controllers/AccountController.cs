using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.WEB.ViewModels;
using INTERESTS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public AccountController (IUserService _userService,
                                  IUserProfileService _userProfileService)
        {
            userService = _userService;
            userProfileService = _userProfileService;
        }

        //LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email,
                                                Password = model.Password };
                bool auth = await userService.SignIn(userDto);
                if (!auth)
                {
                    ModelState.AddModelError("", "Wrong Login or Password!");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        //REGISTER
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            model.Gender = "Male";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Password = model.Password,
                    Role = "user",
                    Birthday = model.Birthday,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    Location = model.Location
                };
                OperationDetails operationDetails = await userService.Create(userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Login", "Account");
                else
                    ModelState.AddModelError(operationDetails.Property, 
                                             operationDetails.Message);
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await userService.SetInitialData(new UserDTO
            {
                Email = "tomka.yuriy@gmail.com",
                UserName = "Tomka",
                Password = "K7k1e9gof8r",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }

        //USERPROFILE
        public async Task<IActionResult> UserProfile()
        {
            UserProfileDTO userprofile = await userProfileService.FindUserProfileByUserName(User.Identity.Name); 
            UserProfileViewModel profile = new UserProfileViewModel {
                UserName = userprofile.GetUser.UserName,
                Email = userprofile.GetUser.Email,
                Phone = userprofile.GetUser.PhoneNumber,
                Age = DateTime.Now.Year - userprofile.GetUser.UserProfile.Birthday.Year,
                Location = userprofile.GetUser.UserProfile.Location,
                Gender = userprofile.GetUser.UserProfile.Gender
                // Avatar = userprofile.GetUser.UserProfile.Avatar?.Url
            };
            return View(profile);
        }

        //LOGOUT
        public async Task<IActionResult> Logout()
        {
            await userService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

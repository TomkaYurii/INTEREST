using INTEREST.BLL.DTO;
using INTEREST.BLL.Infrastructure;
using INTEREST.BLL.Interfaces;
using INTEREST.WEB.ViewModels;
using INTEREST.DAL.Entities;
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
        private readonly IUserService _userService;

        public AccountController (IUserService userService)
        {
            _userService = userService;
        }

        //AUTENTIFICATION
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
                bool auth = await _userService.SignInAsync(userDto);
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
            var model = new RegisterViewModel
            {
                Gender = "Male"
            };
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
                    Avatar = new Photo
                                {
                                    URL = "Default",
                                },
                    Location = new Location()
                                {
                                    Country = model.Country,
                                    City = model.City_state
                                }

                };
                OperationDetails operationDetails = await _userService.CreateAsync(userDto);
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
            await _userService.AdminCreateAsync(new UserDTO
            {
                Email = "tomka.yuriy@gmail.com",
                UserName = "Tomka",
                Password = "K7k1e9gof8r",
                Role = "admin",
                Birthday = DateTime.Now,
                Phone = "0957692191",
                Gender = "male",
                Avatar = new Photo
                {
                    URL = "Default",
                },
                Location = new Location()
                {
                    Country = "Ukraine",
                    City = "Chernivtsi"
                }

            });
        }

    //LOGOUT
    public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

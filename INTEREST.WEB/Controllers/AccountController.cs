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
        private readonly IUserService userService;

        public AccountController (IUserService _userService)
        {
            userService = _userService;
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
                bool auth = await userService.SignInAsync(userDto);
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
                    Location = new Location()
                                {
                                    Country = model.Country,
                                    City = model.City_state
                                }

                };
                OperationDetails operationDetails = await userService.CreateAsync(userDto);
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
            await userService.SetInitialDataAsync(new UserDTO
            {
                Email = "tomka.yuriy@gmail.com",
                UserName = "Tomka",
                Password = "K7k1e9gof8r",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }


        //LOGOUT
        public async Task<IActionResult> Logout()
        {
            await userService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

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
        private readonly SignInManager<User> AuthenticationManager;

        public AccountController(
            SignInManager<User> authenticationManager,
            IUserService _userService
            )
        {
            AuthenticationManager = authenticationManager;
            userService = _userService;
        }

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
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                bool auth = await userService.Authenticate(userDto);
                if (!auth)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
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
                    Password = model.Password,
                    Role = "user",
                    Birthday = model.Birthday,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    UserName = model.Login
                };
                OperationDetails operationDetails = await userService.Create(userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
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

        public async Task<IActionResult> Logout()
        {
            await AuthenticationManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Profile()
        {
            return View();
        }

    }
}

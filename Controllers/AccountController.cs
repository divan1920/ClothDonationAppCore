using ClothDonationApp.Models;
using ClothDonationApp.Models.City;
using ClothDonationApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ICityRepo cityRepo;
        public AccountController(ICityRepo cityRepo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cityRepo = cityRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            IEnumerable<City> cities = cityRepo.GetAllCities();

            var viewModel = new RegisterViewModel
            {
                CityList = new SelectList(cities, "Id", "CityName")
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IEnumerable<City> cities = cityRepo.GetAllCities();

            var viewModel = new RegisterViewModel
            {
                CityList = new SelectList(cities, "Id", "CityName")
            };
            if (ModelState.IsValid)
            {
                int role = (int)model.Role;
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    CityId = model.CityId,
                    Address = model.Address,
                    Role = role
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        
    }
}

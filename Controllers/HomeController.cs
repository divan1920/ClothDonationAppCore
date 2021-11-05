using ClothDonationApp.Models;
using ClothDonationApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        public HomeController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.GetUserAsync(User);
                if (user.Role == 1)
                    return RedirectToAction("DonarHome", "Home");
                else if (user.Role == 2)
                    return RedirectToAction("VolunteerHome", "Home");
                else
                    return RedirectToAction("AdminHome", "Home");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DonarHome()
        {
            var user = await userManager.GetUserAsync(User);
            if(user.Role == 1)
                return View();
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpGet]
        public async Task<IActionResult> AdminHome()
        {
            var user = await userManager.GetUserAsync(User);
            if (user.Role == 3)
                return View();
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpGet]
        public async Task<IActionResult> VolunteerHome()
        {
            var user = await userManager.GetUserAsync(User);
            if (user.Role == 2)
                return View();
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
    }
}

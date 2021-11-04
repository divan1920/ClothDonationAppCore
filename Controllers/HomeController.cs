using ClothDonationApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
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
        public IActionResult DonarHome()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminHome()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VolunteerHome()
        {
            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}

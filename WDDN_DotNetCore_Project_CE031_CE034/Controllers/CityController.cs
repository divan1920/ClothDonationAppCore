using ClothDonationApp.Models;
using ClothDonationApp.Models.City;
using ClothDonationApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        private readonly ICityRepo cityRepo;

        public CityController(ICityRepo cityRepo)
        {
            this.cityRepo = cityRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            bool IsAdmin = (cityRepo.GetRole(User.Identity.Name) == 3);
            if (IsAdmin)
            {
                var model = cityRepo.GetAllCities();
                return View(model);
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not an Admin");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            bool IsAdmin = (cityRepo.GetRole(User.Identity.Name) == 3);

            if (IsAdmin)
            {
                return View();
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not an Admin");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            bool IsAdmin = (cityRepo.GetRole(User.Identity.Name) == 3);

            if (IsAdmin)
            {
                if (ModelState.IsValid)
                {
                    City dCity = cityRepo.Add(city);
                    return RedirectToAction("Index", "City");
                }
                return View();
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not an Admin");
            return View("~/Views/Account/Login.cshtml", Model);
            
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            bool IsAdmin = (cityRepo.GetRole(User.Identity.Name) == 3);

            if (IsAdmin)
            {
                City city = cityRepo.GetCity(Id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city);
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not an Admin");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult ConfirmDelete(int Id)
        {
            var city = cityRepo.GetCity(Id);
            cityRepo.Delete(city.Id);
            return RedirectToAction("index");
        }
    }
}

using ClothDonationApp.Models;
using ClothDonationApp.Models.City;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
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
            var model = cityRepo.GetAllCities();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            if(ModelState.IsValid)
            {
                City dCity = cityRepo.Add(city);
                return RedirectToAction("Index", "City");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            City city = cityRepo.GetCity(Id);
            if(city == null)
            {
                return NotFound();
            }
            return View(city);
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

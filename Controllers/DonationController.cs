using ClothDonationApp.Models;
using ClothDonationApp.Models.City;
using ClothDonationApp.Models.Donation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
    
    public class DonationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDonationRepo donationRepo;

        public DonationController(UserManager<ApplicationUser> userManager, IDonationRepo donationRepo)
        {
            this.userManager = userManager;
            this.donationRepo = donationRepo;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var model = donationRepo.GetAllDonationsByUid(user.Id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
           var Data = from SizeEnum a in Enum.GetValues(typeof(SizeEnum))
                      select new
                      {
                           Id = a.ToString(),
                           Name = a.ToString()
                      };
            ViewBag.Size = new SelectList(Data,"Id","Name");
            ViewBag.CityId = new SelectList(donationRepo.GetCities(),"Id","CityName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Donation donation)
        {
            var user = await userManager.GetUserAsync(User);
            donation.ApplicationUserId = user.Id;
            donation.Status = "Pending";
            Donation d = donationRepo.Add(donation);
            return RedirectToAction("index", "Donation");  
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var donation = donationRepo.GetDonation(Id);
            if(donation == null)
            {
                return NotFound();
            }
            return View(donation);
        }
        [ActionName("Delete"), HttpPost]
        
        public IActionResult ConfirmDelete(int Id)
        {
            var d = donationRepo.GetDonation(Id);
            donationRepo.Delete(d.Id);
            return RedirectToAction("index", "Donation");
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            Donation donation = donationRepo.GetDonation(Id);
            return View(donation);
        }
        [HttpGet]
        public IActionResult Cancel(int Id)
        {
            var d = donationRepo.GetDonation(Id);
            donationRepo.Delete(d.Id);
            return RedirectToAction("index", "Donation");
        }
        [HttpGet]
        public async Task<IActionResult> ManageDonation()
        {
            var user = await userManager.GetUserAsync(User);
            var model = donationRepo.GetAllByCity(user.CityId);
            return View(model);
        }
     
    }
}

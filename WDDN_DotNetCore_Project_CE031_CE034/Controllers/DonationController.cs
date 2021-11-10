using ClothDonationApp.Models;
using ClothDonationApp.Models.City;
using ClothDonationApp.Models.Donation;
using ClothDonationApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Controllers
{
    [Authorize]
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
            if (user.Role == 1)
            {
                var model = donationRepo.GetAllDonationsByUid(user.Id);
                return View(model);
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar ");
            return View("~/Views/Account/Login.cshtml", Model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            int role = donationRepo.GetRole(Username: User.Identity.Name);

            if (role == 1)
            {
                var Data = from SizeEnum a in Enum.GetValues(typeof(SizeEnum))
                           select new
                           {
                               Id = a.ToString(),
                               Name = a.ToString()
                           };
                ViewBag.Size = new SelectList(Data, "Id", "Name");
                ViewBag.CityId = new SelectList(donationRepo.GetCities(), "Id", "CityName");
                return View();
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar");
            return View("~/Views/Account/Login.cshtml", Model);

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
            int role = donationRepo.GetRole(Username: User.Identity.Name);

            if (role == 1)
            {
                var donation = donationRepo.GetDonation(Id);
                if (donation == null)
                {
                    return NotFound();
                }
                return View(donation);
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar");
            return View("~/Views/Account/Login.cshtml", Model);

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
            int role = donationRepo.GetRole(Username: User.Identity.Name);

            if (role == 1)
            {
                var donation = donationRepo.GetDonation(Id);
                donation.Status = StatusEnum.Canceled.ToString();
                donationRepo.Update(donation);
                return RedirectToAction("index", "Donation");
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Donar");
            return View("~/Views/Account/Login.cshtml", Model);

        }
        [HttpGet]
        public async Task<IActionResult> ManageDonation()
        {
            int role = donationRepo.GetRole(Username: User.Identity.Name);

            if (role == 2)
            {
                var user = await userManager.GetUserAsync(User);
                var model = donationRepo.GetAllByCity(user.CityId);
                return View(model);
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Volunteer");
            return View("~/Views/Account/Login.cshtml", Model);

        }
        [HttpGet]
        public IActionResult Reject(int Id)
        {
            int role = donationRepo.GetRole(Username: User.Identity.Name);

            if (role == 2)
            {
                var donation = donationRepo.GetDonation(Id);
                donation.Status = StatusEnum.Rejected.ToString();
                donationRepo.Update(donation);
                return RedirectToAction("ManageDonation", "Donation");
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Volunteer");
            return View("~/Views/Account/Login.cshtml", Model);

        }
        [HttpGet]
        public IActionResult Accept(int Id)
        {
            int role = donationRepo.GetRole(Username: User.Identity.Name);
            if (role == 2)
            {
                var donation = donationRepo.GetDonation(Id);
                donation.Status = StatusEnum.Accepted.ToString();
                donationRepo.Update(donation);
                return RedirectToAction("ManageDonation", "Donation");
            }
            var Model = new LoginViewModel();
            ModelState.AddModelError(string.Empty, "You are not a Volunteer");
            return View("~/Views/Account/Login.cshtml", Model);

        }

    }
}

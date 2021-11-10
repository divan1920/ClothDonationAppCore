using ClothDonationApp.Models;
using ClothDonationApp.Models.City;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public SelectList CityList { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Both Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
    
}

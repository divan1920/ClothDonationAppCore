using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.City
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Donation.Donation> Donations { get; set; }
    }
}

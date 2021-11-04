using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models
{
    public class ApplicationUser : IdentityUser
    { 
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public int Role { get; set; }
        public int CityId { get; set; }
        public City.City City { get; set; }
        public ICollection<Donation.Donation> Donations { get; set; }
    }
    
}

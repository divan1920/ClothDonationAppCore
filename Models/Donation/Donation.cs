using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.Donation
{
    public class Donation
    {
        public int Id { get; set; }
        [Required]
        public string DonarName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [Display(Name ="City")]
        public int CityId { get; set; }
        public City.City City { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
    public enum StatusEnum
    {
        Accepted,
        Rejected,
        Pending,
        Canceled
    }
    public enum SizeEnum
    {
        Low,
        Medium,
        High
    }

}

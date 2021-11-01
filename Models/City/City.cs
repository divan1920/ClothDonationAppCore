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
        public string city { get; set; }

    }
}

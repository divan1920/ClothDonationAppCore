using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.Donation
{
    public interface IDonationRepo
    {
        Donation GetDonation(int Id);
        IEnumerable<Donation> GetAllDonationsByUid(string ApplicationUserId);
        Donation Add(Donation donation);
        Donation Delete(int Id);
        Donation Update(Donation donationChanges);
        IEnumerable<Donation> GetAllByCity(int cityId);
        IEnumerable<City.City> GetCities();
        int GetRole(string Username);
    }
}

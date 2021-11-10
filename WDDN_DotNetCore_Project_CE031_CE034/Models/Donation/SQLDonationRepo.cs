using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.Donation
{
    public class SQLDonationRepo : IDonationRepo
    {
        private readonly AppDbContext context;
        public SQLDonationRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Donation Add(Donation donation)
        {
            context.Donations.Add(donation);
            context.SaveChanges();
            return donation;
        }

        public Donation Delete(int Id)
        {
            Donation donation = context.Donations.Find(Id);
            if(donation != null)
            {
                context.Donations.Remove(donation);
                context.SaveChanges();
            }
            return donation;
        }

        public Donation Update(Donation donationChanges)
        {
            var donation = context.Donations.Attach(donationChanges);
            donation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return donationChanges;
        }

        public IEnumerable<Donation> GetAllDonationsByUid(string userId)
        {
            return context.Donations.Where(m => m.ApplicationUserId == userId).Include(m => m.City).Include(m=>m.ApplicationUser);
        }

        public Donation GetDonation(int Id)
        {
            return context.Donations.Include(m=>m.City).Include(m => m.ApplicationUser).FirstOrDefault(m=>m.Id == Id);
        }
        public IEnumerable<Donation> GetAllByCity(int cityId)
        {
            return context.Donations.Where(m => m.CityId == cityId).Include(m=>m.City).Include(m=>m.ApplicationUser);
        }
        public IEnumerable<City.City> GetCities()
        {
            return context.Cities;
        }
        int IDonationRepo.GetRole(string Username)
        {
            ApplicationUser user = context.Users.FirstOrDefault<ApplicationUser>(m => m.UserName == Username);
            int role = -1;
            if (user != null)
            {
                role = user.Role;
            }
            return role;
        }
    }
}

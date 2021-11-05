using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.City
{
    public class SQLCityRepo : ICityRepo
    {
        private readonly AppDbContext context;

        public SQLCityRepo(AppDbContext context)
        {
            this.context = context;
        }
        
        City ICityRepo.GetCity(int Id)
        {
            return context.Cities.Find(Id);
        }
        IEnumerable<City> ICityRepo.GetAllCities()
        {
            return context.Cities;
        }

        City ICityRepo.Add(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return city;
        }

        City ICityRepo.Delete(int Id)
        {
            City city = context.Cities.Find(Id);
            if (city != null)
            {
                context.Cities.Remove(city);
                context.SaveChanges();
            }
            return city;
        }
        int ICityRepo.GetRole(string Username)
        {
            ApplicationUser user = context.Users.FirstOrDefault<ApplicationUser>(m=>m.UserName == Username);
            int role=-1;
            if(user != null)
            {
                role = user.Role;
            }
            return role;
        }
    }
}

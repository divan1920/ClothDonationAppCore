using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.City
{
    public interface ICityRepo
    {
        City GetCity(int Id);
        IEnumerable<City> GetAllCities();
        City Delete(int Id);
        City Add(City city);
        int GetRole(string Username);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothDonationApp.Models.Role
{
    public interface IRoleRepo 
    {
        public Role GetRole(int Id);
        public IEnumerable<Role> GetAllRoles();
        public Role Delete(int Id);
        public Role Add(int Id);
    }
}

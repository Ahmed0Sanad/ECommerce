using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.Identity
{
    public class AppUser : IdentityUser
    {
        public string Fname { get; set; }
        public string  LName  { get; set; }
        public ICollection<Address> addresses { get; set; } = new HashSet<Address>(); 
    }
}

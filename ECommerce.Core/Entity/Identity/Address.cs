using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entity.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public  string FName { get; set; }
        public string Lname { get; set; }
        public string Country { get; set; }
        public string Street {  get; set; }
      
        public string City { get; set; }
      
    }
}

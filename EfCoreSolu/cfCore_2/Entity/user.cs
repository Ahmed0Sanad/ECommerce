using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.Entity
{
    internal class User
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
        public string Phone {  get; set; }
        public ICollection<Tickett> ticketts { get; set; }

    }
    public enum Role {Participate,Orgnaizer}
}

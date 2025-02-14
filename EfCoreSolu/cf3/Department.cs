using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf3
{
    public class Department
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20)]

        public string Dept_name { get; set; }
        [Range(5,100000)]
        public int Emplyee_num { get; set; }

        public ICollection<Class1> c1 { get; set; } = new HashSet<Class1>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf3
{
    public class Class1
    {
        public int name { get; set; }
        [Required]
        public int id { get; set; }
        public category c  { get; set; }

        public Department dept { get; set; }

    }
    public enum category
{
    Trip,confrence,even
}
}

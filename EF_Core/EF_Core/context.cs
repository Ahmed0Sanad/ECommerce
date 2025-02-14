using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
    internal class context: DbContext
    {
        DbSet<Employee> employees {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=cf_2;Integrated Security=True;trustservercertificate=true;");
        }
    }
}

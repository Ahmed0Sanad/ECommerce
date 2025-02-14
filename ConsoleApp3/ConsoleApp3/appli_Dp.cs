using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class appli_Dp:DbContext
    {
        DbSet<Employee> employees { get; set; }
        DbSet<car>cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=cf_1;Integrated Security=True;trustservercertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(c => c.id);
            modelBuilder.Entity<car>().HasKey(c => new {c.model, c.id});
        }
    }
}

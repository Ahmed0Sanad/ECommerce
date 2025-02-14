using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.context
{
    public class ContextDb:DbContext
    {
       public DbSet<Employee> employees {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=API1;Integrated Security=True;trustservercertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}

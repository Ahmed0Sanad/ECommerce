using ConsoleApp1.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.AppContext
{
    internal class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=cf_4;Integrated Security=True;trustservercertificate=true;");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<EmployeeDepartment> employeeDepartments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<teacher> teachers { get; set; }
        public DbSet<c1> c1s { get; set; }
        public DbSet<c2> c2s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<c1>().HasBaseType<inhirtance>();
            //modelBuilder.Entity<c2>().HasBaseType<inhirtance>();
            //modelBuilder.Entity<c1>().ToTable("c1ss");
            //modelBuilder.Entity<c2>().ToTable("c2ss");

            modelBuilder.Entity<Student>().HasMany(s => s.Teachers).WithMany(t => t.Students);

            //modelBuilder.Entity<Emp_Dept>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}

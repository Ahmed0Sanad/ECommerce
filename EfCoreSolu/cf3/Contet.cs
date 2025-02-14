using cf3.appConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf3
{
    internal class Contet: DbContext
    {
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Class1> events { get; set; }=null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=cf_1;Integrated Security=True;trustservercertificate=true;");    
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(e =>
            {
                e.Property(d=>d.Dept_name).HasMaxLength(50);
                e.Property(d => d.id).IsRequired();

            });
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.Entity<Class1>().HasOne(d => d.dept).WithMany(c=>c.c1).HasForeignKey(e =>e.dept)
        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Department>().HasMany(e => e.c1).WithOne(e => e.dept);
            
        }
        public override int SaveChanges()
        {
           var entitys = from e in ChangeTracker.Entries()
                        where e.State == EntityState.Modified || e.State == EntityState.Added
                        select e.Entity;
            foreach (var entity in entitys) { 
             ValidationContext VC = new ValidationContext(entity);
                Validator.ValidateObject(entity, VC,true);

            }
            return base.SaveChanges();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfCore_2.Entity;
using Microsoft.EntityFrameworkCore;

namespace cfCore_2.context
{
    internal class Context : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event_Class> Events { get; set; }
        public DbSet<Tickett> Ticketets { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<PrivateQuestion> PrivateQuestions { get; set; }
        public DbSet<ChoosedFeatures> ChoosedFeatures { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=Event02;Integrated Security=True;trustservercertificate=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivateQuestion>().HasKey(o => new { o.eventId, o.Question });

            modelBuilder.Entity<ChoosedFeatures>().HasKey(e => new {e.featureId,e.tickettId});

            modelBuilder.Entity<Tickett>().HasOne(t => t.Event_Class).WithMany(e => e.ticketts).
                OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Tickett>().HasOne(t => t.user).WithMany(e => e.ticketts).
                OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event_Class>().HasMany(e=>e.ticketts).WithOne(t=>t.Event_Class).
                OnDelete(DeleteBehavior.NoAction);
            


            base.OnModelCreating(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Scaffould_test.Models;

namespace Scaffould_test.Context;

public partial class Event02Context : DbContext
{
    public Event02Context()
    {
    }

    public Event02Context(DbContextOptions<Event02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<PrivateQuestion> PrivateQuestions { get; set; }

    public virtual DbSet<Ticketet> Ticketets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = DESKTOP-592OS1T; Initial Catalog=Event02;Integrated Security=True;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasOne(d => d.Org).WithMany(p => p.Events).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany(p => p.Features).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Ticketts).WithMany(p => p.Features)
                .UsingEntity<Dictionary<string, object>>(
                    "ChoosedFeature",
                    r => r.HasOne<Ticketet>().WithMany()
                        .HasForeignKey("TickettId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Feature>().WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FeatureId", "TickettId");
                        j.ToTable("ChoosedFeatures");
                        j.HasIndex(new[] { "TickettId" }, "IX_ChoosedFeatures_tickettId");
                        j.IndexerProperty<int>("FeatureId").HasColumnName("featureId");
                        j.IndexerProperty<int>("TickettId").HasColumnName("tickettId");
                    });
        });

        modelBuilder.Entity<PrivateQuestion>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany(p => p.PrivateQuestions).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ticketet>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany(p => p.Ticketets).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Ticketets).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

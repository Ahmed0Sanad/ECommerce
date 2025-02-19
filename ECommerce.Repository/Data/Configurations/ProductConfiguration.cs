using ECommerce.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.Property(p=>p.PictureUrl).HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p=>p.Description).HasMaxLength(500);
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
            builder.HasOne(p=>p.Category).WithMany().HasForeignKey(c => c.CategoryId);
        }
    }
}

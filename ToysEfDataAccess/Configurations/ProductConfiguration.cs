using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToysDomain;

namespace ToysEfDataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            builder.HasIndex(p => p.ProductName).IsUnique();

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}

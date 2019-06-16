using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToysDomain;

namespace ToysEfDataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName).IsRequired();

            builder.HasIndex(c => c.CategoryName).IsUnique();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}

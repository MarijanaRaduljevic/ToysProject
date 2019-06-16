using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToysDomain;

namespace ToysEfDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.RoleName).IsRequired();

            builder.HasIndex(r => r.RoleName).IsUnique();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}

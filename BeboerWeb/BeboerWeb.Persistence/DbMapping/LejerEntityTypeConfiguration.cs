﻿using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class LejerEntityTypeConfiguration : IEntityTypeConfiguration<Lejer>
    {
        public void Configure(EntityTypeBuilder<Lejer> builder)
        {
            builder.Property(le => le.Id).HasDefaultValueSql("NEWID()");

            builder
                .HasMany(le => le.Personer)
                .WithMany(p => p.Lejere);

            builder
                .HasOne(le => le.Lejemaal)
                .WithOne(lm => lm.Lejer)
                .HasForeignKey<Lejer>(le => le.Id);
        }
    }
}

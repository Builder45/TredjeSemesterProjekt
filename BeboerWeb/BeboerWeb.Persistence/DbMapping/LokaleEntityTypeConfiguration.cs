using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class LokaleEntityTypeConfiguration : IEntityTypeConfiguration<Lokale>
    {
        public void Configure(EntityTypeBuilder<Lokale> builder)
        {
            builder.Property(lk => lk.Id).HasDefaultValueSql("NEWID()");

            builder
                .HasOne(lk => lk.Bygning)
                .WithMany(bn => bn.Lokaler);
        }
    }
}

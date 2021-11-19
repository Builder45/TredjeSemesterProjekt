using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class LejemaalEntityTypeConfiguration : IEntityTypeConfiguration<Lejemaal>
    {
        public void Configure(EntityTypeBuilder<Lejemaal> builder)
        {
            builder.Property(lm => lm.Id).HasDefaultValueSql("NEWID()");

            builder
                .HasOne(lm => lm.Bygning)
                .WithMany(bn => bn.Lejemaal);
        }
    }
}

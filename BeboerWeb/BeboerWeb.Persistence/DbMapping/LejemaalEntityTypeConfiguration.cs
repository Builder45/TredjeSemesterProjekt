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
            builder.Property(lm => lm.RowVersion).IsConcurrencyToken();

            builder
                .HasOne(lm => lm.Ejendom)
                .WithMany(e => e.Lejemaal);
        }
    }
}

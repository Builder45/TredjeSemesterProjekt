using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class EjendomEntityTypeConfiguration : IEntityTypeConfiguration<Ejendom>
    {
        public void Configure(EntityTypeBuilder<Ejendom> builder)
        {
            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            builder
                .HasOne(e => e.Afdeling)
                .WithMany(a => a.Ejendomme);
            builder
                .HasMany(e => e.Vicevaerter)
                .WithMany(v => v.Ejendomme);
        }
    }
}

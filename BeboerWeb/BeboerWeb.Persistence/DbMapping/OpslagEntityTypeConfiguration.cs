using Microsoft.EntityFrameworkCore;
using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class OpslagEntityTypeConfiguration : IEntityTypeConfiguration<Opslag>
    {
        public void Configure(EntityTypeBuilder<Opslag> builder)
        {
            builder.Property(o => o.Id).HasDefaultValueSql("NEWID()");
            builder.Property(o => o.Titel).HasMaxLength(100);
            builder.Property(o => o.Besked).HasMaxLength(5000);
            builder
                .HasMany(o => o.Ejendomme)
                .WithMany(e => e.Opslag)
                .UsingEntity(join => join.ToTable("OpslagsOversigt"));
        }
    }
}

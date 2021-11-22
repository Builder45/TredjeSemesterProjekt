using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class AfdelingEntityTypeConfiguration : IEntityTypeConfiguration<Afdeling>
    {
        public void Configure(EntityTypeBuilder<Afdeling> builder)
        {
            builder.Property(a => a.Id).HasDefaultValueSql("NEWID()");
            builder
                .HasMany(a => a.Boligadministratorer)
                .WithMany(ba => ba.Afdelinger)
                .UsingEntity(join => join.ToTable("AdminOversigt"));
        }
    }
}

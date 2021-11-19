using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class BygningEntityTypeConfiguration : IEntityTypeConfiguration<Bygning>
    {
        public void Configure(EntityTypeBuilder<Bygning> builder)
        {
            builder.Property(bn => bn.Id).HasDefaultValueSql("NEWID()");
            builder
                .HasOne(bn => bn.Ejendom)
                .WithMany(e => e.Bygninger);          
        }
    }
}

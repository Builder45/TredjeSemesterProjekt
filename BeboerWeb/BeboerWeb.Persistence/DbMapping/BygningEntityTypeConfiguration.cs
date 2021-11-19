using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class BygningEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Bygning>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Bygning> builder)
        {
            builder
                .HasOne(b => b.Ejendom)
                .WithMany(e => e.Bygninger);
            
        }
    }
}

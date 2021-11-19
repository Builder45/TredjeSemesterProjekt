using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class AfdelingEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Afdeling>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Afdeling> builder)
        {
            builder
                .HasOne(a => a.)
                .WithMany(e => e.);
                
        }
    }
}

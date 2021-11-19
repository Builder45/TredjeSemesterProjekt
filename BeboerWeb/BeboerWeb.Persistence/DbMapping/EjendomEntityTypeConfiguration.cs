using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class EjendomEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Ejendom>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Ejendom> builder)
        {
            builder
                .HasOne(e => e.Afdeling)
                .WithMany(a => a.Ejendomme);
            builder
                .HasMany(e => e.Vicevaerter)
                .WithMany(v => v.Ejendomme);
            
        }
    }
}

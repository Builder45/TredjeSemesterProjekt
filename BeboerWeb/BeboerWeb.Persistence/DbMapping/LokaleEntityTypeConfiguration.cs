using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class LokaleEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Lokale>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Lokale> builder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class LejemaalEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Lejemaal>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Lejemaal> builder)
        {

        }
    }
}

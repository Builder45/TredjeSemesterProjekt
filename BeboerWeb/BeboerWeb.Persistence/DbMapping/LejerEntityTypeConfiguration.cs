using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class LejerEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Lejer>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Lejer> builder)
        {

        }
    }
}

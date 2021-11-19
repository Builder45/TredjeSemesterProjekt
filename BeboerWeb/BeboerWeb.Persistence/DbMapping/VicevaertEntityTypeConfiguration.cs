using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    internal class VicevaertEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Vicevaert>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Vicevaert> builder)
        {

        }
    }
}

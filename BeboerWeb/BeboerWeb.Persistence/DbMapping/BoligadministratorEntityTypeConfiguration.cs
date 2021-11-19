using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class BoligadministratorEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Boligadminstrator>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Boligadministrator> builder)
        {

        }
    }
}

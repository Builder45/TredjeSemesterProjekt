using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Person> builder)
        {

        }
    }
}

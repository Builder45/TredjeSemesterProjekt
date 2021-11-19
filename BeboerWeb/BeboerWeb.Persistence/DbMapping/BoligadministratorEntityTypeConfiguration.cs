using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class BoligadministratorEntityTypeConfiguration : IEntityTypeConfiguration<Boligadministrator>
    {
        public void Configure(EntityTypeBuilder<Boligadministrator> builder)
        {
            builder.Property(ba => ba.Id).HasDefaultValueSql("NEWID()");
        }
    }
}

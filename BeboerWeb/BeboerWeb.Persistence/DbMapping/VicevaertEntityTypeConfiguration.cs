using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    internal class VicevaertEntityTypeConfiguration : IEntityTypeConfiguration<Vicevaert>
    {
        public void Configure(EntityTypeBuilder<Vicevaert> builder)
        {
            builder.Property(v => v.Id).HasDefaultValueSql("NEWID()");

        }
    }
}

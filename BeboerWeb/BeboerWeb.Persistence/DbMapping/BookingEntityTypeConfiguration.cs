using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(bk => bk.Id).HasDefaultValueSql("NEWID()");
            builder
                .HasOne(bk => bk.Person)
                .WithMany(p => p.Bookinger);
            builder
                .HasOne(bk => bk.Lokale)
                .WithMany(lk => lk.Bookinger);
        }
    }
}

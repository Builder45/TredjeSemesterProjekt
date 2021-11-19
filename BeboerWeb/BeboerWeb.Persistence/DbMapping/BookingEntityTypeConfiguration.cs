using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeboerWeb.Persistence.DbMapping
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Booking>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Booking> builder)
        {

        }
    }
}

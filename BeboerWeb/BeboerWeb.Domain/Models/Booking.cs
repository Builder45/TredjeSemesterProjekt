using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime BookingPeriodeStart { get; set; }
        public DateTime BookingPeriodeSlut { get; set; }

        public Person Person { get; set; }
        public Lokale Lokale { get; set; }

        // Tom constructor vigtig for EF
        public Booking() { }
    }
}

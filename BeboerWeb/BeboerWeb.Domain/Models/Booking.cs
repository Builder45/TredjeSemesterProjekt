using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingPeriodeStart { get; set; }
        public DateTime BookingPeriodeSlut { get; set; }
    }
}

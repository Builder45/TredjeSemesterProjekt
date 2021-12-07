using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Booking
{
    public class CreateBookingRequest
    {
        public Guid Id { get; set; }
        public DateTime BookingPeriodeStart { get; set; }
        public DateTime BookingPeriodeSlut { get; set; }
        public Guid PersonId { get; set; }
        public Guid LokaleId { get; set; }
        public CreateBookingRequest(DateTime bookingPeriodeStart, DateTime bookingPeriodeSlut, Guid personId, Guid lokaleId)
        {
            BookingPeriodeStart = bookingPeriodeStart;
            BookingPeriodeSlut = bookingPeriodeSlut;
            PersonId = personId;
            LokaleId = lokaleId;
        }
    }
}

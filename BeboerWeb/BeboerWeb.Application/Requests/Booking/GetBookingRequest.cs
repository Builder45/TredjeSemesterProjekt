using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Booking
{
    public class GetBookingRequest
    {
        public Guid LokaleId { get; set; }
        public Guid PersonId { get; set; }
        public DateTime BookingPeriodeStart { get; set; }
        public DateTime BookingPeriodeSlut { get; set; }
        public DateTime SearchDate { get; set; }
    }
}

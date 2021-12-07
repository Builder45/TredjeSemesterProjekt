using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public DateTime BookingPeriodeStart { get; set; }
        public DateTime BookingPeriodeSlut { get; set; }
        public Guid LokaleId { get; set; }

        public Guid PersonId { get; set; }

    }
}

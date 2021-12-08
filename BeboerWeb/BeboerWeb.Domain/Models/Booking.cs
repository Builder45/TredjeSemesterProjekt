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
        public Booking(DateTime bookingPeriodeStart, DateTime bookingPeriodeSlut, Person person, Lokale lokale)
        {
            BookingPeriodeStart = bookingPeriodeStart;
            BookingPeriodeSlut = bookingPeriodeSlut;
            Person = person;
            Lokale = lokale;
        }

        public bool CheckForOverlaps(List<Booking> otherBookings)
        {
            var check = otherBookings.Except(new[] {this}).Any(a =>
                a.BookingPeriodeStart >= BookingPeriodeStart && BookingPeriodeStart <= a.BookingPeriodeSlut);
            return check;
        }


    }
}

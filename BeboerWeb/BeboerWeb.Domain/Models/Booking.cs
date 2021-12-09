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
            if (bookingPeriodeSlut < bookingPeriodeStart)
                throw new ArgumentException("Slutdatoen skal være efter startdatoen");
            BookingPeriodeStart = bookingPeriodeStart;
            BookingPeriodeSlut = bookingPeriodeSlut;
            Person = person;
            Lokale = lokale;
        }
        public bool IsOverlappingWith(List<Booking> otherBookings)
        {
            foreach (Booking booking in otherBookings)
            {
                if (BookingPeriodeStart < booking.BookingPeriodeSlut)
                {
                    if (BookingPeriodeSlut >= booking.BookingPeriodeStart)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsInThePast()
        {
            if (BookingPeriodeStart < DateTime.Now)
                return true;
            return false;
        }
        public bool IsOldOrStarted()
        {
            if (BookingPeriodeSlut < DateTime.Now)
            {
                return true;
            }

            if (BookingPeriodeStart < DateTime.Now)
            {
                return true;
            }

            return false;
        }
    }
}

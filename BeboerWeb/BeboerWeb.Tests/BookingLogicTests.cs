using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeboerWeb.Tests
{
    [TestClass]
    public class BookingLogicTests
    {
        [TestMethod]
        public void GivenBookingPeriodeStartIsInThePast_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 08, 02), new DateTime(2021,08,03), null, null);
            var result = booking.IsInThePast();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenBookingIsOld_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 01, 01), new DateTime(2021, 01, 02), null, null);
            var result = booking.IsOldOrStarted();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenBookingHasStarted_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 12, 08), new DateTime(2022,02,01), null, null);
            var result = booking.IsOldOrStarted();
            Assert.IsTrue(result);
        }

        // --___--
        // -__----
        [TestMethod]
        public void GivenBookingOverlapsOtherBookingsAtStart_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 12, 10), new DateTime(2021, 12, 18), null, null);
            var otherBookings = new List<Booking>();
            var bookingInList1 = new Booking(new DateTime(2021, 12, 5), new DateTime(2021, 12, 12), null, null);
            var bookingInList2 = new Booking(new DateTime(2021, 12, 28), new DateTime(2021, 12, 30), null, null);
            otherBookings.Add(bookingInList1);
            otherBookings.Add(bookingInList2);

            var result = booking.IsOverlappingWith(otherBookings);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenBookingOverlapsOtherBookingsCompletely_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 12, 10), new DateTime(2021, 12, 18), null, null);
            var otherBookings = new List<Booking>();
            var bookingInList1 = new Booking(new DateTime(2021, 12, 15), new DateTime(2021, 12, 22), null, null);
            var bookingInList2 = new Booking(new DateTime(2021, 12, 28), new DateTime(2021, 12, 30), null, null);
            otherBookings.Add(bookingInList1);
            otherBookings.Add(bookingInList2);

            var result = booking.IsOverlappingWith(otherBookings);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenBookingOverlapsOtherBookingsAtEnd_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 12, 10), new DateTime(2021, 12, 18), null, null);
            var otherBookings = new List<Booking>();
            var bookingInList1 = new Booking(new DateTime(2021, 12, 11), new DateTime(2021, 12, 16), null, null);
            var bookingInList2 = new Booking(new DateTime(2021, 12, 28), new DateTime(2021, 12, 30), null, null);
            otherBookings.Add(bookingInList1);
            otherBookings.Add(bookingInList2);

            var result = booking.IsOverlappingWith(otherBookings);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenBookingBeginsWhenOtherBookingsEnds_Then_ReturnTrue()
        {
            var booking = new Booking(new DateTime(2021, 12, 10), new DateTime(2021, 12, 18), null, null);
            var otherBookings = new List<Booking>();
            var bookingInList1 = new Booking(new DateTime(2021, 12, 18), new DateTime(2021, 12, 20), null, null);
            var bookingInList2 = new Booking(new DateTime(2021, 12, 28), new DateTime(2021, 12, 30), null, null);
            otherBookings.Add(bookingInList1);
            otherBookings.Add(bookingInList2);

            var result = booking.IsOverlappingWith(otherBookings);
            Assert.IsTrue(result);
        }
    }
}

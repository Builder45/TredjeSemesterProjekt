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
    public class BookingConstructorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Slutdatoen skal være senere end startdatoen")]
        public void GivenBookingPeriodeStartIsGreaterThanBookingPeriodeSlut_Then_ThrowException()
        {
            var bookingPeriodeStart = new DateTime(2021, 12, 20);
            var bookingPeriodeSlut = new DateTime(2021, 12, 10);
            var booking = new Booking(bookingPeriodeStart, bookingPeriodeSlut, null, null);
        }
    }
}

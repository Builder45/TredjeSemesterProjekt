using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Tests
{
    [TestClass]
    public class LejerConstructorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Slutsdatoen skal være senere end startsdatoen")]
        public void GivenLejeperiodeStartIsEqualToLejeperiodeSlut_Then_ThrowException()
        {
            var lejeperiodeStart = new DateTime(2021, 12, 10);
            var lejeperiodeSlut = new DateTime(2021, 12, 10);
            var lejer = new Lejer(lejeperiodeStart, lejeperiodeSlut, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Slutsdatoen skal være senere end startsdatoen")]
        public void GivenLejeperiodeStartIsGreaterThanLejeperiodeSlut_Then_ThrowException()
        {
            var lejeperiodeStart = new DateTime(2021, 12, 20);
            var lejeperiodeSlut = new DateTime(2021, 12, 10);
            var lejer = new Lejer(lejeperiodeStart, lejeperiodeSlut, null);
        }

    }
}
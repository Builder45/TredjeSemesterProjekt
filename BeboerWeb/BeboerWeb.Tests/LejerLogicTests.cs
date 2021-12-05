using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Tests
{
    [TestClass]
    public class LejerLogicTests
    {
        // --___--
        // -__----
        [TestMethod]
        public void GivenLejeperiodeOverlapsOtherLejeperiodeAtStart_Then_ReturnTrue()
        {
            var lejer1 = new Lejer(new DateTime(2021, 10, 10), new DateTime(2021, 10, 17), null);
            var lejer2 = new Lejer(new DateTime(2021, 10, 5), new DateTime(2021, 10, 12), null);

            var result = lejer1.IsOverlappingWith(lejer2);

            Assert.IsTrue(result);
        }
        // --___--
        // ---_---
        [TestMethod]
        public void GivenLejeperiodeOverlapsOtherLejeperiodeCompletely_Then_ReturnTrue()
        {
            var lejer1 = new Lejer(new DateTime(2021, 10, 10), new DateTime(2021, 10, 17), null);
            var lejer2 = new Lejer(new DateTime(2021, 10, 15), new DateTime(2021, 10, 22), null);

            var result = lejer1.IsOverlappingWith(lejer2);

            Assert.IsTrue(result);
        }

        // --___--
        // ----__-
        [TestMethod]
        public void GivenLejeperiodeOverlapsOtherLejeperiodeAtEnd_Then_ReturnTrue()
        {
            var lejer1 = new Lejer(new DateTime(2021, 10, 10), new DateTime(2021, 10, 17), null);
            var lejer2 = new Lejer(new DateTime(2021, 10, 11), new DateTime(2021, 10, 16), null);

            var result = lejer1.IsOverlappingWith(lejer2);

            Assert.IsTrue(result);
        }

        // --___--
        // -----__
        [TestMethod]
        public void GivenLejeperiodeBeginsWhenOtherLejeperiodeEnds_Then_ReturnFalse()
        {
            var lejer1 = new Lejer(new DateTime(2021, 10, 10), new DateTime(2021, 10, 17), null);
            var lejer2 = new Lejer(new DateTime(2021, 10, 17), new DateTime(2021, 10, 24), null);

            var result = lejer1.IsOverlappingWith(lejer2);

            Assert.IsFalse(result);
        }
    }
}
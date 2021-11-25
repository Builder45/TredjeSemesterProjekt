using BeboerWeb.API.Contract.DTO;
using BeboerWeb.API.Controllers;
using BeboerWeb.Application.Requests;
using BeboerWeb.Application.UseCases.EjendomUC.Interfaces;
using BeboerWeb.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BeboerWeb.API.Tests
{
    [TestClass]
    public class EjendomControllerTests
    {
        private Mock<ICreateEjendomUseCase> _createEjendomMock;
        private Mock<IGetEjendomUseCase> _getEjendomMock;
        private Mock<IUpdateEjendomUseCase> _updateEjendomMock;

        private EjendomController _controller;

        [TestInitialize]
        public void Setup()
        {
            _createEjendomMock = new Mock<ICreateEjendomUseCase>();
            _getEjendomMock = new Mock<IGetEjendomUseCase>();
            _updateEjendomMock = new Mock<IUpdateEjendomUseCase>();

            _controller = new EjendomController(_createEjendomMock.Object, _getEjendomMock.Object, _updateEjendomMock.Object);
        }

        [TestMethod]
        public void GetEjendomme_ReturnsAllEjendomme()
        {
            _getEjendomMock.Setup(uc => uc.GetEjendomme()).Returns(GetTestEjendomme());
            var testEjendomme = GetTestEjendomme();

            var result = _controller.Get() as List<EjendomDTO>;
            Assert.AreEqual(testEjendomme.Count, result.Count);
        }

        //[TestMethod]
        //public void GetEjendom_ReturnsCorrectEjendom()
        //{
        //    var testEjendomme = GetTestEjendomme();
        //    var exampleGuid = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

        //    _getEjendomMock.Setup(uc => uc.GetEjendom(new GetEjendomRequest { EjendomId = exampleGuid })).Returns(testEjendomme[3]);

        //    var result = _controller.Get(exampleGuid);
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testEjendomme[3].Adresse, result.Adresse);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException), "Ejendom with given ID does not exist")]
        //public void UpdateEjendom_ThrowsExceptionIfIdDoesntExist()
        //{
        //    _controller.Put(new EjendomDTO { Id = Guid.NewGuid() });
        //}

        private List<Ejendom> GetTestEjendomme()
        {
            var testEjendomme = new List<Ejendom>();
            testEjendomme.Add(new Ejendom { Id = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E1"), Adresse = "Ad1", Postnr = 1234, By = "B1" });
            testEjendomme.Add(new Ejendom { Id = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E2"), Adresse = "Ad2", Postnr = 1234, By = "B1" });
            testEjendomme.Add(new Ejendom { Id = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E3"), Adresse = "Ad3", Postnr = 1234, By = "B1" });
            testEjendomme.Add(new Ejendom { Id = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), Adresse = "Ad4", Postnr = 1234, By = "B1" });
            return testEjendomme;
        }
    }
}
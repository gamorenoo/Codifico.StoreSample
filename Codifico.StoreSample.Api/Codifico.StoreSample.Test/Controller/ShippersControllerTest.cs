﻿using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Controllers;
using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Test.Controller
{
    [TestClass]
    public class ShippersControllerTest
    {
        private ShippersController _controller;
        private readonly Mock<IShippersAppService> _process = new Mock<IShippersAppService>();

        [TestInitialize]
        public void TestIniTestInitialize()
        {
            _controller = new ShippersController(_process.Object);
        }

        [TestMethod]
        [DataRow(HttpStatusCode.OK)]
        public async Task GetShippersTest(HttpStatusCode expected)
        {
            //Arrange
            _process.Setup(t => t.getAll()).Returns(Task.FromResult(new List<Shippers>()));

            //Act
            IActionResult result = await _controller.GetAll();
            var r = (HttpStatusCode)((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, r);
        }
    }
}

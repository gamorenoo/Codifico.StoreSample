using Codifico.StoreSample.Api.Application.Contracts;
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
    public class OrdersControllerTest
    {
        private OrdersController _controller;
        private readonly Mock<IOrdersAppService> _process = new Mock<IOrdersAppService>();

        [TestInitialize]
        public void TestIniTestInitialize()
        {
            _controller = new OrdersController(_process.Object);
        }

        [TestMethod]
        [DataRow(HttpStatusCode.OK)]
        public async Task GetByclientTest(HttpStatusCode expected)
        {
            int cusid = 0;
            //Arrange
            _process.Setup(t => t.getByclient(cusid)).Returns(Task.FromResult(new List<Orders>()));

            //Act
            IActionResult result = await _controller.getByclient(cusid);
            var r = (HttpStatusCode)((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, r);
        }

        [TestMethod]
        [DataRow(HttpStatusCode.OK)]
        public async Task GetPredictedOrdersTest(HttpStatusCode expected)
        {
            //Arrange
            _process.Setup(t => t.getPredictedOrders()).Returns(Task.FromResult(new List<PredictedOrders>()));

            //Act
            IActionResult result = await _controller.getPredictedOrders();
            var r = (HttpStatusCode)((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, r);
        }

        [TestMethod]
        [DataRow(HttpStatusCode.OK)]
        public async Task AddOrdersTest(HttpStatusCode expected)
        {
            NewOrders newOrders = new NewOrders();
            //Arrange
            _process.Setup(t => t.add(newOrders)).Returns(Task.FromResult(new NewOrders()));

            //Act
            IActionResult result = await _controller.add(newOrders);
            var r = (HttpStatusCode)((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, r);
        }
    }
}

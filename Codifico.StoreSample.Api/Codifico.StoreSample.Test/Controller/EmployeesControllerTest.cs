using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Application.Services;
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
    public class EmployeesControllerTest
    {
        private EmployeesController _controller;
        private readonly Mock<IEmployeesAppService> _process = new Mock<IEmployeesAppService>();

        [TestInitialize]
        public void TestIniTestInitialize()
        {
            _controller = new EmployeesController(_process.Object);
        }

        [TestMethod]
        [DataRow(HttpStatusCode.OK)]
        public async Task GetEmpleyeesTest(HttpStatusCode expected)
        {
            //Arrange
            _process.Setup(t => t.getAll()).Returns(Task.FromResult(new List<Employees>()));

            //Act
            IActionResult result = await _controller.GetAll();
            var r = (HttpStatusCode)((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, r);
        }
    }
}

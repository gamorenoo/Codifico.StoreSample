using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesAppService _employeesAppService;
        public EmployeesController(IEmployeesAppService employeesAppService) {
            _employeesAppService = employeesAppService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _employeesAppService.getAll();

            return Ok(result);
        }
    }
}

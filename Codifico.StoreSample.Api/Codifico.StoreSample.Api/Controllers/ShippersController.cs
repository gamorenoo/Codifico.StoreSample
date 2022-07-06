using Codifico.StoreSample.Api.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private IShippersAppService _shippersAppService;
        public ShippersController(IShippersAppService shippersAppService)
        {
            _shippersAppService = shippersAppService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _shippersAppService.getAll();

            return Ok(result);
        }
    }
}

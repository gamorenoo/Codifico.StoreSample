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
    public class ShippersController : ControllerBase
    {
        private ShippersAppService _shippersAppService;
        public ShippersController(ShippersAppService shippersAppService)
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

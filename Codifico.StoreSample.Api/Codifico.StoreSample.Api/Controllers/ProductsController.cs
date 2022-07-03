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
    public class ProductsController : ControllerBase
    {
        private ProductsAppService _productsAppService;
        public ProductsController(ProductsAppService productsAppService)
        {
            _productsAppService = productsAppService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _productsAppService.getAll();

            return Ok(result);
        }
    }
}

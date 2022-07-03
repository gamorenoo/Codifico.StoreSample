using Codifico.StoreSample.Api.Application.Services;
using Codifico.StoreSample.Api.DTOs;
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
    public class OrdersController : ControllerBase
    {
        private OrdersAppService _ordersAppService;
        public OrdersController(OrdersAppService ordersAppService)
        {
            _ordersAppService = ordersAppService;
        }

        [HttpGet]
        [Route("customers/{custid}")]
        public async Task<ActionResult> getByclient(int custid)
        {
            var result = await _ordersAppService.getByclient(custid);

            return Ok(result);
        }

        [HttpGet]
        [Route("predictedOrders")]
        public async Task<ActionResult> getPredictedOrders()
        {
            var result = await _ordersAppService.getPredictedOrders();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> add(NewOrders newOrders)
        {
            var result = await _ordersAppService.add(newOrders);

            return Ok(result);
        }
    }
}

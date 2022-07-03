using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using Codifico.StoreSample.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class OrdersAppService
    {
        private OrdersDomainService _ordersDomainService;

        public OrdersAppService(OrdersDomainService ordersDomainService)
        {
            _ordersDomainService = ordersDomainService;
        }

        public async Task<IEnumerable<Orders>> getByclient(int custid)
        {
            try
            {
                return await _ordersDomainService.getByclient(custid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<NewOrders> add(NewOrders newOrders) 
        {
            try
            {
                return await _ordersDomainService.add(newOrders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<PredictedOrders>> getPredictedOrders()
        {
            try
            {
                return await _ordersDomainService.getPredictedOrders();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using Codifico.StoreSample.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class OrdersAppService: IOrdersAppService
    {
        private OrdersDomainService _ordersDomainService;

        public OrdersAppService(OrdersDomainService ordersDomainService)
        {
            _ordersDomainService = ordersDomainService;
        }

        public async Task<List<Orders>> getByclient(int custid)
        {
            try
            {
                var result = await _ordersDomainService.getByclient(custid);
                return result.ToList();
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

        public async Task<List<PredictedOrders>> getPredictedOrders()
        {
            try
            {
                var result = await _ordersDomainService.getPredictedOrders();
                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

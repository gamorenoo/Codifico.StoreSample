using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.DTOs;
using Codifico.StoreSample.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Domain.Services
{
    public class OrdersDomainService
    {
        private OrdersRepository _ordersRepository;
        private OrdersDetailRepository _ordersDetailRepository;
        private PredictedOrdersRepository _predictedOrdersRepository;

        public OrdersDomainService(OrdersRepository ordersRepository, OrdersDetailRepository ordersDetailRepository, PredictedOrdersRepository predictedOrdersRepository)
        {
            _ordersRepository = ordersRepository;
            _ordersDetailRepository = ordersDetailRepository;
            _predictedOrdersRepository = predictedOrdersRepository;
        }

        public async Task<IEnumerable<Orders>> getByclient(int custid)
        {
            return await _ordersRepository.getByclient(custid);
        }

        public async Task<NewOrders> add(NewOrders newOrders) {
            var orderId = await _ordersRepository.add(newOrders);
            newOrders.Orderid = orderId;
            newOrders.OrdersDetail.Orderid = orderId;

            //await _ordersDetailRepository.add(newOrders.OrdersDetail);

            return newOrders;
        }

        public async Task<IEnumerable<PredictedOrders>> getPredictedOrders() {
            return await _predictedOrdersRepository.getAll();
        }
    }
}

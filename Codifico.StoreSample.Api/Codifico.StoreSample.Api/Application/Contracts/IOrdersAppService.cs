using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Contracts
{
    public interface IOrdersAppService
    {
        Task<List<Orders>> getByclient(int custid);

        Task<NewOrders> add(NewOrders newOrders);

        Task<List<PredictedOrders>> getPredictedOrders();
    }
}

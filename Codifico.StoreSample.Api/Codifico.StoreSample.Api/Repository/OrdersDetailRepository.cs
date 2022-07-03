using Codifico.StoreSample.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class OrdersDetailRepository
    {
        private StoreSampleDBcontext _context;
        public OrdersDetailRepository(StoreSampleDBcontext context)
        {
            _context = context;
        }

        public async Task<bool> add(OrdersDetail ordersDetail)
        {
            return await Task.Run(() =>
            {
                string sqlInsert = "INSERT INTO Sales.OrdersDetails(orderid, productid, unitprice, qty, discount)"
                                    + "VALUES (" + ordersDetail.Orderid + ", " + ordersDetail.Productid 
                                    + "," + ordersDetail.Unitprice + "," + ordersDetail.Qty + "," + ordersDetail.Discount + ")";
                
                _context.OrdersDetails.FromSqlRaw(sqlInsert).ToList();
                return true;
            });

            // Para retornar la lista desde entity framework
            // await _context.OrdersDetails.AddAsync(ordersDetail);
            // return true;

        }
    }
}

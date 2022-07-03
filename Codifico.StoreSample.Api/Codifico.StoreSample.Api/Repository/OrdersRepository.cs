using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class OrdersRepository
    {
        private StoreSampleDBcontext _context;
        public OrdersRepository(StoreSampleDBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> getByclient(int custid)
        {
            return await Task.Run(() =>
            {
                return _context.Orders.FromSqlRaw("SELECT orderid, requireddate, shippeddate, shipname, shipaddress, shipcity, custid FROM Sales.Orders WHERE custid = " + custid)
                ?.ToList();
            });

            // Para retornar la lista desde entity framework
            // var orders = _context.Orders.ToList();
            // return orders.Where(o => o.custid == custid).ToList();
            
        }

        public async Task<int> add(NewOrders orders)
        {
            return await Task.Run(() =>
            {
                int orderId = 0;
                //string sqlInsert = "INSERT INTO Sales.Orders(empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)"
                //                    + "VALUES (" + orders.Empid + ", " + orders.Shipperid + ",'" + orders.Shipname 
                //                    + "','" + orders.Shipaddress + "','" + orders.Shipcity + "','" + orders.Orderdate.ToString("yyyy-MM-dd HH:mm:ss")
                //                    + "','" + orders.Requireddate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + orders.Shippeddate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + orders.Freight 
                //                    + "','" + orders.Shipcountry + "')";
                //_context.Database.ExecuteSqlRaw(sqlInsert);

                string sqlInsert = string.Format("EXECUTE Sales.CreateOrder @empid = {0} , @shipperid = {1}, @shipname = '{2}', @shipaddress = '{3}', @shipcity = '{4}', @orderdate = '{5}', @requireddate = '{6}', @shippeddate = '{7}', @freight = '{8}', @shipcountry = '{9}', @productid = {10}, @unitprice = {11}, @qty = {12}, @discount = '{13}'",
                                    orders.Empid, orders.Shipperid, orders.Shipname, orders.Shipaddress, orders.Shipcity, orders.Orderdate.ToString("yyyy-MM-dd HH:mm:ss"), orders.Requireddate.ToString("yyyy-MM-dd HH:mm:ss"), orders.Shippeddate.ToString("yyyy-MM-dd HH:mm:ss"), orders.Freight, orders.Shipcountry, orders.OrdersDetail.Productid, orders.OrdersDetail.Unitprice, orders.OrdersDetail.Qty, orders.OrdersDetail.Discount);

                orderId = _context.Orders.FromSqlRaw(sqlInsert).AsEnumerable().Select(x => x.Orderid).FirstOrDefault();

                return orderId;
            });

            // Para retornar la lista desde entity framework
            // await _context.Orders.AddAsync(ordersDetail);
            // return true;

        }
    }
}

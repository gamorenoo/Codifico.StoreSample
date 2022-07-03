using Codifico.StoreSample.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.DTOs
{
    public class NewOrders
    {
        public int Orderid { get; set; }
        public int Empid { get; set; }
        public int Shipperid { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime Shippeddate { get; set; }
        public decimal Freight { get; set; }
        public string Shipcountry { get; set; }
        public OrdersDetail OrdersDetail { get; set; }
    }
}

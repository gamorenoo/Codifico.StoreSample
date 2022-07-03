using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Codifico.StoreSample.Api.Domain.Entities
{
    public class Orders
    {
        [Key]
        public int Orderid { get; set; }
        public int? custid { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime Shippeddate { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
    }

    public class OrdersDetail
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }

    public class PredictedOrders
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredicatedOrder { get; set; }
    }
}

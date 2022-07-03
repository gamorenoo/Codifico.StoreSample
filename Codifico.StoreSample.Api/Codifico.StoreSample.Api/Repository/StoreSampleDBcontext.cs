using Codifico.StoreSample.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class StoreSampleDBcontext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersDetail> OrdersDetails { get; set; }
        public DbSet<PredictedOrders> PredictedOrders { get; set; }

        public StoreSampleDBcontext(DbContextOptions<StoreSampleDBcontext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersDetail>().HasKey(table => new {
                table.Orderid,
                table.Productid
            });
        }
    }
}

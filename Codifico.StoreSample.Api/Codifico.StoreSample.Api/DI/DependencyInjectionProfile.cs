using Codifico.StoreSample.Api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codifico.StoreSample.Api.Domain.Services;
using Codifico.StoreSample.Api.Application.Services;
using Codifico.StoreSample.Api.Application.Contracts;

namespace Codifico.StoreSample.Api.DI
{
    public class DependencyInjectionProfile
    {
        private readonly IConfiguration Configuration;
        public DependencyInjectionProfile(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<StoreSampleDBcontext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<EmployeesRepository>();
            services.AddTransient<ShippersRepository>();
            services.AddTransient<ProductsRepository>();
            services.AddTransient<OrdersRepository>();
            services.AddTransient<OrdersDetailRepository>();
            services.AddTransient<PredictedOrdersRepository>();

            services.AddTransient<EmployeesDomainService>();
            services.AddTransient<ShippersDomainService>();
            services.AddTransient<ProductsDomainService>();
            services.AddTransient<OrdersDomainService>();

            services.AddTransient<IEmployeesAppService, EmployeesAppService>();
            services.AddTransient<IShippersAppService, ShippersAppService>();
            services.AddTransient<IProductsAppService, ProductsAppService>();
            services.AddTransient<IOrdersAppService, OrdersAppService>();

        }
    }
}

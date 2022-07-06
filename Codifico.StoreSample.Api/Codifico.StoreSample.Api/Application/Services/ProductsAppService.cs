using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class ProductsAppService: IProductsAppService
    {
        private ProductsDomainService _productsDomainService;

        public ProductsAppService(ProductsDomainService productsDomainService)
        {
            _productsDomainService = productsDomainService;
        }

        public async Task<List<Products>> getAll()
        {
            try
            {
                var result = await _productsDomainService.getAll();
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

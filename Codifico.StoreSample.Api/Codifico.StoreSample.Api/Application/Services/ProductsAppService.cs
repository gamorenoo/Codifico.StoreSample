using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class ProductsAppService
    {
        private ProductsDomainService _productsDomainService;

        public ProductsAppService(ProductsDomainService productsDomainService)
        {
            _productsDomainService = productsDomainService;
        }

        public async Task<IEnumerable<Products>> getAll()
        {
            try
            {
                return await _productsDomainService.getAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

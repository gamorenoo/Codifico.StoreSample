using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Domain.Services
{
    public class ProductsDomainService
    {
        private ProductsRepository _productsRepository;

        public ProductsDomainService(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Products>> getAll()
        {
            return await _productsRepository.getAll();
        }
    }
}

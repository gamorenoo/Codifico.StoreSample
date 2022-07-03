using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Domain.Services
{
    public class ShippersDomainService
    {
        private ShippersRepository _shippersRepository;

        public ShippersDomainService(ShippersRepository shippersRepository)
        {
            _shippersRepository = shippersRepository;
        }

        public async Task<IEnumerable<Shippers>> getAll()
        {
            return await _shippersRepository.getAll();
        }
    }
}

using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class ShippersAppService
    {
        private ShippersDomainService _shippersDomainService;

        public ShippersAppService(ShippersDomainService shippersDomainService)
        {
            _shippersDomainService = shippersDomainService;
        }

        public async Task<IEnumerable<Shippers>> getAll()
        {
            try
            {
                return await _shippersDomainService.getAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

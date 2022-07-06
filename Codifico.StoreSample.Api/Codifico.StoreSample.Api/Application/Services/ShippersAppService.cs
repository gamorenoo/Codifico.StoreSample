using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class ShippersAppService : IShippersAppService
    {
        private ShippersDomainService _shippersDomainService;

        public ShippersAppService(ShippersDomainService shippersDomainService)
        {
            _shippersDomainService = shippersDomainService;
        }

        public async Task<List<Shippers>> getAll()
        {
            try
            {
                var result = await _shippersDomainService.getAll();
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

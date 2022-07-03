using Codifico.StoreSample.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class PredictedOrdersRepository
    {
        private StoreSampleDBcontext _context;
        public PredictedOrdersRepository(StoreSampleDBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PredictedOrders>> getAll()
        {
            return await Task.Run(() =>
            {
                return _context.PredictedOrders.FromSqlRaw("EXECUTE Sales.GetNextPredicatedOrder")
                .ToList();
            });

            // Para retornar la lista desde entity framework
            // return _context.Employees.ToList();
        }
    }
}

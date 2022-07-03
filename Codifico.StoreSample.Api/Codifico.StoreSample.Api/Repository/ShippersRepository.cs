using Codifico.StoreSample.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class ShippersRepository
    {
        private StoreSampleDBcontext _context;
        public ShippersRepository(StoreSampleDBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shippers>> getAll()
        {
            return await Task.Run(() =>
            {
                return _context.Shippers.FromSqlRaw("SELECT shipperid, companyname FROM Sales.Shippers")
                .ToList();
            });

            // Para retornar la lista desde entity framework
            // return _context.Shippers.ToList();
        }
    }
}

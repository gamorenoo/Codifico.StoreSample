using Codifico.StoreSample.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class ProductsRepository
    {
        private StoreSampleDBcontext _context;
        public ProductsRepository(StoreSampleDBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> getAll()
        {
            return await Task.Run(() =>
            {
                return _context.Products.FromSqlRaw("SELECT productid, productname FROM Production.Products")
                .ToList();
            });

            // Para retornar la lista desde entity framework
            // return _context.Products.ToList();
        }
    }
}

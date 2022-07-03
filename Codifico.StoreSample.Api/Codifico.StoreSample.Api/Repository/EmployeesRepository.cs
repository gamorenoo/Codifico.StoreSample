using Codifico.StoreSample.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Repository
{
    public class EmployeesRepository
    {
        private StoreSampleDBcontext _context;
        public EmployeesRepository(StoreSampleDBcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employees>> getAll() {
            return await Task.Run(() =>
            {
                return _context.Employees.FromSqlRaw("SELECT empid Empid, CONCAT (firstname,' ', lastname) FullName FROM HR.Employees")
                .ToList();
            });

            // Para retornar la lista desde entity framework
            // return _context.Employees.ToList();
        }
    }
}

using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Domain.Services
{   
    public class EmployeesDomainService
    {
        private EmployeesRepository _employeesRepository;

        public EmployeesDomainService(EmployeesRepository employeesRepository) {
            _employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<Employees>> getAll()
        {
            return await _employeesRepository.getAll();
        }
    }
}

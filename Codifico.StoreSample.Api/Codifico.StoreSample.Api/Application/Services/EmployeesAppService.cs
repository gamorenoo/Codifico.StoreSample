using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class EmployeesAppService
    {
        private EmployeesDomainService _employeesDomainService;

        public EmployeesAppService(EmployeesDomainService employeesDomainService)
        {
            _employeesDomainService = employeesDomainService;
        }

        public async Task<IEnumerable<Employees>> getAll()
        {
            try
            {
                return await _employeesDomainService.getAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

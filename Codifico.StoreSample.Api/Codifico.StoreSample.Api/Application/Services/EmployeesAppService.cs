using Codifico.StoreSample.Api.Application.Contracts;
using Codifico.StoreSample.Api.Domain.Entities;
using Codifico.StoreSample.Api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Services
{
    public class EmployeesAppService: IEmployeesAppService
    {
        private EmployeesDomainService _employeesDomainService;

        public EmployeesAppService(EmployeesDomainService employeesDomainService)
        {
            _employeesDomainService = employeesDomainService;
        }

        public async Task<List<Employees>> getAll()
        {
            try
            {
                var result = await _employeesDomainService.getAll();
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

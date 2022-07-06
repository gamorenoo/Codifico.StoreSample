using Codifico.StoreSample.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Application.Contracts
{
    public interface IShippersAppService
    {
        Task<List<Shippers>> getAll();
    }
}

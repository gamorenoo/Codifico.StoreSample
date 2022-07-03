using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Domain.Entities
{
    public class Products
    {
        [Key]
        public int Productid { get; set; }
        public string Productname { get; set; }
    }
}

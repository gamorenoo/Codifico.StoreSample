using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Codifico.StoreSample.Api.Domain.Entities
{
    public class Employees
    {
        [Key]
        [DataMember(Name = "empid")]
        public int Empid { get; set; }
        public string FullName { get; set; }
        //public string lastname { get; set; }
        //public string firstname { get; set; }
        //public string title { get; set; }
        //public string titleofcourtesy { get; set; }
        //public DateTime birthdate { get; set; }
        //public DateTime hiredate { get; set; }
        //public string address { get; set; }
        //public string city { get; set; }
        //public string region { get; set; }
        //public string postalcode { get; set; }
        //public string country { get; set; }
        //public string phone { get; set; }
        //public int? mgrid { get; set; }
    }
}

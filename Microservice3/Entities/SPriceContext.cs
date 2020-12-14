using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Entities
{
    public class SPriceContext
    {
        [Key]
        public int SPid { get; set; }

        [ForeignKey("Comp")]
        public int Ccode { get; set; }
       
        public string  SE { get; set; }
        public int price { get; set; }
        public DateTime Tstamp { get; set; }

        public CompanyContext Comp { get; set; }
    }
}

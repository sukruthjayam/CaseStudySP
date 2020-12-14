using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Entities
{
    public class SectorContext
    {
       
        [Key]
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string brief { get; set; }
    }
}

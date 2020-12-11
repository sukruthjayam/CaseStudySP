using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class CContext
    { 
        [Key]
        public int cid { get; set; }
        public string cname { get; set; }
        public string ceo { get; set; }
        public string listed { get; set; }
        public string desc { get; set; }
    }
}

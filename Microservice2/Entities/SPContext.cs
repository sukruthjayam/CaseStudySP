using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class SPContext
    {
        [Key]
        public int SPid { get; set; }

        [ForeignKey("Comp")]
        public int Ccode { get; set; }
        public string  SE { get; set; }
        public int price { get; set; }
        public DateTime Tstamp { get; set; }

        public CContext Comp { get; set; }
    }
}

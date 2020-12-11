using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Entities
{
    public class SEContext
    {
        [Key]
        public int sid { get; set; }
        [Required]
        public string name { get; set; }
        public string brief { get; set; }
        public string address { get; set; }
        public string remarks { get; set; }
        public IList<CContext> Company { get; set; }
    }
}

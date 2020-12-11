using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Entities
{
    public class UContext
    {
        
        [Key]
        public int ID { get; set; }
        public string Uname { get; set; }
        public string password { get; set; }
        public string  usertype { get; set; }
        public string email { get;set;  }

        public double pnumber { get; set; }

        public string confirmed { get; set; }
    }
}

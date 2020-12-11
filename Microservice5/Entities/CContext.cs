using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Entities
{
    public class CContext
    {

        [Key]
        public int cid { get; set; }
        public string name { get; set; }
        public IList<SEContext> StockExchange { get; set; }
    }
}

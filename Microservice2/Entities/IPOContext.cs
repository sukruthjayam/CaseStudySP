using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class IPOContext
    {
        [Key]
        public int Iid { get; set; }
        public string Cname { get; set; }
        public string StockExchage { get; set; }
        public string  price_per_share { get; set; }
        public int Total_shares { get; set; }
        public DateTime open_time { get; set; }
    }
}

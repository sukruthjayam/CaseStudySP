using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Entities
{
    public class CompanyContext
    {
        [Key]
        public int Cid { get; set; }
        [ForeignKey("sector")]
        public int Sectorid { get; set; }
        public string Sname { get; set; }
        public SectorContext sector { get; set; }
    }
}

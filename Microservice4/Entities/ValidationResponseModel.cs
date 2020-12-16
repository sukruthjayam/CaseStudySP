using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M4Login.Entities
{
    public class ValidationResponseModel
    {
        public string username { get; set; }
        public string usertype { get; set; }
        public string JWT { get; set; }
    }
}

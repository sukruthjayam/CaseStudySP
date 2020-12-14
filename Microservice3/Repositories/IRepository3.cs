using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Repositories
{
    public interface IRepository3
    {
        //getList
        //getSectorPrice 
        public IEnumerable<CompanyContext> getList(string Sname);
        public IEnumerable<SPriceContext> getSectorPrice(string Sname);
    }
}

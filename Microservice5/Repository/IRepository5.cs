using Microservice5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Repository
{
    public interface IRepository5
    {
        public IEnumerable<SEContext> getStockExchangesList();
        public bool addStockExchange(SEContext se);
        public IEnumerable<CContext> GetCompaniesList(string Sname);
        public IEnumerable<CContext> GetCompaniesStock(string Sname);
    }
}

using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Repository
{
    public class Repository2 : IRepository2
    {
        DBContext ctx;
        public Repository2(DBContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<CContext> getCompanyDetails()
        {
            IEnumerable<CContext> ls = from item in ctx.CContexts
                     select item;
            return ls.ToList();
        }

        public IEnumerable<IPOContext> getCompanyIPODetails(string Coname)
        {
           var ls = from item in ctx.IPOContexts
                            where item.Cname == Coname
                            select item;
            return ls;
        }

        public SPContext getCompanyStockPrice(int cid,DateTime dt)
        {
            var new_list = (from p in ctx.SPContexts
                           join c in ctx.CContexts on p.Ccode equals cid
                           where p.Tstamp==dt
                           select p).FirstOrDefault();
            return new_list;
        }

        public IEnumerable<CContext> getMatchingCompanies(string Cpattern)
        {
            var ls = ctx.CContexts.Where(x => x.cname.StartsWith(Cpattern)
                                         || x.cname.Contains(Cpattern)
                                         || x.cname.Contains(Cpattern));                                                                   
            return ls;
        }
    }
}

using Microservice5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Repository
{
    public class Repository5:IRepository5
    {
        private DBContext ctx;
        public Repository5(DBContext ctx)
        {
            this.ctx = ctx;
        }
        public bool addStockExchange(SEContext se)
        {
            ctx.SEContexts.Add(se);
            int b = ctx.SaveChanges();
            return b > 0;
        }

        public IEnumerable<CContext> GetCompaniesList(String Sname)
        {
            var id = (from var1 in ctx.SEContexts
                      where var1.name == Sname
                      select var1.sid).First();
            var query = from article in ctx.CContexts
                        where article.StockExchange.Any(c => c.sid == id)
                        select article;
            return query;
        }

        public IEnumerable<SEContext> getStockExchangesList()
        {
            var ls = from obj in ctx.SEContexts
                     orderby obj.name
                     select obj;
            return ls.ToList();
        }

        public IEnumerable<CContext> GetCompaniesStock(String Sname)
        {
           var id = (from var1 in ctx.SEContexts
                     where var1.name==Sname
                     select var1.sid).First();
           var query = from article in ctx.CContexts
                        where article.StockExchange.Any(c => c.sid == id)
                        select article;
            return query;
        }
    }
}

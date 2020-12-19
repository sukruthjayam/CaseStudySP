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

        public CContext getCompanyDetailsByID(int cid)
        {
            CContext ls = ctx.CContexts.Find(cid);
            if (ls == null) {
                return null;
            }
            return ls;
        }

        public CContext UpdateCompany(CContext comp)
        {
            CContext UC = ctx.CContexts.Find(comp.cid);
            UC.cname = comp.cname;
            UC.desc = comp.desc;
            UC.ceo = comp.ceo;
            UC.listed = comp.listed;
            ctx.CContexts.Update(UC);
            ctx.SaveChanges();
            return UC;
        }

        public string addCompany(CContext c)
        {
            ctx.CContexts.Add(c);
            ctx.SaveChanges();
            return "added successfully";
        }

        public string delCompanyDetails(int cid)
        {
            CContext ls = ctx.CContexts.Find(cid);
            if (ls == null)
            {
                return null;
            }
           ctx.CContexts.Remove(ls);
            ctx.SaveChanges();
            return "Company Successfully Deleted";
        }
        public IPOContext getCompanyIPODetails(string Coname)
        {
           var ls = (from item in ctx.IPOContexts
                            where item.Cname == Coname
                            select item).FirstOrDefault();
            if (ls == null) {
                return null;
            }
            return ls;
        }

        public string UpdateIPO(IPOContext nipo)
        {
            IPOContext oipo = ctx.IPOContexts.Find(nipo.Iid);
            oipo.Iid = nipo.Iid;
            oipo.Cname = nipo.Cname;
            oipo.StockExchage = nipo.StockExchage;
            oipo.open_time = nipo.open_time;
            oipo.price_per_share = nipo.price_per_share;
            oipo.Total_shares = nipo.Total_shares;
            ctx.IPOContexts.Update(oipo);
            ctx.SaveChanges();
            return "update successful";
        }

        public IEnumerable<SPContext> getCompanyStockPrice(int cid,DateTime fm,DateTime to)
        {
            //var new_list = (from p in ctx.SPContexts
            //                join c in ctx.CContexts on p.Ccode equals cid
            //                where p.Tstamp == dt
            //                select p).FirstOrDefault();
            //return new_list;

            List<SPContext> splist = new List<SPContext>() { };
            IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
            {
                for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                    yield return day;
            }
            //int TSP = 0;
            //int d = 0;
            foreach (DateTime day in EachDay(fm, to))
            {
                var sp = (from p in ctx.SPContexts
                          join c in ctx.CContexts on p.Ccode equals cid
                          where p.Tstamp.Date == day.Date
                          select p).FirstOrDefault();

                splist.Add(sp);
                //if (SP != 0)
                //{
                //    d += 1;
                //}
                //TSP = TSP + SP;
            }

            return splist;


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

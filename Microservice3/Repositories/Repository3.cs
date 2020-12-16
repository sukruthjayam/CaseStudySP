using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Entities;
using Microservice3.Repositories;
namespace Microservice3.Repositories
{
    public class Repository3 : IRepository3
    {
        private DBContext ctx;
        public Repository3(DBContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<CompanyContext> getList(string Sname)
        {
            var Secid = (from item in ctx.SecContexts
                           where item.Sname == Sname
                           select item.Sid).FirstOrDefault();
          

            var CompList = (from com in ctx.CompContexts
                            join  sec in ctx.SecContexts on com.Sectorid equals Secid
                            select com).Distinct();
            

            return CompList.ToList();
        }

        public IEnumerable<SPriceContext> getSectorPrice(string Sname)
        {

            List<SPriceContext> comp_list = new List<SPriceContext>() { };

            int Secid = (from item in ctx.SecContexts
                         where item.Sname == Sname
                         select item.Sid).FirstOrDefault();


            var CompIDList = (from com in ctx.CompContexts
                              join sec in ctx.SecContexts on com.Sectorid equals Secid
                              select com.Cid).Distinct();

            foreach (var item in CompIDList)
            {
                var data = (from p in ctx.SpriceContexts
                            join c in ctx.CompContexts on p.Ccode equals item
                            select p).FirstOrDefault();

                comp_list.Add(data);
            }


            return comp_list.ToList();
        }
    }
}

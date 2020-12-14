using Microservice4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Repositories
{
    public class Repository4 : IRepository4
    {
        private DBContext ctx;
        public Repository4(DBContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Login(string uname, string upass)
        {
            var ls = ctx.UserContexts
                   .Where(x =>x.Uname == uname && x.password==upass);
            return (int)ls.Count() > 0;
        }

        public bool UserSignup(UContext obj)
        {
            ctx.UserContexts.Add(obj);
            int b = ctx.SaveChanges();
            return b > 0;
        }
    }
}

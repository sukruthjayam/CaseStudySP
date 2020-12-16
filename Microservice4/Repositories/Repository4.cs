using M4Login.Entities;
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
        public ValidationResponseModel Login(string uname, string upass)
        {
            ValidationResponseModel vm;
            var name = ctx.UserContexts
                   .Where(x => x.Uname == uname && x.password == upass)
                   ;

            if (name.Count() == 0) {
                return null;
            }

            if (uname == "admin")
            {
                vm = new ValidationResponseModel() { username =uname, usertype = "admin" };
            }
            else {
                vm = new ValidationResponseModel() { username = uname, usertype = "customer" };
            }

            return vm;
        }

        public bool UserSignup(UContext obj)
        {
            ctx.UserContexts.Add(obj);
            int b = ctx.SaveChanges();
            return b > 0;
        }
    }
}

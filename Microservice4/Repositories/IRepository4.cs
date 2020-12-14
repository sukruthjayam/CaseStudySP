using Microservice4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Repositories
{
    public interface IRepository4
    {


        public bool Login(string name, string pass);



        public bool UserSignup(UContext obj);


    }
}

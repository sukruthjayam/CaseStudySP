using M4Login.Entities;
using Microservice4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Repositories
{
    public interface IRepository4
    {


        public ValidationResponseModel Login(string name, string pass);

        public string UpdateProfile(UContext us);
        public UContext getUser(int id);
        public bool UserSignup(UContext obj);


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Entities;
namespace Microservice2.Repository
{
    public interface IRepository2
    {
        // getCompanyStockPrice 
        //getMatchingCompanies 
        //getCompanyDetails 
        //getCompanyIPODetails
        public float getCompanyStockPrice(int cid,DateTime fm,DateTime to);
        public IEnumerable<CContext> getCompanyDetails();
        public IEnumerable<IPOContext> getCompanyIPODetails(string Cname);
        public IEnumerable<CContext> getMatchingCompanies(string Cpattern);

    }
}

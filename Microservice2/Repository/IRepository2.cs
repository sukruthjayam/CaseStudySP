using System;
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
        public IEnumerable<SPContext> getCompanyStockPrice(int cid,DateTime fm,DateTime to);
        public IEnumerable<CContext> getCompanyDetails();
        public CContext getCompanyDetailsByID(int cid);
        public string delCompanyDetails(int cid);
        public string addCompany(CContext c);
        public IPOContext getCompanyIPODetails(string Cname);
        public string UpdateIPO(IPOContext ipo);
        public IEnumerable<CContext> getMatchingCompanies(string Cpattern);
        public CContext UpdateCompany(CContext com);
    }
}

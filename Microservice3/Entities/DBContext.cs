using Microservice3.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Entities
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<SectorContext> SecContexts { get; set; }
        public DbSet<CompanyContext> CompContexts { get; set; }
        public DbSet<SPriceContext> SpriceContexts { get; set; }
    }
}

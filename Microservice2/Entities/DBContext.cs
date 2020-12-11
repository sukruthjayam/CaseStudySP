using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<CContext> CContexts { get; set; }
        public DbSet<SPContext> SPContexts { get; set; }
        public DbSet<IPOContext> IPOContexts { get; set; }
    }
}

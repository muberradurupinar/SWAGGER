using Microsoft.EntityFrameworkCore;
using SWAGGERAPI1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAGGERAPI1.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Urun> Urun { get; set; }

    }
}

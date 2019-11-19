using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class GSSContext : DbContext
    {
        public GSSContext(DbContextOptions<GSSContext> options) : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}

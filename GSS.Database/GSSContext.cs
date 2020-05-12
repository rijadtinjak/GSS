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
        public virtual DbSet<Consensus> Consensus { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Search> Searches { get; set; }
        public virtual DbSet<SearchBackup> SearchBackups { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<SegmentPoint> SegmentPoints { get; set; }
        public virtual DbSet<SegmentSearchHistory> SegmentSearchHistory { get; set; }
        public virtual DbSet<SortedSegmentArchiveEntry> SortedSegmentArchiveEntry { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GSS.Database
{
    public class Search
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateReportedMissing { get; set; }
        public string Comment { get; set; }

        [Column(TypeName = "decimal(8,6)")]
        public decimal Lat { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Lng { get; set; }
        public bool Active { get; set; }
        
        public List<Zone> Zones { get; set; }
        [NotMapped]
        public List<List<SortedSegmentArchiveEntry>> SortedSegmentsArchive { get; set; }
        public List<POSCumulativeArchiveEntry> POSCumulativeArchive { get; set; } = new List<POSCumulativeArchiveEntry>();
        [NotMapped]
        public List<Segment> SegmentsUnassigned { get; set; } = new List<Segment>();
        public List<Person> MissingPeople { get; set; } = new List<Person>();
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GSS.Model
{
    [Serializable]
    public class Search
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

        public List<Zone> Zones { get; set; }
        public List<Manager> Managers { get; set; }
        public List<List<SortedSegmentArchiveEntry>> SortedSegmentsArchive { get; set; }
        public List<double> POSCumulativeArchive { get; set; } = new List<double>();
        public List<Segment> SegmentsUnassigned { get; set; } = new List<Segment>();

        [JsonIgnore]
        [IgnoreDataMember]
        public double SumOfAllConsensus { get => Zones != null ? Zones.Sum(x => x.SumofConsensus) : 0; }
        [JsonIgnore]
        [IgnoreDataMember]
        public bool Closed { get => DateClosed.HasValue; }
    }
}

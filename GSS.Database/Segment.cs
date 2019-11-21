using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Database
{
   public class Segment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public Zone Zone { get; set; }
        public int? ZoneId { get; set; }
        public int NoOfSearches { get => SegmentHistory.Count - 1; }

        public List<SegmentSearchHistory> SegmentHistory { get; set; } = new List<SegmentSearchHistory>();
    }
}

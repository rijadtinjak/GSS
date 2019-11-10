using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Model
{
   public class Segment
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public Zone Zone { get; set; }

        public List<SegmentSearchHistory> SegmentHistory { get; set; } = new List<SegmentSearchHistory>();
    }
}

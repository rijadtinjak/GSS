using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Model
{
    [Serializable]
    public class Segment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Zone Zone { get; set; }
        public int? ZoneId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int NoOfSearches { get => SegmentHistory.Count - 1; }

        public List<SegmentSearchHistory> SegmentHistory { get; set; } = new List<SegmentSearchHistory>();
        public bool IsChecked { get; set; }
    }
}

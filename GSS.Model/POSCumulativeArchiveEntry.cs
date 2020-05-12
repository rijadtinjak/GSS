using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSS.Model
{
    [Serializable]
    public class POSCumulativeArchiveEntry
    {
        public int Id { get; set; }
        public double Value { get; set; }
        [JsonIgnore]
        public Search Search { get; set; }
        public int SearchId { get; set; }
    }
}

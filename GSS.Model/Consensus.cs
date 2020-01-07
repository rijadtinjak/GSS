using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GSS.Model
{
    [Serializable]
    public class Consensus
    {
        public int Id { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }

        public double Value { get; set; }

        public string ZoneName => Zone?.Name;
        public string ManagerName => Manager?.Name;
    }
}

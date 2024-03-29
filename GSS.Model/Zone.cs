﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Model
{
    [Serializable]
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Pden { get; set; }
        public double PoA { get; set; }
        public List<Consensus> Consensus { get; set; } = new List<Consensus>();
        public List<Segment> Segments{ get; set; } = new List<Segment>();

        [JsonIgnore]
        [IgnoreDataMember]
        public double SumofConsensus=0;
    }
}

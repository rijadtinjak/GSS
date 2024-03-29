﻿using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace GSS.Model
{
    [Serializable]
    public class SegmentSearchHistory
    {
        public int Id { get; set; }
        public double Pden { get; set; }
        public double PoA { get; set; }
        public double Coverage { get; set; }
        public double PoD { get; set; }
        public double PoDCumulative { get; set; }
        public double PoS { get; set; }
        public double PoSCumulative { get; set; }
        public double DeltaPoS { get; set; }

        // Active attributes
        public int NoOfSearchers { get; set; }
        public double TrackLength { get; set; }
        public double SweepWidth { get; set; }
        public TypeOfSearcher TypeOfSearcher { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Segment Segment { get; set; }
        public int SegmentId { get; set; }
    }

    [Serializable]
    public enum TypeOfSearcher
    {
        Human, Drone, Dog
    }
}
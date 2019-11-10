using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Model
{
    public class Zone
    {
        public string Name { get; set; }
        public double Area{ get; set; }
        public double Pden { get; set; }
        public double PoA { get; set; }
        public Dictionary<Manager,double> Consensus { get; set; }
        public double SumofConsensus=0;
        public List<Segment> Segments{ get; set; } = new List<Segment>();
    }
}

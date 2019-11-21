using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Database
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area{ get; set; }
        public double Pden { get; set; }
        public double PoA { get; set; }
        public List<Consensus> Consensus { get; set; }
        public List<Segment> Segments{ get; set; } = new List<Segment>();

        public Search Search { get; set; }
        public int SearchId { get; set; }
    }
}

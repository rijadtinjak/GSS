using System;
using System.Collections.Generic;
using System.Text;

namespace GSS.Database
{
    public class Consensus
    {
        public int Id { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }

        public double Value { get; set; }
    }
}

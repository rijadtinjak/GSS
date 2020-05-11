﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GSS.Database
{
    public class POSCumulativeArchiveEntry
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public Search Search { get; set; }
        public int SearchId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GSS.Database
{
    public class SegmentPoint
    {
        public int Id { get; set; }
        public Segment Segment { get; set; }
        public int SegmentId { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Lat { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Lng { get; set; }
    }
}

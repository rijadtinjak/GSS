using System;

namespace GSS.Database
{
    public class SortedSegmentArchiveEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PoA { get; set; }
        public Search Search { get; set; }
        public int SearchId { get; set; }
    }
}
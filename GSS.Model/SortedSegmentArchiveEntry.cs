using System;

namespace GSS.Model
{
    [Serializable]
    public class SortedSegmentArchiveEntry
    {
        public string Name { get; set; }
        public double PoA { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
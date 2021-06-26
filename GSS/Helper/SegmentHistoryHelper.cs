using GSS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.Helper
{
    public static class SegmentHistoryHelper
    {
        public static SegmentSearchHistory GetFirstSearchValues(Segment segment)
        {
            var prev = segment.SegmentHistory.Last();
            var first_search = segment.SegmentHistory[1];
            var seghis = new SegmentSearchHistory
            {
                TypeOfSearcher = first_search.TypeOfSearcher,
                NoOfSearchers = first_search.NoOfSearchers
            };

            seghis.TrackLength = first_search.TrackLength;
            seghis.SweepWidth = first_search.SweepWidth;

            if (segment.Area != 0)
                seghis.Coverage = seghis.NoOfSearchers * seghis.TrackLength * seghis.SweepWidth / segment.Area;

            if (seghis.Coverage > 0)
            {
                seghis.PoD = 1 - Math.Exp(-seghis.Coverage);
            }
            else
                seghis.PoD = 0;

            seghis.PoS = prev.PoA * seghis.PoD;
            seghis.PoSCumulative = prev.PoSCumulative + seghis.PoS;
            seghis.PoDCumulative = (prev.PoDCumulative + seghis.PoD);
            return seghis;
        }
    }
}

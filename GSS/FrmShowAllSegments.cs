using GSS.Model;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS
{
    public partial class FrmShowAllSegments : MaterialForm
    {
        private List<Segment> sortedSegments;

        public FrmShowAllSegments(List<Segment> sortedSegments, int x, int y, int height)
        {
            InitializeComponent();
            this.Location = new Point(x - 220, y);
            this.Height = height;
            this.sortedSegments = sortedSegments;
        }

        private void FrmShowAllSegments_Load(object sender, EventArgs e)
        {
            RefreshSortedSegments();
        }

        private void RefreshSortedSegments()
        {
            for (int i = 0; i < sortedSegments.Count; i++)
            {
                Segment segment = sortedSegments[i];

                tlpSortedSegments.RowCount++;
                tlpSortedSegments.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
                tlpSortedSegments.Height += 18;

                for (int col = 0; col < 3; col++)
                {
                    tlpSortedSegments.Controls.Add(new Label
                    {
                        AutoSize = true,
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        Location = new System.Drawing.Point(4, 1),
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    }, col, i + 1);
                }

                tlpSortedSegments.GetControlFromPosition(0, i + 1).Text = segment.ShortName;
                tlpSortedSegments.GetControlFromPosition(1, i + 1).Text = Math.Round(segment.SegmentHistory[segment.NoOfSearches].Pden, 3).ToString();
                tlpSortedSegments.GetControlFromPosition(2, i + 1).Text = Math.Round(GetFirstSearchPoSCum(segment), 3).ToString("0.000");
            }
        }

        private double GetFirstSearchPoSCum(Segment segment)
        {
            if (segment.NoOfSearches == 0)
                return 0;

            var prev = segment.SegmentHistory.Last();
            var first_search = segment.SegmentHistory[1];
            var seghis = new SegmentSearchHistory
            {
                TypeOfSearcher = first_search.TypeOfSearcher,
                NoOfSearchers = first_search.NoOfSearchers
            };
            if (seghis.TypeOfSearcher == TypeOfSearcher.Dog)
            {
                seghis.PoD = 0.9;
            }
            else
            {
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
            }

            seghis.PoS = prev.PoA * seghis.PoD;
            seghis.PoSCumulative = prev.PoSCumulative + seghis.PoS;

            return seghis.PoSCumulative;
        }

    }
}

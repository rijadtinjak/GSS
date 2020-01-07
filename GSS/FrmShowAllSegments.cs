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
            this.Location = new Point(x-220, y);
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
                if (i != 0)
                {
                    tlpSortedSegments.RowCount++;
                    tlpSortedSegments.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
                    tlpSortedSegments.Height += 19;

                    for (int col = 0; col < 3; col++)
                    {
                        tlpSortedSegments.Controls.Add(new Label
                        {
                            AutoSize = true,
                            Dock = System.Windows.Forms.DockStyle.Fill,
                            Location = new System.Drawing.Point(4, 1),
                            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        }, col, i);
                    }
                }

                tlpSortedSegments.GetControlFromPosition(0, i).Text = segment.Name;
                tlpSortedSegments.GetControlFromPosition(1, i).Text = Math.Round(segment.SegmentHistory[segment.NoOfSearches].PoA, 3).ToString();
            }
        }
    }
}

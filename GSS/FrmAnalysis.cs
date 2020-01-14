using GSS.Helper;
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
using System.Xml;

namespace GSS
{
    public partial class FrmAnalysis : MaterialForm
    {
        private Search Search;
        private List<Zone> Zones = new List<Zone>();
        private List<Manager> managers;
        private List<Segment> sortedSegments = new List<Segment>();

        private Segment SelectedSegment;

        public FrmAnalysis(Search search)
        {
            InitializeComponent();
            this.Search = search;
            this.Zones = search.Zones;
            this.managers = search.Managers;

            this.Text += " of " + Search.Name;

            if (Search.Closed)
            {
                btnApply.Enabled = false;
                btnFinish.Visible = false;
                txtNoSearchers.Enabled = txtSweepWidth.Enabled = txtTrackLength.Enabled = cbSearcher.Enabled = false;
            }
        }

        private void RefreshSegmentComboBox()
        {
            List<Segment> segments = new List<Segment>();
            foreach (Zone zone in Zones)
            {
                foreach (Segment segment in zone.Segments)
                {
                    segments.Add(segment);
                }
            }

            cbSegment.DataSource = segments;
            cbSegment.DisplayMember = "Name";
        }

        private void RefreshSortedSegments()
        {
            sortedSegments.Clear();
            foreach (Zone zone in Zones)
            {
                foreach (Segment segment in zone.Segments)
                {
                    sortedSegments.Add(segment);
                }
            }
            if (sortedSegments.Count == 0)
                return;

            sortedSegments = sortedSegments.OrderByDescending(x => x.SegmentHistory[x.NoOfSearches].PoA).ToList();

            for (int i = 0; i < Math.Min(tlpSortedSegments.RowCount, sortedSegments.Count); i++)
            {
                Segment segment = sortedSegments[i];

                CheckBox checkBox = tlpSortedSegments.GetControlFromPosition(0, i) as CheckBox;
                if (Search.Closed)
                {
                    checkBox.Enabled = false;
                }
                else
                {
                    checkBox.Checked = segment.IsChecked;
                    RefreshSortedSegmentRow(checkBox);
                    checkBox.CheckedChanged -= FrmAnalysis_CheckedChanged;
                    checkBox.CheckedChanged += FrmAnalysis_CheckedChanged;
                }

                tlpSortedSegments.GetControlFromPosition(1, i).Text = segment.Name;
                tlpSortedSegments.GetControlFromPosition(2, i).Text = Math.Round(segment.SegmentHistory[segment.NoOfSearches].PoA, 3).ToString();
                tlpSortedSegments.GetControlFromPosition(3, i).Text = Math.Round(GetFirstSearchPoSCum(segment), 3).ToString("0.000");
            }
        }

        private void ArchiveSortedSegments()
        {
            List<SortedSegmentArchiveEntry> sortedSegmentsHistory = new List<SortedSegmentArchiveEntry>();
            foreach (var segment in sortedSegments)
            {
                sortedSegmentsHistory.Add(new SortedSegmentArchiveEntry
                {
                    Name = segment.Name,
                    PoA = Math.Round(segment.SegmentHistory[segment.NoOfSearches].PoA, 3)
                });
            }

            if (Search.SortedSegmentsArchive is null)
                Search.SortedSegmentsArchive = new List<List<SortedSegmentArchiveEntry>>();

            Search.SortedSegmentsArchive.Add(sortedSegmentsHistory);
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

        private void FrmAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSortedSegmentRow(sender);
        }

        private void RefreshSortedSegmentRow(object control)
        {
            if (control is CheckBox checkBox)
            {
                var position = tlpSortedSegments.GetPositionFromControl(checkBox);
                if (position != null)
                {
                    Segment segment = sortedSegments[position.Row];

                    for (int i = 0; i < 4; i++)
                    {
                        if (checkBox.Checked)
                        {
                            tlpSortedSegments.GetControlFromPosition(i, position.Row).BackColor = SystemColors.Info;
                            segment.IsChecked = true;
                        }
                        else
                        {
                            tlpSortedSegments.GetControlFromPosition(i, position.Row).BackColor = Color.GhostWhite;
                            segment.IsChecked = false;
                        }
                    }
                }
            }
        }

        private void CbSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSegment = cbSegment.SelectedItem as Segment;
            if (SelectedSegment == null)
                return;

            RefreshTypeOfSearcherComboBox();
            RefreshHistoryTabs();
            tabControl1.SelectedIndex = SelectedSegment.SegmentHistory.Count - 1;
        }

        private void RefreshHistoryTabs()
        {
            tabControl1.Visible = true;
            tabControl1.TabPages.Clear();

            for (int i = 0; i < SelectedSegment.SegmentHistory.Count; i++)
            {
                if (i == 0)
                    tabControl1.TabPages.Add("Initial");
                else
                    tabControl1.TabPages.Add("Search " + i);

                SegmentHistory segHistory = new SegmentHistory();
                TableLayoutPanel tlp = segHistory.Controls["tableLayoutPanel1"] as TableLayoutPanel;
                SegmentSearchHistory history = SelectedSegment.SegmentHistory[i];
                tlp.Controls["lblSegmentName"].Text = SelectedSegment.Name;
                tlp.Controls["SegmentArea"].Text = SelectedSegment.Area.ToString();
                tlp.Controls["SegmentPden1"].Text = Math.Round(history.Pden, 3).ToString();
                tlp.Controls["SegmentPoA1"].Text = Math.Round(history.PoA, 3).ToString();
                tlp.Controls["SegmentNoOfSearchers"].Text = history.NoOfSearchers.ToString();
                if (i != 0)
                    tlp.Controls["SegmentTypeOfSearcher"].Text = history.TypeOfSearcher.ToString();
                else
                    tlp.Controls["SegmentTypeOfSearcher"].Text = "";
                tlp.Controls["SegmentTrackLength"].Text = Math.Round(history.TrackLength, 3).ToString();
                tlp.Controls["SegmentSweepWidth"].Text = Math.Round(history.SweepWidth, 3).ToString();
                tlp.Controls["SegmentCoverage"].Text = Math.Round(history.Coverage, 3).ToString();
                tlp.Controls["SegmentPod1"].Text = Math.Round(history.PoD, 3).ToString();
                tlp.Controls["SegmentPodCum"].Text = Math.Round(history.PoDCumulative, 3).ToString();
                tlp.Controls["SegmentPos1"].Text = Math.Round(history.PoS, 3).ToString();
                tlp.Controls["SegmentPosCum"].Text = Math.Round(history.PoSCumulative, 3).ToString();
                if (i > 1)
                {
                    tlp.Controls["SegmentDeltaPos"].Text = Math.Round(history.DeltaPoS, 3).ToString();
                    tlp.Controls["SegmentDeltaPos"].Visible = true;
                    tlp.Controls["lblDeltaPoS"].Text = "ΔPoS";
                }
                else
                {
                    tlp.Controls["SegmentDeltaPos"].Visible = false;
                    tlp.Controls["lblDeltaPoS"].Text = "";
                }
                tlp.Controls["lblPden"].Text = tlp.Controls["lblPden"].Text.Replace("1", i.ToString());
                tlp.Controls["lblPoA"].Text = tlp.Controls["lblPoA"].Text.Replace("1", i.ToString());
                tlp.Controls["lblPoS"].Text = tlp.Controls["lblPoS"].Text.Replace("1", i.ToString());
                tlp.Controls["lblPoScum"].Text = tlp.Controls["lblPoScum"].Text.Replace("1", i.ToString());
                tlp.Controls["lblPoD"].Text = tlp.Controls["lblPoD"].Text.Replace("1", i.ToString());
                tlp.Controls["lblPoDcum"].Text = tlp.Controls["lblPoDcum"].Text.Replace("1", i.ToString());

                tabControl1.TabPages[i].Controls.Add(segHistory);
            }
        }

        private void RefreshTypeOfSearcherComboBox()
        {
            List<TypeOfSearcher> list = new List<TypeOfSearcher>();
            foreach (TypeOfSearcher item in Enum.GetValues(typeof(TypeOfSearcher)))
            {
                list.Add(item);
            }
            cbSearcher.DataSource = list;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (SelectedSegment == null)
            {
                MessageBox.Show("No segment selected");
                return;
            }
            if (!ValidateChildren())
                return;

            var prev = SelectedSegment.SegmentHistory.Last();
            var seghis = new SegmentSearchHistory
            {
                TypeOfSearcher = (TypeOfSearcher)cbSearcher.SelectedItem,
                NoOfSearchers = int.Parse(txtNoSearchers.Text)
            };
            if (seghis.TypeOfSearcher == TypeOfSearcher.Dog)
            {
                seghis.PoD = 0.9;
            }
            else
            {
                seghis.TrackLength = double.Parse(txtTrackLength.Text);
                seghis.SweepWidth = double.Parse(txtSweepWidth.Text);

                if (SelectedSegment.Area != 0)
                    seghis.Coverage = seghis.NoOfSearchers * seghis.TrackLength * seghis.SweepWidth / SelectedSegment.Area;

                if (seghis.Coverage > 0)
                {
                    seghis.PoD = 1 - Math.Exp(-seghis.Coverage);
                }
                else
                    seghis.PoD = 0;
            }

            seghis.PoS = prev.PoA * seghis.PoD;
            seghis.PoSCumulative = prev.PoSCumulative + seghis.PoS;



            if (SelectedSegment.SegmentHistory.First().PoA != 0)
                seghis.PoDCumulative = seghis.PoSCumulative / SelectedSegment.SegmentHistory.First().PoA;
            seghis.PoA = prev.PoA - seghis.PoS;
            if (SelectedSegment.Area != 0)
                seghis.Pden = seghis.PoA / SelectedSegment.Area;
            if (SelectedSegment.SegmentHistory.Count >= 2)
                seghis.DeltaPoS = seghis.PoS - prev.PoS;
            else
                seghis.DeltaPoS = 0;
            SelectedSegment.SegmentHistory.Add(seghis);
            RefreshHistoryTabs();
            txtNoSearchers.Text = "";
            txtSweepWidth.Text = "";
            txtTrackLength.Text = "";
            cbSearcher.SelectedIndex = 0;
            tabControl1.SelectedIndex = SelectedSegment.SegmentHistory.Count - 1;

            foreach (var segment in sortedSegments)
            {
                if (SelectedSegment == segment)
                {
                    segment.IsChecked = false;
                }
            }

            RefreshSortedSegments();
            ArchiveSortedSegments();

            ArchivePoSCumulative(seghis.PoS);

            UpdateSuccessOfSearch();


            Search.SaveToFile();
        }

        private void ArchivePoSCumulative(double PoS)
        {
            if (Search.POSCumulativeArchive.Count == 0)
                Search.POSCumulativeArchive.Add(PoS);
            else
                Search.POSCumulativeArchive.Add(Search.POSCumulativeArchive.Last() + PoS);
        }

        private void UpdateSuccessOfSearch()
        {
            if (Search.POSCumulativeArchive is null)
                Search.POSCumulativeArchive = new List<double>();

            if (Search.POSCumulativeArchive.Count == 0)
                return;

            double Sum_PoA = sortedSegments.Sum(x => x.SegmentHistory[0].PoA);
            double TotalPosCum = Search.POSCumulativeArchive.Last();

            double SuccessPercentage = TotalPosCum / Sum_PoA * 100;
            lblTotalPosCum.Text = SuccessPercentage.ToString("0.00") + "%";
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            var frm = new FrmShowAllSegments(sortedSegments, this.Location.X + this.Width - 4, this.Location.Y, this.Height);
            frm.ShowDialog();
        }

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            RefreshSortedSegments();
            RefreshSegmentComboBox();
            UpdateSuccessOfSearch();
        }

        private void TxtTrackLength_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Enabled && (!double.TryParse(box.Text, out double val) || !(val > 0)))
            {
                box.BackColor = Color.IndianRed;
                box.Text = "";
                e.Cancel = true;
            }
            else
                box.BackColor = Color.White;
        }

        private void TxtSweepWidth_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Enabled && (!double.TryParse(box.Text, out double val) || !(val > 0)))
            {
                box.BackColor = Color.IndianRed;
                box.Text = "";
                e.Cancel = true;
            }
            else
                box.BackColor = Color.White;

        }

        private void TxtNoSearchers_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Enabled && (!int.TryParse(box.Text, out int val) || !(val > 0)))
            {
                box.BackColor = Color.IndianRed;
                box.Text = "";
                e.Cancel = true;
            }
            else
                box.BackColor = Color.White;

        }

        private void CbSearcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Search.Closed)
                return;

            ComboBox cbx = sender as ComboBox;
            if ((TypeOfSearcher)cbx.SelectedItem == TypeOfSearcher.Dog)
            {
                txtNoSearchers.Text = "1";
                txtNoSearchers.Enabled = false;
                txtSweepWidth.Enabled = false;
                txtTrackLength.Enabled = false;

                txtNoSearchers.Validate();
                txtSweepWidth.Validate();
                txtTrackLength.Validate();
            }
            else
            {
                txtNoSearchers.Text = "";
                txtNoSearchers.Enabled = true;
                txtSweepWidth.Enabled = true;
                txtTrackLength.Enabled = true;
            }


        }

        private void UpdatePosCumulativeLabel()
        {
            if (SelectedSegment == null || string.IsNullOrWhiteSpace(txtNoSearchers.Text) || string.IsNullOrWhiteSpace(txtTrackLength.Text) || string.IsNullOrWhiteSpace(txtSweepWidth.Text))
            {
                lblEstimatePoSCum.Visible = false;
                lblEstimatePoS.Visible = false;
                return;
            }

            var prev = SelectedSegment.SegmentHistory.Last();
            var seghis = new SegmentSearchHistory
            {
                TypeOfSearcher = (TypeOfSearcher)cbSearcher.SelectedItem,
                NoOfSearchers = int.TryParse(txtNoSearchers.Text, out int val) ? val : 0
            };
            if (seghis.TypeOfSearcher == TypeOfSearcher.Dog)
            {
                seghis.PoD = 0.9;
            }
            else
            {
                seghis.TrackLength = double.TryParse(txtTrackLength.Text, out double val1) ? val1 : 0;
                seghis.SweepWidth = double.TryParse(txtSweepWidth.Text, out double val2) ? val2 : 0;

                if (SelectedSegment.Area != 0)
                    seghis.Coverage = seghis.NoOfSearchers * seghis.TrackLength * seghis.SweepWidth / SelectedSegment.Area;

                if (seghis.Coverage > 0)
                {
                    seghis.PoD = 1 - Math.Exp(-seghis.Coverage);
                }
                else
                    seghis.PoD = 0;
            }

            seghis.PoS = prev.PoA * seghis.PoD;
            seghis.PoSCumulative = prev.PoSCumulative + seghis.PoS;

            lblEstimatePoSCum.Text = Math.Round(seghis.PoSCumulative, 3).ToString("0.000");

            var displayPoS = Math.Round(seghis.PoS, 3);
            lblEstimatePoS.Text = "(+" + displayPoS.ToString("0.000") + ")";
            lblEstimatePoS.ForeColor = displayPoS >= 0.001 ? Color.Green : Color.Red;

            lblEstimatePoSCum.Visible = lblEstimatePoS.Visible = true;

        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePosCumulativeLabel();
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            if(Search.SortedSegmentsArchive is null || Search.SortedSegmentsArchive.Count == 0)
            {
                MessageBox.Show("Insufficient information to generate the report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Consensus> consensusList = new List<Consensus>();
            foreach (var zone in Zones)
            {
                foreach (var consensus in zone.Consensus)
                {
                    consensusList.Add(consensus);
                }
            }
            var frm = new FrmViewReport(consensusList, Search.SortedSegmentsArchive, Search.POSCumulativeArchive, sortedSegments, Search.Name);
            frm.ShowDialog();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Search.DateClosed = DateTime.Now;
            Search.SaveToFile();
            MessageBox.Show("Search closed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Abort;
        }
    }
}

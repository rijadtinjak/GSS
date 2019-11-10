using GSS.Model;
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
    public partial class FrmAnalysis : Form
    {
        private int numOfZones;
        private double sumOfAllConsensus = 0;

        private List<Zone> Zones = new List<Zone>();
        private List<Manager> managers;
        private List<Segment> sortedSegments = new List<Segment>();

        private Segment SelectedSegment;

        private bool hardcoded = true;

        public FrmAnalysis(int numOfZones, List<Manager> managers)
        {
            InitializeComponent();
            this.numOfZones = numOfZones;
            this.managers = managers;
        }

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            if (hardcoded)
                HardcodedZones();

            if (!hardcoded)
                InitZones();

            RefreshHeader();

            if (hardcoded)
                HardcodedPopulateFields();

        }

        private void HardcodedPopulateFields()
        {
            for (int i = 0; i < Zones.Count; i++)
            {
                for (int j = 0; j < managers.Count; j++)
                {
                    Control c = tlpZones.GetControlFromPosition(i + 1, j + 1);
                    c.Text = Zones[i].Consensus[managers[j]].ToString();
                }
            }
            for (int i = 1; i < tlpZones.ColumnCount; i++)
            {
                Control c = tlpZones.GetControlFromPosition(i, tlpZones.RowCount - 1);
                c.Text = Zones[i - 1].Area.ToString();
            }
        }

        private void InitZones()
        {
            for (int i = 0; i < numOfZones; i++)
            {
                Dictionary<Manager, double> consensus = new Dictionary<Manager, double>();
                foreach (var item in managers)
                {
                    consensus.Add(item, 0);
                }

                Zones.Add(new Zone
                {
                    Name = "Zone " + Convert.ToChar(65 + i),
                    Consensus = consensus
                });
            }
        }

        private void HardcodedZones()
        {
            this.numOfZones = 3;
            this.managers = new List<Manager>()
            {
                new Manager { Name = "Marina" },
                new Manager { Name = "Zdenko" },
                new Manager { Name = "Enes" },
                new Manager { Name = "Bojan" }
            };

            int i = 0;
            {
                Dictionary<Manager, double> consensus = new Dictionary<Manager, double>
                {
                    { managers[0], 100 },
                    { managers[1], 70 },
                    { managers[2], 80 },
                    { managers[3], 100 }
                };

                Zones.Add(new Zone
                {
                    Name = "Zone " + Convert.ToChar(65 + i++),
                    Consensus = consensus,
                    Area = 1.223
                });
            }
            {
                Dictionary<Manager, double> consensus = new Dictionary<Manager, double>
                {
                    { managers[0], 80 },
                    { managers[1], 100 },
                    { managers[2], 80 },
                    { managers[3], 80 }
                };

                Zones.Add(new Zone
                {
                    Name = "Zone " + Convert.ToChar(65 + i++),
                    Consensus = consensus,
                    Area = 2.083
                });
            }
            {
                Dictionary<Manager, double> consensus = new Dictionary<Manager, double>
                {
                    { managers[0], 50 },
                    { managers[1], 70 },
                    { managers[2], 100 },
                    { managers[3], 70 }
                };

                Zones.Add(new Zone
                {
                    Name = "Zone " + Convert.ToChar(65 + i++),
                    Consensus = consensus,
                    Area = 1.342
                });
            }
        }

        private void RefreshHeader()
        {
            int counterColumnHeader = 1;
            tlpZones.AutoScroll = true;
            tlpZones.MaximumSize = new Size(frame.Width, frame.Height);
            tlpZones.ColumnCount = Zones.Count + 1;
            tlpZones.RowCount = managers.Count + 2;
            tlpZones.Width = (tlpZones.ColumnCount - 1) * 80 + tlpZones.ColumnCount + (int)tlpZones.ColumnStyles[0].Width + 17;
            tlpZones.Height = (tlpZones.RowCount - 1) * 25 + tlpZones.RowCount + (int)tlpZones.RowStyles[0].Height + 17;
            foreach (var item in Zones)
            {
                var lbl = new Label
                {
                    Text = item.Name,
                    Location = new Point(2, 2),
                    Margin = new Padding(1),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                tlpZones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                tlpZones.Controls.Add(lbl, counterColumnHeader++, 0);
            }
            int counterRow = 1;
            foreach (var item in managers)
            {
                AddRow(ref counterRow, item);
            }
            AddRow(ref counterRow, new Manager { Name = "Zone Area" });

            if (tlpZones.VerticalScroll.Visible == false)
                tlpZones.Width -= 17;
            if (tlpZones.HorizontalScroll.Visible == false)
                tlpZones.Height -= 17;

        }
        private void AddRow(ref int counterRow, Manager item)
        {
            tlpZones.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            var lbl = new Label
            {
                Text = item.Name,
                Location = new Point(2, 2),
                Margin = new Padding(1),
                TextAlign = ContentAlignment.MiddleCenter
            };

            tlpZones.Controls.Add(lbl, 0, counterRow);

            int counterCol = 1;

            //adding textbox input
            foreach (var zone in Zones)
            {
                var txtBox = new TextBox
                {
                    Size = new Size(70, 20),
                    Anchor = AnchorStyles.None,
                    Location = new Point(2, 4),
                    Margin = new Padding(1),
                };
                tlpZones.Controls.Add(txtBox, counterCol++, counterRow);
            }
            counterRow++;
        }

        private void EstimationInput()
        {
            for (int i = 0; i < Zones.Count; i++)
            {
                for (int j = 0; j < managers.Count; j++)
                {
                    Control c = tlpZones.GetControlFromPosition(i + 1, j + 1);
                    string value = c.Text.ToString();

                    try
                    {
                        Zones[i].Consensus[managers[j]] = double.Parse(value);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Consensus invalid");
                    }
                }

                Zones[i].SumofConsensus = 0;
                foreach (var item in Zones[i].Consensus)
                {
                    Zones[i].SumofConsensus += item.Value;
                }
            }
            for (int i = 1; i < tlpZones.ColumnCount; i++)
            {
                Control c = tlpZones.GetControlFromPosition(i, tlpZones.RowCount - 1);
                string value = c.Text.ToString();
                try
                {
                    Zones[i - 1].Area = double.Parse(value);

                }
                catch (Exception)
                {
                    throw new Exception("Area invalid");
                }
            }
        }
        private void ZonePoAPdenCalc()
        {
            foreach (var item in Zones)
            {
                item.PoA = ((item.SumofConsensus / sumOfAllConsensus) * 100) / 100;
                item.Pden = item.PoA / item.Area;
            }
        }

        //private void NewSearch_Click(object sender, EventArgs e)
        //{
        //    if(sortedSegments.Count == 0)
        //    {
        //        MessageBox.Show("No segments added.");
        //        return;
        //    }

        //    int numOfDisplayedSegments = Math.Min(int.TryParse(txtNoOfSegsInSearch.Text, out int val) ? val : 0, sortedSegments.Count);
        //    if (numOfDisplayedSegments < 1)
        //        return;

        //    TabPage tabPageSearch = new TabPage
        //    {
        //        Name = "tabSearch" + (++tabsearchindex),
        //        Text = "Search" + tabsearchindex,
        //        Width = tabSearchSegments.Width - 20,
        //        Height = tabSearchSegments.Height - 60
        //    };

        //    TableLayoutPanel tlpSearch = new TableLayoutPanel
        //    {
        //        Name = "tlpSearch",
        //        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
        //        MaximumSize = new Size(tabPageSearch.Width - 10, tabPageSearch.Height - 20),
        //        AutoScroll = true,
        //        ColumnCount = numOfDisplayedSegments + 1,
        //        RowCount = 4,
        //        Location = new Point(10, 10)
        //    };
        //    tlpSearch.Width = tlpSearch.ColumnCount * 80 + 1 + tlpSearch.ColumnCount + 25;
        //    tlpSearch.Height = tabPageSearch.Height - 20;


        //    for (int i = 1; i <= numOfDisplayedSegments; i++)
        //    {
        //        tlpSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        //        Label lbl = new Label
        //        {
        //            Text = sortedSegments[i-1].Name,
        //            TextAlign = ContentAlignment.MiddleCenter
        //        };
        //        tlpSearch.Controls.Add(lbl, i, 0);
        //        for (int j = 1; j < tlpSearch.RowCount; j++)
        //        {
        //            tlpSearch.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
        //            TextBox txt = new TextBox
        //            {
        //                Location = new Point(1, 2)
        //            };
        //            if (j == 1)
        //                txt.Text = Math.Round(sortedSegments[i - 1].Area, 3).ToString();
        //            if (j == 2)
        //                txt.Text = Math.Round(sortedSegments[i - 1].Pden, 3).ToString();
        //            if (j == 3)
        //                txt.Text = Math.Round(sortedSegments[i - 1].PoA, 3).ToString();
        //            tlpSearch.Controls.Add(txt, i, j);
        //        }
        //    }
        //    Label lblSeg = new Label
        //    {
        //        Text = "Seg. Name",
        //        Location = new Point(2, 2),
        //        Margin = new Padding(1),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };
        //    tlpSearch.Controls.Add(lblSeg);
        //    Label lblArea = new Label
        //    {
        //        Text = "Area",
        //        Location = new Point(2, 2),
        //        Margin = new Padding(1),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };
        //    tlpSearch.Controls.Add(lblArea);
        //    Label lblPden = new Label
        //    {
        //        Text = "Pden",
        //        Location = new Point(2, 2),
        //        Margin = new Padding(1),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };
        //    tlpSearch.Controls.Add(lblPden);
        //    Label lblPoa = new Label
        //    {
        //        Text = "Poa",
        //        Location = new Point(2, 2),
        //        Margin = new Padding(1),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };
        //    tlpSearch.Controls.Add(lblPoa);

        //    Button AddSegment = new Button
        //    {
        //        Name = "AddSegment" + tabsearchindex,
        //        Text = "Add Segment",
        //        Width = 100,
        //        Location = new Point(tlpSearch.Location.X + tlpSearch.Width - 100, tlpSearch.Location.Y + tlpSearch.Height + 10)
        //    };
        //    tabPageSearch.Controls.Add(tlpSearch);
        //    tabPageSearch.Controls.Add(AddSegment);
        //    tabSearchSegments.TabPages.Add(tabPageSearch);
        //}
        
        private void SortZones()
        {
            try
            {
                EstimationInput();
            }
            catch (Exception)
            {
                throw;
            }


            sumOfAllConsensus = 0;
            foreach (var item in Zones)
            {
                sumOfAllConsensus += item.SumofConsensus;
            }
            ZonePoAPdenCalc();
            List<double> sortZonePden = new List<double>();
            foreach (var item in Zones)
            {
                sortZonePden.Add(item.Pden);
            }
            sortZonePden.Sort();
            sortZonePden.Reverse();
        }

        private void BtnAddSegments_Click(object sender, EventArgs e)
        {
            try
            {
                SortZones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var frmSegments = new FrmAddSegments(Zones);
            frmSegments.ShowDialog();

            RefreshSortedSegments();
            RefreshSegmentComboBox();
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

            segments = segments.OrderBy(x=>x.Name).ToList();

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

            for (int i = 0; i < sortedSegments.Count; i++)
            {
                Segment segment = sortedSegments[i];

                tlpSortedSegments.GetControlFromPosition(0, i).Text = segment.Name;
                tlpSortedSegments.GetControlFromPosition(1, i).Text = Math.Round(segment.SegmentHistory[segment.NoOfSearches].PoA, 3).ToString();
            }
        }

        private void cbSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSegment = cbSegment.SelectedItem as Segment;
            if (SelectedSegment == null)
                return;

            RefreshTypeOfSearcherComboBox();

            tabControl1.Visible = true;
            tabControl1.TabPages.Clear();

            for (int i = 0; i < SelectedSegment.SegmentHistory.Count; i++)
            {
                tabControl1.TabPages.Add("Search " + i);

                SegmentHistory segHistory = new SegmentHistory();
                TableLayoutPanel tlp = segHistory.Controls["tableLayoutPanel1"] as TableLayoutPanel;
                SegmentSearchHistory history = SelectedSegment.SegmentHistory[i];
                tlp.Controls["lblSegmentName"].Text = SelectedSegment.Name;
                tlp.Controls["SegmentArea"].Text = SelectedSegment.Area.ToString();
                tlp.Controls["SegmentPden1"].Text = Math.Round(history.Pden, 3).ToString();
                tlp.Controls["SegmentPoA1"].Text = Math.Round(history.PoA, 3).ToString();
                tlp.Controls["SegmentNoOfSearchers"].Text = history.NoOfSearchers.ToString();
                if(i != 0)
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
                tlp.Controls["SegmentDeltaPos"].Text = Math.Round(history.DeltaPoS, 3).ToString();

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
    }
}

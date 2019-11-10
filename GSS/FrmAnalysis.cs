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
        int tabsearchindex = 0;
        private List<Zone> Zones = new List<Zone>();
        private List<Manager> managers;
        private List<Segment> sortedSegments = new List<Segment>();

        public FrmAnalysis(int numOfZones, List<Manager> managers)
        {
            InitializeComponent();
            this.numOfZones = numOfZones;
            this.managers = managers;
        }

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            //HardcodedZones(); // iskljuci me

            InitZones(); // ukljuci me

            RefreshHeader();

            //HardcdedPopulateFields(); // iskljuci me

        }

        private void HardcdedPopulateFields()
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

            SegmentHistory segHistory = new SegmentHistory();
            tabPage1.Controls.Add(segHistory);

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
                    Zones[i].Consensus[managers[j]] = double.Parse(value);
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
                Zones[i - 1].Area = double.Parse(value);
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

        private void BtnSort_Click(object sender, EventArgs e)
        {
            EstimationInput();
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
            //for (int i = 0; i < sortZonePden.Count; i++)
            //{
            //    tlpSortZones.GetControlFromPosition(0, i).Text = sortZonePden[i].ToString();
            //}
        }

        private void BtnAddSegments_Click(object sender, EventArgs e)
        {
            var frmSegments = new FrmAddSegments(Zones);
            frmSegments.ShowDialog();
            RefreshSortedSegments();
        }

        private void RefreshSortedSegments()
        {
            //sortedSegments.Clear();
            //foreach (Zone zone in Zones)
            //{
            //    foreach (Segment segment in zone.Segments)
            //    {
            //        sortedSegments.Add(segment);
            //    }
            //}
            //sortedSegments = sortedSegments.OrderByDescending(x => x.PoA).ToList();

            //for (int i = 0; i < sortedSegments.Count; i++)
            //{
            //    tlpSortedSegments.GetControlFromPosition(0, i).Text = sortedSegments[i].Name;
            //    tlpSortedSegments.GetControlFromPosition(1, i).Text = Math.Round(sortedSegments[i].PoA, 3).ToString();
            //}
        }
    }
}

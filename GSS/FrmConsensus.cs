using GSS.Helper;
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
    public partial class FrmConsensus : Form
    {
        private List<Zone> Zones;
        private List<Manager> Managers;
        private List<Segment> SortedSegments = new List<Segment>();
        private Search Search;

        public FrmConsensus(Search search)
        {
            InitializeComponent();
            Search = search;
            Managers = Search.Managers;
            Zones = Search.Zones;
        }

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            Search.PopulateFields(tlpZones);
        }

        private void RefreshHeader()
        {
            int counterColumnHeader = 1;
            tlpZones.AutoScroll = true;
            tlpZones.MaximumSize = new Size(frame.Width, frame.Height);
            UpdateTableDimensions();

            foreach (var zone in Zones)
            {
                var lbl = new Label
                {
                    Text = zone.Name,
                    Location = new Point(2, 2),
                    Margin = new Padding(1),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                tlpZones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                tlpZones.Controls.Add(lbl, counterColumnHeader++, 0);
            }
            int counterRow = 1;
            foreach (var manager in Managers)
            {
                AddRow(ref counterRow, manager);
            }
            AddRow(ref counterRow, new Manager { Name = "Zone Area" });

            if (tlpZones.RowCount == 9)
            {
                tlpZones.Width += 2;
            }

            if (tlpZones.VerticalScroll.Visible == false)
                tlpZones.Width -= 17;
            if (tlpZones.HorizontalScroll.Visible == false && tlpZones.RowCount <= 7)
                tlpZones.Height -= 17;

        }

        private void UpdateTableDimensions()
        {
            tlpZones.ColumnCount = Zones.Count + 1;
            tlpZones.RowCount = Managers.Count + 2;
            tlpZones.Width = (tlpZones.ColumnCount - 1) * 80 + tlpZones.ColumnCount + (int)tlpZones.ColumnStyles[0].Width + 17;
            tlpZones.Height = (tlpZones.RowCount - 1) * 25 + tlpZones.RowCount + (int)tlpZones.RowStyles[0].Height + 17;
        }

        private void AddRow(ref int counterRow, Manager manager)
        {
            tlpZones.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            var lbl = new Label
            {
                Text = manager.Name,
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
                    Margin = new Padding(1)
                };
                txtBox.Validating += TxtBox_Validating;
                tlpZones.Controls.Add(txtBox, counterCol++, counterRow);
            }
            counterRow++;
        }

        private void AddZone()
        {
            Zones.Add(new Zone
            {
                Name = "Zone " + Convert.ToChar(65 + Zones.Count)
            });

            Zone zone = Zones.Last();
            foreach (var manager in Managers)
            {
                zone.Consensus.Add(new Consensus { Zone = zone, Manager = manager, Value = 0 });
            }

            UpdateTableDimensions();
            if (Zones.Count == 26)
                BtnAddZone.Enabled = false;

            int totalRows = Managers.Count + 2;
            for (int i = 0; i < totalRows; i++)
            {
                if (i == 0)
                {
                    var lbl = new Label
                    {
                        Text = zone.Name,
                        Location = new Point(2, 2),
                        Margin = new Padding(1),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    tlpZones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                    tlpZones.Controls.Add(lbl, Zones.Count, 0);
                }
                else
                {
                    var txtBox = new TextBox
                    {
                        Size = new Size(70, 20),
                        Anchor = AnchorStyles.None,
                        Location = new Point(2, 4),
                        Margin = new Padding(1)
                    };
                    txtBox.Validating += TxtBox_Validating;
                    tlpZones.Controls.Add(txtBox, Zones.Count, i);
                }
            }

            tlpZones.ScrollControlIntoView(tlpZones.GetControlFromPosition(Zones.Count, 1));

        }

        private void TxtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (!double.TryParse(box.Text, out double val))
            {
                box.BackColor = Color.IndianRed;
                box.Text = "";
            }
            else
                box.BackColor = Color.White;
        }

        private void BtnAddZone_Click(object sender, EventArgs e)
        {
            try
            {
                AddZone();
                SaveSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void BtnAddSegments_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Consensus not fully entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Search.SortZones(tlpZones);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var frmSegments = new FrmAddSegments(Zones, 622);
            frmSegments.ShowDialog();

            SaveSearch();
        }

        private void SaveSearch()
        {
            Search.EstimationInput(tlpZones, false);
            Search.ZonePoAPdenCalc();
            Search.SaveToFile();
        }

        private void FrmConsensus_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSearch();
        }
    }

}



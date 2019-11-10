using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSS.Model;

namespace GSS
{
    public partial class FrmAddSegments : Form
    {
        private List<Zone> zones;
        public FrmAddSegments()
        {
        }

        public FrmAddSegments(List<Zone> zones)
        {
            InitializeComponent();
            this.zones = zones;
        }

        private void FrmAddSegments_Load(object sender, EventArgs e)
        {
            //Creating tabs and tlp header
            foreach (var item in zones)
            {
                int colCount = 0;
                TabPage zoneTab = new TabPage(item.Name)
                {
                    Name = item.Name
                };
                TableLayoutPanel tlpSegments = new TableLayoutPanel
                {
                    Name = "tlpSegments",
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                    ColumnCount = 4,
                    RowCount = 1,
                    Width = 4 * 80 + 4
                };
                tlpSegments.Height = tlpSegments.RowCount * 26;
                var lbl = new Label
                {
                    Text = "Name",
                    Location = new Point(1, 1),
                    Margin = new Padding(1),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var lbl2 = new Label
                {
                    Text = "Area",
                    Location = new Point(1, 1),
                    Margin = new Padding(1),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var lbl3 = new Label
                {
                    Text = "Pden",
                    Location = new Point(1, 1),
                    Margin = new Padding(1),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var lbl4 = new Label
                {
                    Text = "PoA",
                    Location = new Point(1, 1),
                    Margin = new Padding(1),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                tlpSegments.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                tlpSegments.Controls.Add(lbl, colCount++, 0);

                tlpSegments.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                tlpSegments.Controls.Add(lbl2, colCount++, 0);

                tlpSegments.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                tlpSegments.Controls.Add(lbl3, colCount++, 0);

                tlpSegments.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
                tlpSegments.Controls.Add(lbl4, colCount++, 0);

                zoneTab.Controls.Add(tlpSegments);
                //btn shit
                Button btnAddSegment = new Button
                {
                    Name = "btnAddSegment",
                    Text = "Add Segment",
                    Width = 80,
                    Location = new Point(lbl4.Location.X, tlpSegments.Location.Y * tlpSegments.RowCount + 30)
                };
                btnAddSegment.Click += new EventHandler(BtnAddSegment_Click);
                Button btnSaveToZone = new Button
                {
                    Name = "btnSaveToZone",
                    Text = "Save",
                    Width = 80,
                    Location = new Point(btnAddSegment.Location.X - 85, btnAddSegment.Location.Y)
                };
                btnSaveToZone.Click += new EventHandler(BtnSaveToZone_Click);
                zoneTab.Controls.Add(btnSaveToZone);
                zoneTab.Controls.Add(btnAddSegment);
                tabZones.TabPages.Add(zoneTab);
            }

        }
        private void BtnAddSegment_Click(object sender, EventArgs e)
        {
            TableLayoutPanel tlp = tabZones.SelectedTab.Controls["tlpSegments"] as TableLayoutPanel;
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            var lbl = new Label
            {
                Text = "Segment " + tabZones.SelectedTab.Name[5] + " " + tlp.RowCount,
                Location = new Point(1, 1),
                Margin = new Padding(1),
                TextAlign = ContentAlignment.MiddleCenter
            };
            tlp.Controls.Add(lbl, 0, tlp.RowCount);

            for (int i = 1; i < tlp.ColumnCount; i++)
            {
                TextBox txtBox = new TextBox
                {
                    Size = new Size(70, 24),
                    Anchor = AnchorStyles.None,
                    Text = "0",
                    Location = new Point(2, 2),
                    Margin = new Padding(1)
                };
                if (i == 1) // Area textbox
                {
                    txtBox.TextChanged += txtBox_TextChanged;
                }
                if (i == 2) // PDen textbox
                {
                    txtBox.Text = Math.Round(zones[tabZones.SelectedIndex].Pden, 3).ToString();
                    txtBox.ReadOnly = true;
                }
                if (i == 3) // PoA textbox
                {
                    txtBox.ReadOnly = true;
                }
                tlp.Controls.Add(txtBox, i, tlp.RowCount);
            }
            tlp.RowCount++;
            tlp.Height = tlp.RowCount * 26 + tlp.RowCount;
            Button btn = tabZones.SelectedTab.Controls["btnAddSegment"] as Button;
            Button save = tabZones.SelectedTab.Controls["btnSaveToZone"] as Button;
            btn.Location = new Point(btn.Location.X, tlp.RowCount * 26 + tlp.RowCount + 2);
            save.Location = new Point(btn.Location.X - 85, btn.Location.Y);
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            TableLayoutPanel tlp = tabZones.SelectedTab.Controls["tlpSegments"] as TableLayoutPanel;


            for (int i = 0; i <= tlp.ColumnCount; i++)
            {
                for (int j = 0; j <= tlp.RowCount; j++)
                {
                    Control c = tlp.GetControlFromPosition(i, j);

                    if (c != null && c == sender)
                    {
                        double area = Math.Round(double.TryParse((sender as TextBox).Text, out double val) ? val : 0.0, 3);

                        Control txtBoxPden = tlp.GetControlFromPosition(i + 1, j);
                        Control txtBoxPoA = tlp.GetControlFromPosition(i + 2, j);
                        if (txtBoxPden != null && txtBoxPoA != null)
                        {
                            double pden = Math.Round(double.TryParse(txtBoxPden.Text, out double pden_val) ? pden_val : 0.0, 3);
                            double poa = Math.Round(pden * area, 3);
                            txtBoxPoA.Text = poa.ToString();
                        }
                    }
                }
            }
        }

        private void BtnSaveToZone_Click(object sender, EventArgs e)
        {
            TableLayoutPanel tlp = tabZones.SelectedTab.Controls["tlpSegments"] as TableLayoutPanel;
            zones[tabZones.SelectedIndex].Segments.Clear();
            for (int i = 1; i < tlp.RowCount; i++)
            {
                Segment seg = new Segment
                {
                    Name = tlp.GetControlFromPosition(0, i).Text,
                    Area = double.Parse(tlp.GetControlFromPosition(1, i).Text),
                    //Pden = double.Parse(tlp.GetControlFromPosition(2, i).Text),
                    //PoA = double.Parse(tlp.GetControlFromPosition(3, i).Text),
                    Zone = zones[tabZones.SelectedIndex]
                };
                zones[tabZones.SelectedIndex].Segments.Add(seg);
            }
        }
    }
}

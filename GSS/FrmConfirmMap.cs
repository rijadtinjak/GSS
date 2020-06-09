using GSS.Helper;
using GSS.Model;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS
{
    public partial class FrmConfirmMap : MaterialForm
    {
        public Search Search { get; set; }
        public List<Segment> Segments { get; set; }
        public List<Zone> Zones { get; set; }

        private bool loaded = false;

        public FrmConfirmMap(Search search)
        {
            InitializeComponent();

            this.Search = search;
            this.Zones = search.Zones;
            this.Segments = search.Zones[0].Segments;

            RefreshZonesDataGrid();
            RefreshSegmentsDataGrid();

            webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_CreateZones.html");
            webBrowser1.ObjectForScripting = new ScriptingObject(this);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            DialogResult = DialogResult.OK;
        }


        private void EvalCode(string code)
        {
            webBrowser1.Document.InvokeScript("eval", new object[] { code });
        }


        [ComVisible(true)]
        public class ScriptingObject
        {
            private readonly FrmConfirmMap frm;

            public ScriptingObject(FrmConfirmMap FrmConfirmMap)
            {
                this.frm = FrmConfirmMap;
            }

            // can be called from JavaScript

            public void SelectSegment(int index)
            {
                if (index < 0 || index >= frm.Segments.Count)
                {
                    MessageBox.Show("Error", "List index out of bounds during select: " + index + ".", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (frm.dgvSegments.Rows[index].Selected)
                    return;

                frm.dgvSegments.SelectionChanged -= frm.DgvSegments_SelectionChanged;
                frm.dgvSegments.Rows[index].Selected = true;
                frm.dgvSegments.SelectionChanged += frm.DgvSegments_SelectionChanged;

            }
            public void DeselectSegment(int index)
            {
                if (index < 0 || index >= frm.Segments.Count)
                {
                    MessageBox.Show("Error", "List index out of bounds during select: " + index + ".", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!frm.dgvSegments.Rows[index].Selected)
                    return;

                frm.dgvSegments.SelectionChanged -= frm.DgvSegments_SelectionChanged;
                frm.dgvSegments.Rows[index].Selected = false;
                frm.dgvSegments.SelectionChanged += frm.DgvSegments_SelectionChanged;

            }

            public void UpdateSegmentArea(int index, double area)
            {
                int counter = 0;
                foreach (var zone in frm.Zones)
                {
                    foreach (var segment in zone.Segments)
                    {
                        if (counter == index)
                        {
                            segment.Area = Math.Round(area / 1000000, 3);
                            break;
                        }

                        counter++;

                    }

                }
            }

            public void OnLoad()
            {
                frm.loaded = true;

                frm.EvalCode("map.setCenter({lat: " + frm.Search.Lat + ", lng: " + frm.Search.Lng + "}); ");
                frm.EvalCode("setLocationMarker(new google.maps.LatLng(" + frm.Search.Lat + ", " + frm.Search.Lng + ")); ");

                int counter = 0;

                foreach (var zone in frm.Zones)
                {
                    foreach (var segment in zone.Segments)
                    {
                        var latitudes = segment.SegmentPoints.Select(x => x.Lat.ToString()).ToList();
                        var longitudes = segment.SegmentPoints.Select(x => x.Lng.ToString()).ToList();

                        var joined_lat = string.Join(",", latitudes);
                        var joined_lng = string.Join(",", longitudes);
                        var script = "AddSegment([" + joined_lat + "], [" + joined_lng + "]); ";

                        frm.EvalCode(script);

                        string HexColor = ZoneHelper.ZoneColors[frm.Zones.IndexOf(zone)].ToHex();

                        frm.EvalCode("SetSegmentZoneColor(" + counter + ", \"" + HexColor + "\");");
                        frm.EvalCode("TriggerUpdateArea(" + counter + ");");

                        counter++;
                    }
                }

                frm.RefreshSegmentsDataGrid();

                foreach (var zone in frm.Zones)
                {
                    zone.Area = zone.Segments.Sum(x => x.Area);

                    foreach (var manager in frm.Search.Managers)
                    {
                        zone.Consensus.Add(new Consensus { Zone = zone, Manager = manager, Value = 0 });
                    }
                }
                frm.RefreshZonesDataGrid();

            }
        }



        private void UpdateSegmentSequence()
        {
            var i = 0;
            foreach (var item in Segments)
            {
                item.Name = "Segment " + ++i;
            }
        }

        private void RefreshSegmentsDataGrid()
        {
            dgvSegments.AutoGenerateColumns = false;
            var list = new BindingList<Segment>(Segments);
            dgvSegments.DataSource = list;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Zone != null)
                {
                    dgvSegments.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(171, 171, 171);

                }

            }

        }

        private void RefreshZonesDataGrid()
        {
            dgvZones.AutoGenerateColumns = false;
            dgvZones.DataSource = new BindingList<Zone>(Zones);
        }

        private void DgvSegments_SelectionChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;

            EvalCode("DeselectAllSegments();");


            for (int i = 0; i < dgvSegments.SelectedRows.Count; i++)
            {
                var Segment = dgvSegments.SelectedRows[i].DataBoundItem as Segment;
                if (Segment.Zone != null)
                {
                    dgvSegments.SelectedRows[i].Selected = false;
                }
                else
                {
                    EvalCode("SelectSegment(" + dgvSegments.SelectedRows[i].Index + ");");
                }
            }
        }

        private void BtnCreateZone_Click(object sender, EventArgs e)
        {
            if (dgvSegments.SelectedRows.Count == 0)
            {
                return;
            }

            if (Zones.Count < ZoneHelper.MaxZones)
            {
                Zone NewZone = new Zone
                {
                    Name = "Zone " + Convert.ToChar(65 + Zones.Count)
                };

                string HexColor = ZoneHelper.ZoneColors[Zones.Count].ToHex();
                int counter = 0;
                foreach (DataGridViewRow row in dgvSegments.SelectedRows)
                {
                    Segment SelectedSegment = row.DataBoundItem as Segment;

                    NewZone.Segments.Add(SelectedSegment);
                    SelectedSegment.Name = "Segment " + NewZone.Name[5] + " " + ++counter;
                    SelectedSegment.Zone = NewZone;

                    EvalCode("SetSegmentZoneColor(" + row.Index + ", \"" + HexColor + "\");");
                }
                NewZone.Area = NewZone.Segments.Sum(x => x.Area);

                foreach (var manager in Search.Managers)
                {
                    NewZone.Consensus.Add(new Consensus { Zone = NewZone, Manager = manager, Value = 0 });
                }
                Zones.Add(NewZone);

                RefreshSegmentsDataGrid();
                RefreshZonesDataGrid();
            }
            else
            {
                MessageBox.Show("You can only create up to " + ZoneHelper.MaxZones + " zones.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvSegments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSegments.ClearSelection();
        }

        private void dgvZones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvZones.ClearSelection();
        }

        private void dgvZones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvZones.SelectedRows.Count == 0)
                return;

            this.Segments = (dgvZones.SelectedRows[0].DataBoundItem as Zone).Segments;
            RefreshSegmentsDataGrid();
        }
    }
}

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
    public partial class FrmCreateZones : MaterialForm
    {
        public Search Search { get; set; }
        public List<Segment> Segments { get; set; }
        public List<Zone> Zones { get; set; }

        private bool loaded = false;
        private bool offlineVersion;

        public FrmCreateZones(Search search, bool offlineVersion = false)
        {
            InitializeComponent();

            this.Search = search;
            this.Zones = search.Zones;
            this.Segments = search.SegmentsUnassigned;
            this.offlineVersion = offlineVersion;

            RefreshSegmentsDataGrid();
            RefreshZonesDataGrid();

            if(!offlineVersion)
            {
                webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_CreateZones.html");
                webBrowser1.ObjectForScripting = new ScriptingObject(this);
            }
            else
            {
                webBrowser1.Url = new Uri("about:blank");
                webBrowser1.Visible = false;
                lblOfflineMode.Visible = true;
                BtnCreateZone.Visible = false;
            }
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
            private readonly FrmCreateZones frm;

            public ScriptingObject(FrmCreateZones FrmCreateZones)
            {
                this.frm = FrmCreateZones;
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

                frm.BtnCreateZone.Enabled = true;
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

                if (frm.dgvSegments.SelectedRows.Count == 0)
                    frm.BtnCreateZone.Enabled = false;
            }

            public void OnLoad()
            {
                frm.loaded = true;

                frm.EvalCode("map.setCenter({lat: " + frm.Search.Lat + ", lng: " + frm.Search.Lng + "}); ");
                frm.EvalCode("setLocationMarker(new google.maps.LatLng(" + frm.Search.Lat + ", " + frm.Search.Lng + ")); ");

                for (int i = 0; i < frm.Segments.Count; i++)
                {
                    var latitudes = frm.Segments[i].SegmentPoints.Select(x => x.Lat.ToString()).ToList();
                    var longitudes = frm.Segments[i].SegmentPoints.Select(x => x.Lng.ToString()).ToList();

                    var joined_lat = string.Join(",", latitudes);
                    var joined_lng = string.Join(",", longitudes);
                    var script = "AddSegment([" + joined_lat + "], [" + joined_lng + "]); ";

                    frm.EvalCode(script);
                }

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
            BtnCreateZone.Enabled = false;

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

            if (dgvSegments.SelectedRows.Count == 0)
                BtnCreateZone.Enabled = false;
            else
                BtnCreateZone.Enabled = true;

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
                BtnCreateZone.Enabled = false;
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
    }
}

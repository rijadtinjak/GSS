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
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GSS
{
    public partial class FrmMarkSegments : MaterialForm
    {
        public List<Segment> Segments { get; set; }
        public int ActiveRowIndex { get; set; } = -1;
        public Search Search { get; set; }

        public FrmMarkSegments(Search search)
        {
            InitializeComponent();

            this.Search = search;
            this.Segments = search.SegmentsUnassigned;

            webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_MarkSegments.html");
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
            private readonly FrmMarkSegments frm;

            public ScriptingObject(FrmMarkSegments FrmMarkSegments)
            {
                this.frm = FrmMarkSegments;
            }

            // can be called from JavaScript
            public void UpdateSegment(int index, double area, string Points)
            {
                if (index < 0 || index >= frm.Segments.Count)
                {
                    MessageBox.Show("Error", "List index out of bounds during update: " + index + ".", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frm.Segments[index].Area = Math.Round(area / 1000000, 3);
                frm.Segments[index].SegmentPoints.Clear();
                if (!string.IsNullOrEmpty(Points))
                {
                    var points_list = Points.Split(';');
                    for (int i = 0; i < points_list.Length; i++)
                    {
                        var coords = points_list[i].Split(',');
                        if (coords.Length == 2)
                        {
                            frm.Segments[index].SegmentPoints.Add(new SegmentPoint
                            {
                                Lat = InputHelper.ParseDecimal(coords[0]),
                                Lng = InputHelper.ParseDecimal(coords[1])
                            });
                        }

                    }
                }

                frm.RefreshDataGrid();
            }

            public void DeleteSegment(int index)
            {
                if (index < 0 || index >= frm.Segments.Count)
                {
                    MessageBox.Show("Error", "List index out of bounds during delete: " + index + ".", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frm.Segments.RemoveAt(index);
                frm.ActiveRowIndex = -1;
                frm.UpdateSegmentSequence();
                frm.RefreshDataGrid();

            }

            public void SelectSegment(int index)
            {
                if (index < 0 || index >= frm.Segments.Count)
                {
                    MessageBox.Show("Error", "List index out of bounds during select: " + index + ".", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frm.ActiveRowIndex = index;
                frm.BtnEditSegment.Enabled = true;
                frm.BtnDeleteSegment.Enabled = true;
                frm.BtnFinishSegment.Enabled = false;
                frm.BtnNewSegment.Enabled = true;
                frm.RefreshDataGrid();
            }

            public void OnLoad()
            {
                frm.EvalCode("map.setCenter({lat: " + frm.Search.Lat + ", lng: " + frm.Search.Lng + "}); ");
                frm.EvalCode("setLocationMarker(new google.maps.LatLng(" + frm.Search.Lat + ", " + frm.Search.Lng + ")); ");

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

        private void UpdateActiveRow()
        {
            if (ActiveRowIndex == -1)
                return;
            dgvSegments.ClearSelection();
            dgvSegments.Rows[ActiveRowIndex].Selected = true;
        }

        private void RefreshDataGrid()
        {
            dgvSegments.AutoGenerateColumns = false;
            dgvSegments.DataSource = null;
            dgvSegments.DataSource = Segments;
            UpdateActiveRow();
            if (Segments.Count == 0)
            {
                BtnEditSegment.Enabled = false;
                BtnDeleteSegment.Enabled = false;
            }
        }

        private void BtnNewSegment_Click(object sender, EventArgs e)
        {
            EvalCode("new_segment()");
            BtnNewSegment.Enabled = false;
            BtnFinishSegment.Enabled = true;
            BtnEditSegment.Enabled = false;
            BtnDeleteSegment.Enabled = false;

            btnNext.Enabled = false;


            Segments.Add(new Segment
            {
                Area = 0,
                Name = "Segment " + (Segments.Count + 1)
            });
            ActiveRowIndex = dgvSegments.RowCount;
            RefreshDataGrid();
            dgvSegments.Enabled = false;
        }

        private void BtnFinishSegment_Click(object sender, EventArgs e)
        {
            EvalCode("finish_segment(" + dgvSegments.SelectedRows[0].Index + " )");
            BtnFinishSegment.Enabled = false;
            BtnNewSegment.Enabled = true;
            BtnEditSegment.Enabled = true;
            BtnDeleteSegment.Enabled = true;
            RefreshDataGrid();
            dgvSegments.Enabled = true;
            btnNext.Enabled = true;
        }

        private void BtnEditSegment_Click(object sender, EventArgs e)
        {
            dgvSegments.Enabled = false;
            BtnEditSegment.Enabled = false;
            BtnFinishSegment.Enabled = true;
            BtnDeleteSegment.Enabled = false;
            BtnNewSegment.Enabled = false;

            btnNext.Enabled = false;

            ActiveRowIndex = dgvSegments.SelectedRows[0].Index;
            EvalCode("EditSegment(" + dgvSegments.SelectedRows[0].Index + ");");
        }

        private void DgvSegments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSegments.SelectedRows.Count == 0)
                return;

            EvalCode("SelectSegment(" + dgvSegments.SelectedRows[0].Index + ");");
        }

        private void BtnDeleteSegment_Click(object sender, EventArgs e)
        {
            if (dgvSegments.SelectedRows.Count == 0)
                return;

            EvalCode("RemoveSegment(" + dgvSegments.SelectedRows[0].Index + ");");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileName = openFileDialog1.FileName;
                    XmlDocument gpxDoc = new XmlDocument();
                    gpxDoc.Load(fileName);

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(gpxDoc.NameTable);
                    nsmgr.AddNamespace("x", "http://www.topografix.com/GPX/1/1");
                    XmlNodeList list_trk = gpxDoc.SelectNodes("//x:trk", nsmgr);

                    Search.Zones = new List<Zone>();

                    foreach (XmlNode trk in list_trk)
                    {
                        string name = trk.Name;
                        var name_node = trk["name"];
                        var seg_name = name_node.InnerText;
                        var zone_name = "Zone " + seg_name[0];

                        var zone = Search.Zones.Where(x => x.Name == zone_name).FirstOrDefault();
                        if (zone == null)
                        {
                            Search.Zones.Add(new Zone
                            {
                                Name = zone_name
                            });
                            zone = Search.Zones.Last();
                        }

                        XmlNodeList list_trkpt = trk["trkseg"].ChildNodes;

                        var seg_points = new List<SegmentPoint>();
                        foreach (XmlNode trkpt in list_trkpt)
                        {
                            seg_points.Add(new SegmentPoint
                            {
                                Lat = decimal.Parse(trkpt.Attributes["lat"].Value),
                                Lng = decimal.Parse(trkpt.Attributes["lon"].Value)
                            });
                        }

                        zone.Segments.Add(new Segment
                        {
                            Name = "Segment " + seg_name,
                            Zone = zone,
                            SegmentPoints = seg_points
                        });
                    }

                    DialogResult = DialogResult.OK;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }


        }
    }
}

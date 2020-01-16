using GSS.Helper;
using GSS.Model;
using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GSS
{
    public partial class frmOverView : MaterialForm
    {
        private bool loaded;

        public List<Search> Searches { get; set; } = new List<Search>();

        public frmOverView()
        {
            InitializeComponent();

            UpdateFormData();
            
            webBrowser1.ObjectForScripting = new ScriptingObject(this);
            webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_Overview.html");
        }

        private void UpdateFormData()
        {
            LoadHistory();
            LoadCmbOngoingSearch();
        }

        private void LoadCmbOngoingSearch()
        {
            var OngoingSearches = Searches.Where(x => x.DateClosed == null).ToList();

            cmbOngoingSearches.DataSource = null;
            cmbOngoingSearches.DataSource = OngoingSearches;
            cmbOngoingSearches.DisplayMember = "Name";
            cmbOngoingSearches.ValueMember = "Id";
        }

        private void LoadHistory()
        {
            Searches.Clear();
            string appDir = FileHelper.GetAppDir();

            var savedSearches = Directory.GetFiles(appDir, "*.bin", SearchOption.TopDirectoryOnly);
            foreach (string fileName in savedSearches)
            {
                Search savedSearch = SearchHelper.LoadFromFile(fileName);
                if (savedSearch != null)
                    Searches.Add(savedSearch);
            }
            Searches = Searches.OrderByDescending(x => x.DateCreated).ToList();

            var FinishedSearches = Searches.Where(x => x.DateClosed != null).ToList();

            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.DataSource = null;
            dgvHistory.DataSource = FinishedSearches;

            dgvHistory.ClearSelection();
            lblNoSearches.Visible = true;
            webBrowser1.Visible = false;
        }

        private void BtnStartSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var dialog = new FrmInitial();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var NewSearch = new Search
                {
                    Name = txtNewSearchName.Text,
                    DateCreated = DateTime.Now
                };
                NewSearch.SetUpSearch(dialog.Managers, dialog.Lat, dialog.Lng);
                NewSearch.SaveToFile();

                FrmMarkSegments dialog_segments = new FrmMarkSegments(NewSearch);

                if (dialog_segments.ShowDialog() == DialogResult.OK)
                {
                    NewSearch.SaveToFile();

                    var dialog_zones = new FrmCreateZones(NewSearch);
                    if (dialog_zones.ShowDialog() == DialogResult.OK)
                    {
                        NewSearch.SaveToFile();
                    }
                }

                Searches.Add(NewSearch);

                var dialog_analysis = new FrmConsensus(NewSearch);
                dialog_analysis.ShowDialog();
                NewSearch.SaveToFile();
                UpdateFormData();
            }

            txtNewSearchName.Text = "";

        }

        private void BtnOpenSearch_Click(object sender, EventArgs e)
        {
            if (!(cmbOngoingSearches.SelectedItem is Search SelectedSearch))
            {
                return;
            }

            var dialog_analysis = new FrmConsensus(SelectedSearch);
            dialog_analysis.ShowDialog();

            UpdateFormData();
        }

        private void TxtNewSearchName_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                box.BackColor = Color.IndianRed;
                e.Cancel = true;
            }
            else
            {
                box.BackColor = SystemColors.Window;
            }
        }

        private void DgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgvHistory.SelectedRows[0].DataBoundItem is Search SelectedSearch))
                return;

            var dialog_analysis = new FrmConsensus(SelectedSearch);
            dialog_analysis.ShowDialog();

            UpdateFormData();
        }

        [ComVisible(true)]
        public class ScriptingObject
        {
            private frmOverView frm;
            public Search Search;

            public ScriptingObject(frmOverView frmOverView)
            {
                this.frm = frmOverView;
            }

            // can be called from JavaScript
            public void OnLoad()
            {
                frm.loaded = true;

                Search = frm.dgvHistory.SelectedRows[0].DataBoundItem as Search;
                if (Search is null)
                    return;

                frm.EvalCode("map.setCenter({lat: " + Search.Lat + ", lng: " + Search.Lng + "}); ");
                frm.EvalCode("setLocationMarker(new google.maps.LatLng(" + Search.Lat + ", " + Search.Lng + ")); ");

                for (int i = 0; i < Search.Zones.Count; i++)
                {
                    string HexColor = ZoneHelper.ZoneColors[i].ToHex();

                    for (int j = 0; j < Search.Zones[i].Segments.Count; j++)
                    {
                        var latitudes = Search.Zones[i].Segments[j].SegmentPoints.Select(x => x.Lat.ToString()).ToList();
                        var longitudes = Search.Zones[i].Segments[j].SegmentPoints.Select(x => x.Lng.ToString()).ToList();
                        if (latitudes.Count > 0 && longitudes.Count > 0)
                        {

                            var joined_lat = string.Join(",", latitudes);
                            var joined_lng = string.Join(",", longitudes);
                            var script = "AddSegment([" + joined_lat + "], [" + joined_lng + "], \"" + HexColor + "\"); ";

                            frm.EvalCode(script);
                        }

                    }
                }


            }
        }

        private void EvalCode(object code)
        {
            webBrowser1.Document.InvokeScript("eval", new object[] { code });
        }

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblNoSearches.Visible = false;
            webBrowser1.Visible = true;

            webBrowser1.Refresh();
        }
    }
}

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
using Flurl.Http;

namespace GSS
{
    public partial class frmOverView : MaterialForm
    {
        public bool loaded { get; set; }

        public List<Search> Searches { get; set; } = new List<Search>();
        public APIService _searchService = new APIService("Search");

        public frmOverView()
        {
            InitializeComponent();

            webBrowser1.ObjectForScripting = new ScriptingObject(this);
            webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_Overview.html");

            if (APIService.OfflineMode)
            {
                lblNoSearches.Text = "Map is not available in offline mode.";
            }
        }

        private void UpdateFormData()
        {
            LoadHistory();
            LoadCmbOngoingSearch();
            cmbFilterStatus.SelectedIndex = 0;

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
                {
                    if (savedSearch.UserId != 0 && APIService.LoggedInUser != null && savedSearch.UserId != APIService.LoggedInUser.Id)
                        continue;
                    if (APIService.OfflineMode && savedSearch.User != null && savedSearch.User.Email != APIService.Email)
                        continue;

                    Searches.Add(savedSearch);
                }
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

            bool OfflineVersion = false;

            if (APIService.OfflineMode || !NetworkHelper.IsUp())
                OfflineVersion = true;

            var dialog = new FrmInitial(OfflineVersion);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var NewSearch = new Search
                {
                    Name = txtNewSearchName.Text,
                    DateCreated = DateTime.Now
                };
                NewSearch.SetUpSearch(dialog.Managers, dialog.MissingPeople, dialog.Lat, dialog.Lng, dialog.DateReportedMissing);
                NewSearch.SaveToFile();

                FrmMarkSegments dialog_segments = new FrmMarkSegments(NewSearch, OfflineVersion);

                if (dialog_segments.ShowDialog() == DialogResult.OK)
                {
                    NewSearch.SaveToFile();

                    if (NewSearch.Zones.Count == 0)
                    {
                        var dialog_zones = new FrmCreateZones(NewSearch, OfflineVersion);
                        if (dialog_zones.ShowDialog() == DialogResult.OK)
                        {
                            NewSearch.SaveToFile();
                        }
                    }
                    else
                    {
                        var dialog_confirm = new FrmConfirmMap(NewSearch, OfflineVersion);
                        if (dialog_confirm.ShowDialog() == DialogResult.OK)
                        {
                            NewSearch.SaveToFile();
                        }
                    }
                }

                Searches.Add(NewSearch);

                var dialog_analysis = new FrmConsensus(NewSearch);
                if (dialog_analysis.ShowDialog() != DialogResult.Abort)
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
            if(dialog_analysis.ShowDialog() == DialogResult.Abort)
            {
                UpdateFormData();
            }
        }


        private void EvalCode(object code)
        {
            webBrowser1.Document.InvokeScript("eval", new object[] { code });
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                return;

            e.SuppressKeyPress = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string appDir = FileHelper.GetAppDir();

            var savedSearches = Directory.GetFiles(appDir, "*.bin", SearchOption.TopDirectoryOnly);
            var FilteredSearches = new List<Search>();

            Searches.Clear();
            dgvHistory.ClearSelection();

            foreach (string fileName in savedSearches)
            {
                Search savedSearch = SearchHelper.LoadFromFile(fileName);
                if (savedSearch != null)
                {
                    if (savedSearch.UserId != 0 && APIService.LoggedInUser != null && savedSearch.UserId != APIService.LoggedInUser.Id)
                        continue;
                    if (APIService.OfflineMode && savedSearch.User != null && savedSearch.User.Email != APIService.Email)
                        continue;

                    if (savedSearch.DateCreated.Date >= dtpStart.Value.Date && savedSearch.DateCreated.Date <= dtpEnd.Value.Date &&
                        (string.IsNullOrWhiteSpace(txtSearchName.Text) || (
                            savedSearch.Name.ToLower().Contains(txtSearchName.Text.ToLower()) ||
                            savedSearch.MissingPeople.Any(x => txtSearchName.Text.ToLower().Contains(x.FirstName.ToLower()) ||
                                                             txtSearchName.Text.ToLower().Contains(x.LastName.ToLower()))
                        )) &&
                        (cmbFilterStatus.SelectedIndex <= 0 || savedSearch.MissingPeople.Any(x => (int)x.PersonStatus == cmbFilterStatus.SelectedIndex - 1)))
                    {
                        FilteredSearches.Add(savedSearch);
                    }
                }
            }

            Searches = FilteredSearches.Where(x => x.DateClosed != null)
                        .OrderByDescending(x => x.DateCreated).ToList();


            dgvHistory.DataSource = null;
            dgvHistory.DataSource = Searches;
            dgvHistory.ClearSelection();

            if (Searches.Count == 0)
            {
                lblNoSearches.Visible = true;
                webBrowser1.Visible = false;
            }
            else
            {
                lblNoSearches.Visible = false;
                webBrowser1.Visible = true;

                webBrowser1.ObjectForScripting = new ScriptingObjectFiltered(this);
                webBrowser1.Refresh();
            }

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
                if (frm.dgvHistory.SelectedRows.Count == 0)
                    return;
                Search = frm.dgvHistory.SelectedRows[0].DataBoundItem as Search;
                if (Search is null)
                    return;

                frm.EvalCode("map.setCenter({lat: " + Search.Lat + ", lng: " + Search.Lng + "}); ");
                frm.EvalCode("map.setZoom(14); ");
                frm.EvalCode("setLocationMarker(new google.maps.LatLng(" + Search.Lat + ", " + Search.Lng + ")); ");

                foreach (var person in Search.MissingPeople)
                {
                    if (person.Lat is null || person.Lng is null)
                    {
                        continue;
                    }

                    if (person.PersonStatus == PersonStatus.FoundAlive)
                        frm.EvalCode("setAliveMarker(new google.maps.LatLng(" + person.Lat + ", " + person.Lng + "), '" + person.ToString() + "'); ");
                    else if (person.PersonStatus == PersonStatus.FoundDead)
                        frm.EvalCode("setDeadMarker(new google.maps.LatLng(" + person.Lat + ", " + person.Lng + "), '" + person.ToString() + "'); ");
                }


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


        [ComVisible(true)]
        public class ScriptingObjectFiltered
        {
            private frmOverView frm;

            public ScriptingObjectFiltered(frmOverView frmOverView)
            {
                this.frm = frmOverView;
            }

            // can be called from JavaScript
            public void OnLoad()
            {
                frm.loaded = true;
                if (frm.Searches.Count == 0)
                    return;

                decimal centerLat = frm.Searches.Average(x => x.Lat);
                decimal centerLng = frm.Searches.Average(x => x.Lng);

                frm.EvalCode("map.setCenter({lat: " + centerLat + ", lng: " + centerLng + "}); ");
                frm.EvalCode("map.setZoom(9); ");

                foreach (var search in frm.Searches)
                {
                    frm.EvalCode("setLocationMarker(new google.maps.LatLng(" + search.Lat + ", " + search.Lng + "), '" + search.Name + "'); ");


                    foreach (var person in search.MissingPeople)
                    {
                        if (person.Lat is null || person.Lng is null)
                        {
                            continue;
                        }

                        if (person.PersonStatus == PersonStatus.FoundAlive)
                            frm.EvalCode("setAliveMarker(new google.maps.LatLng(" + person.Lat + ", " + person.Lng + "), '" + person.ToString() + "'); ");
                        else if (person.PersonStatus == PersonStatus.FoundDead)
                            frm.EvalCode("setDeadMarker(new google.maps.LatLng(" + person.Lat + ", " + person.Lng + "), '" + person.ToString() + "'); ");
                    }


                }
            }
        }

        private async void frmOverView_Load(object sender, EventArgs e)
        {
            if (APIService.LoggedInUser != null && NetworkHelper.IsUp())
            {
                var list = await _searchService.Get<List<Model.SearchBackup>>(null, "Backup");

                string appDir = FileHelper.GetAppDir();

                var savedSearches = Directory.GetFiles(appDir, "*.bin", SearchOption.TopDirectoryOnly);


                foreach (var search_backup in list)
                {
                    bool download = true;
                    bool remove_file = false;
                    string file_name_to_remove = null;

                    foreach (string fileName in savedSearches)
                    {
                        if (search_backup.Name + ".bin" == Path.GetFileName(fileName))
                        {
                            DateTime lastModified = File.GetLastWriteTime(fileName);

                            if (lastModified >= search_backup.DateModified)
                            {
                                download = false;
                            }
                            else
                            {
                                remove_file = true;
                                file_name_to_remove = fileName;
                            }

                            break;
                        }
                    }


                    if (download)
                    {
                        if (remove_file)
                            File.Delete(file_name_to_remove);

                        var url = $"{Properties.Settings.Default.APIUrl}/Search/Backup/{search_backup.Name}";
                        await url.WithBasicAuth(APIService.Email, APIService.Password)
                            .DownloadFileAsync(appDir, search_backup.Name + ".bin");
                    }
                }

                APIService.Managers = await ManagerHelper.LoadFromAPI();
                ManagerHelper.SaveToFile(APIService.LoggedInUser.Id, APIService.Managers);
            }
            else
            {
                APIService.Managers = ManagerHelper.LoadFromFile(APIService.OfflineModeUserId);
            }
            UpdateFormData();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            UpdateFormData();
        }

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
                return;

            lblNoSearches.Visible = false;
            webBrowser1.Visible = true;

            webBrowser1.ObjectForScripting = new ScriptingObject(this);

            webBrowser1.Refresh();
        }

        private async void btnRemoveSearch_Click(object sender, EventArgs e)
        {
            if (!(cmbOngoingSearches.SelectedItem is Search SelectedSearch))
            {
                return;
            }

            var response = MessageBox.Show("Are you sure you want to delete the search \"" + SelectedSearch.Name + "\"?", "Delete search", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response != DialogResult.Yes)
                return;

            var update = await _searchService.Update<Model.Search>(SelectedSearch.Name, new Model.Requests.SearchUpdateRequest
            {
                Active = false
            });
            if (update != null)
            {
                string appDir = FileHelper.GetAppDir();
                var file_name_to_remove = Path.Combine(appDir, SelectedSearch.Name + ".bin");
                if (File.Exists(file_name_to_remove))
                    File.Delete(file_name_to_remove);

                MessageBox.Show("Search deleted successfully.", "Delete search", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateFormData();
            }


        }
    }
}

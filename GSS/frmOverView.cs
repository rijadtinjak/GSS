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

namespace GSS
{
    public partial class frmOverView : MaterialForm
    {
        public List<Search> Searches { get; set; } = new List<Search>();

        public frmOverView()
        {
            InitializeComponent();

            UpdateFormData();
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
                Searches.Add(savedSearch);
            }
            Searches = Searches.OrderByDescending(x => x.DateCreated).ToList();

            var FinishedSearches = Searches.Where(x => x.DateClosed != null).ToList();

            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.DataSource = null;
            dgvHistory.DataSource = FinishedSearches;
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
                NewSearch.SetUpSearch(dialog.NumOfZones, dialog.Managers);
                NewSearch.SaveToFile();
                Searches.Add(NewSearch);

                var dialog_analysis = new FrmConsensus(NewSearch);
                dialog_analysis.ShowDialog();

                UpdateFormData();
            }

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

        private void txtNewSearchName_Validating(object sender, CancelEventArgs e)
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

        private void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var SelectedSearch = dgvHistory.SelectedRows[0].DataBoundItem as Search;
            if (SelectedSearch is null)
                return;

            var dialog_analysis = new FrmConsensus(SelectedSearch);
            dialog_analysis.ShowDialog();

            UpdateFormData();
        }
    }
}

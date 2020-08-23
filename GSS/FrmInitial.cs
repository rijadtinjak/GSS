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
    public partial class FrmInitial : MaterialForm
    {
        private bool offlineVersion;

        public FrmInitial(bool offlineVersion = false)
        {
            InitializeComponent();
            this.offlineVersion = offlineVersion;

            if (!offlineVersion)
            {
                webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_IPP.html");
                webBrowser1.ObjectForScripting = new ScriptingObject(this);
            }
            else
            {
                webBrowser1.Url = new Uri("about:blank");
                webBrowser1.Visible = false;
                lblOfflineMode.Visible = true;
            }

            dgvManagers.AutoGenerateColumns = false;
        }

        public List<Manager> Managers
        {
            get
            {
                return dgvManagers.DataSource as List<Manager>;
            }
        }

        public DateTime DateReportedMissing
        {
            get
            {
                return dtpDateReportedMissing.Value.Date + dtpTimeReportedMissing.Value.TimeOfDay;
            }
        }

        public List<Person> MissingPeople
        {
            get
            {
                var temp = new List<Person>();
                foreach (DataGridViewRow row in dgvMissingPeople.Rows)
                {
                    var Person = new Person
                    {
                        FirstName = row.Cells["FirstName"].Value?.ToString(),
                        LastName = row.Cells["LastName"].Value?.ToString(),
                        Age = int.TryParse(row.Cells["Age"].Value?.ToString(), out int result) ? result : 0,
                        Gender = row.Cells["Gender"].Value?.ToString(),
                        PersonStatus = PersonStatus.NotFound
                    };
                    if (!string.IsNullOrWhiteSpace(Person.FirstName))
                        temp.Add(Person);
                }

                return temp;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            DialogResult = DialogResult.OK;
        }

        private void DgvManagers_Validating(object sender, CancelEventArgs e)
        {
            bool valid = dgvManagers.Rows.Count > 0;

            if (!valid)
            {
                errorProvider1.SetError(dgvManagers, "At least 1 manager is required.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(dgvManagers, null);
        }

        private void TxtLat_Validating(object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;
            if (!IsValidLat(control.Text))
                errorProvider1.SetError(control, "Decimal value is required.");
            else
            {
                errorProvider1.SetError(control, null);
                return;
            }
            e.Cancel = true;
        }

        private void TxtLng_Validating(object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;
            if (!IsValidLng(control.Text))
                errorProvider1.SetError(control, "Decimal value is required.");
            else
            {
                errorProvider1.SetError(control, null);
                return;
            }
            e.Cancel = true;
        }

        private void TxtLat_Leave(object sender, EventArgs e)
        {
            if (IsValidLat(txtLat.Text) && IsValidLng(txtLng.Text))
            {
                var lat = InputHelper.ParseDouble(txtLat.Text).ToString("0.00000");
                var lng = InputHelper.ParseDouble(txtLng.Text).ToString("0.00000");

                EvalCode("map.setCenter({lat: " + lat + ", lng: " + lng + "}); ");
                EvalCode("setLocationMarker(new google.maps.LatLng(" + lat + ", " + lng + ")); ");
            }
        }

        public decimal Lat { get => IsValidLat(txtLat.Text) ? InputHelper.ParseDecimal(txtLat.Text) : 0; }
        public decimal Lng { get => IsValidLng(txtLat.Text) ? InputHelper.ParseDecimal(txtLng.Text) : 0; }

        private void EvalCode(string code)
        {
            if (!offlineVersion)
                webBrowser1.Document.InvokeScript("eval", new object[] { code });
        }

        private static bool IsValidLat(string lat)
        {
            return !string.IsNullOrWhiteSpace(lat) && InputHelper.TryParseDouble(lat, out double val) && val >= -90 && val <= 90;
        }
        private static bool IsValidLng(string lng)
        {
            return !string.IsNullOrWhiteSpace(lng) && InputHelper.TryParseDouble(lng, out double val) && val >= -180 && val <= 180;
        }

        [ComVisible(true)]
        public class ScriptingObject
        {
            private readonly FrmInitial frm;

            public ScriptingObject(FrmInitial frmInitial)
            {
                this.frm = frmInitial;
            }

            // can be called from JavaScript
            public void SetLatLng(double lat, double lng)
            {
                frm.txtLat.TextChanged -= frm.TxtLat_Leave;
                frm.txtLng.TextChanged -= frm.TxtLat_Leave;

                frm.txtLat.Text = lat.ToString("0.00000");
                frm.txtLng.Text = lng.ToString("0.00000");

                frm.txtLat.TextChanged += frm.TxtLat_Leave;
                frm.txtLng.TextChanged += frm.TxtLat_Leave;

                frm.dtpDateReportedMissing.Enabled = frm.dtpTimeReportedMissing.Enabled = frm.dgvManagers.Enabled = frm.dgvMissingPeople.Enabled = false;

                frm.ValidateChildren(ValidationConstraints.Enabled);

                frm.dtpDateReportedMissing.Enabled = frm.dtpTimeReportedMissing.Enabled = frm.dgvManagers.Enabled = frm.dgvMissingPeople.Enabled = true;
            }
        }

        private void dgvMissingPeople_Validating(object sender, CancelEventArgs e)
        {
            bool valid = false;

            for (int i = 0; i < dgvMissingPeople.Rows.Count; i++)
            {
                var cmb = dgvMissingPeople.Rows[i].Cells["Gender"].Value;
                if (!string.IsNullOrWhiteSpace(dgvMissingPeople.Rows[i].Cells["FirstName"].Value as string) &&
                    !string.IsNullOrWhiteSpace(dgvMissingPeople.Rows[i].Cells["LastName"].Value as string) &&
                    int.TryParse(dgvMissingPeople.Rows[i].Cells["Age"].Value as string, out int Age)
                    && Age >= 1 && Age <= 127 &&
                    !string.IsNullOrWhiteSpace(cmb as string))
                    valid = true;
            }

            if (!valid)
            {
                errorProvider1.SetError(dgvMissingPeople, "At least 1 missing person is required.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(dgvMissingPeople, null);
        }

        private void FrmInitial_Load(object sender, EventArgs e)
        {
            var list = new List<Manager>(APIService.Managers);
            list.Insert(0, new Manager
            {
                Name = "Select manager"
            });
            cmbManagers.DataSource = list;
            cmbManagers.DisplayMember = "Name";
            cmbManagers.ValueMember = "Id";
        }

        private void cmbManagers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbManagers.SelectedIndex == 0)
                return;

            var selectedManager = cmbManagers.SelectedItem as Manager;

            List<Manager> dgvList = null;
            if (dgvManagers.DataSource is null)
                dgvList = new List<Manager>();
            else
                dgvList = new List<Manager>(dgvManagers.DataSource as List<Manager>);
            dgvList.Add(selectedManager);
            dgvManagers.DataSource = dgvList;

            var cmbList = new List<Manager>(cmbManagers.DataSource as List<Manager>)
                .Where(x => x != selectedManager)
                .ToList();
            cmbManagers.DataSource = cmbList;
            cmbManagers.SelectedIndex = 0;
        }

        private void btnRemoveManager_Click(object sender, EventArgs e)
        {
            List<Manager> dgvList = new List<Manager>(dgvManagers.DataSource as List<Manager>);
            var cmbList = new List<Manager>(cmbManagers.DataSource as List<Manager>);

            for (int i = 0; i < dgvManagers.SelectedRows.Count; i++)
            {
                for (int j = 0; j < dgvList.Count; j++)
                {
                    if (dgvManagers.SelectedRows[i].DataBoundItem is Manager manager && manager.Id == dgvList[j].Id)
                    {
                        cmbList.Add(dgvList[j]);
                        dgvList.RemoveAt(j);
                        j--;
                    }
                }
            }

            dgvManagers.DataSource = dgvList;

            cmbManagers.DataSource = cmbList.OrderBy(x => x.Id).ToList();
            cmbManagers.SelectedIndex = 0;
        }

        private void dgvManagers_SelectionChanged(object sender, EventArgs e)
        {
            btnRemoveManager.Enabled = dgvManagers.SelectedRows.Count != 0;
        }
    }
}

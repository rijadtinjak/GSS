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

namespace GSS
{
    public partial class FrmInitial : Form
    {
        public FrmInitial()
        {
            InitializeComponent();
        }

        public int NumOfZones {
            get => int.TryParse(txtNumZones.Text, out int val) ? val : 0;
            set => txtNumZones.Text=value.ToString();
        }
   
        public List<Manager> Managers {
            get {
                var temp = new List<Manager>();
                for (int i = 0; i < dgvManagers.Rows.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(dgvManagers.Rows[i].Cells["ManagerName"].Value as string))
                        temp.Add(new Manager { Name = dgvManagers.Rows[i].Cells["ManagerName"].Value.ToString() });
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

        private void TxtNumZones_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNumZones.Text) || !int.TryParse(txtNumZones.Text, out int val))
                errorProvider1.SetError(txtNumZones, "Numerical value is required.");
            else if (val < 1 || val > 100)
                errorProvider1.SetError(txtNumZones, "Numerical value between 1 and 100 is required.");
            else
            {
                errorProvider1.SetError(txtNumZones, null);
                return;
            }
            e.Cancel = true;
        }

        private void DgvManagers_Validating(object sender, CancelEventArgs e)
        {
            bool valid = false;

            for (int i = 0; i < dgvManagers.Rows.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(dgvManagers.Rows[i].Cells["ManagerName"].Value as string))
                    valid = true;
            }

            if (!valid)
            {
                errorProvider1.SetError(dgvManagers, "At least 1 manager is required.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(dgvManagers, null);
        }
    }
}

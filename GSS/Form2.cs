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
    public partial class Form2 : Form
    {
        public Form2()
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
                    if (dgvManagers.Rows[i].Cells["ManagerName"].Value != null) 
                    temp.Add(new Manager { Name = dgvManagers.Rows[i].Cells["ManagerName"].Value.ToString() });
                }
                return temp;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    
    }
}

﻿using GSS.Model;
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
        public FrmInitial()
        {
            InitializeComponent();

            webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_IPP.html");
            webBrowser1.ObjectForScripting = new ScriptingObject(this);
        }
   
        public List<Manager> Managers {
            get {
                var temp = new List<Manager>();
                for (int i = 0; i < dgvManagers.Rows.Count; i++)
                {
                    var name = dgvManagers.Rows[i].Cells["ManagerName"].Value;
                    if (name != null && !string.IsNullOrWhiteSpace(name.ToString()))
                        temp.Add(new Manager { Name = name.ToString() });
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

        private void txtLat_Validating(object sender, CancelEventArgs e)
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

        private void txtLng_Validating(object sender, CancelEventArgs e)
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

        private void txtLat_Leave(object sender, EventArgs e)
        {
            if (IsValidLat(txtLat.Text) && IsValidLng(txtLng.Text))
            {
                var lat = double.Parse(txtLat.Text).ToString("0.00000");
                var lng = double.Parse(txtLng.Text).ToString("0.00000");

                EvalCode("map.setCenter({lat: " + lat + ", lng: " + lng + "}); ");
                EvalCode("setLocationMarker(new google.maps.LatLng(" + lat + ", " + lng + ")); ");
            }
        }

        public decimal Lat { get => IsValidLat(txtLat.Text) ? decimal.Parse(txtLat.Text) : 0;  }
        public decimal Lng { get => IsValidLng(txtLat.Text) ? decimal.Parse(txtLng.Text) : 0;  }

        private void EvalCode(string code)
        {
            webBrowser1.Document.InvokeScript("eval", new object[] { code });
        }

        private static bool IsValidLat(string lat)
        {
            return !string.IsNullOrWhiteSpace(lat) && double.TryParse(lat, out double val) && val >= -90 && val <= 90;
        }
        private static bool IsValidLng(string lng)
        {
            return !string.IsNullOrWhiteSpace(lng) && double.TryParse(lng, out double val) && val >= -180 && val <= 180;
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
                frm.txtLat.TextChanged -= frm.txtLat_Leave;
                frm.txtLng.TextChanged -= frm.txtLat_Leave;

                frm.txtLat.Text = lat.ToString("0.00000");
                frm.txtLng.Text = lng.ToString("0.00000");

                frm.txtLat.TextChanged += frm.txtLat_Leave;
                frm.txtLng.TextChanged += frm.txtLat_Leave;
            }
        }

    }
}

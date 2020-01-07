using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace GSS
{
    public partial class FrmLogin : MaterialForm
    {
        private readonly APIService _serviceUser = new APIService("User");

        public FrmLogin()
        {
            InitializeComponent();
            btnLogin.AutoSize = false;
            btnOffline.AutoSize = false;
            btnLogin.Width = 100;
            btnLogin.Height = 20;
            btnOffline.Width = 100;
            btnOffline.Height = 20;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            APIService.Email = txtEmail.Text;
            APIService.Password = txtPassword.Text;
            try
            {
                APIService.LoggedInUser = await _serviceUser.Get<Model.User>(null, "GetCurrentUser");
                if (APIService.LoggedInUser.UserRole == "User")
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Not permitted");
            }
            catch (Exception)
            {
            }
        }

        private void LblPassword_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "gssmostar@gmail.com";
            txtPassword.Text = "gssmostar";
            btnLogin.PerformClick();
        }

        private void BtnOffline_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

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
using GSS.Helper;
using GSS.Model;
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


        private void BtnOffline_Click(object sender, EventArgs e)
        {
            APIService.Email = txtEmail.Text;
            APIService.Password = txtPassword.Text;
            APIService.OfflineMode = true;

            string appDir = FileHelper.GetAppDir();

            var savedSearches = Directory.GetFiles(appDir, "*.bin", SearchOption.TopDirectoryOnly);
            foreach (string fileName in savedSearches)
            {
                Search savedSearch = SearchHelper.LoadFromFile(fileName);
                if (savedSearch != null)
                {
                    if (savedSearch.User != null && savedSearch.User.Email == APIService.Email)
                    {
                        APIService.OfflineModeUserId = savedSearch.UserId;
                        DialogResult = DialogResult.Ignore;
                        return;
                    }

                }
            }

            MessageBox.Show("No saved searches found, please check your email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lblPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmail.Text = "gssmostar@gmail.com";
            txtPassword.Text = "gssmostar";
            if (e.Button == MouseButtons.Left)
                btnLogin.PerformClick();
            else
                btnOffline.PerformClick();
        }
    }
}

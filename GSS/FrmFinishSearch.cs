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
    public partial class FrmFinishSearch : Form
    {
        private readonly string placeholder = "Please enter the search comment, such as the seach result, location of the found person, etc.";
        public string Comment => txtComment.Text;
        public FrmFinishSearch()
        {
            InitializeComponent();
            txtComment.Text = placeholder;
            txtComment.ForeColor = Color.Gray;
        }

        private void btnFinishSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            DialogResult = DialogResult.OK;
        }

        private void txtComment_Enter(object sender, EventArgs e)
        {
            if (Comment == placeholder)
            {
                txtComment.Text = "";
                txtComment.ForeColor = Color.Black;
            }
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            if (Comment == "")
            {
                txtComment.Text = placeholder;
                txtComment.ForeColor = Color.Gray;
            }
        }

        private void txtComment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Comment) || Comment == placeholder)
            {
                errorProvider1.SetError(txtComment, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtComment, null);
            }
        }
    }
}

using GSS.Helper;
using GSS.Model;
using MaterialSkin.Controls;
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
    public partial class FrmFinishSearch : MaterialForm
    {
        private readonly string placeholder = "Please enter the search comment, such as the seach result, location of the found person, etc.";
        public string Comment => txtComment.Text;
        public List<Person> MissingPeople
        {
            get
            {
                var temp = new List<Person>();
                foreach (DataGridViewRow row in dgvMissingPeople.Rows)
                {
                    var status = row.Cells["Status"].Value as string;
                    if (status != null)
                    {
                        PersonStatus StatusEnum;
                        if (status == "Not Found")
                            StatusEnum = PersonStatus.NotFound;
                        else if (status == "Found Alive")
                            StatusEnum = PersonStatus.FoundAlive;
                        else
                            StatusEnum = PersonStatus.FoundDead;

                        var Person = new Person
                        {
                            FirstName = row.Cells["FirstName"].Value?.ToString(),
                            LastName = row.Cells["LastName"].Value?.ToString(),
                            Age = int.TryParse(row.Cells["Age"].Value?.ToString(), out int result) ? result : 0,
                            Gender = row.Cells["Gender"].Value?.ToString(),
                            PersonStatus = StatusEnum,
                            Lat = InputHelper.TryParseDecimal(row.Cells["Lat"].Value.ToString(), out decimal Lat) ? Lat : new decimal?(),
                            Lng = InputHelper.TryParseDecimal(row.Cells["Lng"].Value.ToString(), out decimal Lng) ? Lng : new decimal?(),
                        };
                        temp.Add(Person);
                    }
                }

                return temp;
            }
        }

        public FrmFinishSearch(Search search)
        {
            InitializeComponent();
            txtComment.Text = placeholder;
            txtComment.ForeColor = Color.Gray;

            dgvMissingPeople.AutoGenerateColumns = false;
            dgvMissingPeople.DataSource = search.MissingPeople;

            // Add the events to listen for
            dgvMissingPeople.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dgvMissingPeople.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);

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


        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMissingPeople.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dgvMissingPeople.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // My combobox column is the second one so I hard coded a 1, flavor to taste
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvMissingPeople.Rows[e.RowIndex].Cells[4];
            if (cb.Value != null)
            {
                // do stuff
                //dgvMissingPeople.Invalidate();

                if (cb.Value.ToString() == "Found Alive" || cb.Value.ToString() == "Found Dead")
                {
                    dgvMissingPeople.Rows[e.RowIndex].Cells[5].ReadOnly = false;
                    dgvMissingPeople.Rows[e.RowIndex].Cells[6].ReadOnly = false;
                }
                else
                {

                    dgvMissingPeople.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                    dgvMissingPeople.Rows[e.RowIndex].Cells[5].Value = "";
                    dgvMissingPeople.Rows[e.RowIndex].Cells[6].ReadOnly = true;
                    dgvMissingPeople.Rows[e.RowIndex].Cells[6].Value = "";
                }
            }
        }

    }
}

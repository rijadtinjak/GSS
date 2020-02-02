namespace GSS
{
    partial class FrmFinishSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnFinishSearch = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvMissingPeople = new System.Windows.Forms.DataGridView();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(80, 187);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(351, 97);
            this.txtComment.TabIndex = 2;
            this.txtComment.Enter += new System.EventHandler(this.txtComment_Enter);
            this.txtComment.Leave += new System.EventHandler(this.txtComment_Leave);
            this.txtComment.Validating += new System.ComponentModel.CancelEventHandler(this.txtComment_Validating);
            // 
            // btnFinishSearch
            // 
            this.btnFinishSearch.Location = new System.Drawing.Point(345, 290);
            this.btnFinishSearch.Name = "btnFinishSearch";
            this.btnFinishSearch.Size = new System.Drawing.Size(86, 23);
            this.btnFinishSearch.TabIndex = 1;
            this.btnFinishSearch.Text = "Finish Search";
            this.btnFinishSearch.UseVisualStyleBackColor = true;
            this.btnFinishSearch.Click += new System.EventHandler(this.btnFinishSearch_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(13, 31);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(54, 19);
            this.materialLabel5.TabIndex = 114;
            this.materialLabel5.Text = "people";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(6, 12);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(62, 19);
            this.materialLabel1.TabIndex = 113;
            this.materialLabel1.Text = "Missing";
            // 
            // dgvMissingPeople
            // 
            this.dgvMissingPeople.AllowUserToAddRows = false;
            this.dgvMissingPeople.AllowUserToDeleteRows = false;
            this.dgvMissingPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMissingPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.Age,
            this.Gender,
            this.Status});
            this.dgvMissingPeople.Location = new System.Drawing.Point(80, 12);
            this.dgvMissingPeople.Name = "dgvMissingPeople";
            this.dgvMissingPeople.RowHeadersVisible = false;
            this.dgvMissingPeople.RowHeadersWidth = 72;
            this.dgvMissingPeople.Size = new System.Drawing.Size(351, 148);
            this.dgvMissingPeople.TabIndex = 112;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(5, 186);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 115;
            this.materialLabel2.Text = "Comment";
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.FillWeight = 15F;
            this.FirstName.HeaderText = "First name";
            this.FirstName.MinimumWidth = 9;
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FirstName.Width = 80;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LastName.Width = 80;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Age.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Age.Width = 32;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Gender.Width = 50;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "Not Found",
            "Found Alive",
            "Found Dead"});
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.Width = 85;
            // 
            // FrmFinishSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 329);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dgvMissingPeople);
            this.Controls.Add(this.btnFinishSearch);
            this.Controls.Add(this.txtComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFinishSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finish Search";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnFinishSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dgvMissingPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewComboBoxColumn Gender;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
    }
}
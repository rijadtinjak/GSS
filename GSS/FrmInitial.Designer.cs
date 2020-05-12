namespace GSS
{
    partial class FrmInitial
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
            this.dgvManagers = new System.Windows.Forms.DataGridView();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvMissingPeople = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDateReportedMissing = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeReportedMissing = new System.Windows.Forms.DateTimePicker();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtLat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManagers
            // 
            this.dgvManagers.AllowUserToResizeRows = false;
            this.dgvManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManagerName});
            this.dgvManagers.Location = new System.Drawing.Point(106, 167);
            this.dgvManagers.Name = "dgvManagers";
            this.dgvManagers.RowHeadersVisible = false;
            this.dgvManagers.RowHeadersWidth = 72;
            this.dgvManagers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManagers.Size = new System.Drawing.Size(246, 148);
            this.dgvManagers.TabIndex = 6;
            this.dgvManagers.Validating += new System.ComponentModel.CancelEventHandler(this.DgvManagers_Validating);
            // 
            // ManagerName
            // 
            this.ManagerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManagerName.HeaderText = "Name";
            this.ManagerName.MinimumWidth = 9;
            this.ManagerName.Name = "ManagerName";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Depth = 0;
            this.btnNext.Location = new System.Drawing.Point(871, 437);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.Primary = false;
            this.btnNext.Size = new System.Drawing.Size(46, 36);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(24, 167);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 103;
            this.materialLabel2.Text = "Managers";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Location = new System.Drawing.Point(367, 67);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(554, 362);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("http://w", System.UriKind.Absolute);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(32, 325);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(62, 19);
            this.materialLabel1.TabIndex = 110;
            this.materialLabel1.Text = "Missing";
            // 
            // dgvMissingPeople
            // 
            this.dgvMissingPeople.AllowUserToResizeRows = false;
            this.dgvMissingPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMissingPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.Age,
            this.Gender});
            this.dgvMissingPeople.Location = new System.Drawing.Point(106, 325);
            this.dgvMissingPeople.Name = "dgvMissingPeople";
            this.dgvMissingPeople.RowHeadersVisible = false;
            this.dgvMissingPeople.RowHeadersWidth = 72;
            this.dgvMissingPeople.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMissingPeople.Size = new System.Drawing.Size(246, 148);
            this.dgvMissingPeople.TabIndex = 7;
            this.dgvMissingPeople.Validating += new System.ComponentModel.CancelEventHandler(this.dgvMissingPeople_Validating);
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FirstName.FillWeight = 15F;
            this.FirstName.HeaderText = "First name";
            this.FirstName.MinimumWidth = 9;
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 80;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            this.LastName.Width = 80;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Age.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Age.Width = 32;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.Gender.Name = "Gender";
            this.Gender.Width = 50;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(39, 344);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(54, 19);
            this.materialLabel5.TabIndex = 111;
            this.materialLabel5.Text = "people";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(60, 117);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(100, 19);
            this.materialLabel6.TabIndex = 112;
            this.materialLabel6.Text = "Date reported";
            // 
            // dtpDateReportedMissing
            // 
            this.dtpDateReportedMissing.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateReportedMissing.Location = new System.Drawing.Point(163, 118);
            this.dtpDateReportedMissing.Name = "dtpDateReportedMissing";
            this.dtpDateReportedMissing.Size = new System.Drawing.Size(90, 20);
            this.dtpDateReportedMissing.TabIndex = 4;
            // 
            // dtpTimeReportedMissing
            // 
            this.dtpTimeReportedMissing.CustomFormat = "HH:mm";
            this.dtpTimeReportedMissing.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeReportedMissing.Location = new System.Drawing.Point(262, 117);
            this.dtpTimeReportedMissing.Name = "dtpTimeReportedMissing";
            this.dtpTimeReportedMissing.ShowUpDown = true;
            this.dtpTimeReportedMissing.Size = new System.Drawing.Size(90, 20);
            this.dtpTimeReportedMissing.TabIndex = 5;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(98, 136);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(62, 19);
            this.materialLabel7.TabIndex = 115;
            this.materialLabel7.Text = "missing";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(90, 94);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(70, 19);
            this.materialLabel4.TabIndex = 108;
            this.materialLabel4.Text = "(lat / lng)";
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(262, 78);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(90, 20);
            this.txtLng.TabIndex = 3;
            this.txtLng.TextChanged += new System.EventHandler(this.TxtLat_Leave);
            this.txtLng.Leave += new System.EventHandler(this.TxtLat_Leave);
            this.txtLng.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLng_Validating);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(18, 76);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(142, 19);
            this.materialLabel3.TabIndex = 105;
            this.materialLabel3.Text = "Inital Planning Point";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(163, 78);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(90, 20);
            this.txtLat.TabIndex = 2;
            this.txtLat.TextChanged += new System.EventHandler(this.TxtLat_Leave);
            this.txtLat.Leave += new System.EventHandler(this.TxtLat_Leave);
            this.txtLat.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLat_Validating);
            // 
            // FrmInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 487);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtLng);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.dtpTimeReportedMissing);
            this.Controls.Add(this.dtpDateReportedMissing);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dgvMissingPeople);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dgvManagers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInitial";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Search";
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvManagers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton btnNext;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dgvMissingPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewComboBoxColumn Gender;
        private System.Windows.Forms.DateTimePicker dtpDateReportedMissing;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.DateTimePicker dtpTimeReportedMissing;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.TextBox txtLat;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtLng;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}
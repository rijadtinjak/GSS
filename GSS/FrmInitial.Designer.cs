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
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDateReportedMissing = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeReportedMissing = new System.Windows.Forms.DateTimePicker();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblOfflineMode = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnRemoveManager = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManagers
            // 
            this.dgvManagers.AllowUserToAddRows = false;
            this.dgvManagers.AllowUserToDeleteRows = false;
            this.dgvManagers.AllowUserToResizeRows = false;
            this.dgvManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManagerName});
            this.dgvManagers.Location = new System.Drawing.Point(16, 270);
            this.dgvManagers.Name = "dgvManagers";
            this.dgvManagers.ReadOnly = true;
            this.dgvManagers.RowHeadersVisible = false;
            this.dgvManagers.RowHeadersWidth = 72;
            this.dgvManagers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManagers.Size = new System.Drawing.Size(246, 119);
            this.dgvManagers.TabIndex = 6;
            this.dgvManagers.Validating += new System.ComponentModel.CancelEventHandler(this.DgvManagers_Validating);
            // 
            // ManagerName
            // 
            this.ManagerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManagerName.HeaderText = "Name";
            this.ManagerName.MinimumWidth = 9;
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.ReadOnly = true;
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
            this.btnNext.Location = new System.Drawing.Point(781, 488);
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
            this.materialLabel2.Location = new System.Drawing.Point(12, 195);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 103;
            this.materialLabel2.Text = "Managers";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Location = new System.Drawing.Point(277, 66);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(554, 412);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("http://w", System.UriKind.Absolute);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(18, 397);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(111, 19);
            this.materialLabel1.TabIndex = 110;
            this.materialLabel1.Text = "Missing people";
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
            this.dgvMissingPeople.Location = new System.Drawing.Point(16, 421);
            this.dgvMissingPeople.Name = "dgvMissingPeople";
            this.dgvMissingPeople.RowHeadersVisible = false;
            this.dgvMissingPeople.RowHeadersWidth = 72;
            this.dgvMissingPeople.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMissingPeople.Size = new System.Drawing.Size(246, 103);
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
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(12, 134);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(157, 19);
            this.materialLabel6.TabIndex = 112;
            this.materialLabel6.Text = "Date reported missing";
            // 
            // dtpDateReportedMissing
            // 
            this.dtpDateReportedMissing.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateReportedMissing.Location = new System.Drawing.Point(16, 160);
            this.dtpDateReportedMissing.Name = "dtpDateReportedMissing";
            this.dtpDateReportedMissing.Size = new System.Drawing.Size(113, 20);
            this.dtpDateReportedMissing.TabIndex = 4;
            // 
            // dtpTimeReportedMissing
            // 
            this.dtpTimeReportedMissing.CustomFormat = "HH:mm";
            this.dtpTimeReportedMissing.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeReportedMissing.Location = new System.Drawing.Point(150, 160);
            this.dtpTimeReportedMissing.Name = "dtpTimeReportedMissing";
            this.dtpTimeReportedMissing.ShowUpDown = true;
            this.dtpTimeReportedMissing.Size = new System.Drawing.Size(112, 20);
            this.dtpTimeReportedMissing.TabIndex = 5;
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(150, 105);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(112, 20);
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
            this.materialLabel3.Location = new System.Drawing.Point(12, 77);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(207, 19);
            this.materialLabel3.TabIndex = 105;
            this.materialLabel3.Text = "Inital Planning Point (lat / lng)";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(16, 105);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(113, 20);
            this.txtLat.TabIndex = 2;
            this.txtLat.TextChanged += new System.EventHandler(this.TxtLat_Leave);
            this.txtLat.Leave += new System.EventHandler(this.TxtLat_Leave);
            this.txtLat.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLat_Validating);
            // 
            // lblOfflineMode
            // 
            this.lblOfflineMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOfflineMode.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblOfflineMode.Location = new System.Drawing.Point(277, 64);
            this.lblOfflineMode.Name = "lblOfflineMode";
            this.lblOfflineMode.Size = new System.Drawing.Size(564, 412);
            this.lblOfflineMode.TabIndex = 116;
            this.lblOfflineMode.Text = "Map is not available in offline mode.";
            this.lblOfflineMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOfflineMode.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 228);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 117;
            // 
            // btnRemoveManager
            // 
            this.btnRemoveManager.Location = new System.Drawing.Point(186, 227);
            this.btnRemoveManager.Name = "btnRemoveManager";
            this.btnRemoveManager.Size = new System.Drawing.Size(76, 23);
            this.btnRemoveManager.TabIndex = 118;
            this.btnRemoveManager.Text = "Remove";
            this.btnRemoveManager.UseVisualStyleBackColor = true;
            // 
            // FrmInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(841, 535);
            this.Controls.Add(this.btnRemoveManager);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblOfflineMode);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtLng);
            this.Controls.Add(this.dtpTimeReportedMissing);
            this.Controls.Add(this.dtpDateReportedMissing);
            this.Controls.Add(this.materialLabel6);
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
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dgvMissingPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewComboBoxColumn Gender;
        private System.Windows.Forms.DateTimePicker dtpDateReportedMissing;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.DateTimePicker dtpTimeReportedMissing;
        private System.Windows.Forms.TextBox txtLat;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label lblOfflineMode;
        private System.Windows.Forms.Button btnRemoveManager;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
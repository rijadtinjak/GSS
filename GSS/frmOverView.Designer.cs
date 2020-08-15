namespace GSS
{
    partial class frmOverView
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
            this.spSearches = new System.Windows.Forms.SplitContainer();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbOngoingSearches = new System.Windows.Forms.ComboBox();
            this.x = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoSearches = new System.Windows.Forms.Label();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lbHistory = new System.Windows.Forms.Label();
            this.lblNewSearch = new System.Windows.Forms.Label();
            this.txtNewSearchName = new System.Windows.Forms.TextBox();
            this.spOverview = new System.Windows.Forms.SplitContainer();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.xs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spSearches)).BeginInit();
            this.spSearches.Panel1.SuspendLayout();
            this.spSearches.Panel2.SuspendLayout();
            this.spSearches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spOverview)).BeginInit();
            this.spOverview.Panel1.SuspendLayout();
            this.spOverview.Panel2.SuspendLayout();
            this.spOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // spSearches
            // 
            this.spSearches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spSearches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spSearches.Location = new System.Drawing.Point(0, 0);
            this.spSearches.Name = "spSearches";
            this.spSearches.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spSearches.Panel1
            // 
            this.spSearches.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spSearches.Panel1.Controls.Add(this.materialLabel2);
            this.spSearches.Panel1.Controls.Add(this.cmbOngoingSearches);
            this.spSearches.Panel1.Controls.Add(this.x);
            this.spSearches.Panel1.Controls.Add(this.label2);
            // 
            // spSearches.Panel2
            // 
            this.spSearches.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spSearches.Panel2.Controls.Add(this.splitContainer1);
            this.spSearches.Panel2.Controls.Add(this.lbHistory);
            this.spSearches.Size = new System.Drawing.Size(1003, 600);
            this.spSearches.SplitterDistance = 105;
            this.spSearches.TabIndex = 0;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(10, 47);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(49, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Name";
            // 
            // cmbOngoingSearches
            // 
            this.cmbOngoingSearches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOngoingSearches.FormattingEnabled = true;
            this.cmbOngoingSearches.Location = new System.Drawing.Point(62, 47);
            this.cmbOngoingSearches.Name = "cmbOngoingSearches";
            this.cmbOngoingSearches.Size = new System.Drawing.Size(263, 21);
            this.cmbOngoingSearches.TabIndex = 3;
            // 
            // x
            // 
            this.x.BackColor = System.Drawing.Color.Gainsboro;
            this.x.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.x.FlatAppearance.BorderSize = 0;
            this.x.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x.Location = new System.Drawing.Point(346, 46);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(120, 22);
            this.x.TabIndex = 4;
            this.x.Text = "OPEN";
            this.x.UseVisualStyleBackColor = false;
            this.x.Click += new System.EventHandler(this.BtnOpenSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ongoing Search";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(14, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClearSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchName);
            this.splitContainer1.Panel1.Controls.Add(this.btnFilter);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbFilterStatus);
            this.splitContainer1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvHistory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblNoSearches);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel3);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel4);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel5);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(984, 461);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 106;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(104, 56);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(96, 23);
            this.btnClearSearch.TabIndex = 12;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name:";
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(52, 29);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(96, 20);
            this.txtSearchName.TabIndex = 10;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(206, 56);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(102, 23);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status:";
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "Any",
            "Not Found",
            "Found Alive",
            "Found Dead"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(206, 29);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(101, 21);
            this.cmbFilterStatus.TabIndex = 6;
            this.cmbFilterStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(207, 5);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(101, 20);
            this.dtpEnd.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(52, 5);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(96, 20);
            this.dtpStart.TabIndex = 4;
            this.dtpStart.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.DateCreated,
            this.DateClosed});
            this.dgvHistory.Location = new System.Drawing.Point(0, 85);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(328, 374);
            this.dgvHistory.TabIndex = 2;
            this.dgvHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistory_CellDoubleClick);
            this.dgvHistory.SelectionChanged += new System.EventHandler(this.dgvHistory_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Search Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Date of search";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            // 
            // DateClosed
            // 
            this.DateClosed.DataPropertyName = "DateClosed";
            this.DateClosed.HeaderText = "Date closed";
            this.DateClosed.Name = "DateClosed";
            this.DateClosed.ReadOnly = true;
            // 
            // lblNoSearches
            // 
            this.lblNoSearches.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNoSearches.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblNoSearches.Location = new System.Drawing.Point(222, 178);
            this.lblNoSearches.Name = "lblNoSearches";
            this.lblNoSearches.Size = new System.Drawing.Size(224, 109);
            this.lblNoSearches.TabIndex = 107;
            this.lblNoSearches.Text = "Click on a finished search to show a detailed map.";
            this.lblNoSearches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(40, 11);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(146, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Initial Planning Point";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(236, 11);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(87, 19);
            this.materialLabel4.TabIndex = 109;
            this.materialLabel4.Text = "Found Alive";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(436, 10);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(88, 19);
            this.materialLabel5.TabIndex = 110;
            this.materialLabel5.Text = "Found Dead";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GSS.Properties.Resources.IPP;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 45);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GSS.Properties.Resources.icon_alive;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(200, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 45);
            this.pictureBox2.TabIndex = 107;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::GSS.Properties.Resources.icon_dead;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(400, -2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 45);
            this.pictureBox3.TabIndex = 108;
            this.pictureBox3.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 43);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(652, 418);
            this.webBrowser1.TabIndex = 105;
            this.webBrowser1.Visible = false;
            // 
            // lbHistory
            // 
            this.lbHistory.AutoSize = true;
            this.lbHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHistory.Location = new System.Drawing.Point(10, 5);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(141, 20);
            this.lbHistory.TabIndex = 3;
            this.lbHistory.Text = "Finished Searches";
            // 
            // lblNewSearch
            // 
            this.lblNewSearch.AutoSize = true;
            this.lblNewSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewSearch.Location = new System.Drawing.Point(10, 10);
            this.lblNewSearch.Name = "lblNewSearch";
            this.lblNewSearch.Size = new System.Drawing.Size(95, 20);
            this.lblNewSearch.TabIndex = 0;
            this.lblNewSearch.Text = "New Search";
            // 
            // txtNewSearchName
            // 
            this.txtNewSearchName.Location = new System.Drawing.Point(62, 44);
            this.txtNewSearchName.Name = "txtNewSearchName";
            this.txtNewSearchName.Size = new System.Drawing.Size(264, 20);
            this.txtNewSearchName.TabIndex = 1;
            this.txtNewSearchName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtNewSearchName_Validating);
            // 
            // spOverview
            // 
            this.spOverview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spOverview.IsSplitterFixed = true;
            this.spOverview.Location = new System.Drawing.Point(0, 62);
            this.spOverview.Name = "spOverview";
            this.spOverview.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spOverview.Panel1
            // 
            this.spOverview.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spOverview.Panel1.Controls.Add(this.materialLabel1);
            this.spOverview.Panel1.Controls.Add(this.txtNewSearchName);
            this.spOverview.Panel1.Controls.Add(this.xs);
            this.spOverview.Panel1.Controls.Add(this.lblNewSearch);
            // 
            // spOverview.Panel2
            // 
            this.spOverview.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.spOverview.Panel2.Controls.Add(this.spSearches);
            this.spOverview.Size = new System.Drawing.Size(1003, 690);
            this.spOverview.SplitterDistance = 86;
            this.spOverview.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(11, 45);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Name";
            // 
            // xs
            // 
            this.xs.BackColor = System.Drawing.Color.Gainsboro;
            this.xs.FlatAppearance.BorderSize = 0;
            this.xs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xs.Location = new System.Drawing.Point(346, 42);
            this.xs.Name = "xs";
            this.xs.Size = new System.Drawing.Size(120, 22);
            this.xs.TabIndex = 2;
            this.xs.Text = "START SEARCH";
            this.xs.UseVisualStyleBackColor = false;
            this.xs.Click += new System.EventHandler(this.BtnStartSearch_Click);
            // 
            // frmOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1003, 752);
            this.Controls.Add(this.spOverview);
            this.MaximizeBox = false;
            this.Name = "frmOverView";
            this.Padding = new System.Windows.Forms.Padding(0, 62, 0, 0);
            this.Sizable = false;
            this.Text = "Overview";
            this.Load += new System.EventHandler(this.frmOverView_Load);
            this.spSearches.Panel1.ResumeLayout(false);
            this.spSearches.Panel1.PerformLayout();
            this.spSearches.Panel2.ResumeLayout(false);
            this.spSearches.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSearches)).EndInit();
            this.spSearches.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.spOverview.Panel1.ResumeLayout(false);
            this.spOverview.Panel1.PerformLayout();
            this.spOverview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spOverview)).EndInit();
            this.spOverview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spSearches;
        private System.Windows.Forms.ComboBox cmbOngoingSearches;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label lblNewSearch;
        private System.Windows.Forms.TextBox txtNewSearchName;
        private System.Windows.Forms.SplitContainer spOverview;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Button xs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateClosed;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblNoSearches;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearSearch;

        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
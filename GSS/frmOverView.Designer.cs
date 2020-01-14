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
            this.lbHistory = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lblNewSearch = new System.Windows.Forms.Label();
            this.txtNewSearchName = new System.Windows.Forms.TextBox();
            this.spOverview = new System.Windows.Forms.SplitContainer();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.xs = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spSearches)).BeginInit();
            this.spSearches.Panel1.SuspendLayout();
            this.spSearches.Panel2.SuspendLayout();
            this.spSearches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
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
            this.spSearches.Panel2.Controls.Add(this.lbHistory);
            this.spSearches.Panel2.Controls.Add(this.dgvHistory);
            this.spSearches.Size = new System.Drawing.Size(475, 391);
            this.spSearches.SplitterDistance = 92;
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
            this.cmbOngoingSearches.TabIndex = 4;
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
            this.x.TabIndex = 3;
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
            this.dgvHistory.Location = new System.Drawing.Point(3, 33);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(463, 254);
            this.dgvHistory.TabIndex = 2;
            this.dgvHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistory_CellDoubleClick);
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
            this.txtNewSearchName.TabIndex = 2;
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
            this.spOverview.Size = new System.Drawing.Size(475, 495);
            this.spOverview.SplitterDistance = 100;
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
            this.xs.TabIndex = 1;
            this.xs.Text = "START SEARCH";
            this.xs.UseVisualStyleBackColor = false;
            this.xs.Click += new System.EventHandler(this.BtnStartSearch_Click);
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
            // frmOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(475, 557);
            this.Controls.Add(this.spOverview);
            this.MaximizeBox = false;
            this.Name = "frmOverView";
            this.Padding = new System.Windows.Forms.Padding(0, 62, 0, 0);
            this.Sizable = false;
            this.Text = "Overview";
            this.spSearches.Panel1.ResumeLayout(false);
            this.spSearches.Panel1.PerformLayout();
            this.spSearches.Panel2.ResumeLayout(false);
            this.spSearches.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSearches)).EndInit();
            this.spSearches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
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
    }
}
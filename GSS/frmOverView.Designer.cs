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
            this.spOverview = new System.Windows.Forms.SplitContainer();
            this.lblNewSearch = new System.Windows.Forms.Label();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblNewSearchName = new System.Windows.Forms.Label();
            this.spSearches = new System.Windows.Forms.SplitContainer();
            this.lbHistory = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbOngoingSearches = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spOverview)).BeginInit();
            this.spOverview.Panel1.SuspendLayout();
            this.spOverview.Panel2.SuspendLayout();
            this.spOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSearches)).BeginInit();
            this.spSearches.Panel1.SuspendLayout();
            this.spSearches.Panel2.SuspendLayout();
            this.spSearches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // spOverview
            // 
            this.spOverview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spOverview.Location = new System.Drawing.Point(0, 0);
            this.spOverview.Name = "spOverview";
            this.spOverview.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spOverview.Panel1
            // 
            this.spOverview.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.spOverview.Panel1.Controls.Add(this.lblNewSearchName);
            this.spOverview.Panel1.Controls.Add(this.textBox1);
            this.spOverview.Panel1.Controls.Add(this.btnStartSearch);
            this.spOverview.Panel1.Controls.Add(this.lblNewSearch);
            this.spOverview.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.SpOverview_Panel1_Paint);
            // 
            // spOverview.Panel2
            // 
            this.spOverview.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.spOverview.Panel2.Controls.Add(this.spSearches);
            this.spOverview.Size = new System.Drawing.Size(537, 450);
            this.spOverview.SplitterDistance = 79;
            this.spOverview.TabIndex = 0;
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
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(321, 41);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStartSearch.TabIndex = 1;
            this.btnStartSearch.Text = "Start Search";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lblNewSearchName
            // 
            this.lblNewSearchName.AutoSize = true;
            this.lblNewSearchName.Location = new System.Drawing.Point(10, 47);
            this.lblNewSearchName.Name = "lblNewSearchName";
            this.lblNewSearchName.Size = new System.Drawing.Size(35, 13);
            this.lblNewSearchName.TabIndex = 3;
            this.lblNewSearchName.Text = "Name";
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
            this.spSearches.Panel1.Controls.Add(this.label1);
            this.spSearches.Panel1.Controls.Add(this.cmbOngoingSearches);
            this.spSearches.Panel1.Controls.Add(this.btnOpen);
            this.spSearches.Panel1.Controls.Add(this.label2);
            // 
            // spSearches.Panel2
            // 
            this.spSearches.Panel2.Controls.Add(this.lbHistory);
            this.spSearches.Panel2.Controls.Add(this.dataGridView1);
            this.spSearches.Size = new System.Drawing.Size(537, 367);
            this.spSearches.SplitterDistance = 71;
            this.spSearches.TabIndex = 0;
            // 
            // lbHistory
            // 
            this.lbHistory.AutoSize = true;
            this.lbHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHistory.Location = new System.Drawing.Point(10, 5);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(58, 20);
            this.lbHistory.TabIndex = 3;
            this.lbHistory.Text = "History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(3, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(529, 254);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Search Name";
            this.Column1.Name = "Column1";
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
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(321, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // cmbOngoingSearches
            // 
            this.cmbOngoingSearches.FormattingEnabled = true;
            this.cmbOngoingSearches.Location = new System.Drawing.Point(52, 37);
            this.cmbOngoingSearches.Name = "cmbOngoingSearches";
            this.cmbOngoingSearches.Size = new System.Drawing.Size(263, 21);
            this.cmbOngoingSearches.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // frmOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 450);
            this.Controls.Add(this.spOverview);
            this.Name = "frmOverView";
            this.Text = "Overview";
            this.spOverview.Panel1.ResumeLayout(false);
            this.spOverview.Panel1.PerformLayout();
            this.spOverview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spOverview)).EndInit();
            this.spOverview.ResumeLayout(false);
            this.spSearches.Panel1.ResumeLayout(false);
            this.spSearches.Panel1.PerformLayout();
            this.spSearches.Panel2.ResumeLayout(false);
            this.spSearches.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSearches)).EndInit();
            this.spSearches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spOverview;
        private System.Windows.Forms.Label lblNewSearch;
        private System.Windows.Forms.Label lblNewSearchName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.SplitContainer spSearches;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbHistory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cmbOngoingSearches;
        private System.Windows.Forms.Label label1;
    }
}
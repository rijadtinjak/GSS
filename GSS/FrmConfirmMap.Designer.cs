namespace GSS
{
    partial class FrmConfirmMap
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
            this.dgvSegments = new System.Windows.Forms.DataGridView();
            this.SegmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvZones = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSegments
            // 
            this.dgvSegments.AllowUserToAddRows = false;
            this.dgvSegments.AllowUserToDeleteRows = false;
            this.dgvSegments.AllowUserToResizeColumns = false;
            this.dgvSegments.AllowUserToResizeRows = false;
            this.dgvSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SegmentName,
            this.Area});
            this.dgvSegments.Location = new System.Drawing.Point(137, 277);
            this.dgvSegments.Name = "dgvSegments";
            this.dgvSegments.ReadOnly = true;
            this.dgvSegments.RowHeadersVisible = false;
            this.dgvSegments.RowHeadersWidth = 72;
            this.dgvSegments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSegments.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSegments.Size = new System.Drawing.Size(189, 192);
            this.dgvSegments.TabIndex = 5;
            this.dgvSegments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSegments_DataBindingComplete);
            this.dgvSegments.SelectionChanged += new System.EventHandler(this.DgvSegments_SelectionChanged);
            // 
            // SegmentName
            // 
            this.SegmentName.DataPropertyName = "Name";
            this.SegmentName.HeaderText = "Name";
            this.SegmentName.MinimumWidth = 90;
            this.SegmentName.Name = "SegmentName";
            this.SegmentName.ReadOnly = true;
            this.SegmentName.Width = 150;
            // 
            // Area
            // 
            this.Area.DataPropertyName = "Area";
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 50;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 75;
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
            this.btnNext.Location = new System.Drawing.Point(859, 478);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.Primary = false;
            this.btnNext.Size = new System.Drawing.Size(46, 36);
            this.btnNext.TabIndex = 102;
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
            this.materialLabel2.Location = new System.Drawing.Point(50, 277);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(76, 19);
            this.materialLabel2.TabIndex = 103;
            this.materialLabel2.Text = "Segments";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Location = new System.Drawing.Point(352, 69);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(553, 395);
            this.webBrowser1.TabIndex = 104;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(75, 73);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(51, 19);
            this.materialLabel1.TabIndex = 107;
            this.materialLabel1.Text = "Zones";
            // 
            // dgvZones
            // 
            this.dgvZones.AllowUserToAddRows = false;
            this.dgvZones.AllowUserToDeleteRows = false;
            this.dgvZones.AllowUserToResizeColumns = false;
            this.dgvZones.AllowUserToResizeRows = false;
            this.dgvZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvZones.Location = new System.Drawing.Point(137, 73);
            this.dgvZones.MultiSelect = false;
            this.dgvZones.Name = "dgvZones";
            this.dgvZones.ReadOnly = true;
            this.dgvZones.RowHeadersVisible = false;
            this.dgvZones.RowHeadersWidth = 72;
            this.dgvZones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvZones.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZones.Size = new System.Drawing.Size(189, 192);
            this.dgvZones.TabIndex = 106;
            this.dgvZones.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvZones_DataBindingComplete);
            this.dgvZones.SelectionChanged += new System.EventHandler(this.dgvZones_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 90;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Area";
            this.dataGridViewTextBoxColumn2.HeaderText = "Area";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // FrmConfirmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 516);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dgvZones);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dgvSegments);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfirmMap";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm Search Area";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSegments;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton btnNext;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dgvZones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
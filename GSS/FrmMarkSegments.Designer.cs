namespace GSS
{
    partial class FrmMarkSegments
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnNewSegment = new System.Windows.Forms.Button();
            this.BtnFinishSegment = new System.Windows.Forms.Button();
            this.BtnEditSegment = new System.Windows.Forms.Button();
            this.BtnDeleteSegment = new System.Windows.Forms.Button();
            this.SegmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSegments
            // 
            this.dgvSegments.AllowUserToAddRows = false;
            this.dgvSegments.AllowUserToDeleteRows = false;
            this.dgvSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SegmentName,
            this.Area});
            this.dgvSegments.Location = new System.Drawing.Point(205, 80);
            this.dgvSegments.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvSegments.MultiSelect = false;
            this.dgvSegments.Name = "dgvSegments";
            this.dgvSegments.ReadOnly = true;
            this.dgvSegments.RowHeadersVisible = false;
            this.dgvSegments.RowHeadersWidth = 72;
            this.dgvSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSegments.Size = new System.Drawing.Size(284, 296);
            this.dgvSegments.TabIndex = 5;
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
            this.btnNext.Location = new System.Drawing.Point(1318, 613);
            this.btnNext.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.Primary = false;
            this.btnNext.Size = new System.Drawing.Size(66, 36);
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
            this.materialLabel2.Location = new System.Drawing.Point(75, 80);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(110, 27);
            this.materialLabel2.TabIndex = 103;
            this.materialLabel2.Text = "Segments";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Location = new System.Drawing.Point(528, 80);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(30, 31);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(830, 487);
            this.webBrowser1.TabIndex = 104;
            // 
            // BtnNewSegment
            // 
            this.BtnNewSegment.Location = new System.Drawing.Point(205, 394);
            this.BtnNewSegment.Name = "BtnNewSegment";
            this.BtnNewSegment.Size = new System.Drawing.Size(135, 35);
            this.BtnNewSegment.TabIndex = 105;
            this.BtnNewSegment.Text = "New Segment";
            this.BtnNewSegment.UseVisualStyleBackColor = true;
            this.BtnNewSegment.Click += new System.EventHandler(this.BtnNewSegment_Click);
            // 
            // BtnFinishSegment
            // 
            this.BtnFinishSegment.Enabled = false;
            this.BtnFinishSegment.Location = new System.Drawing.Point(354, 394);
            this.BtnFinishSegment.Name = "BtnFinishSegment";
            this.BtnFinishSegment.Size = new System.Drawing.Size(135, 35);
            this.BtnFinishSegment.TabIndex = 106;
            this.BtnFinishSegment.Text = "Finish Segment";
            this.BtnFinishSegment.UseVisualStyleBackColor = true;
            this.BtnFinishSegment.Click += new System.EventHandler(this.BtnFinishSegment_Click);
            // 
            // BtnEditSegment
            // 
            this.BtnEditSegment.Enabled = false;
            this.BtnEditSegment.Location = new System.Drawing.Point(205, 435);
            this.BtnEditSegment.Name = "BtnEditSegment";
            this.BtnEditSegment.Size = new System.Drawing.Size(135, 35);
            this.BtnEditSegment.TabIndex = 107;
            this.BtnEditSegment.Text = "Edit Segment";
            this.BtnEditSegment.UseVisualStyleBackColor = true;
            this.BtnEditSegment.Click += new System.EventHandler(this.BtnEditSegment_Click);
            // 
            // BtnDeleteSegment
            // 
            this.BtnDeleteSegment.Enabled = false;
            this.BtnDeleteSegment.Location = new System.Drawing.Point(354, 435);
            this.BtnDeleteSegment.Name = "BtnDeleteSegment";
            this.BtnDeleteSegment.Size = new System.Drawing.Size(135, 35);
            this.BtnDeleteSegment.TabIndex = 108;
            this.BtnDeleteSegment.Text = "Delete Segment";
            this.BtnDeleteSegment.UseVisualStyleBackColor = true;
            // 
            // SegmentName
            // 
            this.SegmentName.DataPropertyName = "Name";
            this.SegmentName.HeaderText = "Name";
            this.SegmentName.MinimumWidth = 90;
            this.SegmentName.Name = "SegmentName";
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
            // FrmMarkSegments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 660);
            this.Controls.Add(this.BtnDeleteSegment);
            this.Controls.Add(this.BtnEditSegment);
            this.Controls.Add(this.BtnFinishSegment);
            this.Controls.Add(this.BtnNewSegment);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dgvSegments);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMarkSegments";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mark Segments";
            this.Load += new System.EventHandler(this.FrmMarkSegments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSegments;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton btnNext;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnNewSegment;
        private System.Windows.Forms.Button BtnFinishSegment;
        private System.Windows.Forms.Button BtnEditSegment;
        private System.Windows.Forms.Button BtnDeleteSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
    }
}
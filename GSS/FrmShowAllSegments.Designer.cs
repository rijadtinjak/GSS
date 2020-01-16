namespace GSS
{
    partial class FrmShowAllSegments
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
            this.tlpSortedSegments = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tlpSortedSegments.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSortedSegments
            // 
            this.tlpSortedSegments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpSortedSegments.AutoScroll = true;
            this.tlpSortedSegments.BackColor = System.Drawing.Color.GhostWhite;
            this.tlpSortedSegments.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpSortedSegments.ColumnCount = 3;
            this.tlpSortedSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.54369F));
            this.tlpSortedSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.27184F));
            this.tlpSortedSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.18447F));
            this.tlpSortedSegments.Controls.Add(this.label1, 1, 0);
            this.tlpSortedSegments.Controls.Add(this.label4, 2, 0);
            this.tlpSortedSegments.Controls.Add(this.label3, 0, 0);
            this.tlpSortedSegments.Location = new System.Drawing.Point(33, 170);
            this.tlpSortedSegments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpSortedSegments.MaximumSize = new System.Drawing.Size(315, 550);
            this.tlpSortedSegments.Name = "tlpSortedSegments";
            this.tlpSortedSegments.RowCount = 1;
            this.tlpSortedSegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpSortedSegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpSortedSegments.Size = new System.Drawing.Size(315, 34);
            this.tlpSortedSegments.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Segment name";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 70;
            this.label1.Text = "PoA";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 71;
            this.label4.Text = "PoSCum";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label42.Location = new System.Drawing.Point(38, 115);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(196, 29);
            this.label42.TabIndex = 34;
            this.label42.Text = "Sorted segments";
            // 
            // FrmShowAllSegments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 740);
            this.Controls.Add(this.tlpSortedSegments);
            this.Controls.Add(this.label42);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowAllSegments";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Segments";
            this.Load += new System.EventHandler(this.FrmShowAllSegments_Load);
            this.tlpSortedSegments.ResumeLayout(false);
            this.tlpSortedSegments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSortedSegments;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}
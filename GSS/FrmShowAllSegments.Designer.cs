﻿namespace GSS
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tlpSortedSegments.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSortedSegments
            // 
            this.tlpSortedSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSortedSegments.AutoScroll = true;
            this.tlpSortedSegments.BackColor = System.Drawing.SystemColors.Info;
            this.tlpSortedSegments.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpSortedSegments.ColumnCount = 3;
            this.tlpSortedSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSortedSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSortedSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSortedSegments.Controls.Add(this.label2, 2, 0);
            this.tlpSortedSegments.Controls.Add(this.label1, 0, 0);
            this.tlpSortedSegments.Controls.Add(this.label22, 1, 0);
            this.tlpSortedSegments.Location = new System.Drawing.Point(38, 32);
            this.tlpSortedSegments.MaximumSize = new System.Drawing.Size(201, 530);
            this.tlpSortedSegments.Name = "tlpSortedSegments";
            this.tlpSortedSegments.RowCount = 1;
            this.tlpSortedSegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpSortedSegments.Size = new System.Drawing.Size(201, 20);
            this.tlpSortedSegments.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(153, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 68;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 38;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(103, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 18);
            this.label22.TabIndex = 67;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label42.Location = new System.Drawing.Point(41, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(137, 20);
            this.label42.TabIndex = 34;
            this.label42.Text = "Sortirani segmenti";
            // 
            // FrmShowAllSegments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 583);
            this.Controls.Add(this.tlpSortedSegments);
            this.Controls.Add(this.label42);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowAllSegments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmShowAllSegments";
            this.Load += new System.EventHandler(this.FrmShowAllSegments_Load);
            this.tlpSortedSegments.ResumeLayout(false);
            this.tlpSortedSegments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSortedSegments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label2;
    }
}
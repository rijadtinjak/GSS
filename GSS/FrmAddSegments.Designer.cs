﻿namespace GSS
{
    partial class FrmAddSegments
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
            this.tabZones = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabZones
            // 
            this.tabZones.Location = new System.Drawing.Point(21, 78);
            this.tabZones.Name = "tabZones";
            this.tabZones.SelectedIndex = 0;
            this.tabZones.Size = new System.Drawing.Size(350, 413);
            this.tabZones.TabIndex = 0;
            // 
            // FrmAddSegments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 524);
            this.Controls.Add(this.tabZones);
            this.MaximizeBox = false;
            this.Name = "FrmAddSegments";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Segments";
            this.Load += new System.EventHandler(this.FrmAddSegments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabZones;
    }
}
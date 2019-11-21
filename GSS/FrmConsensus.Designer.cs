namespace GSS
{
    partial class FrmConsensus
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
            this.label5 = new System.Windows.Forms.Label();
            this.tlpZones = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.frame = new System.Windows.Forms.Panel();
            this.BtnAddZone = new System.Windows.Forms.Button();
            this.btnAddSegments = new System.Windows.Forms.Button();
            this.tlpZones.SuspendLayout();
            this.frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Unos podataka";
            // 
            // tlpZones
            // 
            this.tlpZones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpZones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tlpZones.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpZones.ColumnCount = 1;
            this.tlpZones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpZones.Controls.Add(this.label15, 0, 0);
            this.tlpZones.Location = new System.Drawing.Point(0, 0);
            this.tlpZones.Margin = new System.Windows.Forms.Padding(0);
            this.tlpZones.MaximumSize = new System.Drawing.Size(650, 220);
            this.tlpZones.Name = "tlpZones";
            this.tlpZones.RowCount = 1;
            this.tlpZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpZones.Size = new System.Drawing.Size(100, 26);
            this.tlpZones.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.Location = new System.Drawing.Point(9, 7);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 23);
            this.label15.TabIndex = 68;
            this.label15.Text = "Ocjenjivac";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frame
            // 
            this.frame.Controls.Add(this.tlpZones);
            this.frame.Location = new System.Drawing.Point(15, 33);
            this.frame.Margin = new System.Windows.Forms.Padding(0);
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(635, 215);
            this.frame.TabIndex = 35;
            // 
            // BtnAddZone
            // 
            this.BtnAddZone.Location = new System.Drawing.Point(412, 251);
            this.BtnAddZone.Name = "BtnAddZone";
            this.BtnAddZone.Size = new System.Drawing.Size(105, 23);
            this.BtnAddZone.TabIndex = 37;
            this.BtnAddZone.Text = "Add Zone";
            this.BtnAddZone.UseVisualStyleBackColor = true;
            this.BtnAddZone.Click += new System.EventHandler(this.BtnAddZone_Click);
            // 
            // btnAddSegments
            // 
            this.btnAddSegments.Location = new System.Drawing.Point(545, 251);
            this.btnAddSegments.Name = "btnAddSegments";
            this.btnAddSegments.Size = new System.Drawing.Size(105, 23);
            this.btnAddSegments.TabIndex = 38;
            this.btnAddSegments.Text = "Add Segments";
            this.btnAddSegments.UseVisualStyleBackColor = true;
            this.btnAddSegments.Click += new System.EventHandler(this.BtnAddSegments_Click);
            // 
            // FrmConsensus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 297);
            this.Controls.Add(this.btnAddSegments);
            this.Controls.Add(this.BtnAddZone);
            this.Controls.Add(this.frame);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmConsensus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analiza zona";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsensus_FormClosing);
            this.Load += new System.EventHandler(this.FrmAnalysis_Load);
            this.tlpZones.ResumeLayout(false);
            this.frame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tlpZones;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel frame;
        private System.Windows.Forms.Button BtnAddZone;
        private System.Windows.Forms.Button btnAddSegments;
    }
}


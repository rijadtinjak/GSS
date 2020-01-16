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
            this.BtnAddZone = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAddSegments = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.tlpZones.SuspendLayout();
            this.frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(10, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Data entry";
            // 
            // tlpZones
            // 
            this.tlpZones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpZones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tlpZones.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpZones.ColumnCount = 1;
            this.tlpZones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tlpZones.Controls.Add(this.label15, 0, 0);
            this.tlpZones.Location = new System.Drawing.Point(0, 0);
            this.tlpZones.Margin = new System.Windows.Forms.Padding(0);
            this.tlpZones.MaximumSize = new System.Drawing.Size(650, 220);
            this.tlpZones.Name = "tlpZones";
            this.tlpZones.RowCount = 1;
            this.tlpZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpZones.Size = new System.Drawing.Size(100, 26);
            this.tlpZones.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.Location = new System.Drawing.Point(13, 11);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 23);
            this.label15.TabIndex = 68;
            this.label15.Text = "Leaders";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frame
            // 
            this.frame.Controls.Add(this.tlpZones);
            this.frame.Location = new System.Drawing.Point(9, 111);
            this.frame.Margin = new System.Windows.Forms.Padding(0);
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(635, 215);
            this.frame.TabIndex = 35;
            // 
            // BtnAddZone
            // 
            this.BtnAddZone.AutoSize = true;
            this.BtnAddZone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnAddZone.Depth = 0;
            this.BtnAddZone.Location = new System.Drawing.Point(443, 335);
            this.BtnAddZone.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnAddZone.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnAddZone.Name = "BtnAddZone";
            this.BtnAddZone.Primary = false;
            this.BtnAddZone.Size = new System.Drawing.Size(78, 36);
            this.BtnAddZone.TabIndex = 39;
            this.BtnAddZone.Text = "Add Zone";
            this.BtnAddZone.UseVisualStyleBackColor = true;
            this.BtnAddZone.Visible = false;
            this.BtnAddZone.Click += new System.EventHandler(this.BtnAddZone_Click);
            // 
            // btnAddSegments
            // 
            this.btnAddSegments.AutoSize = true;
            this.btnAddSegments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSegments.Depth = 0;
            this.btnAddSegments.Location = new System.Drawing.Point(538, 335);
            this.btnAddSegments.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddSegments.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSegments.Name = "btnAddSegments";
            this.btnAddSegments.Primary = false;
            this.btnAddSegments.Size = new System.Drawing.Size(106, 36);
            this.btnAddSegments.TabIndex = 40;
            this.btnAddSegments.Text = "Add Segment";
            this.btnAddSegments.UseVisualStyleBackColor = true;
            this.btnAddSegments.Visible = false;
            this.btnAddSegments.Click += new System.EventHandler(this.BtnAddSegments_Click);
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Depth = 0;
            this.btnNext.Location = new System.Drawing.Point(574, 335);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.Primary = false;
            this.btnNext.Size = new System.Drawing.Size(46, 36);
            this.btnNext.TabIndex = 41;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // FrmConsensus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(653, 385);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAddSegments);
            this.Controls.Add(this.BtnAddZone);
            this.Controls.Add(this.frame);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.Name = "FrmConsensus";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consensus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsensus_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsensus_Load);
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
        private MaterialSkin.Controls.MaterialFlatButton BtnAddZone;
        private MaterialSkin.Controls.MaterialFlatButton btnAddSegments;
        private MaterialSkin.Controls.MaterialFlatButton btnNext;
    }
}


namespace GSS
{
    partial class FrmInitial
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
            this.txtNumZones = new System.Windows.Forms.TextBox();
            this.dgvManagers = new System.Windows.Forms.DataGridView();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumZones
            // 
            this.txtNumZones.Location = new System.Drawing.Point(161, 157);
            this.txtNumZones.Name = "txtNumZones";
            this.txtNumZones.Size = new System.Drawing.Size(189, 20);
            this.txtNumZones.TabIndex = 0;
            this.txtNumZones.Validating += new System.ComponentModel.CancelEventHandler(this.TxtNumZones_Validating);
            // 
            // dgvManagers
            // 
            this.dgvManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManagerName});
            this.dgvManagers.Location = new System.Drawing.Point(161, 211);
            this.dgvManagers.Name = "dgvManagers";
            this.dgvManagers.RowHeadersVisible = false;
            this.dgvManagers.Size = new System.Drawing.Size(189, 148);
            this.dgvManagers.TabIndex = 5;
            this.dgvManagers.Validating += new System.ComponentModel.CancelEventHandler(this.DgvManagers_Validating);
            // 
            // ManagerName
            // 
            this.ManagerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManagerName.HeaderText = "Name";
            this.ManagerName.Name = "ManagerName";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(57, 156);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(97, 19);
            this.materialLabel1.TabIndex = 101;
            this.materialLabel1.Text = "No. of Zones";
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Depth = 0;
            this.btnNext.Location = new System.Drawing.Point(303, 368);
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
            this.materialLabel2.Location = new System.Drawing.Point(79, 211);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 103;
            this.materialLabel2.Text = "Managers";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Location = new System.Drawing.Point(365, 100);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(588, 317);
            this.webBrowser1.TabIndex = 104;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(11, 102);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(142, 19);
            this.materialLabel3.TabIndex = 105;
            this.materialLabel3.Text = "Inital Planning Point";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(161, 102);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(90, 20);
            this.txtLat.TabIndex = 106;
            this.txtLat.TextChanged += new System.EventHandler(this.txtLat_Leave);
            this.txtLat.Leave += new System.EventHandler(this.txtLat_Leave);
            this.txtLat.Validating += new System.ComponentModel.CancelEventHandler(this.txtLat_Validating);
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(260, 102);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(90, 20);
            this.txtLng.TabIndex = 107;
            this.txtLng.TextChanged += new System.EventHandler(this.txtLat_Leave);
            this.txtLng.Leave += new System.EventHandler(this.txtLat_Leave);
            this.txtLng.Validating += new System.ComponentModel.CancelEventHandler(this.txtLng_Validating);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(83, 121);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(70, 19);
            this.materialLabel4.TabIndex = 108;
            this.materialLabel4.Text = "(lat / lng)";
            // 
            // FrmInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 429);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtLng);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dgvManagers);
            this.Controls.Add(this.txtNumZones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInitial";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Search";
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumZones;
        private System.Windows.Forms.DataGridView dgvManagers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton btnNext;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtLat;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.TextBox txtLng;
    }
}
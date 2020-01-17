namespace GSS
{
    partial class FrmFinishSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnFinishSearch = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(70, 10);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(346, 97);
            this.txtComment.TabIndex = 2;
            this.txtComment.Enter += new System.EventHandler(this.txtComment_Enter);
            this.txtComment.Leave += new System.EventHandler(this.txtComment_Leave);
            this.txtComment.Validating += new System.ComponentModel.CancelEventHandler(this.txtComment_Validating);
            // 
            // btnFinishSearch
            // 
            this.btnFinishSearch.Location = new System.Drawing.Point(330, 113);
            this.btnFinishSearch.Name = "btnFinishSearch";
            this.btnFinishSearch.Size = new System.Drawing.Size(86, 23);
            this.btnFinishSearch.TabIndex = 1;
            this.btnFinishSearch.Text = "Finish Search";
            this.btnFinishSearch.UseVisualStyleBackColor = true;
            this.btnFinishSearch.Click += new System.EventHandler(this.btnFinishSearch_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmFinishSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 144);
            this.Controls.Add(this.btnFinishSearch);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFinishSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finish Search";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnFinishSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
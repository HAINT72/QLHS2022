namespace View
{
    partial class fGiaoviec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGiaoviec));
            this.lstbNV = new System.Windows.Forms.ListBox();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnCV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsDtgvGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemFilePdfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendMailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgvGV = new UserControls.dtgvCrudUC();
            this.dtgvCV = new UserControls.dtgvFilterCVUC();
            this.panel1.SuspendLayout();
            this.cmsDtgvGV.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstbNV
            // 
            this.lstbNV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbNV.FormattingEnabled = true;
            this.lstbNV.ItemHeight = 16;
            this.lstbNV.Location = new System.Drawing.Point(5, 42);
            this.lstbNV.Name = "lstbNV";
            this.lstbNV.Size = new System.Drawing.Size(134, 500);
            this.lstbNV.TabIndex = 2;
            // 
            // btnNV
            // 
            this.btnNV.Image = ((System.Drawing.Image)(resources.GetObject("btnNV.Image")));
            this.btnNV.Location = new System.Drawing.Point(1169, 285);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(32, 30);
            this.btnNV.TabIndex = 5;
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnCV
            // 
            this.btnCV.Image = ((System.Drawing.Image)(resources.GetObject("btnCV.Image")));
            this.btnCV.Location = new System.Drawing.Point(628, 285);
            this.btnCV.Name = "btnCV";
            this.btnCV.Size = new System.Drawing.Size(34, 30);
            this.btnCV.TabIndex = 4;
            this.btnCV.UseVisualStyleBackColor = true;
            this.btnCV.Click += new System.EventHandler(this.btnCV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thực hiện";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstbNV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1207, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 557);
            this.panel1.TabIndex = 9;
            // 
            // cmsDtgvGV
            // 
            this.cmsDtgvGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemFilePdfMenuItem,
            this.SendMailMenuItem});
            this.cmsDtgvGV.Name = "cmsDtgvGV";
            this.cmsDtgvGV.Size = new System.Drawing.Size(181, 70);
            // 
            // xemFilePdfMenuItem
            // 
            this.xemFilePdfMenuItem.Enabled = false;
            this.xemFilePdfMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xemFilePdfMenuItem.Image")));
            this.xemFilePdfMenuItem.Name = "xemFilePdfMenuItem";
            this.xemFilePdfMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xemFilePdfMenuItem.Text = "Xem file PDF";
            this.xemFilePdfMenuItem.Click += new System.EventHandler(this.xemFilePdfMenuItem_Click);
            // 
            // SendMailMenuItem
            // 
            this.SendMailMenuItem.Enabled = false;
            this.SendMailMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SendMailMenuItem.Image")));
            this.SendMailMenuItem.Name = "SendMailMenuItem";
            this.SendMailMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SendMailMenuItem.Text = "Gửi Email";
            this.SendMailMenuItem.Click += new System.EventHandler(this.SendMailMenuItem_Click);
            // 
            // dtgvGV
            // 
            this.dtgvGV.ContextMenuStrip = this.cmsDtgvGV;
            this.dtgvGV.Location = new System.Drawing.Point(668, 23);
            this.dtgvGV.Name = "dtgvGV";
            this.dtgvGV.Size = new System.Drawing.Size(495, 557);
            this.dtgvGV.TabIndex = 1;
            this.dtgvGV.Enter += new System.EventHandler(this.dtgvGV_Enter);
            // 
            // dtgvCV
            // 
            this.dtgvCV.Location = new System.Drawing.Point(12, 23);
            this.dtgvCV.Name = "dtgvCV";
            this.dtgvCV.Size = new System.Drawing.Size(610, 557);
            this.dtgvCV.TabIndex = 0;
            // 
            // fGiaoviec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 592);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNV);
            this.Controls.Add(this.btnCV);
            this.Controls.Add(this.dtgvGV);
            this.Controls.Add(this.dtgvCV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fGiaoviec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng giao việc";
            this.Load += new System.EventHandler(this.fGiaoviec_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsDtgvGV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.dtgvFilterCVUC dtgvCV;
        private UserControls.dtgvCrudUC dtgvGV;
        private System.Windows.Forms.ListBox lstbNV;
        private System.Windows.Forms.Button btnCV;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsDtgvGV;
        private System.Windows.Forms.ToolStripMenuItem xemFilePdfMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendMailMenuItem;
    }
}
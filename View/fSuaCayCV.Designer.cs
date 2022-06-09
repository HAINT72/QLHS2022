namespace View
{
    partial class fSuaCayCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSuaCayCV));
            this.sptContainerCayCV = new System.Windows.Forms.SplitContainer();
            this.tvwCV = new System.Windows.Forms.TreeView();
            this.cmsCayCV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemPDFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemNhanhMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GiamNhanhMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuaCayCVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.txbNoidungCVCha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbNgayCVCha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbSoCVCha = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbMSCVcha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbGiaidoan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbCoquan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbLoaiCV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbNoidung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNgayCV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSoCV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMSCV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainerCayCV)).BeginInit();
            this.sptContainerCayCV.Panel1.SuspendLayout();
            this.sptContainerCayCV.Panel2.SuspendLayout();
            this.sptContainerCayCV.SuspendLayout();
            this.cmsCayCV.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptContainerCayCV
            // 
            this.sptContainerCayCV.AllowDrop = true;
            this.sptContainerCayCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptContainerCayCV.Location = new System.Drawing.Point(0, 0);
            this.sptContainerCayCV.Name = "sptContainerCayCV";
            // 
            // sptContainerCayCV.Panel1
            // 
            this.sptContainerCayCV.Panel1.Controls.Add(this.tvwCV);
            // 
            // sptContainerCayCV.Panel2
            // 
            this.sptContainerCayCV.Panel2.Controls.Add(this.label11);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbNoidungCVCha);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label10);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbNgayCVCha);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label9);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbSoCVCha);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label8);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbMSCVcha);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label7);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbGiaidoan);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label6);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbCoquan);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label5);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbLoaiCV);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label4);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbNoidung);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label3);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbNgayCV);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label2);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbSoCV);
            this.sptContainerCayCV.Panel2.Controls.Add(this.label1);
            this.sptContainerCayCV.Panel2.Controls.Add(this.txbMSCV);
            this.sptContainerCayCV.Size = new System.Drawing.Size(1219, 585);
            this.sptContainerCayCV.SplitterDistance = 904;
            this.sptContainerCayCV.TabIndex = 0;
            // 
            // tvwCV
            // 
            this.tvwCV.ContextMenuStrip = this.cmsCayCV;
            this.tvwCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCV.ForeColor = System.Drawing.Color.Blue;
            this.tvwCV.Location = new System.Drawing.Point(0, 0);
            this.tvwCV.Name = "tvwCV";
            this.tvwCV.Size = new System.Drawing.Size(904, 585);
            this.tvwCV.TabIndex = 1;
            this.tvwCV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCV_AfterSelect);
            this.tvwCV.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwCV_DragDrop);
            this.tvwCV.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvwCV_DragEnter);
            this.tvwCV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwCV_MouseDown);
            // 
            // cmsCayCV
            // 
            this.cmsCayCV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCayCV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemPDFMenuItem,
            this.ThemNhanhMenuItem,
            this.GiamNhanhMenuItem,
            this.SuaCayCVMenuItem});
            this.cmsCayCV.Name = "cmsCayCV";
            this.cmsCayCV.Size = new System.Drawing.Size(203, 114);
            // 
            // xemPDFMenuItem
            // 
            this.xemPDFMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xemPDFMenuItem.Image")));
            this.xemPDFMenuItem.Name = "xemPDFMenuItem";
            this.xemPDFMenuItem.Size = new System.Drawing.Size(202, 22);
            this.xemPDFMenuItem.Text = "Xem file (dạng PDF)";
            this.xemPDFMenuItem.Click += new System.EventHandler(this.xemPDFMenuItem_Click);
            // 
            // ThemNhanhMenuItem
            // 
            this.ThemNhanhMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ThemNhanhMenuItem.Image")));
            this.ThemNhanhMenuItem.Name = "ThemNhanhMenuItem";
            this.ThemNhanhMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ThemNhanhMenuItem.Text = "Thêm nhánh công văn";
            this.ThemNhanhMenuItem.Click += new System.EventHandler(this.ThemNhanhMenuItem_Click);
            // 
            // GiamNhanhMenuItem
            // 
            this.GiamNhanhMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GiamNhanhMenuItem.Image")));
            this.GiamNhanhMenuItem.Name = "GiamNhanhMenuItem";
            this.GiamNhanhMenuItem.Size = new System.Drawing.Size(202, 22);
            this.GiamNhanhMenuItem.Text = "Giảm nhánh công văn";
            this.GiamNhanhMenuItem.Click += new System.EventHandler(this.GiamNhanhMenuItem_Click);
            // 
            // SuaCayCVMenuItem
            // 
            this.SuaCayCVMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SuaCayCVMenuItem.Image")));
            this.SuaCayCVMenuItem.Name = "SuaCayCVMenuItem";
            this.SuaCayCVMenuItem.Size = new System.Drawing.Size(202, 22);
            this.SuaCayCVMenuItem.Text = "Bật kéo/thả công văn";
            this.SuaCayCVMenuItem.Click += new System.EventHandler(this.SuaCayCVMenuItem_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(34, 448);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Nội dung";
            // 
            // txbNoidungCVCha
            // 
            this.txbNoidungCVCha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNoidungCVCha.ForeColor = System.Drawing.Color.Red;
            this.txbNoidungCVCha.Location = new System.Drawing.Point(104, 445);
            this.txbNoidungCVCha.Multiline = true;
            this.txbNoidungCVCha.Name = "txbNoidungCVCha";
            this.txbNoidungCVCha.ReadOnly = true;
            this.txbNoidungCVCha.Size = new System.Drawing.Size(191, 108);
            this.txbNoidungCVCha.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(37, 418);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Ngày CV";
            // 
            // txbNgayCVCha
            // 
            this.txbNgayCVCha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNgayCVCha.ForeColor = System.Drawing.Color.Red;
            this.txbNgayCVCha.Location = new System.Drawing.Point(104, 415);
            this.txbNgayCVCha.Name = "txbNgayCVCha";
            this.txbNgayCVCha.ReadOnly = true;
            this.txbNgayCVCha.Size = new System.Drawing.Size(191, 21);
            this.txbNgayCVCha.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(50, 385);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Số CV";
            // 
            // txbSoCVCha
            // 
            this.txbSoCVCha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoCVCha.ForeColor = System.Drawing.Color.Red;
            this.txbSoCVCha.Location = new System.Drawing.Point(104, 382);
            this.txbSoCVCha.Name = "txbSoCVCha";
            this.txbSoCVCha.ReadOnly = true;
            this.txbSoCVCha.Size = new System.Drawing.Size(191, 21);
            this.txbSoCVCha.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(11, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "MSCV cha";
            // 
            // txbMSCVcha
            // 
            this.txbMSCVcha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMSCVcha.ForeColor = System.Drawing.Color.Red;
            this.txbMSCVcha.Location = new System.Drawing.Point(80, 350);
            this.txbMSCVcha.Multiline = true;
            this.txbMSCVcha.Name = "txbMSCVcha";
            this.txbMSCVcha.ReadOnly = true;
            this.txbMSCVcha.Size = new System.Drawing.Size(216, 21);
            this.txbMSCVcha.TabIndex = 14;
            this.txbMSCVcha.TextChanged += new System.EventHandler(this.txbMSCVcha_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giai đoạn";
            // 
            // txbGiaidoan
            // 
            this.txbGiaidoan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbGiaidoan.Location = new System.Drawing.Point(80, 316);
            this.txbGiaidoan.Multiline = true;
            this.txbGiaidoan.Name = "txbGiaidoan";
            this.txbGiaidoan.ReadOnly = true;
            this.txbGiaidoan.Size = new System.Drawing.Size(216, 21);
            this.txbGiaidoan.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cơ quan";
            // 
            // txbCoquan
            // 
            this.txbCoquan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCoquan.Location = new System.Drawing.Point(80, 282);
            this.txbCoquan.Multiline = true;
            this.txbCoquan.Name = "txbCoquan";
            this.txbCoquan.ReadOnly = true;
            this.txbCoquan.Size = new System.Drawing.Size(216, 21);
            this.txbCoquan.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loại CV";
            // 
            // txbLoaiCV
            // 
            this.txbLoaiCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLoaiCV.Location = new System.Drawing.Point(80, 248);
            this.txbLoaiCV.Multiline = true;
            this.txbLoaiCV.Name = "txbLoaiCV";
            this.txbLoaiCV.ReadOnly = true;
            this.txbLoaiCV.Size = new System.Drawing.Size(216, 21);
            this.txbLoaiCV.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nội dung";
            // 
            // txbNoidung
            // 
            this.txbNoidung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNoidung.Location = new System.Drawing.Point(80, 122);
            this.txbNoidung.Multiline = true;
            this.txbNoidung.Name = "txbNoidung";
            this.txbNoidung.ReadOnly = true;
            this.txbNoidung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbNoidung.Size = new System.Drawing.Size(216, 113);
            this.txbNoidung.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày CV";
            // 
            // txbNgayCV
            // 
            this.txbNgayCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNgayCV.Location = new System.Drawing.Point(80, 88);
            this.txbNgayCV.Name = "txbNgayCV";
            this.txbNgayCV.ReadOnly = true;
            this.txbNgayCV.Size = new System.Drawing.Size(216, 21);
            this.txbNgayCV.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số CV";
            // 
            // txbSoCV
            // 
            this.txbSoCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoCV.Location = new System.Drawing.Point(80, 54);
            this.txbSoCV.Name = "txbSoCV";
            this.txbSoCV.ReadOnly = true;
            this.txbSoCV.Size = new System.Drawing.Size(216, 21);
            this.txbSoCV.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "MSCV";
            // 
            // txbMSCV
            // 
            this.txbMSCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMSCV.Location = new System.Drawing.Point(80, 20);
            this.txbMSCV.Name = "txbMSCV";
            this.txbMSCV.ReadOnly = true;
            this.txbMSCV.Size = new System.Drawing.Size(216, 21);
            this.txbMSCV.TabIndex = 0;
            // 
            // fSuaCayCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 585);
            this.Controls.Add(this.sptContainerCayCV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fSuaCayCV";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều chỉnh cây công văn";
            this.sptContainerCayCV.Panel1.ResumeLayout(false);
            this.sptContainerCayCV.Panel2.ResumeLayout(false);
            this.sptContainerCayCV.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptContainerCayCV)).EndInit();
            this.sptContainerCayCV.ResumeLayout(false);
            this.cmsCayCV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptContainerCayCV;
        private System.Windows.Forms.TreeView tvwCV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbMSCVcha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbGiaidoan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbCoquan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbLoaiCV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbNoidung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNgayCV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSoCV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMSCV;
        private System.Windows.Forms.ContextMenuStrip cmsCayCV;
        private System.Windows.Forms.ToolStripMenuItem xemPDFMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SuaCayCVMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbNoidungCVCha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbNgayCVCha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbSoCVCha;
        private System.Windows.Forms.ToolStripMenuItem ThemNhanhMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GiamNhanhMenuItem;
    }
}
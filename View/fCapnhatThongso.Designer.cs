namespace View
{
    partial class fCapnhatThongso
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
            System.Windows.Forms.Label mSTSLabel;
            System.Windows.Forms.Label nOIDUNGLabel;
            System.Windows.Forms.Label sTR_DATALabel;
            System.Windows.Forms.Label sTR_PATHLabel;
            System.Windows.Forms.Label hIEULUCLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCapnhatThongso));
            this.txbMSTS = new System.Windows.Forms.TextBox();
            this.txbNoidung = new System.Windows.Forms.TextBox();
            this.txbStrData = new System.Windows.Forms.TextBox();
            this.txbStrPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkHieuluc = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.dtgvThongSo = new UserControls.dtgvBaseUC();
            this.thongSoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            mSTSLabel = new System.Windows.Forms.Label();
            nOIDUNGLabel = new System.Windows.Forms.Label();
            sTR_DATALabel = new System.Windows.Forms.Label();
            sTR_PATHLabel = new System.Windows.Forms.Label();
            hIEULUCLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thongSoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mSTSLabel
            // 
            mSTSLabel.AutoSize = true;
            mSTSLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mSTSLabel.Location = new System.Drawing.Point(6, 7);
            mSTSLabel.Name = "mSTSLabel";
            mSTSLabel.Size = new System.Drawing.Size(67, 16);
            mSTSLabel.TabIndex = 1;
            mSTSLabel.Text = "Tên CSDL";
            // 
            // nOIDUNGLabel
            // 
            nOIDUNGLabel.AutoSize = true;
            nOIDUNGLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nOIDUNGLabel.Location = new System.Drawing.Point(6, 38);
            nOIDUNGLabel.Name = "nOIDUNGLabel";
            nOIDUNGLabel.Size = new System.Drawing.Size(59, 16);
            nOIDUNGLabel.TabIndex = 3;
            nOIDUNGLabel.Text = "Nội dung";
            // 
            // sTR_DATALabel
            // 
            sTR_DATALabel.AutoSize = true;
            sTR_DATALabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sTR_DATALabel.Location = new System.Drawing.Point(6, 116);
            sTR_DATALabel.Name = "sTR_DATALabel";
            sTR_DATALabel.Size = new System.Drawing.Size(84, 16);
            sTR_DATALabel.TabIndex = 5;
            sTR_DATALabel.Text = "Chuỗi kết nối";
            // 
            // sTR_PATHLabel
            // 
            sTR_PATHLabel.AutoSize = true;
            sTR_PATHLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sTR_PATHLabel.Location = new System.Drawing.Point(6, 200);
            sTR_PATHLabel.Name = "sTR_PATHLabel";
            sTR_PATHLabel.Size = new System.Drawing.Size(74, 16);
            sTR_PATHLabel.TabIndex = 7;
            sTR_PATHLabel.Text = "Đường dẫn";
            // 
            // hIEULUCLabel
            // 
            hIEULUCLabel.AutoSize = true;
            hIEULUCLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hIEULUCLabel.Location = new System.Drawing.Point(7, 248);
            hIEULUCLabel.Name = "hIEULUCLabel";
            hIEULUCLabel.Size = new System.Drawing.Size(57, 16);
            hIEULUCLabel.TabIndex = 8;
            hIEULUCLabel.Text = "Hiệu lực";
            // 
            // txbMSTS
            // 
            this.txbMSTS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMSTS.Location = new System.Drawing.Point(100, 4);
            this.txbMSTS.Name = "txbMSTS";
            this.txbMSTS.Size = new System.Drawing.Size(231, 22);
            this.txbMSTS.TabIndex = 2;
            // 
            // txbNoidung
            // 
            this.txbNoidung.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNoidung.Location = new System.Drawing.Point(100, 35);
            this.txbNoidung.Multiline = true;
            this.txbNoidung.Name = "txbNoidung";
            this.txbNoidung.Size = new System.Drawing.Size(231, 67);
            this.txbNoidung.TabIndex = 4;
            // 
            // txbStrData
            // 
            this.txbStrData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStrData.Location = new System.Drawing.Point(100, 113);
            this.txbStrData.Multiline = true;
            this.txbStrData.Name = "txbStrData";
            this.txbStrData.Size = new System.Drawing.Size(231, 69);
            this.txbStrData.TabIndex = 6;
            // 
            // txbStrPath
            // 
            this.txbStrPath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStrPath.Location = new System.Drawing.Point(100, 194);
            this.txbStrPath.Multiline = true;
            this.txbStrPath.Name = "txbStrPath";
            this.txbStrPath.Size = new System.Drawing.Size(231, 46);
            this.txbStrPath.TabIndex = 8;
            this.txbStrPath.DoubleClick += new System.EventHandler(this.txbStrPath_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(hIEULUCLabel);
            this.panel1.Controls.Add(this.chkHieuluc);
            this.panel1.Controls.Add(this.txbNoidung);
            this.panel1.Controls.Add(this.txbStrPath);
            this.panel1.Controls.Add(mSTSLabel);
            this.panel1.Controls.Add(sTR_PATHLabel);
            this.panel1.Controls.Add(this.txbMSTS);
            this.panel1.Controls.Add(this.txbStrData);
            this.panel1.Controls.Add(nOIDUNGLabel);
            this.panel1.Controls.Add(sTR_DATALabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 287);
            this.panel1.TabIndex = 10;
            // 
            // chkHieuluc
            // 
            this.chkHieuluc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHieuluc.Location = new System.Drawing.Point(99, 248);
            this.chkHieuluc.Name = "chkHieuluc";
            this.chkHieuluc.Size = new System.Drawing.Size(231, 24);
            this.chkHieuluc.TabIndex = 9;
            this.chkHieuluc.Text = "(chọn để sử dụng Database)";
            this.chkHieuluc.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnCapnhat);
            this.panel2.Location = new System.Drawing.Point(12, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 46);
            this.panel2.TabIndex = 11;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(215, 8);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 35);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapnhat.ForeColor = System.Drawing.Color.Blue;
            this.btnCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapnhat.Image")));
            this.btnCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapnhat.Location = new System.Drawing.Point(101, 8);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(92, 35);
            this.btnCapnhat.TabIndex = 0;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // dtgvThongSo
            // 
            this.dtgvThongSo.Location = new System.Drawing.Point(360, 12);
            this.dtgvThongSo.Name = "dtgvThongSo";
            this.dtgvThongSo.Size = new System.Drawing.Size(782, 336);
            this.dtgvThongSo.TabIndex = 9;
            // 
            // thongSoBindingSource
            // 
            this.thongSoBindingSource.DataSource = typeof(Model.ThongSo);
            // 
            // fCapnhatThongso
            // 
            this.AcceptButton = this.btnCapnhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 361);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvThongSo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCapnhatThongso";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thông số kết nối";
            this.Load += new System.EventHandler(this.fCapnhatThongso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thongSoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource thongSoBindingSource;
        private System.Windows.Forms.TextBox txbMSTS;
        private System.Windows.Forms.TextBox txbNoidung;
        private System.Windows.Forms.TextBox txbStrData;
        private System.Windows.Forms.TextBox txbStrPath;
        private UserControls.dtgvBaseUC dtgvThongSo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.CheckBox chkHieuluc;
        private System.Windows.Forms.Button btnXoa;
    }
}
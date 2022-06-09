namespace View
{
    partial class fCaidatUser
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
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label mSNVLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCaidatUser));
            this.chkHieuluc = new System.Windows.Forms.CheckBox();
            this.txbHoten = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.btnResetMK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.grpQuyenTC = new System.Windows.Forms.GroupBox();
            this.radioBtnKO = new System.Windows.Forms.RadioButton();
            this.radioBtnAD = new System.Windows.Forms.RadioButton();
            this.radioBtnNV = new System.Windows.Forms.RadioButton();
            this.radioBtnLD = new System.Windows.Forms.RadioButton();
            this.radioBtnVT = new System.Windows.Forms.RadioButton();
            this.dtgvNhanvien = new UserControls.dtgvBaseUC();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            hOTENLabel = new System.Windows.Forms.Label();
            mSNVLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpQuyenTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hOTENLabel.Location = new System.Drawing.Point(18, 42);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(62, 16);
            hOTENLabel.TabIndex = 4;
            hOTENLabel.Text = "Họ và tên";
            // 
            // mSNVLabel
            // 
            mSNVLabel.AutoSize = true;
            mSNVLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mSNVLabel.Location = new System.Drawing.Point(17, 6);
            mSNVLabel.Name = "mSNVLabel";
            mSNVLabel.Size = new System.Drawing.Size(67, 16);
            mSNVLabel.TabIndex = 6;
            mSNVLabel.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(18, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 16);
            label1.TabIndex = 24;
            label1.Text = "Email";
            // 
            // chkHieuluc
            // 
            this.chkHieuluc.Checked = true;
            this.chkHieuluc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHieuluc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHieuluc.ForeColor = System.Drawing.Color.Black;
            this.chkHieuluc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkHieuluc.Location = new System.Drawing.Point(21, 271);
            this.chkHieuluc.Name = "chkHieuluc";
            this.chkHieuluc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHieuluc.Size = new System.Drawing.Size(248, 24);
            this.chkHieuluc.TabIndex = 6;
            this.chkHieuluc.Text = "Hiệu lực (cho phép user đăng nhập?)";
            this.chkHieuluc.UseVisualStyleBackColor = true;
            // 
            // txbHoten
            // 
            this.txbHoten.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbHoten.Location = new System.Drawing.Point(84, 36);
            this.txbHoten.Name = "txbHoten";
            this.txbHoten.Size = new System.Drawing.Size(185, 22);
            this.txbHoten.TabIndex = 2;
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(84, 3);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(185, 22);
            this.txbUsername.TabIndex = 1;
            this.txbUsername.TextChanged += new System.EventHandler(this.txbUsername_TextChanged);
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapnhat.ForeColor = System.Drawing.Color.Blue;
            this.btnCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapnhat.Image")));
            this.btnCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapnhat.Location = new System.Drawing.Point(21, 6);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(98, 32);
            this.btnCapnhat.TabIndex = 7;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // btnResetMK
            // 
            this.btnResetMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetMK.ForeColor = System.Drawing.Color.Red;
            this.btnResetMK.Image = ((System.Drawing.Image)(resources.GetObject("btnResetMK.Image")));
            this.btnResetMK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetMK.Location = new System.Drawing.Point(150, 6);
            this.btnResetMK.Name = "btnResetMK";
            this.btnResetMK.Size = new System.Drawing.Size(98, 32);
            this.btnResetMK.TabIndex = 10;
            this.btnResetMK.Text = "Reset PW";
            this.btnResetMK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetMK.UseVisualStyleBackColor = true;
            this.btnResetMK.Click += new System.EventHandler(this.btnResetMK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnResetMK);
            this.panel1.Controls.Add(this.btnCapnhat);
            this.panel1.Location = new System.Drawing.Point(6, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 42);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbEmail);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(this.grpQuyenTC);
            this.panel2.Controls.Add(this.txbHoten);
            this.panel2.Controls.Add(this.txbUsername);
            this.panel2.Controls.Add(mSNVLabel);
            this.panel2.Controls.Add(this.chkHieuluc);
            this.panel2.Controls.Add(hOTENLabel);
            this.panel2.Location = new System.Drawing.Point(6, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 299);
            this.panel2.TabIndex = 21;
            // 
            // txbEmail
            // 
            this.txbEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEmail.Location = new System.Drawing.Point(84, 71);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(185, 22);
            this.txbEmail.TabIndex = 23;
            // 
            // grpQuyenTC
            // 
            this.grpQuyenTC.Controls.Add(this.radioBtnKO);
            this.grpQuyenTC.Controls.Add(this.radioBtnAD);
            this.grpQuyenTC.Controls.Add(this.radioBtnNV);
            this.grpQuyenTC.Controls.Add(this.radioBtnLD);
            this.grpQuyenTC.Controls.Add(this.radioBtnVT);
            this.grpQuyenTC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQuyenTC.ForeColor = System.Drawing.Color.Blue;
            this.grpQuyenTC.Location = new System.Drawing.Point(20, 104);
            this.grpQuyenTC.Name = "grpQuyenTC";
            this.grpQuyenTC.Size = new System.Drawing.Size(249, 161);
            this.grpQuyenTC.TabIndex = 22;
            this.grpQuyenTC.TabStop = false;
            this.grpQuyenTC.Text = "Quyền truy cập :";
            // 
            // radioBtnKO
            // 
            this.radioBtnKO.AutoSize = true;
            this.radioBtnKO.Location = new System.Drawing.Point(63, 125);
            this.radioBtnKO.Name = "radioBtnKO";
            this.radioBtnKO.Size = new System.Drawing.Size(116, 20);
            this.radioBtnKO.TabIndex = 7;
            this.radioBtnKO.Text = "Không xác định";
            this.radioBtnKO.UseVisualStyleBackColor = true;
            // 
            // radioBtnAD
            // 
            this.radioBtnAD.AutoSize = true;
            this.radioBtnAD.Location = new System.Drawing.Point(63, 99);
            this.radioBtnAD.Name = "radioBtnAD";
            this.radioBtnAD.Size = new System.Drawing.Size(63, 20);
            this.radioBtnAD.TabIndex = 6;
            this.radioBtnAD.Text = "Admin";
            this.radioBtnAD.UseVisualStyleBackColor = true;
            this.radioBtnAD.CheckedChanged += new System.EventHandler(this.radioBtnAD_CheckedChanged);
            // 
            // radioBtnNV
            // 
            this.radioBtnNV.AutoSize = true;
            this.radioBtnNV.Location = new System.Drawing.Point(63, 73);
            this.radioBtnNV.Name = "radioBtnNV";
            this.radioBtnNV.Size = new System.Drawing.Size(82, 20);
            this.radioBtnNV.TabIndex = 5;
            this.radioBtnNV.Text = "Nhân viên";
            this.radioBtnNV.UseVisualStyleBackColor = true;
            this.radioBtnNV.CheckedChanged += new System.EventHandler(this.radioBtnNV_CheckedChanged);
            // 
            // radioBtnLD
            // 
            this.radioBtnLD.AutoSize = true;
            this.radioBtnLD.Location = new System.Drawing.Point(63, 50);
            this.radioBtnLD.Name = "radioBtnLD";
            this.radioBtnLD.Size = new System.Drawing.Size(79, 20);
            this.radioBtnLD.TabIndex = 4;
            this.radioBtnLD.Text = "Lãnh đạo";
            this.radioBtnLD.UseVisualStyleBackColor = true;
            this.radioBtnLD.CheckedChanged += new System.EventHandler(this.radioBtnLD_CheckedChanged);
            // 
            // radioBtnVT
            // 
            this.radioBtnVT.AutoSize = true;
            this.radioBtnVT.Checked = true;
            this.radioBtnVT.Location = new System.Drawing.Point(63, 27);
            this.radioBtnVT.Name = "radioBtnVT";
            this.radioBtnVT.Size = new System.Drawing.Size(73, 20);
            this.radioBtnVT.TabIndex = 3;
            this.radioBtnVT.TabStop = true;
            this.radioBtnVT.Text = "Văn thư";
            this.radioBtnVT.UseVisualStyleBackColor = true;
            this.radioBtnVT.CheckedChanged += new System.EventHandler(this.radioBtnVT_CheckedChanged);
            // 
            // dtgvNhanvien
            // 
            this.dtgvNhanvien.Location = new System.Drawing.Point(291, 15);
            this.dtgvNhanvien.Name = "dtgvNhanvien";
            this.dtgvNhanvien.Size = new System.Drawing.Size(624, 340);
            this.dtgvNhanvien.TabIndex = 11;
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataSource = typeof(Model.NhanVien);
            // 
            // fCaidatUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvNhanvien);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCaidatUser";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt user";
            this.Load += new System.EventHandler(this.fCaidatUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpQuyenTC.ResumeLayout(false);
            this.grpQuyenTC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private System.Windows.Forms.CheckBox chkHieuluc;
        private System.Windows.Forms.TextBox txbHoten;
        private System.Windows.Forms.TextBox txbUsername;
        private UserControls.dtgvBaseUC dtgvNhanvien;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Button btnResetMK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpQuyenTC;
        private System.Windows.Forms.RadioButton radioBtnNV;
        private System.Windows.Forms.RadioButton radioBtnLD;
        private System.Windows.Forms.RadioButton radioBtnVT;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.RadioButton radioBtnAD;
        private System.Windows.Forms.RadioButton radioBtnKO;
    }
}
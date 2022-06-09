namespace View
{
    partial class fTimkiemCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTimkiemCV));
            this.chkTimtheocumtu = new System.Windows.Forms.CheckBox();
            this.chkTimkhongdau = new System.Windows.Forms.CheckBox();
            this.dtpkNgaytu = new System.Windows.Forms.DateTimePicker();
            this.dtpkNgayden = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMSCQ = new System.Windows.Forms.ComboBox();
            this.cbMSLoaiCV = new System.Windows.Forms.ComboBox();
            this.txbNoidung = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMSGiaiDoan = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhaplai = new System.Windows.Forms.Button();
            this.btnNhapMSCVcha = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnNhapCV = new System.Windows.Forms.Button();
            this.dtgvTimkiemCV = new UserControls.dtgvFilterCVUC();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkTimtheocumtu
            // 
            this.chkTimtheocumtu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTimtheocumtu.Location = new System.Drawing.Point(89, 105);
            this.chkTimtheocumtu.Name = "chkTimtheocumtu";
            this.chkTimtheocumtu.Size = new System.Drawing.Size(302, 21);
            this.chkTimtheocumtu.TabIndex = 4;
            this.chkTimtheocumtu.Text = "Tìm theo cụm từ phân cách bằng dấu ;";
            this.chkTimtheocumtu.UseVisualStyleBackColor = true;
            this.chkTimtheocumtu.CheckedChanged += new System.EventHandler(this.chkTimtheocumtu_CheckedChanged);
            // 
            // chkTimkhongdau
            // 
            this.chkTimkhongdau.AutoSize = true;
            this.chkTimkhongdau.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTimkhongdau.Location = new System.Drawing.Point(90, 81);
            this.chkTimkhongdau.Name = "chkTimkhongdau";
            this.chkTimkhongdau.Size = new System.Drawing.Size(147, 20);
            this.chkTimkhongdau.TabIndex = 3;
            this.chkTimkhongdau.Text = "Tìm kiếm không dấu";
            this.chkTimkhongdau.UseVisualStyleBackColor = true;
            // 
            // dtpkNgaytu
            // 
            this.dtpkNgaytu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkNgaytu.Location = new System.Drawing.Point(88, 240);
            this.dtpkNgaytu.Name = "dtpkNgaytu";
            this.dtpkNgaytu.Size = new System.Drawing.Size(303, 25);
            this.dtpkNgaytu.TabIndex = 8;
            // 
            // dtpkNgayden
            // 
            this.dtpkNgayden.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkNgayden.Location = new System.Drawing.Point(88, 275);
            this.dtpkNgayden.Name = "dtpkNgayden";
            this.dtpkNgayden.Size = new System.Drawing.Size(303, 25);
            this.dtpkNgayden.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cơ quan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Loại CV";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nội dung";
            // 
            // cbMSCQ
            // 
            this.cbMSCQ.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMSCQ.FormattingEnabled = true;
            this.cbMSCQ.Location = new System.Drawing.Point(88, 169);
            this.cbMSCQ.Name = "cbMSCQ";
            this.cbMSCQ.Size = new System.Drawing.Size(303, 25);
            this.cbMSCQ.TabIndex = 7;
            // 
            // cbMSLoaiCV
            // 
            this.cbMSLoaiCV.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMSLoaiCV.FormattingEnabled = true;
            this.cbMSLoaiCV.Location = new System.Drawing.Point(88, 134);
            this.cbMSLoaiCV.Name = "cbMSLoaiCV";
            this.cbMSLoaiCV.Size = new System.Drawing.Size(303, 25);
            this.cbMSLoaiCV.TabIndex = 6;
            // 
            // txbNoidung
            // 
            this.txbNoidung.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNoidung.Location = new System.Drawing.Point(88, 33);
            this.txbNoidung.Multiline = true;
            this.txbNoidung.Name = "txbNoidung";
            this.txbNoidung.Size = new System.Drawing.Size(303, 42);
            this.txbNoidung.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbMSGiaiDoan);
            this.panel1.Controls.Add(this.chkTimtheocumtu);
            this.panel1.Controls.Add(this.dtpkNgaytu);
            this.panel1.Controls.Add(this.dtpkNgayden);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkTimkhongdau);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbNoidung);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbMSLoaiCV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbMSCQ);
            this.panel1.Location = new System.Drawing.Point(9, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 457);
            this.panel1.TabIndex = 22;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(17, 313);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(374, 134);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Nhập và lựa chọn điều kiện tìm kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Giai đoạn";
            // 
            // cbMSGiaiDoan
            // 
            this.cbMSGiaiDoan.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMSGiaiDoan.FormattingEnabled = true;
            this.cbMSGiaiDoan.Location = new System.Drawing.Point(88, 206);
            this.cbMSGiaiDoan.Name = "cbMSGiaiDoan";
            this.cbMSGiaiDoan.Size = new System.Drawing.Size(303, 25);
            this.cbMSGiaiDoan.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNhaplai);
            this.panel2.Controls.Add(this.btnNhapMSCVcha);
            this.panel2.Controls.Add(this.btnTimkiem);
            this.panel2.Controls.Add(this.btnNhapCV);
            this.panel2.Location = new System.Drawing.Point(7, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 44);
            this.panel2.TabIndex = 17;
            // 
            // btnNhaplai
            // 
            this.btnNhaplai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNhaplai.ForeColor = System.Drawing.Color.Blue;
            this.btnNhaplai.Image = ((System.Drawing.Image)(resources.GetObject("btnNhaplai.Image")));
            this.btnNhaplai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhaplai.Location = new System.Drawing.Point(102, 7);
            this.btnNhaplai.Name = "btnNhaplai";
            this.btnNhaplai.Size = new System.Drawing.Size(94, 33);
            this.btnNhaplai.TabIndex = 32;
            this.btnNhaplai.Text = "Nhập lại";
            this.btnNhaplai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhaplai.UseVisualStyleBackColor = true;
            this.btnNhaplai.Click += new System.EventHandler(this.btnNhaplai_Click);
            // 
            // btnNhapMSCVcha
            // 
            this.btnNhapMSCVcha.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNhapMSCVcha.Enabled = false;
            this.btnNhapMSCVcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapMSCVcha.ForeColor = System.Drawing.Color.Blue;
            this.btnNhapMSCVcha.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapMSCVcha.Image")));
            this.btnNhapMSCVcha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapMSCVcha.Location = new System.Drawing.Point(302, 7);
            this.btnNhapMSCVcha.Name = "btnNhapMSCVcha";
            this.btnNhapMSCVcha.Size = new System.Drawing.Size(94, 33);
            this.btnNhapMSCVcha.TabIndex = 31;
            this.btnNhapMSCVcha.Text = "MSCV cha";
            this.btnNhapMSCVcha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhapMSCVcha.UseVisualStyleBackColor = true;
            this.btnNhapMSCVcha.Click += new System.EventHandler(this.btnNhapMSCVcha_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.ForeColor = System.Drawing.Color.Blue;
            this.btnTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.Image")));
            this.btnTimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimkiem.Location = new System.Drawing.Point(2, 7);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(94, 33);
            this.btnTimkiem.TabIndex = 29;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnNhapCV
            // 
            this.btnNhapCV.Enabled = false;
            this.btnNhapCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapCV.ForeColor = System.Drawing.Color.Blue;
            this.btnNhapCV.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapCV.Image")));
            this.btnNhapCV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapCV.Location = new System.Drawing.Point(202, 7);
            this.btnNhapCV.Name = "btnNhapCV";
            this.btnNhapCV.Size = new System.Drawing.Size(94, 33);
            this.btnNhapCV.TabIndex = 30;
            this.btnNhapCV.Text = "Sửa CV";
            this.btnNhapCV.UseVisualStyleBackColor = true;
            this.btnNhapCV.Click += new System.EventHandler(this.btnNhapCV_Click);
            // 
            // dtgvTimkiemCV
            // 
            this.dtgvTimkiemCV.Location = new System.Drawing.Point(412, 12);
            this.dtgvTimkiemCV.Name = "dtgvTimkiemCV";
            this.dtgvTimkiemCV.Size = new System.Drawing.Size(777, 505);
            this.dtgvTimkiemCV.TabIndex = 27;
            // 
            // fTimkiemCV
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1203, 529);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtgvTimkiemCV);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fTimkiemCV";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm công văn";
            this.Load += new System.EventHandler(this.fTimkiemCV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMSCQ;
        private System.Windows.Forms.ComboBox cbMSLoaiCV;
        private System.Windows.Forms.DateTimePicker dtpkNgayden;
        private System.Windows.Forms.DateTimePicker dtpkNgaytu;
        private System.Windows.Forms.TextBox txbNoidung;
        private System.Windows.Forms.CheckBox chkTimtheocumtu;
        private System.Windows.Forms.CheckBox chkTimkhongdau;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.dtgvFilterCVUC dtgvTimkiemCV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMSGiaiDoan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNhaplai;
        private System.Windows.Forms.Button btnNhapMSCVcha;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnNhapCV;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
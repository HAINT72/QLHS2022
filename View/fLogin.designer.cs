namespace View
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChonCSDL = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChonCSDL);
            this.panel1.Controls.Add(this.btnFix);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(330, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 112);
            this.panel1.TabIndex = 0;
            // 
            // btnChonCSDL
            // 
            this.btnChonCSDL.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonCSDL.ForeColor = System.Drawing.Color.Blue;
            this.btnChonCSDL.Image = ((System.Drawing.Image)(resources.GetObject("btnChonCSDL.Image")));
            this.btnChonCSDL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChonCSDL.Location = new System.Drawing.Point(15, 78);
            this.btnChonCSDL.Name = "btnChonCSDL";
            this.btnChonCSDL.Size = new System.Drawing.Size(92, 30);
            this.btnChonCSDL.TabIndex = 4;
            this.btnChonCSDL.Text = "Chọn CSDL";
            this.btnChonCSDL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChonCSDL.UseVisualStyleBackColor = true;
            this.btnChonCSDL.Click += new System.EventHandler(this.btnChonCSDL_Click);
            // 
            // btnFix
            // 
            this.btnFix.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.ForeColor = System.Drawing.Color.Blue;
            this.btnFix.Image = ((System.Drawing.Image)(resources.GetObject("btnFix.Image")));
            this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.Location = new System.Drawing.Point(14, 43);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(93, 30);
            this.btnFix.TabIndex = 3;
            this.btnFix.Text = "Thông số";
            this.btnFix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Blue;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(15, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(92, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.Blue;
            this.lblData.Location = new System.Drawing.Point(3, 5);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(120, 15);
            this.lblData.TabIndex = 5;
            this.lblData.Text = "Cơ sở dữ liệu kết nối";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblData);
            this.panel2.Location = new System.Drawing.Point(108, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 28);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbUserName);
            this.panel3.Controls.Add(this.txbPassWord);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(108, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 86);
            this.panel3.TabIndex = 1;
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(118, 10);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(88, 25);
            this.txbUserName.TabIndex = 1;
            // 
            // txbPassWord
            // 
            this.txbPassWord.AllowDrop = true;
            this.txbPassWord.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassWord.Location = new System.Drawing.Point(118, 46);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(88, 25);
            this.txbPassWord.TabIndex = 1;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(458, 138);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Blue;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnChonCSDL;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


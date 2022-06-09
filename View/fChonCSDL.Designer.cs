namespace View
{
    partial class fChonCSDL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChonCSDL));
            this.btnChon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.dtgvTS = new UserControls.dtgvBaseUC();
            this.btnLocalData = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.ForeColor = System.Drawing.Color.Blue;
            this.btnChon.Image = ((System.Drawing.Image)(resources.GetObject("btnChon.Image")));
            this.btnChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChon.Location = new System.Drawing.Point(13, 42);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(71, 34);
            this.btnChon.TabIndex = 1;
            this.btnChon.Text = "Chọn";
            this.btnChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLocalData);
            this.panel1.Controls.Add(this.btnChon);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Location = new System.Drawing.Point(557, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 230);
            this.panel1.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(12, 134);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(71, 34);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Hủy";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dtgvTS
            // 
            this.dtgvTS.Location = new System.Drawing.Point(12, 12);
            this.dtgvTS.Name = "dtgvTS";
            this.dtgvTS.Size = new System.Drawing.Size(543, 230);
            this.dtgvTS.TabIndex = 0;
            // 
            // btnLocalData
            // 
            this.btnLocalData.Enabled = false;
            this.btnLocalData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalData.ForeColor = System.Drawing.Color.Blue;
            this.btnLocalData.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalData.Image")));
            this.btnLocalData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalData.Location = new System.Drawing.Point(12, 88);
            this.btnLocalData.Name = "btnLocalData";
            this.btnLocalData.Size = new System.Drawing.Size(71, 34);
            this.btnLocalData.TabIndex = 3;
            this.btnLocalData.Text = "Offline";
            this.btnLocalData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocalData.UseVisualStyleBackColor = true;
            // 
            // fChonCSDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 252);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvTS);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fChonCSDL";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.fChonCSDL_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.dtgvBaseUC dtgvTS;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLocalData;
    }
}
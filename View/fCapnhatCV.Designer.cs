namespace View
{
    partial class fCapnhatCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCapnhatCV));
            this.dtgvCV = new UserControls.dtgvFilterCVUC();
            this.detailCV = new UserControls.detailCVUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvCV
            // 
            this.dtgvCV.Location = new System.Drawing.Point(468, 12);
            this.dtgvCV.Name = "dtgvCV";
            this.dtgvCV.Size = new System.Drawing.Size(720, 577);
            this.dtgvCV.TabIndex = 1;
            // 
            // detailCV
            // 
            this.detailCV.Location = new System.Drawing.Point(10, 12);
            this.detailCV.Name = "detailCV";
            this.detailCV.Size = new System.Drawing.Size(450, 528);
            this.detailCV.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTimkiem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnCapnhat);
            this.panel1.Location = new System.Drawing.Point(54, 551);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 38);
            this.panel1.TabIndex = 8;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.ForeColor = System.Drawing.Color.Blue;
            this.btnTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.Image")));
            this.btnTimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimkiem.Location = new System.Drawing.Point(275, 3);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(96, 35);
            this.btnTimkiem.TabIndex = 2;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(159, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 35);
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
            this.btnCapnhat.Location = new System.Drawing.Point(43, 3);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(96, 35);
            this.btnCapnhat.TabIndex = 0;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // fCapnhatCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 597);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.detailCV);
            this.Controls.Add(this.dtgvCV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCapnhatCV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật công văn";
            this.Load += new System.EventHandler(this.fCapnhatCV_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.dtgvFilterCVUC dtgvCV;
        private UserControls.detailCVUC detailCV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapnhat;
    }
}
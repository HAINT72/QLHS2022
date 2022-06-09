namespace View
{
    partial class fCayCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCayCV));
            this.imageListCayCV = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwCV = new System.Windows.Forms.TreeView();
            this.cmsTvwCV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ViewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileToListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNodeToListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilesToListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstBoxCV = new System.Windows.Forms.ListBox();
            this.cmsListBoxCV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveCVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveAllCVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsTvwCV.SuspendLayout();
            this.cmsListBoxCV.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListCayCV
            // 
            this.imageListCayCV.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCayCV.ImageStream")));
            this.imageListCayCV.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCayCV.Images.SetKeyName(0, "baseline_menu_black_18dp.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvwCV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstBoxCV);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Size = new System.Drawing.Size(1184, 562);
            this.splitContainer1.SplitterDistance = 934;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvwCV
            // 
            this.tvwCV.AllowDrop = true;
            this.tvwCV.CheckBoxes = true;
            this.tvwCV.ContextMenuStrip = this.cmsTvwCV;
            this.tvwCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCV.ForeColor = System.Drawing.Color.Blue;
            this.tvwCV.ImageIndex = 0;
            this.tvwCV.ImageList = this.imageListCayCV;
            this.tvwCV.Location = new System.Drawing.Point(0, 0);
            this.tvwCV.Name = "tvwCV";
            this.tvwCV.SelectedImageIndex = 0;
            this.tvwCV.Size = new System.Drawing.Size(934, 562);
            this.tvwCV.TabIndex = 2;
            this.tvwCV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwCV_NodeMouseClick);
            // 
            // cmsTvwCV
            // 
            this.cmsTvwCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsTvwCV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewFileMenuItem,
            this.toolStripSeparator1,
            this.FileToListMenuItem,
            this.FileNodeToListMenuItem,
            this.FilesToListMenuItem});
            this.cmsTvwCV.Name = "cmsTvwCV";
            this.cmsTvwCV.Size = new System.Drawing.Size(211, 98);
            // 
            // ViewFileMenuItem
            // 
            this.ViewFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ViewFileMenuItem.Image")));
            this.ViewFileMenuItem.Name = "ViewFileMenuItem";
            this.ViewFileMenuItem.Size = new System.Drawing.Size(210, 22);
            this.ViewFileMenuItem.Text = "Xem file (chỉ dạng PDF)";
            this.ViewFileMenuItem.Click += new System.EventHandler(this.ViewFileMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // FileToListMenuItem
            // 
            this.FileToListMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FileToListMenuItem.Image")));
            this.FileToListMenuItem.Name = "FileToListMenuItem";
            this.FileToListMenuItem.Size = new System.Drawing.Size(210, 22);
            this.FileToListMenuItem.Text = "Đưa file vào danh sách";
            this.FileToListMenuItem.Click += new System.EventHandler(this.FileToListMenuItem_Click);
            // 
            // FileNodeToListMenuItem
            // 
            this.FileNodeToListMenuItem.Enabled = false;
            this.FileNodeToListMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FileNodeToListMenuItem.Image")));
            this.FileNodeToListMenuItem.Name = "FileNodeToListMenuItem";
            this.FileNodeToListMenuItem.Size = new System.Drawing.Size(210, 22);
            this.FileNodeToListMenuItem.Text = "Đưa nút vào danh sách";
            this.FileNodeToListMenuItem.Click += new System.EventHandler(this.FileNodeToListMenuItem_Click);
            // 
            // FilesToListMenuItem
            // 
            this.FilesToListMenuItem.Enabled = false;
            this.FilesToListMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FilesToListMenuItem.Image")));
            this.FilesToListMenuItem.Name = "FilesToListMenuItem";
            this.FilesToListMenuItem.Size = new System.Drawing.Size(210, 22);
            this.FilesToListMenuItem.Text = "Đưa n file vào danh sách";
            this.FilesToListMenuItem.Click += new System.EventHandler(this.FilesToListMenuItem_Click);
            // 
            // lstBoxCV
            // 
            this.lstBoxCV.ContextMenuStrip = this.cmsListBoxCV;
            this.lstBoxCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxCV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxCV.FormattingEnabled = true;
            this.lstBoxCV.HorizontalScrollbar = true;
            this.lstBoxCV.ItemHeight = 15;
            this.lstBoxCV.Location = new System.Drawing.Point(0, 0);
            this.lstBoxCV.Name = "lstBoxCV";
            this.lstBoxCV.ScrollAlwaysVisible = true;
            this.lstBoxCV.Size = new System.Drawing.Size(246, 562);
            this.lstBoxCV.TabIndex = 0;
            this.lstBoxCV.SelectedIndexChanged += new System.EventHandler(this.lstBoxCV_SelectedIndexChanged);
            // 
            // cmsListBoxCV
            // 
            this.cmsListBoxCV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveCVMenuItem,
            this.RemoveAllCVMenuItem,
            this.CopyCVMenuItem});
            this.cmsListBoxCV.Name = "cmsListBoxCV";
            this.cmsListBoxCV.Size = new System.Drawing.Size(181, 92);
            // 
            // RemoveCVMenuItem
            // 
            this.RemoveCVMenuItem.Enabled = false;
            this.RemoveCVMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoveCVMenuItem.Image")));
            this.RemoveCVMenuItem.Name = "RemoveCVMenuItem";
            this.RemoveCVMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RemoveCVMenuItem.Text = "Bỏ chọn công văn";
            this.RemoveCVMenuItem.Click += new System.EventHandler(this.RemoveCVMenuItem_Click);
            // 
            // RemoveAllCVMenuItem
            // 
            this.RemoveAllCVMenuItem.Enabled = false;
            this.RemoveAllCVMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoveAllCVMenuItem.Image")));
            this.RemoveAllCVMenuItem.Name = "RemoveAllCVMenuItem";
            this.RemoveAllCVMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RemoveAllCVMenuItem.Text = "Bỏ chọn toàn bộ";
            this.RemoveAllCVMenuItem.Click += new System.EventHandler(this.RemoveAllCVMenuItem_Click);
            // 
            // CopyCVMenuItem
            // 
            this.CopyCVMenuItem.Enabled = false;
            this.CopyCVMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyCVMenuItem.Image")));
            this.CopyCVMenuItem.Name = "CopyCVMenuItem";
            this.CopyCVMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyCVMenuItem.Text = "Chép về thư mục";
            this.CopyCVMenuItem.Click += new System.EventHandler(this.CopyCVMenuItem_Click);
            // 
            // fCayCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCayCV";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem công văn dạng cây";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsTvwCV.ResumeLayout(false);
            this.cmsListBoxCV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageListCayCV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwCV;
        private System.Windows.Forms.ContextMenuStrip cmsTvwCV;
        private System.Windows.Forms.ToolStripMenuItem ViewFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilesToListMenuItem;
        private System.Windows.Forms.ListBox lstBoxCV;
        private System.Windows.Forms.ContextMenuStrip cmsListBoxCV;
        private System.Windows.Forms.ToolStripMenuItem RemoveCVMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyCVMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveAllCVMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem FileNodeToListMenuItem;
    }
}
using System.Windows.Forms;
using System.Drawing;
using System;
using App;
using Model;
using ViewModel;
using System.Data;

namespace UserControls
{
    public class detailCVUC : UserControl
    {
        #region Variable      
        private FlowLayoutPanel fpnlDetail = new FlowLayoutPanel();
        private Label label0 = new Label();
        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label label5 = new Label();
        private Label label6 = new Label();
        private Label label7 = new Label();
        private Label label8 = new Label();
        private Label label9 = new Label();
        private Label label10 = new Label();
        private Label label11 = new Label();
        private Label TitleDtgv = new Label();
        public TextBox txbFileRAR = new TextBox();
        public TextBox txbFileOffice = new TextBox();
        public TextBox txbFilePDF = new TextBox();
        public TextBox txbNoidung = new TextBox();
        public TextBox txbSoCV = new TextBox();
        public TextBox txbMSCV = new TextBox();
        public ComboBox cbMSCVCHA = new ComboBox();
        public ComboBox cbMSCQ = new ComboBox();
        public ComboBox cbMSGiaidoan = new ComboBox();
        public ComboBox cbMSLoaiCV = new ComboBox();
        public ComboBox cbMSDUOICV = new ComboBox();
        public DateTimePicker dtpkNgayCV = new DateTimePicker();
        public ToolTip tltip = new ToolTip();
        private ContextMenuStrip cms = new ContextMenuStrip();
        #endregion

        #region TemporaryVariable
        //Khai báo các biến định dạng
        private Font ftDefaultFont = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        int heightControl = 30;
        int widthTextbox = 354;
        int widthLabel = 80;

        //Khai báo các biến dùng chung
        NhanVien nv = ShareVar.Instance.NV;
        private string stLoaiFile = string.Empty; // Lưu loại file pdf, office, rar để truyền cho MenuContext
        private string stFileName = string.Empty; // Lưu tên File nhập từ FileOpenDialog
        private string stFileFilterType = string.Empty; // Lưu kiểu file (*.pdf, *.doc, *.rar) để hiển thị khi chọn đính kèm
        #endregion

        public detailCVUC()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            fpnlDetail.FlowDirection = FlowDirection.LeftToRight;
            fpnlDetail.WrapContents = true;
            fpnlDetail.Size = new Size(widthTextbox + widthLabel + 15, heightControl * 18);

            TitleDtgv.Dock = DockStyle.Top;
            TitleDtgv.Font = ftDefaultFont;
            TitleDtgv.Size = new Size(widthTextbox + widthLabel + 10, heightControl);
            TitleDtgv.ForeColor = Color.Blue;
            TitleDtgv.Visible = false;
            TitleDtgv.TextAlign = ContentAlignment.MiddleCenter;
            TitleDtgv.BorderStyle = BorderStyle.FixedSingle;

            label0.Size = new Size(widthLabel, heightControl);
            label0.Font = ftDefaultFont;
            label0.Text = "MSCV";

            label1.Size = new Size(widthLabel, heightControl);
            label1.Font = ftDefaultFont;
            label1.Text = "Số CV";

            label2.Size = new Size(widthLabel, heightControl);
            label2.Font = ftDefaultFont;
            label2.Text = "Ngày CV";

            label3.Size = new Size(widthLabel, heightControl);
            label3.Font = ftDefaultFont;
            label3.Text = "Nội dung";

            label4.Size = new Size(widthLabel, heightControl);
            label4.Font = ftDefaultFont;
            label4.Text = "Loại CV";

            label5.Size = new Size(widthLabel, heightControl);
            label5.Font = ftDefaultFont;
            label5.Text = "Cơ quan";

            label6.Size = new Size(widthLabel, heightControl);
            label6.Font = ftDefaultFont;
            label6.Text = "Giai đoạn";

            label7.Size = new Size(widthLabel, heightControl);
            label7.Font = ftDefaultFont;
            label7.Text = "Số CV cha";

            label8.Size = new Size(widthLabel, heightControl);
            label8.Font = ftDefaultFont;
            label8.Text = "File PDF";

            label9.Size = new Size(widthLabel, heightControl);
            label9.Font = ftDefaultFont;
            label9.Text = "File Office";

            label10.Size = new Size(widthLabel, heightControl);
            label10.Font = ftDefaultFont;
            label10.Text = "File RAR";

            txbMSCV.ReadOnly = true;
            txbMSCV.Font = ftDefaultFont;
            txbMSCV.Size = new Size(widthTextbox, heightControl);

            txbSoCV.Font = ftDefaultFont;
            txbSoCV.ForeColor = Color.Red;
            txbSoCV.Size = new Size(widthTextbox / 3 * 2 - 5, heightControl);

            txbNoidung.Font = ftDefaultFont;
            txbNoidung.Multiline = true;
            txbNoidung.ScrollBars = ScrollBars.Vertical;
            txbNoidung.Size = new Size(widthTextbox, heightControl * 3);

            txbFilePDF.Font = ftDefaultFont;
            txbFilePDF.Multiline = true;
            txbFilePDF.ScrollBars = ScrollBars.Vertical;
            txbFilePDF.Size = new Size(widthTextbox, heightControl * 2);
            txbFilePDF.ReadOnly = true;

            txbFileOffice.Font = ftDefaultFont;
            txbFileOffice.Multiline = true;
            txbFileOffice.ScrollBars = ScrollBars.Vertical;
            txbFileOffice.Size = new Size(widthTextbox, heightControl * 2);
            txbFileOffice.ReadOnly = true;

            txbFileRAR.Font = ftDefaultFont;
            txbFileRAR.Multiline = true;
            txbFileRAR.ScrollBars = ScrollBars.Vertical;
            txbFileRAR.Size = new Size(widthTextbox, heightControl * 2);
            txbFileRAR.ReadOnly = true;

            //cbMSCVCHA.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMSCVCHA.Font = ftDefaultFont;
            cbMSCVCHA.Size = new Size(widthTextbox, heightControl);

            cbMSCQ.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMSCQ.Font = ftDefaultFont;
            cbMSCQ.Size = new Size(widthTextbox, heightControl);

            cbMSGiaidoan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMSGiaidoan.Font = ftDefaultFont;
            cbMSGiaidoan.Size = new Size(widthTextbox, heightControl);

            cbMSLoaiCV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMSLoaiCV.Font = ftDefaultFont;
            cbMSLoaiCV.Size = new Size(widthTextbox, heightControl);

            cbMSDUOICV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMSDUOICV.Font = ftDefaultFont;
            cbMSDUOICV.Size = new Size(widthTextbox / 3, heightControl);

            dtpkNgayCV.AllowDrop = true;
            dtpkNgayCV.Font = ftDefaultFont;
            dtpkNgayCV.Size = new Size(widthTextbox, heightControl);
            dtpkNgayCV.Value = DateTime.Now;

            //Tạo tooltip
            tltip.SetToolTip(txbMSCV, "Mã số công văn được cấp tự động");
            tltip.SetToolTip(txbSoCV, "Nhập đầy đủ số công văn/nhập số và lựa chọn phần đuôi công văn. Với công văn đến phải chọn mục '_CV ĐẾN'");
            tltip.SetToolTip(txbNoidung, "Nhập nội dung văn bản");
            tltip.SetToolTip(dtpkNgayCV, "Chọn ngày công văn");
            tltip.SetToolTip(cbMSLoaiCV, "Chọn loại công văn. Nếu không có loại công văn phù hợp thì chọn '_CHƯA XÁC ĐỊNH'");
            tltip.SetToolTip(cbMSGiaidoan, "Chọn giai đoạn thực hiện của Dự án theo nội dung công văn");
            tltip.SetToolTip(cbMSCQ, "Chọn cơ quan gửi/nhận. Nếu không có cơ quan phù hợp thì chọn '_CHƯA XÁC ĐỊNH'");
            tltip.SetToolTip(cbMSCVCHA, "Chọn số công văn liên kết. Nếu không có số công văn phù hợp thì để trống");
            tltip.SetToolTip(txbFilePDF, "Bấm chuột phải để nhập đường dẫn file PDF. Nếu chưa có file thì để trống");
            tltip.SetToolTip(txbFileOffice, "Bấm chuột phải để nhập đường dẫn file Office. Nếu chưa có file thì để trống");
            tltip.SetToolTip(txbFileRAR, "Bấm chuột phải để nhập đường dẫn file RAR. Nếu chưa có file thì để trống");

            //Tạo MenuContext

            cms.Items.Add("Đính kèm file", null, new EventHandler(AttachFile_Click));
            cms.Items.Add("Xem file", null, new EventHandler(OpenFile_Click));
            cms.Items[0].Image = global::App.Properties.Resources.baseline_attach_file_black_18dp;
            cms.Items[1].Image = global::App.Properties.Resources._51955_document_file_pdf_icon;
            cms.Items[0].Enabled = false;
            cms.Items[1].Enabled = false;
            txbFilePDF.ContextMenuStrip = cms;
            txbFileOffice.ContextMenuStrip = cms;
            txbFileRAR.ContextMenuStrip = cms;

            //Tạo sự kiện
            txbFilePDF.Enter += txbFilePDF_Enter;
            txbFileOffice.Enter += txbFileOffice_Enter;
            txbFileRAR.Enter += txbFileRAR_Enter;
            cbMSDUOICV.Leave += CbMSDUOICV_Leave;
            cbMSGiaidoan.Leave += CbMSGIAIDOAN_Leave;

            fpnlDetail.Controls.AddRange(new Control[]
                {
                    TitleDtgv,
                    label0, txbMSCV,
                    label1, txbSoCV, cbMSDUOICV,
                    label2, dtpkNgayCV,
                    label3, txbNoidung,
                    label4, cbMSLoaiCV,
                    label5, cbMSCQ,
                    label6, cbMSGiaidoan,
                    label7, cbMSCVCHA,
                    label8, txbFilePDF,
                    label9, txbFileOffice,
                    label10,txbFileRAR
                });

            Controls.AddRange(new Control[] { fpnlDetail });
        }

        #region Events
        private void txbFilePDF_Enter(object sender, EventArgs e)
        {
            stLoaiFile = "PDF";
            stFileFilterType = "PDF file (*.pdf)|*.pdf";
            stFileName = txbFilePDF.Text;
            EnableContextMenuItem(true, !string.IsNullOrEmpty(stFileName));
        }

        private void txbFileOffice_Enter(object sender, EventArgs e)
        {
            stLoaiFile = "OFFICE";
            stFileFilterType = "Word documents (*.docx)|*.docx|Word 97-2003 documents (*.doc)|*.doc";
            stFileName = txbFileOffice.Text;
            EnableContextMenuItem(true, !string.IsNullOrEmpty(stFileName));
        }

        private void txbFileRAR_Enter(object sender, EventArgs e)
        {
            stLoaiFile = "RAR";
            stFileFilterType = "RAR file (*.rar)|*.rar|ZIP file (*.zip)|*.zip";
            stFileName = txbFileRAR.Text;
            EnableContextMenuItem(true, !string.IsNullOrEmpty(stFileName));
        }

        private void EnableContextMenuItem(bool bEnableAttachFileMenuItem, bool bEnableViewFileMenuItem)
        {
            cms.Items[0].Enabled = bEnableAttachFileMenuItem;
            cms.Items[1].Enabled = bEnableViewFileMenuItem;
        }

        private void CbMSDUOICV_Leave(object sender, EventArgs e)
        {
            string stMSDUOICV = cbMSDUOICV.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(stMSDUOICV)) return;
            txbSoCV.Text += (stMSDUOICV != "_CV ĐẾN") ? @"/" + cbMSDUOICV.SelectedValue.ToString() : string.Empty;
        }

        private void CbMSGIAIDOAN_Leave(object sender, EventArgs e)
        {
            int iMSGIAIDOAN = Convert.ToInt32(cbMSGiaidoan.SelectedValue);
            if (iMSGIAIDOAN > 0)
            {
                GiaiDoan gd = GiaiDoanVM.Instance.GetGiaiDoanByMSGD(iMSGIAIDOAN);
                string stMSCV = gd.MSCVGOC;
                MovecbMSCVCHA(stMSCV);
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {            
            Utilities.Instance.OpenFileAtch(stFileName);
        }

        private void AttachFile_Click(object sender, EventArgs e)
        {
            stFileName = Utilities.Instance.GetFullFileName(stFileFilterType);
            if (!string.IsNullOrEmpty(stFileName))
            {
                switch (stLoaiFile.ToUpper())
                {
                    case "PDF": //Gán vào txbFilePDF
                        txbFilePDF.Text = stFileName;
                        break;

                    case "OFFICE": //Gán vào txbFileOffice
                        txbFileOffice.Text = stFileName;
                        break;

                    case "RAR": //Gán vào txbFileRAR
                        txbFileRAR.Text = stFileName;
                        break;
                }
            }
        }
        #endregion

        #region Method
        public string GetDateString()
        {
            return dtpkNgayCV.Value.ToShortDateString();
        }

        public void SetTitle(string stTitle)
        {
            TitleDtgv.Visible = true;
            TitleDtgv.Text = stTitle;
        }

        public void SetBlankAllControl()
        {
            txbMSCV.Text = null;
            txbSoCV.Text = null;
            txbNoidung.Text = null;
            txbFilePDF.Text = null;
            txbFileOffice.Text = null;
            txbFileRAR.Text = null;
            txbMSCV.Text = null;
            cbMSDUOICV.SelectedIndex = -1;
            cbMSCVCHA.SelectedIndex = -1;
            cbMSCQ.SelectedIndex = -1;
            cbMSLoaiCV.SelectedIndex = -1;
            cbMSGiaidoan.SelectedIndex = -1;
        }

        protected CongVan GetCongVan()
        {
            string stMSDUOICV = cbMSDUOICV.SelectedValue?.ToString();
            string stMSCV = txbMSCV.Text;
            if (string.IsNullOrEmpty(stMSCV))
                stMSCV = (stMSDUOICV == "_CV ĐẾN") ? "F" : "T"; //Ký tự đầu MSCV (F: CV đến; T: CV đi)
            string stSOCV = txbSoCV.Text.ToUpper();
            string stNOIDUNG = txbNoidung.Text;
            DateTime dNGAYCV = Convert.ToDateTime(dtpkNgayCV.Value);
            int iMSLOAICV = Convert.ToInt32(cbMSLoaiCV.SelectedValue);
            int iMSCQ = Convert.ToInt32(cbMSCQ.SelectedValue);
            int iMSGIAIDOAN = Convert.ToInt32(cbMSGiaidoan.SelectedValue);
            string stMSCVCHA = (cbMSCVCHA.SelectedValue != null) ? cbMSCVCHA.SelectedValue?.ToString() : "";
            string stFILEPDF = txbFilePDF.Text;
            string stFILEOFFICE = txbFileOffice.Text;
            string stFILERAR = txbFileRAR.Text;
            string stMSNV = nv.MSNV;
            CongVan cv = new CongVan(stMSCV, stSOCV, dNGAYCV, stNOIDUNG, stMSNV, iMSLOAICV, iMSCQ, iMSGIAIDOAN, stMSCVCHA, stFILEPDF, stFILEOFFICE, stFILERAR);
            return cv;
        }

        public void LoadData()
        {
            //Load cbDuoiCV
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tDUOICV ORDER BY DUOICV");
            cbMSDUOICV.DataSource = data;
            cbMSDUOICV.DisplayMember = "DUOICV";
            cbMSDUOICV.ValueMember = "DUOICV";

            // Load cbMSLoaiCV
            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tLOAICV ORDER BY LOAICV");
            cbMSLoaiCV.DataSource = data;
            cbMSLoaiCV.DisplayMember = "LOAICV";
            cbMSLoaiCV.ValueMember = "MSLOAICV";

            // Load cbMSCQ
            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tCOQUAN ORDER BY TENCQ");
            cbMSCQ.DataSource = data;
            cbMSCQ.DisplayMember = "TENCQ";
            cbMSCQ.ValueMember = "MSCQ";

            // Load cbMSGIAIDOAN
            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tGIAIDOAN");
            cbMSGiaidoan.DataSource = data;
            cbMSGiaidoan.DisplayMember = "GIAIDOAN";
            cbMSGiaidoan.ValueMember = "MSGIAIDOAN";

            // Load cbMSCVCHA
            LoadcbMSCVCHA();

            //Xoá trắng control
            SetBlankAllControl();
        }

        public void LoadcbMSCVCHA()
        {
            string query = "SELECT MSCV , SOCV + ' ngày ' + CONVERT(NVARCHAR, NGAYCV, 103) AS [SOCVNGAY] FROM dbo.tCongVan ORDER BY NGAYCV DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            cbMSCVCHA.DataSource = data;
            cbMSCVCHA.DisplayMember = "SOCVNGAY";
            cbMSCVCHA.ValueMember = "MSCV";
        }

        public bool ThemCongvan()
        {
            CongVan cv = GetCongVan();
            cv.MSCV = CongVanVM.Instance.ThemCongvan(cv);
            if (cv.MSCV != null && CongVanVM.Instance.CopyFileAtchsToServer(cv))
            {
                Functions.MsgBox("Thêm công văn thành công", MessageType.Success);
                LoadcbMSCVCHA();
                return true;
            }
            else
            {
                Functions.MsgBox("Thêm công văn thất bại", MessageType.Error);
                return false;
            }
           
        }

        public bool SuaCongvan()
        {
            CongVan cv = GetCongVan();
            if (UserLoginCanDeleteEdit(cv.MSCV) == false)
            {
                Functions.MsgBox("Công văn đã phê duyệt/ User không có quyền sửa.", MessageType.Information);
                return false;
            }
            
            //Kiểm tra NGAYCV có bị thay đổi không?
            if (CongVanVM.Instance.SuaCongvan(cv) && CongVanVM.Instance.CopyFileAtchsToServer(cv))
            {
                Functions.MsgBox("Sửa công văn thành công", MessageType.Success);
                return true;
            }
            else
            {
                Functions.MsgBox("Sửa công văn thất bại", MessageType.Error);
                return false;
            }
        }

        public bool XoaCongvan()
        {
            CongVan cv = GetCongVan();
            if (UserLoginCanDeleteEdit(cv.MSCV)==false)
            {
                Functions.MsgBox("Công văn đã phê duyệt/ User không có quyền xóa công văn", MessageType.Information);
                return false;
            }

            if (CongVanVM.Instance.XoaCongvan(cv.MSCV) && CongVanVM.Instance.DeleteFilesOnServer(cv))
            {
                Functions.MsgBox("Xoá công văn thành công", MessageType.Success);
                return true;
            }
            else
            {
                Functions.MsgBox("Xoá công văn thất bại", MessageType.Error);
                return false;
            }
        }

        public void MovecbMSCVCHA(string stMSCV)
        {
            if (string.IsNullOrEmpty(stMSCV)) return;
            int iIndex = Utilities.Instance.GetIndexCombobox(cbMSCVCHA, stMSCV);
            cbMSCVCHA.SelectedIndex = iIndex;
        }

        private bool UserLoginCanDeleteEdit(string stMSCV)
        {
            if (string.IsNullOrEmpty(stMSCV)) return false;
            CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(stMSCV);
            if (nv.QUYENTRUYCAP == "VT" || (cv.MSNV == nv.MSNV && cv.PHEDUYET == false))
                return true;
            else
                return false;
        }

        #endregion
    }
}

using App;
using Model;
using System;
using System.Windows.Forms;
using ViewModel;

namespace View
{
    public partial class fSuaCVGoc : Form
    {
        public fSuaCVGoc()
        {
            InitializeComponent();
        }

        private void fSuaCVGoc_Load(object sender, EventArgs e)
        {
            //Load Dtgv
            string stQuery = "SELECT * FROM tGiaiDoan";
            this.dtgvGD.SetDataSource(stQuery, false);
            this.dtgvGD.SetHeaderText(new string[] { "Id", "Giai đoạn", "MSCV gốc" });
            
            //Load Binding tGiaiDoan
            this.txbMSGD.DataBindings.Add("Text", dtgvGD.bindDtgv, "MSGIAIDOAN", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txbGiaiDoan.DataBindings.Add("Text", dtgvGD.bindDtgv, "GIAIDOAN", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txbMSCV.DataBindings.Add("Text", dtgvGD.bindDtgv, "MSCVGOC", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void txbMSCV_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbMSCV.Text))
            {
                this.txbSoCV.Text = string.Empty;
                this.txbNgayCV.Text = string.Empty;
                this.txbNoidungCV.Text = string.Empty;
            }
            else //Load CongVan
            {
                CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(this.txbMSCV.Text);
                if(cv!=null)
                {
                    this.txbSoCV.Text = cv.SOCV;
                    this.txbNgayCV.Text = cv.NGAYCV.ToShortDateString();
                    this.txbNoidungCV.Text = cv.NOIDUNG;
                }
            }
        }

        private void btnXoaGiaiDoan_Click(object sender, EventArgs e)
        {
            int iMSGD = Convert.ToInt32(txbMSGD.Text);
            bool bKetQua = GiaiDoanVM.Instance.XoaGiaiDoan(iMSGD);
            if (bKetQua)
                Functions.MsgBox("Xóa dữ liệu Bảng 'Giai đoạn' thành công.");
            else
                Functions.MsgBox("Xóa dữ liệu Bảng 'Giai đoạn' thất bại.");
        }

        private void btnResetCayCV_Click(object sender, EventArgs e)
        {
            bool bKetQua = GiaiDoanVM.Instance.ResetCayCV();
            if (bKetQua)
                Functions.MsgBox("Reset cây công văn thành công.");
            else
                Functions.MsgBox("Không rest cây công văn.");
        }

        private void btnCapNhatGiaiDoan_Click(object sender, EventArgs e)
        {
            //Cập nhật tGiaiDoan
            int iMSGD = Convert.ToInt32(txbMSGD.Text);
            GiaiDoan gd = GiaiDoanVM.Instance.GetGiaiDoanByMSGD(iMSGD);
            string stMSCVSource = gd.MSCVGOC;
            string stGiaiDoan = txbGiaiDoan.Text;
            string stMSCVGoc = txbMSCV.Text;
            bool bKetQua = GiaiDoanVM.Instance.CapNhatGiaiDoan(iMSGD, stGiaiDoan, stMSCVGoc);
            if (bKetQua)
                Functions.MsgBox("Cập nhật dữ liệu Bảng 'Giai đoạn' thành công.");
            else
                Functions.MsgBox("Cập nhật dữ liệu Bảng 'Giai đoạn' thất bại.");

            //Cập nhật Cây Công văn
            bKetQua = GiaiDoanVM.Instance.CapNhatCayCV(stMSCVSource, stMSCVGoc);
            if (bKetQua)
                Functions.MsgBox("Cập nhật cây công văn thành công.");
            else
                Functions.MsgBox("Không cập nhật cây công văn.");
        }
    }
}

using System;
using System.Windows.Forms;
using App;
using ViewModel;
using System.Data;

namespace View
{
    public partial class fTimkiemCV : Form
    {
        public fTimkiemCV()
        {
            InitializeComponent();           
        }
        private void fTimkiemCV_Load(object sender, EventArgs e)
        {           
            LoadData();                        
            SetBlankForm();
            EnableButtons();
        }
        
        #region Methods
        private void LoadData()
        {
            // Load cbMSLoaiCV
            cbMSLoaiCV.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM tLOAICV ORDER BY LOAICV ");
            cbMSLoaiCV.DisplayMember = "LOAICV";
            cbMSLoaiCV.ValueMember = "MSLOAICV";
            
            // Load cbMSCQ
            cbMSCQ.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM tCOQUAN ORDER BY TENCQ");
            cbMSCQ.DisplayMember = "TENCQ";
            cbMSCQ.ValueMember = "MSCQ";
            
            // Load dtpkNgay
            dtpkNgaytu.Value = (DateTime)DataProvider.Instance.ExecuteScalar("SELECT MIN(NGAYCV) FROM tCONGVAN");
            dtpkNgayden.Value = DateTime.Today;

            //Load cbMSGiaiDoan
            cbMSGiaiDoan.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM tGIAIDOAN");
            cbMSGiaiDoan.DisplayMember = "GIAIDOAN";
            cbMSGiaiDoan.ValueMember = "MSGIAIDOAN";

            //Load dtgv
            this.dtgvTimkiemCV.SetDataSource("SELECT * FROM tCongVan", true);
            this.dtgvTimkiemCV.SetHeaderText(new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung"});
        }

        private void EnableButtons()
        {
            if (Utilities.Instance.IsLoadForm("fNhapCV")) this.btnNhapMSCVcha.Enabled = true;
            if (Utilities.Instance.IsLoadForm("fCapnhatCV")) this.btnNhapCV.Enabled = true;
        }

        private void SetBlankForm()
        {
            txbNoidung.Text = string.Empty;
            chkTimkhongdau.Checked = false;
            chkTimtheocumtu.Checked = false;
            cbMSCQ.SelectedItem = null;
            cbMSGiaiDoan.SelectedItem = null;
            cbMSLoaiCV.SelectedItem = null;
            dtpkNgaytu.Value = (DateTime)DataProvider.Instance.ExecuteScalar("SELECT MIN(NGAYCV) FROM tCONGVAN");
            dtpkNgayden.Value = DateTime.Today;
        }

        private void TimkiemCV(bool bTimkhongdau)
        {
            string stNoidung = txbNoidung.Text?.ToString();
            int? iMSLoaiCV = Convert.ToInt32(cbMSLoaiCV.SelectedValue);
            int? iMSCQ = Convert.ToInt32(cbMSCQ.SelectedValue);
            int? iMSGiaiDoan = Convert.ToInt32(cbMSGiaiDoan.SelectedValue);
            DateTime? dNgayCVTu = Convert.ToDateTime(dtpkNgaytu.Value);
            DateTime? dNgayCVDen = Convert.ToDateTime(dtpkNgayden.Value);
            if (bTimkhongdau) stNoidung = Functions.ConvertToUnsign(stNoidung);
            DataTable data = CongVanVM.Instance.TimkiemCongvan(stNoidung, iMSLoaiCV, iMSCQ, iMSGiaiDoan, dNgayCVTu, dNgayCVDen, bTimkhongdau);
            this.dtgvTimkiemCV.SetDataSource(data);
        }

        private void chkTimtheocumtu_CheckedChanged(object sender, EventArgs e)
        {
            cbMSCQ.Enabled = !cbMSCQ.Enabled;
            cbMSLoaiCV.Enabled = !cbMSLoaiCV.Enabled;
            cbMSGiaiDoan.Enabled = !cbMSGiaiDoan.Enabled;
            dtpkNgaytu.Enabled = !dtpkNgaytu.Enabled;
            dtpkNgayden.Enabled = !dtpkNgayden.Enabled;
        }
        #endregion

        #region Events
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            bool bTimkiemkhongdau = (chkTimkhongdau.Checked == true);
            if (chkTimtheocumtu.Checked == true)
            {
                DataTable data = CongVanVM.Instance.TimkiemCongvantheoCumtuNoidung(txbNoidung.Text, bTimkiemkhongdau);
                this.dtgvTimkiemCV.SetDataSource(data);
            }
            else
                TimkiemCV(bTimkiemkhongdau);
        }

        private void btnNhapCV_Click(object sender, EventArgs e)
        {
            ShareVar.Instance.MSCV = dtgvTimkiemCV.GetID();
            this.Close();
        }

        private void btnNhapMSCVcha_Click(object sender, EventArgs e)
        {
            ShareVar.Instance.MSCVCHA = dtgvTimkiemCV.GetID();
            this.Close();
        }

        private void btnNhaplai_Click(object sender, EventArgs e)
        {
            SetBlankForm();
            dtgvTimkiemCV.ResetData(true);
        }
        #endregion

    }
}

using App;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    public partial class fNhapCV : Form
    {
        public fNhapCV()
        {
            InitializeComponent();                    
        }   

        private void fNhapCV_Load(object sender, EventArgs e)
        {
            //Set data cho dtgv
            string stQuery = $"SELECT * FROM tCONGVAN WHERE NGAYCV = CONVERT(DATETIME,'{detailCV.GetDateString()}',103)";
            dtgvCV.SetDataSource(stQuery);
            dtgvCV.SetHeaderText(new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung" });
            //Set Binding
            SetBindingCongVan();
            //Tạo sự kiện 
            ShareVar.Instance.PropertyChanged += ShareVarInstance_PropertyChanged; //để cập nhật cbMSCVCHA
            detailCV.LoadData();
            detailCV.dtpkNgayCV.ValueChanged += detailCVDtpkNgayCV_ValueChanged;
            detailCV.txbMSCV.TextChanged += txbMSCV_TextChanged;
        }

        private void txbMSCV_TextChanged(object sender, EventArgs e)
        {
            ShareVar.Instance.MSCV = detailCV.txbMSCV.Text;
        }

        private void detailCVDtpkNgayCV_ValueChanged(object sender, EventArgs e)
        {
            string stQuery = $"SELECT * FROM tCONGVAN WHERE NGAYCV = CONVERT(DATETIME,'{detailCV.GetDateString()}',103)";
            dtgvCV.SetDataSource(stQuery);
        }

        private void ShareVarInstance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "MSCVCHA") //Move đến MSCV cha theo MSCV tai form Tìm kiếm
            {
                string stMSCVcha = ShareVar.Instance.MSCVCHA;
                if (!string.IsNullOrEmpty(stMSCVcha)) detailCV.MovecbMSCVCHA(stMSCVcha);
            }
            if (e.PropertyName == "MSCV") //Cập nhật btnXoa và btnCapNhat theo tình trạng của MSCV
            {
                string stMSCV = detailCV.txbMSCV.Text;
                this.btnXoa.Enabled = !string.IsNullOrEmpty(stMSCV);
                this.btnCapnhat.Text = string.IsNullOrEmpty(stMSCV) ? "Thêm mới" : "Cập nhật";
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fTimkiemCV f = new fTimkiemCV();
            f.ShowDialog();
            this.Show();
        }

        private void SetBindingCongVan()
        {
            if (dtgvCV.bindDtgv.DataSource == null) return;
            detailCV.txbMSCV.DataBindings.Add("Text", dtgvCV.bindDtgv, "MSCV", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.txbSoCV.DataBindings.Add("Text", dtgvCV.bindDtgv, "SOCV", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.txbNoidung.DataBindings.Add("Text", dtgvCV.bindDtgv, "NOIDUNG", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.txbFilePDF.DataBindings.Add("Text", dtgvCV.bindDtgv, "FILEPDF", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.txbFileOffice.DataBindings.Add("Text", dtgvCV.bindDtgv, "FILEOFFICE", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.txbFileRAR.DataBindings.Add("Text", dtgvCV.bindDtgv, "FILERAR", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.dtpkNgayCV.DataBindings.Add("Value", dtgvCV.bindDtgv, "NGAYCV", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.cbMSCQ.DataBindings.Add("SelectedValue", dtgvCV.bindDtgv, "MSCQ", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.cbMSLoaiCV.DataBindings.Add("SelectedValue", dtgvCV.bindDtgv, "MSLOAICV", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.cbMSCVCHA.DataBindings.Add("SelectedValue", dtgvCV.bindDtgv, "MSCVCHA", true, DataSourceUpdateMode.OnPropertyChanged);
            detailCV.cbMSGiaidoan.DataBindings.Add("SelectedValue", dtgvCV.bindDtgv, "MSGIAIDOAN", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(detailCV.txbMSCV.Text))
            {
                detailCV.ThemCongvan();
                detailCV.SetBlankAllControl();
            }
            else
            {
                detailCV.SuaCongvan();
            }
            detailCV.LoadcbMSCVCHA();
            dtgvCV.ResetData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(detailCV.txbMSCV.Text)) return;
            Functions.MsgBox("Bạn có chắc chắn muốn xoá Công văn này?", MessageType.Confirmation, 
                              ()=>{ detailCV.XoaCongvan(); dtgvCV.ResetData(); detailCV.LoadcbMSCVCHA();});
        }
    }
}

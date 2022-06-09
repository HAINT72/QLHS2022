using App;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    public partial class fCapnhatCV : Form
    {
        public fCapnhatCV()
        {
            InitializeComponent();
        }

        private void fCapnhatCV_Load(object sender, EventArgs e)
        {
            string stQuery = "SELECT * FROM tCongVan";
            dtgvCV.SetDataSource(stQuery, true);
            dtgvCV.SetHeaderText(new string[] { "MSCV", "Số CV",  "Ngày CV" ,"Nội dung"});
            detailCV.LoadData();
            ShareVar.Instance.PropertyChanged += ShareVarInstance_PropertyChanged;
            SetBindingCongVan();
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

        private void ShareVarInstance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "MSCV")
            {
                string stMSCV = ShareVar.Instance.MSCV;
                if (!string.IsNullOrEmpty(stMSCV)) dtgvCV.MoveCongVan(stMSCV);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            this.detailCV.SuaCongvan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.detailCV.XoaCongvan();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            fTimkiemCV f = new fTimkiemCV();
            f.ShowDialog();
        }
    }
}

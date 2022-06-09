using App;
using Model;
using System;
using System.Windows.Forms;
using ViewModel;

namespace View
{
    public partial class fCapnhatThongso : Form
    {
        public fCapnhatThongso()
        {
            InitializeComponent();
        }

        private void fCapnhatThongso_Load(object sender, EventArgs e)
        {
            this.dtgvThongSo.SetDataSource("SELECT * FROM tThongso");
            this.dtgvThongSo.SetHeaderText(new string[] { "Tên CSDL", "Nội dung", "Chuỗi kết nối", "Đường dẫn File", "*" });
            this.dtgvThongSo.AutoSizeDtgvCellsOn();
            SetBinding();
        }

        private void SetBinding()
        {
            txbMSTS.DataBindings.Add("Text", dtgvThongSo.bindDtgv, "MSTS", true, DataSourceUpdateMode.OnPropertyChanged);
            txbNoidung.DataBindings.Add("Text", dtgvThongSo.bindDtgv, "NOIDUNG", true, DataSourceUpdateMode.OnPropertyChanged);
            txbStrPath.DataBindings.Add("Text", dtgvThongSo.bindDtgv, "STR_PATH", true, DataSourceUpdateMode.OnPropertyChanged);
            txbStrData.DataBindings.Add("Text", dtgvThongSo.bindDtgv, "STR_DATA", true, DataSourceUpdateMode.OnPropertyChanged);
            chkHieuluc.DataBindings.Add("Checked", dtgvThongSo.bindDtgv, "HIEULUC", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void txbStrPath_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdlg = new FolderBrowserDialog();
            fbdlg.ShowDialog();
            txbStrPath.Text = fbdlg.SelectedPath;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            ThongSo ts = dtgvThongSo.GetDataCurrent<ThongSo>();
            if (ThongSoVM.Instance.CapnhatThongSo(ts))
                Functions.MsgBox("Cập nhật dữ liệu thành công", MessageType.Success);
            else
                Functions.MsgBox("Đã có lỗi khi cập nhật", MessageType.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ThongSo ts = dtgvThongSo.GetDataCurrent<ThongSo>();
            if (ThongSoVM.Instance.XoaThongSo(ts))
                Functions.MsgBox("Xoá dữ liệu thành công", MessageType.Success);
            else
                Functions.MsgBox("Đã có lỗi khi xoá", MessageType.Error);
        }
    }
}

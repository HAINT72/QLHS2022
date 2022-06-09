using App;
using System;
using System.Windows.Forms;
using ViewModel;

namespace View
{
    public partial class fChonCSDL : Form
    {
        public fChonCSDL()
        {
            InitializeComponent();
        }

        private void fChonCSDL_Load(object sender, EventArgs e)
        {
            this.dtgvTS.SetDataSource("SELECT * FROM tThongSo WHERE HIEULUC = 1");
            this.dtgvTS.SetHeaderText(new string[] { "Tên CSDL", "Nội dung" });
            this.dtgvTS.AutoSizeDtgvCellsOn();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            string stMSTS = dtgvTS.GetID();
            if (string.IsNullOrEmpty(stMSTS) || stMSTS == DataProvider.Instance.stMSTS) return;
            ThongSoVM.Instance.EditAppSetting(stMSTS);
            string stMess = $"Đã chọn dữ liệu sử dụng [{stMSTS}].\n Thoát chương trình để dùng dữ liệu mới.";
            Functions.MsgBox(stMess, MessageType.Information);
            Application.Exit();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            string stMSTS = DataProvider.Instance.stMSTS;
            string stMess = $"Bạn không đổi dữ liệu sử dụng. \n Dữ liệu sử dụng [{stMSTS}].";
            Functions.MsgBox(stMess, MessageType.Information);
            this.Close();
        }
    }
}

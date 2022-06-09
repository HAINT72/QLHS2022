using System;
using System.Windows.Forms;
using App;
using ViewModel;
using Model;

namespace View
{
    public partial class fCaidatUser : Form
    {
        public fCaidatUser()
        {
            InitializeComponent();
        }

        private void fCaidatUser_Load(object sender, EventArgs e)
        {
            this.dtgvNhanvien.SetDataSource("SELECT * FROM tNhanvien ORDER BY MSNV");
            this.dtgvNhanvien.SetHeaderText(new string[] { "Username", "Họ và tên", "Quyền", "Email", null, "*" });
            this.dtgvNhanvien.AutoSizeDtgvCellsOn();
            this.radioBtnAD.Enabled = (ShareVar.Instance.NV.QUYENTRUYCAP == "AD");
            SetBinding();
        }
        private void SetBinding()
        {
            grpQuyenTC.DataBindings.Add("Tag", dtgvNhanvien.bindDtgv, "QUYENTRUYCAP", true, DataSourceUpdateMode.OnPropertyChanged);            
            UpdateStateRadioButton();
            txbHoten.DataBindings.Add("Text", dtgvNhanvien.bindDtgv, "HOTEN", true, DataSourceUpdateMode.OnPropertyChanged);
            txbEmail.DataBindings.Add("Text", dtgvNhanvien.bindDtgv, "EMAIL", true, DataSourceUpdateMode.OnPropertyChanged);
            txbUsername.DataBindings.Add("Text", dtgvNhanvien.bindDtgv, "MSNV", true, DataSourceUpdateMode.OnPropertyChanged);            
            chkHieuluc.DataBindings.Add("Checked", dtgvNhanvien.bindDtgv, "HIEULUC", true, DataSourceUpdateMode.OnPropertyChanged);            
        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            UpdateStateRadioButton();
        }

        private void UpdateStateRadioButton()
        {
            switch (grpQuyenTC.Tag.ToString())
            {
                case "LD":
                    radioBtnLD.Checked = true;
                    break;
                case "VT":
                    radioBtnVT.Checked = true;
                    break;
                case "NV":
                    radioBtnNV.Checked = true;
                    break;
                case "AD":
                    radioBtnAD.Checked = true;
                    break;
                default:
                    radioBtnKO.Checked = true;
                    break;
            }           
        }

        private void radioBtnVT_CheckedChanged(object sender, EventArgs e)
        {
            grpQuyenTC.Tag = "VT";
        }

        private void radioBtnLD_CheckedChanged(object sender, EventArgs e)
        {
            grpQuyenTC.Tag = "LD";
        }

        private void radioBtnNV_CheckedChanged(object sender, EventArgs e)
        {
            grpQuyenTC.Tag = "NV";
        }

        private void radioBtnAD_CheckedChanged(object sender, EventArgs e)
        {                          
            grpQuyenTC.Tag = "AD";
        }

        private void btnResetMK_Click(object sender, EventArgs e)
        {
            if (NhanVienVM.Instance.ResetPassword(this.txbUsername.Text))
                Functions.MsgBox("Đã reset mật khẩu thành công. Mật khẩu mới của bạn là '1'.", MessageType.Success);
            else
                Functions.MsgBox("Reset mật khẩu thất bại.", MessageType.Error);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            NhanVien nv = dtgvNhanvien.GetDataCurrent<NhanVien>();            
            if (NhanVienVM.Instance.CapnhatNhanVien(nv))
                Functions.MsgBox("Cập nhật dữ liệu thành công", MessageType.Success);
            else
                Functions.MsgBox("Đã có lỗi khi cập nhật", MessageType.Error);
        }

    }
}

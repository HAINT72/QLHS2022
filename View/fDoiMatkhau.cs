using App;
using ViewModel;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class fDoiMatkhau : Form
    {
        public fDoiMatkhau()
        {
            InitializeComponent();
        }
        #region event
        private void btnOK_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text;
            string passWord = txbOldPassword.Text;
            if (NhanVienVM.Instance.Login(userName, passWord) == false)
            {
                Functions.MsgBox( "Sai tên tài khoản hoặc mật khẩu!", MessageType.Error);
                return;
            }
            string newPassword = txbNewPassword.Text;
            string rePassword = txbRePassword.Text;
            if (newPassword!=rePassword)
            {
                Functions.MsgBox("Nhập lại mật khẩu không khớp!", MessageType.Error);
                return;                               
            }
            newPassword= Utilities.Instance.stToMD5(newPassword);
            if (NhanVienVM.Instance.UpdatePassword(userName, newPassword))
            {
                Functions.MsgBox( "Đổi mật khẩu thành công", MessageType.Success);
                return;
            }
            this.Close();           
        }

        private void fDoiMatkhau_Load(object sender, EventArgs e)
        {
            txbUsername.Text = ShareVar.Instance.NV.MSNV;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

using ViewModel;
using System;
using System.Windows.Forms;
using App;
using System.IO;

namespace View
{
    public partial class fLogin : Form
    {
        
        public fLogin()
        {
            InitializeComponent();
            string stLabel = $"Cơ sở dữ liệu hiện hành: [{DataProvider.Instance.stMSTS}]";
            this.lblData.Text = stLabel;
            //Tạo thư mục temp lưu file đính kèm
            string stDirectoryOfFileAttch = Utilities.Instance.stDirectoryOfFileAttch;
            if (!Directory.Exists(stDirectoryOfFileAttch)) Directory.CreateDirectory(stDirectoryOfFileAttch);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (NhanVienVM.Instance.Login(userName, passWord))
            {
                DangNhapVM.Instance.SaveLoginLogout("Login");
                using (fMain f = new fMain()) { f.ShowDialog();}
            }
            else
                Functions.MsgBox("Sai tên tài khoản hoặc mật khẩu!", MessageType.Error);
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (NhanVienVM.Instance.Login(userName, passWord) && (ShareVar.Instance.NV.QUYENTRUYCAP =="AD"))
            {
                fThongsoCaidat f = new fThongsoCaidat();
                f.ShowDialog();
            }
            else
                Functions.MsgBox("Bạn không có quyền truy cập mục này.", MessageType.Error);
        }

        private void btnChonCSDL_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (NhanVienVM.Instance.Login(userName, passWord))
            {
                fChonCSDL f = new fChonCSDL();
                f.ShowDialog();
            }
            else
                Functions.MsgBox("Sai tên tài khoản hoặc mật khẩu!", MessageType.Error);
        }
    }
}

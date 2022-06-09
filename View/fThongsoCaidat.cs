using System;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using App;

namespace View
{
    public partial class fThongsoCaidat : Form
    {
        public fThongsoCaidat()
        {
            InitializeComponent();
        }

        private void fThongsoCaidat_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dicSetting = new Dictionary<string, string>();
            dicSetting = DataProvider.Instance.GetAppSetting();
            txbTenCSDL.Text = dicSetting["MSTS"];
            txbChuoiketnoi.Text = dicSetting["stCnn"];
            txbEmail.Text = dicSetting["mailName"];
            txbMatkhau.Text = dicSetting["passMail"];
            txbPort.Text = dicSetting["smtpPort"];
            txbMaychu.Text = dicSetting["smtpHost"];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.EditAppSetting("MSTS", txbTenCSDL.Text);
            DataProvider.Instance.EditAppSetting("stCnn", txbChuoiketnoi.Text);
            DataProvider.Instance.EditAppSetting("mailName", txbEmail.Text);
            DataProvider.Instance.EditAppSetting("passMail", txbMatkhau.Text);
            DataProvider.Instance.EditAppSetting("smtpPort", txbPort.Text);
            DataProvider.Instance.EditAppSetting("smtpHost", txbMaychu.Text);
            Functions.MsgBox("Đã hoàn thành cập nhật. Bạn có muốn thoát?", MessageType.Confirmation, () => { this.Close(); });
        }
    }
}

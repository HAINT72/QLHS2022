using App;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class fDieuchinhMSDulieuPT : Form
    {
        public fDieuchinhMSDulieuPT()
        {
            InitializeComponent();
        }

        private void btnOK_MSCQ_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSCQ_Base.Text) || string.IsNullOrEmpty(txbMSCQ_Edit.Text)) return;
            string stMess = "Cập nhật thay đổi dữ liệu. Bạn có chắc chắn muốn thực hiện không?\n (Lưu ý: Backup dữ liệu trước khi thực hiện lệnh này.)";
            if (Functions.MsgBox(stMess, MessageType.Confirmation) != DialogResult.Yes) return;

            int iBaseId = Convert.ToInt32(txbMSCQ_Base.Text);
            string stEditId = txbMSCQ_Edit.Text;
            string[] listEidtId = stEditId.Split(',');
            foreach (string item in listEidtId)
            {
                int iEditId = Convert.ToInt32(item);
                string stQueryUpdate = $"UPDATE tCongVan SET MSCQ = {iBaseId} WHERE MSCQ = {iEditId}";
                DataProvider.Instance.ExecuteNonQuery(stQueryUpdate);
                string stQueryDelete = $"DELETE FROM tCoQuan WHERE MSCQ = {iEditId}";
                DataProvider.Instance.ExecuteNonQuery(stQueryDelete);
            }
            Functions.MsgBox("Đã hoàn thành cập nhật");
            txbMSCQ_Edit.Text = string.Empty;
            txbMSCQ_Base.Text = string.Empty;
        }

        private void btnOK_MSLOAICV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSLOAICV_Base.Text) || string.IsNullOrEmpty(txbMSLOAICV_Edit.Text)) return;
            string stMess = "Cập nhật thay đổi dữ liệu. Bạn có chắc chắn muốn thực hiện không?\n (Lưu ý: Backup dữ liệu trước khi thực hiện lệnh này.)";
            if (Functions.MsgBox(stMess, MessageType.Confirmation) != DialogResult.Yes) return;

            int iBaseId = Convert.ToInt32(txbMSLOAICV_Base.Text);
            string stEditId = txbMSLOAICV_Edit.Text;
            string[] listEidtId = stEditId.Split(',');
            foreach (string item in listEidtId)
            {
                int iEditId = Convert.ToInt32(item);
                string stQueryUpdate = $"UPDATE tCongVan SET MSLOAICV = {iBaseId} WHERE MSLOAICV = {iEditId}";
                DataProvider.Instance.ExecuteNonQuery(stQueryUpdate);
                string stQueryDelete = $"DELETE FROM tLOAICV WHERE MSLOAICV = {iEditId}";
                DataProvider.Instance.ExecuteNonQuery(stQueryDelete);
            }
            Functions.MsgBox("Đã hoàn thành cập nhật");
            txbMSLOAICV_Edit.Text = string.Empty;
            txbMSLOAICV_Base.Text = string.Empty;
        }

        private void btnOK_MSDUOICV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSDUOICV_Base.Text) || string.IsNullOrEmpty(txbMSDUOICV_Edit.Text)) return;
            string stMess = "Thay đổi dữ liệu cơ sở. Bạn có chắc chắn muốn thực hiện không?\n (Lưu ý: Backup dữ liệu trước khi thực hiện lệnh này.)";
            if (Functions.MsgBox(stMess, MessageType.Confirmation) != DialogResult.Yes) return;

            int iBaseId = Convert.ToInt32(txbMSDUOICV_Base.Text);
            string stEditId = txbMSDUOICV_Edit.Text;
            string[] listEidtId = stEditId.Split(',');
            foreach (string item in listEidtId)
            {
                int iEditId = Convert.ToInt32(item);
                string stQueryUpdate = $"UPDATE tCongVan SET MSDUOICV = {iBaseId} WHERE MSDUOICV = {iEditId}";
                DataProvider.Instance.ExecuteNonQuery(stQueryUpdate);
                string stQueryDelete = $"DELETE FROM tDuoiCV WHERE MSDUOICV = {iEditId}";
                DataProvider.Instance.ExecuteNonQuery(stQueryDelete);
            }
            Functions.MsgBox("Đã hoàn thành cập nhật");
            txbMSDUOICV_Edit.Text = string.Empty;
            txbMSDUOICV_Base.Text = string.Empty;
        }
    }
}

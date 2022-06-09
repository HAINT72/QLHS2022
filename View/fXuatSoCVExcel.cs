using App;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ViewModel;

namespace View
{
    public partial class fXuatSoCVExcel : Form
    {
        public fXuatSoCVExcel()
        {
            InitializeComponent();
        }

        private void fXuatSoCVExcel_Load(object sender, EventArgs e)
        {
            // Load dtpkNgay
            dtpkNgayTu.Value = (DateTime)DataProvider.Instance.ExecuteScalar("SELECT MIN(NGAYCV) FROM tCONGVAN");
            dtpkNgayDen.Value = DateTime.Today;
            // Select radioBtnToanBo
            this.radioBtnToanBo.Checked = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatSoCV_Click(object sender, EventArgs e)
        {
            DateTime dNgayTu = this.dtpkNgayTu.Value;
            DateTime dNgayDen = this.dtpkNgayDen.Value;

            if(CheckDateInput(dNgayDen, dNgayTu))
            {
                Functions.MsgBox("Không được chọn 'Từ ngày' sau 'Đến ngày'. Hãy chọn lại", MessageType.Error);
                return;
            }

            string stFilePath = Utilities.Instance.GetFullFileExcelName();
            if (string.IsNullOrEmpty(stFilePath)) return;
            if (File.Exists(stFilePath)) File.Delete(stFilePath);

            DataTable data = new DataTable();
            if (this.radioBtnCVDi.Checked)
            {
                data = CongVanVM.Instance.GetSoCV(dNgayTu, dNgayDen, "T");
                Utilities.Instance.ExportToExcel(data, stFilePath, "Sổ CV đi");
            }
            else if (this.radioBtnCVDen.Checked)
            {
                data = CongVanVM.Instance.GetSoCV(dNgayTu, dNgayDen, "F");
                Utilities.Instance.ExportToExcel(data, stFilePath, "Sổ CV đến");
            }
            else
            {
                data = CongVanVM.Instance.GetSoCV(dNgayTu, dNgayDen, "T");
                Utilities.Instance.ExportToExcel(data, stFilePath, "Sổ CV đi");
                data = CongVanVM.Instance.GetSoCV(dNgayTu, dNgayDen, "F");
                Utilities.Instance.ExportToExcel(data, stFilePath, "Sổ CV đến");
            }
            string stMess = "Đã hoàn thành xuất Sổ CV ra Ms.Excel. Bạn có muốn mở file không?";
            Functions.MsgBox(stMess, MessageType.Confirmation, () => { Process.Start(stFilePath);});
        }
        private bool CheckDateInput(DateTime dNgayTu, DateTime dNgayDen)
        {
            return DateTime.Compare(dNgayDen, dNgayTu)>0;
        }
    }
}

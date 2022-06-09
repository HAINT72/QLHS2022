using App;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ViewModel;

namespace View
{
    public partial class fGiaoviec : Form
    {
        public fGiaoviec()
        {
            InitializeComponent();
        }

        private void fGiaoviec_Load(object sender, EventArgs e)
        {
            //Load dtgvCV
            dtgvCV.SetDataSource("SELECT * FROM tCongVan WHERE PHEDUYET=0 ORDER BY NGAYCV DESC", true);
            dtgvCV.SetHeaderText(new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung" });
            //Load dtgvGV
            dtgvGV.SetDataSource("SELECT * FROM tGiaoViec WHERE MSCVGIAOVIEC NOT IN (SELECT MSCV FROM tCongVan WHERE PHEDUYET=1) ORDER BY MSCVGIAOVIEC DESC, NGAYGIO ASC");
            dtgvGV.SetBinding();
            dtgvGV.SetHeaderText(new string[] { "MSCV", "MSNV", "Nội dung chỉ đạo", "Ngày, giờ" });
            //Load Listbox
            lstbNV.DataSource = DataProvider.Instance.ExecuteQuery("SELECT MSNV, HOTEN FROM tNhanVien");
            lstbNV.DisplayMember = "HOTEN";
            lstbNV.ValueMember = "MSNV";
        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            string stMSCV = dtgvCV.GetID();
            dtgvCV.bindDtgv.RemoveCurrent();
            List<GiaoViec> lst = dtgvGV.bindDtgv.DataSource as List<GiaoViec>;
            if (lst.Exists((gv) => { return gv.MSCVGIAOVIEC == stMSCV; }))
            {
                Functions.MsgBox("Công văn đã được chỉ đạo", MessageType.Information);
                return;
            }
            string stMSNV = ShareVar.Instance.NV.MSNV;
            GiaoViecVM.Instance.CapnhatGiaoViec(stMSCV, stMSNV, "@", false);
            dtgvGV.ResetData();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            GiaoViec gv = dtgvGV.GetDataCurrent<GiaoViec>();
            string stMSCV = gv.MSCVGIAOVIEC;
            string stMSNV = lstbNV.SelectedValue.ToString();
            List<GiaoViec> lst = dtgvGV.bindDtgv.DataSource as List<GiaoViec>;
            if (lst.Exists((g) => { return ((g.MSCVGIAOVIEC == stMSCV) && (g.MSNVGIAOVIEC == stMSNV)); }))
            {
                Functions.MsgBox("Nhân viên đã có trong danh sách giao việc", MessageType.Information);
                return;
            }
            GiaoViecVM.Instance.CapnhatGiaoViec(stMSCV, stMSNV, string.Empty, true);
            dtgvGV.ResetData();
        }
        
        private void xemFilePdfMenuItem_Click(object sender, EventArgs e)
        {
            string stMSCV = dtgvGV.GetID();
            CongVanVM.Instance.OpenFileAtch(stMSCV);
        }

        private void SendMailMenuItem_Click(object sender, EventArgs e)
        {
            GiaoViecVM.Instance.SendEmailGV(dtgvGV.GetID());
        }

        private void dtgvGV_Enter(object sender, EventArgs e)
        {
            int iRowCount = dtgvGV.bindDtgv.Count;
            cmsDtgvGV.Items[0].Enabled = (iRowCount > 0);
            cmsDtgvGV.Items[1].Enabled = (iRowCount > 0);
            //string stID = this.dtgvGV.GetID();
            //cmsDtgvGV.Items[0].Enabled = !string.IsNullOrEmpty(stID);
            //cmsDtgvGV.Items[1].Enabled = !string.IsNullOrEmpty(stID);
        }
    }
}

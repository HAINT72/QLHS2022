using System;
using System.Windows.Forms;
using App;
using ViewModel;
using UserControls;
using System.Threading;
using System.Data;

namespace View
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            string stMSCV = ShareVar.Instance.NV.MSNV;
            string stQuery = $"UPDATE UVW_GiaoViec SET THONGBAO =1 WHERE MSNVGIAOVIEC ='{stMSCV}' AND PHEDUYET = 0 AND CHIDAO !='@'";
            DataProvider.Instance.ExecuteNonQuery(stQuery);
            timerMain.Start();
        }
        private void fMain_Activated(object sender, EventArgs e)
        {
            string stMSNV = ShareVar.Instance.NV.MSNV;
            string stQuyenTC = ShareVar.Instance.NV.QUYENTRUYCAP;
            string stDatabaseName = DataProvider.Instance.stMSTS;
            txbtoolStripUsername.Text = $"Người đăng nhập: {stMSNV} ({stQuyenTC})";
            txbtoolStripDatabaseName.Text = $"Dữ liệu sử dụng: [{stDatabaseName}]";
            AdminMenuItem.Enabled = (stQuyenTC == "AD");
            VanThuMenuItem.Enabled = (stQuyenTC == "VT" || stQuyenTC == "AD");
            LanhDaoMenuItem.Enabled = (stQuyenTC == "LD" || stQuyenTC == "AD");
            NhanVienMenuItem.Enabled = (stQuyenTC != "OFFLINE");
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Functions.MsgBox("Bạn có thật sự muốn đăng xuất?", MessageType.Confirmation, () => { DangNhapVM.Instance.SaveLoginLogout("Logout"); }, () => { e.Cancel = true; });
        }

        private void AD_ThongSoKetNoiMenuItem_Click(object sender, EventArgs e)
        {
            fCapnhatThongso f = new fCapnhatThongso();
            f.ShowDialog();
        }

        private void AD_ThongSoCaiDatMenuItem_Click(object sender, EventArgs e)
        {
            fThongsoCaidat f = new fThongsoCaidat();
            f.ShowDialog();
        }

        private void AD_NhatKyDangNhapMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            string[] stArrayHeader = new string[] { "User", "Ngày giờ vào", "Ngày giờ ra" };
            string stQuery = "SELECT *, MSNVLOGIN AS [COL0] FROM tDangnhap ORDER BY NGAYGIOVAO DESC";
            ShowDtgvFilterUC(stArrayHeader, stQuery);
        }

        private void AD_DieuChinhMSMenuItem_Click(object sender, EventArgs e)
        {
            fDieuchinhMSDulieuPT f = new fDieuchinhMSDulieuPT();
            f.ShowDialog();
        }

        private void AD_CapNhatCVGocMenuItem_Click(object sender, EventArgs e)
        {
            fSuaCVGoc f = new fSuaCVGoc();
            f.ShowDialog();
        }

        private void VT_ThemCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            Thread t1 = new Thread(() =>
            {
                string stLabel = "Nhập CÔNG VĂN";
                this.Invoke(new Action(() => { ShowDetailCrudUC(stLabel);}));
            });
            t1.Start();
            t1.IsBackground = true;

            Thread t2 = new Thread(() =>
            {
                string stLabel = "Cập nhật 'nội dung' CÔNG VĂN";
                string stQuery = "SELECT * FROM tCongVan WHERE NOIDUNG ='' OR NOIDUNG IS NULL";
                this.Invoke(new Action(() => { ShowDetailCrudUC(stLabel, stQuery); }));
            });
            t2.Start();
            t2.IsBackground = true;

            Thread t3 = new Thread(() =>
            {
                string stLabel = "Cập nhật 'số' CÔNG VĂN";
                string stQuery = "SELECT * FROM tCongVan WHERE SOCV ='' OR SOCV IS NULL";
                this.Invoke(new Action(() => { ShowDetailCrudUC(stLabel, stQuery); }));
            });
            t3.Start();
            t3.IsBackground = true;
        }

        private void VT_PhathanhCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            string stLabel = "Phát hành công văn đi";
            string stQuery = "SELECT * FROM tCongVan WHERE PHEDUYET = 0 AND LEFT(MSCV,1)='T'";
            ShowDetailCrudUC(stLabel, stQuery); 
        }

        private void VT_CapnhatCVMenuItem_Click(object sender, EventArgs e)
        {
            fCapnhatCV f = new fCapnhatCV();
            f.ShowDialog();
        }

        private void VT_BosungDinhkemMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            Thread t1 = new Thread(() =>
            {
                string stLabel = "Đính kèm file PDF cho CÔNG VĂN ĐI";
                string stQuery = "SELECT * FROM tCongVan WHERE LEFT(MSCV,1)='T' AND (FILEPDF='' OR FILEPDF IS NULL)";
                this.Invoke(new Action(() => { ShowDetailCrudUC(stLabel, stQuery); }));
            });
            t1.Start();
            t1.IsBackground = true;

            Thread t2 = new Thread(() =>
            {
                string stLabel = "Đính kèm file OFFICE cho CÔNG VĂN ĐI";
                string stQuery = "SELECT * FROM tCongVan WHERE LEFT(MSCV,1)='T' AND (FILEOFFICE ='' OR FILEOFFICE IS NULL)";
                this.Invoke(new Action(() => { ShowDetailCrudUC(stLabel, stQuery); }));
            });
            t2.Start();
            t2.IsBackground = true;

            Thread t3 = new Thread(() =>
            {
                string stLabel = "Đính kèm file cho CÔNG VĂN ĐẾN";
                string stQuery = "SELECT * FROM tCongVan WHERE LEFT(MSCV,1)='F' AND (FILEPDF='' OR FILEPDF IS NULL)";
                this.Invoke(new Action(() => { ShowDetailCrudUC(stLabel, stQuery); }));
            });
            t3.Start();
            t3.IsBackground = true;
        }

        private void VT_CapnhatUserMenuItem_Click(object sender, EventArgs e)
        {
            fCaidatUser f = new fCaidatUser();
            f.ShowDialog();
        }

        private void VT_DulieuPT_CoQuanMenuItem_Click(object sender, EventArgs e)
        {
            string[] stArrayHeader = new string[] { "Id", "Cơ quan" };
            string stQuery = "SELECT * FROM tCoQuan ORDER BY TENCQ";
            ShowDtgvCrudUC(stArrayHeader, stQuery);
        }

        private void VT_DulieuPT_LoaiCVMenuItem_Click(object sender, EventArgs e)
        {
            string[] stArrayHeader = new string[] { "Id", "Loại CV" };
            string stQuery = "SELECT * FROM tLoaiCV ORDER BY LOAICV";
            ShowDtgvCrudUC(stArrayHeader, stQuery);
        }

        private void VT_DulieuPT_DuoiCVMenuItem_Click(object sender, EventArgs e)
        {
            string[] stArrayHeader = new string[] { "Id", "Đuôi CV" };
            string stQuery = "SELECT * FROM tDuoiCV ORDER BY DUOICV";
            ShowDtgvCrudUC(stArrayHeader, stQuery);
        }

        private void VT_DulieuPT_UserMenuItem_Click(object sender, EventArgs e)
        {
            string[] stArrayHeader = new string[] { "Username", null, "Quyền", null, null, "*" };
            string stQuery = "SELECT * FROM tNhanVien ORDER BY QUYENTRUYCAP DESC";
            ShowDtgvCrudUC(stArrayHeader, stQuery);
        }

        private void VT_DulieuPT_GiaiDoanMenuItem_Click(object sender, EventArgs e)
        {
            string[] stArrayHeader = new string[] { "Id", "Giai đoạn", "MSCV gốc" };
            string stQuery = "SELECT * FROM tGiaiDoan";
            ShowDtgvCrudUC(stArrayHeader, stQuery);
        }

        private void VT_XuatSoCVMSExcelMenuItem_Click(object sender, EventArgs e)
        {
            fXuatSoCVExcel f = new fXuatSoCVExcel();
            f.ShowDialog();
        }

        private void VT_SuaCayCVMenuItem_Click(object sender, EventArgs e)
        {
            fSuaCayCV f = new fSuaCayCV();
            f.ShowDialog();
        }

        private void LD_GiaoviecNVMenuItem_Click(object sender, EventArgs e)
        {
            fGiaoviec f = new fGiaoviec();
            f.ShowDialog();
        }

        private void LD_PheduyetCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            string stLabel = "Phê duyệt Công văn đến";
            string stQuery = "SELECT * FROM tCongVan WHERE PHEDUYET = 0 AND LEFT(MSCV,1)='F'";
            ShowDetailCrudUC(stLabel, stQuery); 
        }

        private void NV_NhapCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            fNhapCV f = new fNhapCV();
            f.ShowDialog();
        }

        private void NV_TimkiemCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            fTimkiemCV f = new fTimkiemCV();
            f.ShowDialog();
        }

        private void NV_SoCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            Thread t1 = new Thread(() =>
            {
                string[] stArrayHeader = new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung" };
                string stQuery = "SELECT * FROM tCongVan WHERE LEFT(MSCV,1)='F'";
                this.Invoke(new Action(() => { ShowDtgvCVFilterUC(stArrayHeader, stQuery); }));
            });
            t1.Start();
            t1.IsBackground = true;

            Thread t2 = new Thread(() =>
            {
                string[] stArrayHeader = new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung" };
                string stQuery = "SELECT * FROM tCongVan WHERE PHEDUYET=1 AND LEFT(MSCV,1)='T' ";
                this.Invoke(new Action(() => { ShowDtgvCVFilterUC(stArrayHeader, stQuery); }));
            });
            t2.Start();
            t2.IsBackground = true;
        }

        private void NV_CayCVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            fCayCV f = new fCayCV();
            f.ShowDialog();
        }

        private void NV_BangGVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            string[] stArrayHeader = new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung", "Chỉ đạo", "Ngày, giờ" };
            string stMSCV = ShareVar.Instance.NV.MSNV;
            string stQuery = $"SELECT * FROM UVW_GIAOVIEC WHERE MSNVGIAOVIEC='{stMSCV}'";
            ShowDtgvCVFilterUC(stArrayHeader, stQuery); 
        }

        private void NV_ThaydoiCSDLMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            fChonCSDL f = new fChonCSDL();
            f.ShowDialog();
        }

        private void NV_ThaydoiMKMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            fDoiMatkhau f = new fDoiMatkhau();
            f.ShowDialog();
        }

        private void NV_DangxuatMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            LogoutCurrentUser();
        }

        private void LogoutCurrentUser()
        {
            DangNhapVM.Instance.SaveLoginLogout("Logout");
            this.Close();
        }

        private void ShowDetailCrudUC(string stTitle, string stQuery = null)
        {
            if (!string.IsNullOrEmpty(stQuery))
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
                if (data.Rows.Count == 0)
                {
                    Functions.MsgBox("Không có dữ liệu.", MessageType.Information);
                    return;
                }
            }
            detailCrudCVUC dCrudCV = new detailCrudCVUC();
            dCrudCV.SetDataSource(stQuery);
            dCrudCV.LoadData();
            dCrudCV.EnableAddnewButton();
            dCrudCV.SetBindingCongVan();
            dCrudCV.SetTitle(stTitle);
            this.flowLayoutPnlMain.Controls.Add(dCrudCV);
        }

        private void ShowDtgvCVFilterUC(string[] stHeaders, string stQuery)
        {
            dtgvFilterCVUC dtgvCV = new dtgvFilterCVUC();
            dtgvCV.SetDataSource(stQuery, true);
            this.flowLayoutPnlMain.Controls.Add(dtgvCV);
            dtgvCV.SetHeaderText(stHeaders);
        }

        private void ShowDtgvFilterUC(string[] stHeaders, string stQuery)
        {
            dtgvFilterUC dtgvCV = new dtgvFilterUC();
            dtgvCV.SetDataSource(stQuery, true);
            this.flowLayoutPnlMain.Controls.Add(dtgvCV);
            dtgvCV.SetHeaderText(stHeaders);
        }

        private void ShowDtgvCrudUC(string[] stHeaders, string stQuery)
        {
            dtgvCrudUC dtgv = new dtgvCrudUC(stQuery);
            this.flowLayoutPnlMain.Controls.Add(dtgv);
            dtgv.SetHeaderText(stHeaders);
            dtgv.AutoSizeDtgvCellsOn();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            string stMSCV = ShareVar.Instance.NV.MSNV;
            string stQuery = $"SELECT COUNT(*) FROM UVW_GiaoViec WHERE MSNVGIAOVIEC ='{stMSCV}' AND THONGBAO =1 AND PHEDUYET=0";
            int iSoCV = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(stQuery));
            if (iSoCV > 0)
            {
                notifyIconMain.BalloonTipTitle = "QLHS thông báo";
                notifyIconMain.BalloonTipText = $"Bạn có {iSoCV} công văn cần xử lý";
                notifyIconMain.ShowBalloonTip(5000);
            }
        }

        private void cmsNotifyIconMain_GVMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
            string[] stArrayHeader = new string[] { "MSCV", "Số CV", "Ngày CV", "Nội dung", "Chỉ đạo", "Ngày, giờ" };
            string stMSCV = ShareVar.Instance.NV.MSNV;
            string stQuery = $"SELECT * FROM UVW_GIAOVIEC WHERE MSNVGIAOVIEC='{stMSCV}'";
            ShowDtgvCVFilterUC(stArrayHeader, stQuery);
        }

        private void cmsNotifyIconMain_OkMenuItem_Click(object sender, EventArgs e)
        {
            string stMSCV = ShareVar.Instance.NV.MSNV;
            string stQuery = $"UPDATE UVW_GiaoViec SET THONGBAO = 0 WHERE MSNVGIAOVIEC ='{stMSCV}' AND PHEDUYET=0";
            DataProvider.Instance.ExecuteNonQuery(stQuery);
        }

        private void cmsNotifyIconMain_CloseMenuItem_Click(object sender, EventArgs e)
        {
            timerMain.Enabled = !timerMain.Enabled;
            string stThongbao = cmsNotifyIconMain_CloseMenuItem.Text;
            cmsNotifyIconMain_CloseMenuItem.Text = (stThongbao == "Bật thông báo") ? "Tắt thông báo" : "Bật thông báo";
        }

        private void cmsFormMainTimCVMenuItem_Click(object sender, EventArgs e)
        {
            NV_TimkiemCVMenuItem_Click(this, null);
        }

        private void cmsFormMainSoCVMenuItem_Click(object sender, EventArgs e)
        {
            NV_SoCVMenuItem_Click(this, null);
        }

        private void cmsFormMainCayCVMenuItem_Click(object sender, EventArgs e)
        {
            NV_CayCVMenuItem_Click(this, null);
        }

        private void cmsFormMainThaydoiCSDLMenuItem_Click(object sender, EventArgs e)
        {
            NV_ThaydoiCSDLMenuItem_Click(this, null);
        }

        private void cmsFormMainDangxuatMenuItem_Click(object sender, EventArgs e)
        {
            NV_DangxuatMenuItem_Click(this, null);
        }

        private void cmsFormMainXoaMHMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPnlMain.Controls.Clear();
        }

        private void AD_CapNhatFilePDFMenuItem_Click(object sender, EventArgs e)
        {
            string[,] TenFiles = Utilities.Instance.ReadFileNameFromServerDirectory();
            int iLength = TenFiles.GetLength(1);
            for (int i = 0; i < iLength; i++)
            {
                CongVanVM.Instance.ThemCongvan(TenFiles[1, i], TenFiles[0, i]);
            }
            Functions.MsgBox("Đã hoàn thành thêm dữ liệu");
        }
    }
}

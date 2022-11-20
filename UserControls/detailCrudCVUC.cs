using App;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace UserControls
{
    // Chỉ áp dụng trên menu Văn thư; cho phép Sửa, Xoá; không cho phép Thêm
    public class detailCrudCVUC : detailCVUC
    {
        private BindingSource bindCV = new BindingSource();
        private BindingNavigator bindNavigator = new BindingNavigator(true);
        private ToolStripButton tsbtnSave = new ToolStripButton();
        private ToolStripButton tsbtnDelete = new ToolStripButton();
        private string stQuerySave = null;

        public detailCrudCVUC()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Cài đặt bindNavigator 
            bindNavigator.Dock = DockStyle.Bottom;
            bindNavigator.BindingSource = bindCV;
            bindNavigator.AddNewItem.Enabled = false;
            bindNavigator.DeleteItem.Enabled = false;
            bindNavigator.Size = new Size(450, 30);

            //Cài đặt nút save trên BindingNavigator            
            tsbtnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnSave.Image = global::App.Properties.Resources.baseline_check_black_18dp;
            bindNavigator.Items.Add(tsbtnSave);

            //Cài đặt nút delete trên BindingNavigator            
            tsbtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnDelete.Image = global::App.Properties.Resources.outline_delete_black_18dp;
            bindNavigator.Items.Add(tsbtnDelete);

            //Phát sinh events
            bindNavigator.AddNewItem.Click += bindNavigatorAddNewItem_Click;
            tsbtnSave.Click += tsbtnSave_Click;
            tsbtnDelete.Click += tsbtnDelete_Click;
            bindNavigator.Paint += bindNavigator_Paint;

            //Add vào control
            Controls.AddRange(new Control[] { bindNavigator });
            Size = new Size(ScreenSize.Width/3 - 7, ScreenSize.Height -50);
        }

        private void bindNavigator_Paint(object sender, PaintEventArgs e)
        {
            tsbtnDelete.Enabled = (bindCV.Count > 0);
        }

        #region Method
        public void SetDataSource(string stQuery)
        {
            if (string.IsNullOrEmpty(stQuery)) return;
            DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
            if (data.Rows.Count > 0)
            {
                bindCV.DataSource = data;
                bindCV.ResetCurrentItem();
            }
            else
            {
                bindNavigator.Enabled = false;
                SetBlankAllControl();
            }
            stQuerySave = stQuery;
        }

        private void ResetData()
        {
            SetDataSource(stQuerySave);
            LoadcbMSCVCHA();
        }

        public void EnableAddnewButton()
        {
            bindNavigator.AddNewItem.Enabled = true;
            bindNavigator.DeleteItem.Enabled = true;
        }

        public void SetBindingCongVan()
        {
            if (bindCV.DataSource == null) return;
            txbMSCV.DataBindings.Add("Text", bindCV, "MSCV", true, DataSourceUpdateMode.Never);
            txbSoCV.DataBindings.Add("Text", bindCV, "SOCV", true, DataSourceUpdateMode.Never);
            txbNoidung.DataBindings.Add("Text", bindCV, "NOIDUNG", true, DataSourceUpdateMode.Never);
            txbFilePDF.DataBindings.Add("Text", bindCV, "FILEPDF", true, DataSourceUpdateMode.Never);
            txbFileOffice.DataBindings.Add("Text", bindCV, "FILEOFFICE", true, DataSourceUpdateMode.Never);
            txbFileRAR.DataBindings.Add("Text", bindCV, "FILERAR", true, DataSourceUpdateMode.Never);
            dtpkNgayCV.DataBindings.Add("Value", bindCV, "NGAYCV", true, DataSourceUpdateMode.Never);
            cbMSCQ.DataBindings.Add("SelectedValue", bindCV, "MSCQ", true, DataSourceUpdateMode.Never);
            cbMSLoaiCV.DataBindings.Add("SelectedValue", bindCV, "MSLOAICV", true, DataSourceUpdateMode.Never);
            cbMSCVCHA.DataBindings.Add("SelectedValue", bindCV, "MSCVCHA", true, DataSourceUpdateMode.Never);
            cbMSGiaidoan.DataBindings.Add("SelectedValue", bindCV, "MSGIAIDOAN", true, DataSourceUpdateMode.Never);
        }

        private void tsbtnDelete_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSCV.Text)) return;
            string stMsg = "Bạn có chắc chắn xoá Công văn này?";
            Functions.MsgBox(stMsg, MessageType.Confirmation, () => { XoaCongvan(); });
            ResetData();
        }

        private void tsbtnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSCV.Text))
            {   //Thêm công văn mới
                ThemCongvan();
                SetBlankAllControl();
            }
            else
            {   //Sửa và phát hành công văn (nếu sửa thành công)
                if (SuaCongvan())
                {
                    string stQuery = $"UPDATE tCongVan SET PHEDUYET=1 WHERE MSCV ='{txbMSCV.Text}'";
                    DataProvider.Instance.ExecuteNonQuery(stQuery);
                }
            }
            ResetData();
        }

        private void bindNavigatorAddNewItem_Click(object sender, System.EventArgs e)
        {
            SetBlankAllControl();
        }

        public void MoveCongVan(long lMSCV)
        {
            int iIndex = 0;
            if (bindCV.Current.GetType() == typeof(CongVan))
            {
                List<CongVan> lst = bindCV.DataSource as List<CongVan>;
                iIndex = lst.FindIndex((cv) => { return cv.MSCV == lMSCV; }); //Tìm kiếm dạng List
            }
            else
                iIndex = bindCV.Find("MSCV", lMSCV); //Tìm kiếm dạng DataTable
            bindCV.Position = iIndex;
        }
        #endregion
    }
}

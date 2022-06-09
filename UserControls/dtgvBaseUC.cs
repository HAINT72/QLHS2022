using App;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;

namespace UserControls
{
    public class dtgvBaseUC : UserControl
    {
        private DataGridView _dtgv = new DataGridView();
        public DataGridView dtgv
        {
            get { return _dtgv; }
            private set { _dtgv = value; }
        }

        private BindingSource _bindDtgv = new BindingSource();
        public BindingSource bindDtgv
        {
            get { return _bindDtgv; }
            set { _bindDtgv = value; }
        }

        private BindingNavigator _bindNavigator = new BindingNavigator(true);
        public BindingNavigator bindNavigator
        {
            get { return _bindNavigator; }
            set { _bindNavigator = value; }
        }
        private ToolStripButton tsbtnAutosizeDtgvCells = new ToolStripButton();
        public ToolTip tltip = new ToolTip();

        protected string stId = string.Empty;
        private string stQuerySave = string.Empty;

        public dtgvBaseUC()
        {
            InitializeComponent();
        }

        public void SetDataSource(DataTable data, bool bDataTableType = true)
        {
            if (bDataTableType)
                bindDtgv.DataSource = data;
            else
                SetDataSourceByDataList(data);
        }

        public void SetDataSource(string stQuery, bool bDataTableType = false)
        {
            stQuerySave = stQuery;
            DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
            if (bDataTableType)
                bindDtgv.DataSource = data;
            else
                SetDataSourceByDataList(data);
        }

        private void SetDataSourceByDataList(DataTable data)
        {   //Gán bindDtgv.Datasource dạng List<Moddel>; Không áp dụng được với DtgvFilter
            string stPKModel = data.Columns[0].ToString().ToUpper();
            switch (stPKModel) //Lấy ra Id của bảng
            {
                case "MSLOAICV":
                    bindDtgv.DataSource = typeof(LoaiCV);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<LoaiCV>(data);
                    break;
                case "MSDUOICV":
                    bindDtgv.DataSource = typeof(DuoiCV);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<DuoiCV>(data);
                    break;
                case "MSGIAIDOAN":
                    bindDtgv.DataSource = typeof(GiaiDoan);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<GiaiDoan>(data);
                    break;
                case "MSCQ":
                    bindDtgv.DataSource = typeof(CoQuan);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<CoQuan>(data);
                    break;
                case "MSNV":
                    bindDtgv.DataSource = typeof(NhanVien);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<NhanVien>(data);
                    break;
                case "MSCV":
                    bindDtgv.DataSource = typeof(CongVan);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<CongVan>(data);
                    break;
                case "MSTS":
                    bindDtgv.DataSource = typeof(ThongSo);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<ThongSo>(data);
                    break;
                case "MSCVGIAOVIEC":
                    bindDtgv.DataSource = typeof(GiaoViec);
                    bindDtgv.DataSource = DataProvider.Instance.DataTableToList<GiaoViec>(data);
                    break;
                default:
                    Functions.MsgBox("To admin: Chưa có typeof này. Tạm gán dữ liệu kiểu DataTable", MessageType.Information);
                    bindDtgv.DataSource = data;
                    return;
            }
        }

        public void ResetData(bool bDataTableType = false)
        {
            if (string.IsNullOrEmpty(stQuerySave)) return;
            SetDataSource(stQuerySave, bDataTableType);
        }

        private void InitializeComponent()
        {
            // Cài đặt dtgv           
            dtgv.Dock = DockStyle.Fill;
            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgv.AllowUserToAddRows = false;
            dtgv.AllowUserToDeleteRows = false;
            dtgv.MultiSelect = false;
            dtgv.ReadOnly = true;
            dtgv.DefaultCellStyle.Font = new Font("Arial", 9F);
            dtgv.DefaultCellStyle.ForeColor = Color.Blue;
            dtgv.Name = "dtgvBase";
            dtgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9F, FontStyle.Bold);
            dtgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgv.DataSource = bindDtgv;

            //Cài đặt BindingNavigator
            bindNavigator.BindingSource = bindDtgv;
            bindNavigator.Dock = DockStyle.Bottom;
            bindNavigator.AddNewItem.ToolTipText = "Thêm mới dòng để nhập dữ liệu. Để lưu dữ liệu, chọn 'Cập nhật dữ liệu'";
            bindNavigator.DeleteItem.ToolTipText = "Xoá dòng dữ liệu hiển thị. Để xoá dữ liệu, chọn 'Xoá dữ liệu";

            //Cài đặt nút Refresh trên BindingNavigator            
            tsbtnAutosizeDtgvCells.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAutosizeDtgvCells.Image = global::App.Properties.Resources.outline_expand_black_18dp;
            tsbtnAutosizeDtgvCells.ToolTipText = "Bật/Tắt tự động điều chỉnh hàng, cột";
            bindNavigator.Items.Add(tsbtnAutosizeDtgvCells);

            //Tạo event
            dtgv.CellEnter += dtgv_CellEnter;
            tsbtnAutosizeDtgvCells.Click += tsbtnAutoSizeDtgvCells_Click;

            //Add controls 
            Controls.AddRange(new Control[] { dtgv, bindNavigator });
        }

        private void tsbtnAutoSizeDtgvCells_Click(object sender, System.EventArgs e)
        {
            dtgv.AutoSizeRowsMode = (dtgv.AutoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)? DataGridViewAutoSizeRowsMode.AllCells: DataGridViewAutoSizeRowsMode.None;
            dtgv.AutoSizeColumnsMode = (dtgv.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None) ? DataGridViewAutoSizeColumnsMode.AllCells : DataGridViewAutoSizeColumnsMode.None;
        }

        public void AutoSizeDtgvCellsOn()
        {
            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dtgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            stId = dtgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            ShareVar.Instance.ID = stId;
            tsbtnAutosizeDtgvCells.Enabled = (bindDtgv.Count < 100);

        }

        public void SetHeaderText(string[] stArrayHeaderText) //Đặt tiêu đề cột và ẩn các cột phía sau (sử dụng sau khi hiển thị control)
        {
            string stHeaderText = null;
            for (int i = 0; i < dtgv.Columns.Count; i++)
            {
                if (i < stArrayHeaderText.Length)
                {
                    stHeaderText = stArrayHeaderText[i];
                    if (string.IsNullOrEmpty(stHeaderText))
                        dtgv.Columns[i].Visible = false;
                    else
                        dtgv.Columns[i].HeaderText = stArrayHeaderText[i];
                }
                else
                    dtgv.Columns[i].Visible = false;
            }
        }

        public T GetDataCurrent<T>() where T : class, new() //Gọi từ dtgvCRUD: Trả về Data hiện hành theo đúng loại dữ liệu truyền vào.
        {
            if (bindDtgv.Current.GetType() == typeof(T)) return bindDtgv.Current as T;
            else
            {
                int i = dtgv.CurrentRow.Index;
                List<T> lst = DataProvider.Instance.DataTableToList<T>(bindDtgv.DataSource as DataTable);
                return lst[i];
            }
        }

        public string GetID()
        {
            return stId;
        }
    }
}

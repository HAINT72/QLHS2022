using App;
using Model;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UserControls
{
    //Áp dụng khi dùng control CRUD; 1 textbox nhập liệu.
    public class dtgvCrudUC : dtgvBaseUC
    {               
        private ToolStripButton tsbtnSave = new ToolStripButton();
        private ToolStripButton tsbtnDelete = new ToolStripButton();
        private TextBox txbNoidung = new TextBox();

        public dtgvCrudUC()
        {
            InitializeComponent();           
        }

        public dtgvCrudUC(string stQuery)
        {
            InitializeComponent();
            SetDataSource(stQuery);
            SetBinding();
        }

        public void SetBinding ()
        {
            Type typeModel = bindDtgv.DataSource.GetType();                 
            if (typeModel == typeof(List<LoaiCV>)) txbNoidung.DataBindings.Add("Text", bindDtgv, "LOAICV", true, DataSourceUpdateMode.OnPropertyChanged);                    
            else if (typeModel == typeof(List<DuoiCV>)) txbNoidung.DataBindings.Add("Text", bindDtgv, "DUOICV", true, DataSourceUpdateMode.OnPropertyChanged);
            else if (typeModel == typeof(List<CoQuan>)) txbNoidung.DataBindings.Add("Text", bindDtgv, "TENCQ", true, DataSourceUpdateMode.OnPropertyChanged);
            else if (typeModel == typeof(List<GiaiDoan>)) txbNoidung.DataBindings.Add("Text", bindDtgv, "GIAIDOAN", true, DataSourceUpdateMode.OnPropertyChanged);
            else if (typeModel == typeof(List<NhanVien>)) txbNoidung.DataBindings.Add("Text", bindDtgv, "HOTEN", true, DataSourceUpdateMode.OnPropertyChanged);
            else if (typeModel == typeof(List<GiaoViec>)) txbNoidung.DataBindings.Add("Text", bindDtgv, "CHIDAO", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void InitializeComponent()
        {
            //Cài đặt textbox
            txbNoidung.Dock = DockStyle.Top;
            txbNoidung.Multiline = true;
            txbNoidung.ScrollBars = ScrollBars.Vertical;
            txbNoidung.Font = new Font("Arial", 10F);
            txbNoidung.Size = new Size(350, 40);
            tltip.SetToolTip(txbNoidung, "Nhập nội dung cần sửa hoặc thêm mới; Nhấn phím TAB và chọn 'Cập nhật dữ liệu'");
                 
            //Cài đặt nút save trên BindingNavigator            
            tsbtnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnSave.Image = global::App.Properties.Resources.baseline_check_black_18dp;
            tsbtnSave.ToolTipText = "Cập nhật dữ liệu";
            tsbtnSave.Enabled = false;
            bindNavigator.Items.Add(tsbtnSave);

            //Cài đặt nút delete trên BindingNavigator            
            tsbtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnDelete.Image = global::App.Properties.Resources.outline_delete_black_18dp;
            tsbtnDelete.ToolTipText = "Xoá dữ liệu";
            bindNavigator.Items.Add(tsbtnDelete);

            //Cài đặt events            
            tsbtnSave.Click += tsbtnSave_Click;
            tsbtnDelete.Click += tsbtnDelete_Click;
            txbNoidung.Leave += txbNoidung_Leave;
            dtgv.Enter += Dtgv_Enter;

            //Add controls 
            Controls.AddRange(new Control[] { txbNoidung });
            Size = new Size(ScreenSize.Width/3-7, ScreenSize.Height - 50);
        }

        private void Dtgv_Enter(object sender, EventArgs e)
        {
            tsbtnDelete.Enabled = (bindDtgv.Count > 0);
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            Type typeModel = bindDtgv.Current.GetType();
            bool bKetqua = false;
            if (typeModel == typeof(GiaoViec))
                bKetqua = GiaoViecVM.Instance.XoaGiaoViec(GetDataCurrent<GiaoViec>());
            else
                bKetqua = OtherVM.Instance.DeleteData(typeModel, GetID());
            
            if (!bKetqua)
                Functions.MsgBox("Đã có lỗi khi xoá", MessageType.Error);
            else
                Functions.MsgBox("Xoá dữ liệu thành công", MessageType.Success);

            bindDtgv.RemoveCurrent();
        }

        private void txbNoidung_Leave(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = !string.IsNullOrEmpty(txbNoidung.Text);
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            bool bKetqua = false;
            Type typeModel = bindDtgv.Current.GetType();
            if (typeModel == typeof(LoaiCV)) bKetqua = OtherVM.Instance.UpdateData<LoaiCV>(GetDataCurrent<LoaiCV>());
            else if (typeModel == typeof(DuoiCV)) bKetqua = OtherVM.Instance.UpdateData<DuoiCV>(GetDataCurrent<DuoiCV>());
            else if (typeModel == typeof(GiaiDoan)) bKetqua = OtherVM.Instance.UpdateData<GiaiDoan>(GetDataCurrent<GiaiDoan>());
            else if (typeModel == typeof(CoQuan)) bKetqua = OtherVM.Instance.UpdateData<CoQuan>(GetDataCurrent<CoQuan>());
            else if (typeModel == typeof(GiaoViec)) bKetqua = OtherVM.Instance.UpdateData<GiaoViec>(GetDataCurrent<GiaoViec>());
            else if (typeModel == typeof(NhanVien)) bKetqua = OtherVM.Instance.UpdateData<NhanVien>(GetDataCurrent<NhanVien>()); //Với tNhanVien chỉ thêm mới không cập nhật.

            if (!bKetqua)
                Functions.MsgBox("Đã có lỗi khi cập nhật", MessageType.Error);
            else
                Functions.MsgBox("Cập nhật dữ liệu thành công", MessageType.Success);

            ResetData();
            tsbtnSave.Enabled = false;  
        }

        public void ShowDetail(Action<string> showDetail)
        {
            string stId = GetID();
            showDetail?.Invoke(stId);
        }
    }
}

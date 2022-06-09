using App;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UserControls
{
    //Áp dụng bảng tCongVan, filter 3 cột (MSCV, SoCV, NOIDUNG); BindingDataSource cần truyền loại DataTable
    public class dtgvFilterCVUC : dtgvCVUC
    {
        private TextBox txbFilter0 = new TextBox();
        private TextBox txbFilter1 = new TextBox();
        private TextBox txbFilter2 = new TextBox();
        private FlowLayoutPanel fpnl = new FlowLayoutPanel();

        public dtgvFilterCVUC()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Cài đặt FlowlayoutPanel để chứa 2 ô textbox
            fpnl.Dock = DockStyle.Top;
            fpnl.Size = new Size(750, 30);

            //Cài đặt textbox                 
            txbFilter0.Font = new Font("Arial", 10F);
            txbFilter0.Size = new Size(195, 30);
            txbFilter1.Font = new Font("Arial", 10F);
            txbFilter1.Size = new Size(195, 30);
            txbFilter2.Font = new Font("Arial", 10F);
            txbFilter2.Size = new Size(195, 30);

            //Cài đặt tooltip
            tltip.SetToolTip(txbFilter0, "Nhập để lọc dữ liệu theo mã số công văn");
            tltip.SetToolTip(txbFilter1, "Nhập để lọc dữ liệu theo số công văn");
            tltip.SetToolTip(txbFilter2, "Nhập để lọc dữ liệu theo nội dung công văn");

            //Cài đặt dtgv
            bindNavigator.AddNewItem.Enabled = false;
            bindNavigator.DeleteItem.Enabled = false;

            //Cài đặt events
            txbFilter0.TextChanged += txbFilter0_TextChanged;
            txbFilter1.TextChanged += txbFilter1_TextChanged;
            txbFilter2.TextChanged += txbFilter2_TextChanged;

            fpnl.Controls.AddRange(new Control[] { txbFilter0, txbFilter1, txbFilter2 });
            Controls.AddRange(new Control[] { fpnl });
            Size = new Size(ScreenSize.Width/2 - 10, ScreenSize.Height-50);
        }

        private void txbFilter0_TextChanged(object sender, EventArgs e)
        {
            if (dtgv.Columns["MSCV"].ValueType != typeof(string)) return;
            string stFilter =  $"MSCV like '%{txbFilter0.Text}%'"; //dtgv.Columns[0].Name.ToString(); --COL0 từ câu lệnh SQL 
            bindDtgv.Filter = stFilter;
        }

        private void txbFilter1_TextChanged(object sender, EventArgs e)
        {
            if (dtgv.Columns["SOCV"].ValueType != typeof(string)) return;
            string stFilter =  $"SOCV like '%{txbFilter1.Text}%'"; //dtgv.Columns[1].Name.ToString();  -- COL1 từ câu lệnh SQL
            bindDtgv.Filter = stFilter;
        }

        private void txbFilter2_TextChanged(object sender, EventArgs e)
        {
            if (dtgv.Columns["NOIDUNG_unsign"].ValueType != typeof(string)) return;
            string stFilter = Functions.ConvertToUnsign(txbFilter2.Text);
            bindDtgv.Filter = $"NOIDUNG_unsign like '%{stFilter}%'"; //dtgv.Columns[2].Name.ToString();  -- COL2 từ câu lệnh SQL
        }

    }
}

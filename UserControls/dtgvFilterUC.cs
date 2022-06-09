using App;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UserControls
{
    //Áp dụng cho các bảng chỉ cần filter 1 cột; BindingDataSource cần truyền loại DataTable
    public class dtgvFilterUC: dtgvBaseUC
    {
        private TextBox txbFilter0 = new TextBox();
        
        public dtgvFilterUC()
        {
            InitializeComponent();            
        }

        private void InitializeComponent()
        {
            //Cài đặt textbox  
            txbFilter0.Dock = DockStyle.Top;
            txbFilter0.Font = new Font("Arial", 10F);         
            txbFilter0.Size = new Size(600, 30);

            //Cài đặt tooltip
            tltip.SetToolTip(txbFilter0, "Nhập để lọc dữ liệu");

            //Cài đặt dtgv
            bindNavigator.AddNewItem.Enabled = false;
            bindNavigator.DeleteItem.Enabled = false;

            //Cài đặt events
            txbFilter0.TextChanged += txbFilter0_TextChanged;       
                      
            Controls.AddRange(new Control[] {txbFilter0 });
            Size = new Size(ScreenSize.Width/2, ScreenSize.Height -50);
        }

        private void txbFilter0_TextChanged(object sender, EventArgs e)
        {
            if (dtgv.Columns[0].ValueType != typeof(string)) return;
            string stFilter =  $"COL0 like '%{txbFilter0.Text}%'"; //dtgv.Columns[0].Name.ToString() +; --COL0 đưa vào từ SQL
            bindDtgv.Filter = stFilter;            
        }
    }
}

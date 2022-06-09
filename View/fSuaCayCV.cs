using System.Windows.Forms;
using ViewModel;
using Model;
using System.Drawing;

namespace View
{
    public partial class fSuaCayCV : Form
    {
        BindingSource bs = new BindingSource();
        public fSuaCayCV()
        {
            InitializeComponent();
            CayCongVanVM.Instance.LoadCayCV(tvwCV);
            SetBinding();
        }

        private void SetBinding()
        {
            bs.DataSource = typeof(CongVanView);
            bs.DataSource = new CongVanView();
            txbMSCV.DataBindings.Add("Text", bs, "MSCV");
            txbSoCV.DataBindings.Add("Text", bs, "SOCV");
            txbNoidung.DataBindings.Add("Text", bs, "NOIDUNG");
            txbNgayCV.DataBindings.Add("Text", bs, "NGAYCV");
            txbLoaiCV.DataBindings.Add("Text", bs, "LOAICV");
            txbCoquan.DataBindings.Add("Text", bs, "TENCQ");
            txbGiaidoan.DataBindings.Add("Text", bs, "GIAIDOAN");
            txbMSCVcha.DataBindings.Add("Text", bs, "MSCVCHA");
        }

        private void tvwCV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            bs.DataSource = CongVanVM.Instance.GetCongVanViewByMSCV(node.Name.ToString());
        }

        private void tvwCV_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode nodeSource = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            TreeNode nodeTarget = tvwCV.GetNodeAt(PointToClient(new Point(e.X, e.Y)));
            if (nodeSource != null && nodeTarget != null)
            {
                CayCongVanVM.Instance.SuaCayCV(tvwCV, nodeSource, nodeTarget);
                e.Effect = DragDropEffects.None;
            }
        }

        private void tvwCV_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tvwCV_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = tvwCV.GetNodeAt(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && tvwCV.AllowDrop)
                tvwCV.DoDragDrop(node, DragDropEffects.Move);
        }

        private void SuaCayCVMenuItem_Click(object sender, System.EventArgs e)
        {
            tvwCV.AllowDrop = !tvwCV.AllowDrop;
            string stLabel = SuaCayCVMenuItem.Text;
            SuaCayCVMenuItem.Text = (stLabel =="Bật kéo/thả công văn")? "Tắt kéo / thả công văn": "Bật kéo/thả công văn";
        }

        private void xemPDFMenuItem_Click(object sender, System.EventArgs e)
        {
            string stMSCV = tvwCV.SelectedNode.Name.ToString();
            CongVanVM.Instance.OpenFileAtch(stMSCV);
        }

        private void txbMSCVcha_TextChanged(object sender, System.EventArgs e)
        {
            string stMSCV = txbMSCVcha.Text;
            if (string.IsNullOrEmpty(stMSCV))
            {
                txbSoCVCha.Text = string.Empty;
                txbNgayCVCha.Text = string.Empty;
                txbNoidungCVCha.Text = string.Empty;
            }
            else
            {
                CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(stMSCV);
                txbSoCVCha.Text = cv.SOCV;
                txbNgayCVCha.Text = cv.NGAYCV.ToShortDateString();
                txbNoidungCVCha.Text = cv.NOIDUNG;
            }
           
        }

        private void ThemNhanhMenuItem_Click(object sender, System.EventArgs e)
        {
            CayCongVanVM.Instance.ThemNhanhCayCV(tvwCV, tvwCV.SelectedNode);
        }

        private void GiamNhanhMenuItem_Click(object sender, System.EventArgs e)
        {
            CayCongVanVM.Instance.GiamNhanhCayCV(tvwCV, tvwCV.SelectedNode);
        }
    }
}

using System;
using System.Windows.Forms;
using ViewModel;

namespace View
{
    public partial class fCayCV : Form
    {
        public fCayCV()
        {
            InitializeComponent();
            CayCongVanVM.Instance.LoadCayCV(tvwCV);
        }

        private void tvwCV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CayCongVanVM.Instance.SetCheckNode(e.Node);
            FilesToListMenuItem.Enabled = e.Node.Checked;
            FileNodeToListMenuItem.Enabled = e.Node.Checked;
        }

        private void ViewFileMenuItem_Click(object sender, EventArgs e)
        {
            string stMSCV = tvwCV.SelectedNode.Name.ToString();
            CongVanVM.Instance.OpenFileAtch(stMSCV);
        }

        private void FileToListMenuItem_Click(object sender, EventArgs e)
        {
            string stMSCV = tvwCV.SelectedNode.Name.ToString();
            CayCongVanVM.Instance.AddCVToListBox(stMSCV, lstBoxCV);
        }

        private void FilesToListMenuItem_Click(object sender, EventArgs e)
        {
            CayCongVanVM.Instance.AddTreeViewToListBox(tvwCV, lstBoxCV);
        }

        private void FileNodeToListMenuItem_Click(object sender, EventArgs e)
        {
            CayCongVanVM.Instance.AddNodeToListBox(tvwCV.SelectedNode, lstBoxCV);
        }

        private void RemoveCVMenuItem_Click(object sender, EventArgs e)
        {
            int iIndex = lstBoxCV.SelectedIndex;
            if(iIndex>=0)
            {
                lstBoxCV.Items.RemoveAt(iIndex);
            }
        }

        private void RemoveAllCVMenuItem_Click(object sender, EventArgs e)
        {
            lstBoxCV.Items.Clear();
            SetEnableCmsListBoxCV(false);
        }

        private void CopyCVMenuItem_Click(object sender, EventArgs e)
        {
            CayCongVanVM.Instance.CopyCVInListBox(lstBoxCV);
        }

        private void lstBoxCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnableCmsListBoxCV((lstBoxCV.Items.Count > 0));
        }

        private void SetEnableCmsListBoxCV(bool b)
        {
            RemoveAllCVMenuItem.Enabled = b;
            RemoveCVMenuItem.Enabled = b;
            CopyCVMenuItem.Enabled = b;
        }
    }
}



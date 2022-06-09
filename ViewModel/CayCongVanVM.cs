using App;
using Model;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ViewModel
{
    public class CayCongVanVM
    {
        private static CayCongVanVM instance;
        public static CayCongVanVM Instance
        {
            get { if (instance == null) instance = new CayCongVanVM(); return instance; }
            private set { instance = value; }
        }

        private List<CongVan> lstCV = new List<CongVan>();

        public void SetCheckNode(TreeNode node)
        {
            if (node.Nodes == null) return;
            bool bStateNode = node.Checked;
            foreach (TreeNode n in node.Nodes)
            {
                n.Checked = bStateNode;
                SetCheckNode(n);
            }
        }

        public void AddNodeToListBox(TreeNode node, ListBox lst)
        {
            if (node.Nodes != null)
            {
                if(node.Checked)
                {
                    string stMSCV = node.Name.ToString();
                    AddCVToListBox(stMSCV, lst);
                }
                foreach (TreeNode n in node.Nodes)
                {
                    AddNodeToListBox(n, lst);
                }
            }
        }

        public void AddTreeViewToListBox(TreeView tv, ListBox lst)
        {
            foreach (TreeNode node in tv.Nodes)
            {
                AddNodeToListBox(node, lst);
            }
        }

        public void AddCVToListBox(string stMSCV, ListBox lst)
        {
            if (string.IsNullOrEmpty(stMSCV)) return;
            CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(stMSCV);
            if (lst.FindString(stMSCV) < 0) //Chưa có trong ListBox thì đưa vào
            {
                lst.Items.Add(cv.MSCV + "; " + cv.SOCV + ", " + cv.NGAYCV.ToShortDateString());
            }
        }

        public void CopyCVInListBox(ListBox lst)
        {
            if (lst.Items.Count == 0) return;
            bool bKetqua = false;
            string stFolder = Utilities.Instance.GetFolderName();
            if (string.IsNullOrEmpty(stFolder)) return;
            //Copy vào thư mục
            foreach (var item in lst.Items)
            {
                string stMSCV = item.ToString().Split(';')[0];
                CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(stMSCV);
                bKetqua = Utilities.Instance.CopyFileFromServer(cv.FILEPDF, stFolder);
            }
            //Tạo file Excel checklist
            bKetqua = ExportFileExcelChecklist(lst, Path.Combine(stFolder, "Checklist.xlsx"));
            //Thông báo kết quả
            if (bKetqua)
                Functions.MsgBox($"Đã hoàn thành copy file PDF vào thư mục {stFolder}");
            else
                Functions.MsgBox($"Đã có lỗi khi copy file PDF vào thư mục {stFolder}", MessageType.Error);
        }

        private bool ExportFileExcelChecklist(ListBox lst, string stFilePath)
        {
            if (File.Exists(stFilePath)) File.Delete(stFilePath);
            string stQuery = "SELECT MSCV, SOCV, NGAYCV, NOIDUNG, FILEPDF FROM tCongVan WHERE MSCV = ";
            string stMSCV = string.Empty;
            foreach (var item in lst.Items)
            {
                stMSCV = item.ToString().Split(';')[0];
                stQuery += $"'{stMSCV}' OR MSCV = ";
            }
            stQuery += $"'{stMSCV}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
            if(data != null)
            {
                Utilities.Instance.ExportToExcel(data, stFilePath, "Checklist");
                return true;
            }
            return false;
        }

        public void LoadCayCV(TreeView tvw)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tCongVan ORDER BY NGAYCV");
            lstCV = DataProvider.Instance.DataTableToList<CongVan>(data);
            if (lstCV.Count == 0) return;
            List<CongVan> lstCVRoot = lstCV.FindAll((CongVan cv) => { return string.IsNullOrEmpty(cv.MSCVCHA); }); //Lấy công văn làm node gốc
            foreach (CongVan cv in lstCVRoot)
            {
                string stRootLabel = GiaiDoanVM.Instance.GetTenGiaiDoanByMSGD(cv.MSGIAIDOAN);
                TreeNode node = tvw.Nodes.Add(cv.MSCV, $"[{stRootLabel}]: ({cv.MSCV} - {cv.SOCV}, {cv.NGAYCV})");
                LoadNodeCV(node, cv.MSCV);
            }
        }

        private void LoadNodeCV(TreeNode root, string stMSCV)
        {
            if (string.IsNullOrEmpty(stMSCV)) return;
            List<CongVan> lstCVNode = lstCV.FindAll((CongVan cv) => { return cv.MSCVCHA == stMSCV; }); //Lấy công văn cha
            if (lstCVNode.Count == 0) return;
            foreach (CongVan cv in lstCVNode)
            {
                TreeNode node = root.Nodes.Add(cv.MSCV, $"({cv.MSCV}) - {cv.SOCV}: {cv.NOIDUNG}");
                LoadNodeCV(node, cv.MSCV);
            }
        }

        public void SuaCayCV(TreeView tv, TreeNode nodeSource, TreeNode nodeTarget, bool bAskBeforeRun = true)
        {
            string stMSCVCha = nodeTarget.Name.ToString();
            string stMSCV = nodeSource.Name.ToString();

            if (stMSCVCha == stMSCV) return; //user nhấp và thả cùng 1 vị trí
            if (bAskBeforeRun) //Áp dụng cho trường hợp kéo/thả
            {
                string stMsg = $"Bạn chắc chắn muốn dời công văn '{stMSCV}' đến '{stMSCVCha}'";
                if (Functions.MsgBox(stMsg, MessageType.Confirmation) != DialogResult.Yes) return;
            }
            //Xử lý trên UI
            tv.Nodes.Remove(nodeSource);
            nodeTarget.Nodes.Add(nodeSource);
            //Xử lý tại Database SQL
            string stQuery = $"UPDATE tCongVan SET MSCVCHA = '{stMSCVCha}' WHERE MSCV ='{stMSCV}'";
            DataProvider.Instance.ExecuteNonQuery(stQuery);
        }

        public void ThemNhanhCayCV(TreeView tv, TreeNode nodeSource)
        {
            TreeNode nodeTarget = new TreeNode();
            if (nodeSource.PrevNode == null)
                nodeTarget = nodeSource.NextNode;
            else
                nodeTarget = tv.SelectedNode.PrevNode;
            SuaCayCV(tv, nodeSource, nodeTarget, false);
        }

        public void GiamNhanhCayCV(TreeView tv, TreeNode nodeSource)
        {
            string stMSCV = nodeSource.Name.ToString();
            CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(stMSCV);
            if (string.IsNullOrEmpty(cv.MSCVCHA))
            {
                Functions.MsgBox("Không thể giảm nhánh do công văn đã nằm vị trí gốc", MessageType.Information);
                return;
            }
            cv= CongVanVM.Instance.GetCongVanByMSCV(cv.MSCVCHA);
            string stMSCVCha = cv.MSCVCHA;
            //Xử lý trên UI
            tv.Nodes.Remove(nodeSource);            
            if (string.IsNullOrEmpty(stMSCVCha)) 
            {
                tv.Nodes.Add(nodeSource); //Vị trí Gốc
            }
            else
            {
                TreeNode nodeTarget = tv.Nodes.Find(stMSCVCha, true)[0];
                nodeTarget.Nodes.Add(nodeSource); ////Vị trí Nhánh
            }
            //Xử lý tại Database SQL
            string stQuery = $"UPDATE tCongVan SET MSCVCHA = '{stMSCVCha}' WHERE MSCV ='{stMSCV}'";
            DataProvider.Instance.ExecuteNonQuery(stQuery);
        }
    }
}

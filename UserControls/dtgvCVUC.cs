using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModel;

namespace UserControls
{
    public class dtgvCVUC : dtgvBaseUC
    {
        private ContextMenuStrip cms = new ContextMenuStrip();
        public dtgvCVUC()
        {
            InitializeComponent();
        }

        public void MoveCongVan(string stMSCV)
        {
            int iIndex = 0;
            if (bindDtgv.Current.GetType() == typeof(CongVan))
            {
                List<CongVan> lst = bindDtgv.DataSource as List<CongVan>;
                iIndex = lst.FindIndex((cv) => { return cv.MSCV == stMSCV; }); //Tìm kiếm dạng List
            }
            else
                iIndex = bindDtgv.Find("MSCV", stMSCV); //Tìm kiếm dạng DataTable
            bindDtgv.Position = iIndex;
        }

        private void InitializeComponent()
        {
            //Tạo ContextMenu
            cms.Items.Add("Xem file PDF", null, new EventHandler(cmsOpenFilePDFAtch_Click));
            cms.Items.Add("Xem file Offfice", null, new EventHandler(cmsOpenFileOfficeAtch_Click));
            cms.Items.Add("Xem file RAR", null, new EventHandler(cmsOpenFileRARAtch_Click));
            cms.Items[0].Image = global::App.Properties.Resources._51955_document_file_pdf_icon;
            cms.Items[1].Image = global::App.Properties.Resources._65892_document_docx_file_win_icon;
            cms.Items[2].Image = global::App.Properties.Resources._2276070_document_file_name_rar_icon;
            cms.Items[0].Enabled = false;
            cms.Items[1].Enabled = false;
            cms.Items[2].Enabled = false;
            dtgv.ContextMenuStrip = cms;
            dtgv.CellEnter += dtgv_CellEnter;

            //Cài đặt tooltip
            tltip.SetToolTip(dtgv, "Bấm chuột phải để xem file đính kèm");
        }

        private void dtgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(stId) || bindDtgv.Count ==0)
            {
                cms.Items[0].Enabled = false;
                cms.Items[1].Enabled = false;
                cms.Items[2].Enabled =false;
            }
            else
            {
                CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(stId);
                cms.Items[0].Enabled = !string.IsNullOrEmpty(cv.FILEPDF);
                cms.Items[1].Enabled = !string.IsNullOrEmpty(cv.FILEOFFICE);
                cms.Items[2].Enabled = !string.IsNullOrEmpty(cv.FILERAR);
            }
        }

        private void cmsOpenFilePDFAtch_Click(object sender, EventArgs e)
        {
            CongVanVM.Instance.OpenFileAtch(stId, "PDF");
        }

        private void cmsOpenFileOfficeAtch_Click(object sender, EventArgs e)
        {
            CongVanVM.Instance.OpenFileAtch(stId, "OFFICE");
        }

        private void cmsOpenFileRARAtch_Click(object sender, EventArgs e)
        {
            CongVanVM.Instance.OpenFileAtch(stId, "RAR");
        }
    }
}

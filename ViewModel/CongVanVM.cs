using App;
using System.Data;
using Model;
using System;

namespace ViewModel
{
    public class CongVanVM 
    {
        private static CongVanVM instance;
        public static CongVanVM Instance
        {
            get { if (instance == null) instance = new CongVanVM(); return instance; }
            private set { instance = value; }
        }

        #region Method
        public CongVan GetCongVanByMSCV(long lMSCV)
        {
            CongVan cv = null;
            if (lMSCV ==0)
            {
                string stQuery = string.Format("SELECT * FROM tCONGVAN WHERE MSCV = ", lMSCV);
                DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
                if(data.Rows.Count>0) cv = new CongVan(data.Rows[0]);
            }
            return cv;
        }

        public CongVanView GetCongVanViewByMSCV(string stMSCV)
        {
            CongVanView cvv = null;
            if (!string.IsNullOrEmpty(stMSCV))
            {
                string stQuery = string.Format("SELECT * FROM UVW_CONGVAN WHERE MSCV = N'{0}'", stMSCV);
                DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
                cvv = new CongVanView(data.Rows[0]);
            }
            return cvv;
        }

        public void OpenFileAtch(long lMSCV, string stFileType = "PDF")
        {
            if (lMSCV ==0) return;
            CongVan cv = GetCongVanByMSCV(lMSCV);
            if (cv != null)
            {
                switch (stFileType.ToUpper())
                {
                    case "PDF": //Mở file PDF
                        Utilities.Instance.OpenFileAtch(cv.FILEPDF);
                        break;

                    case "OFFICE": //Mở file OFFICE
                        Utilities.Instance.OpenFileAtch(cv.FILEOFFICE);
                        break;

                    case "RAR": ////Mở file RAR
                        Utilities.Instance.OpenFileAtch(cv.FILERAR);
                        break;

                    default: //Mở file PDF
                        Utilities.Instance.OpenFileAtch(cv.FILEPDF);
                        break;
                }
            }
        }

        public long ThemCongvan(CongVan cv) //Thêm công văn đầy đủ
        {
            string stDestPath = Utilities.Instance.GetPathFile();
            string stQuery = "exec USP_ThemCongvan @stFirstMSCV , @stSOCV , @stNOIDUNG , @dNGAYCV , @stMSNV , @iMSLOAICV , @iMSCQ , @iMSGIAIDOAN , @stMSCVCHA , @stPATHSERVER , @stFILEPDF , @stFILEOFFICE , @stFILERAR ";
            var result = DataProvider.Instance.ExecuteScalar(stQuery, new object[] { cv.MSCV, cv.SOCV, cv.NOIDUNG, cv.NGAYCV, cv.MSNV, cv.MSLOAICV, cv.MSCQ, cv.MSGIAIDOAN, cv.MSCVCHA, stDestPath, cv.FILEPDF, cv.FILEOFFICE, cv.FILERAR });
            return Convert.ToInt64(result);
        }

        public string ThemCongvan(string stMSCV, string stFilePDF) //Thêm công văn chỉ MSCV và file PDF - Dùng khi cập nhật công văn đã có file PDF trên Server
        {
            string stQuery = "exec USP_ThemCongvanMSCV @ststMSCV , @stFILEPDF";
            var result = DataProvider.Instance.ExecuteScalar(stQuery, new object[] { stMSCV, stFilePDF});
            return result.ToString();
        }

        public bool SuaCongvan(CongVan cv)
        {
            string stQuery = "exec USP_SuaCongvan @stMSCV , @stSOCV , @stNOIDUNG , @dNGAYCV , @iMSLOAICV , @iMSCQ , @iMSGIAIDOAN , @stMSCVCHA , @stFILEPDF , @stFILEOFFICE , @stFILERAR ";
            int result = DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { cv.MSCV, cv.SOCV, cv.NOIDUNG, cv.NGAYCV, cv.MSLOAICV, cv.MSCQ, cv.MSGIAIDOAN, cv.MSCVCHA, cv.FILEPDF, cv.FILEOFFICE, cv.FILERAR });
            return result > 0;
        }

        public bool XoaCongvan(long lMSCV)
        {
            string stQuery = $"DELETE FROM tCongVan WHERE MSCV ={lMSCV}";
            int result = DataProvider.Instance.ExecuteNonQuery(stQuery);
            return result > 0;
        }

        public bool CopyFileAtchsToServer(CongVan cvSource)
        {
            CongVan cvDest = GetCongVanByMSCV(cvSource.MSCV);
            bool bKetqua = true;
            if (cvSource != null && cvDest !=null)
            {
                if (!string.IsNullOrEmpty(cvSource.FILEPDF))
                    bKetqua = bKetqua && Utilities.Instance.CopyFileToServer(cvSource.FILEPDF, cvDest.FILEPDF);

                if (!string.IsNullOrEmpty(cvSource.FILEOFFICE))
                    bKetqua = bKetqua && Utilities.Instance.CopyFileToServer(cvSource.FILEOFFICE, cvDest.FILEOFFICE);

                if (!string.IsNullOrEmpty(cvSource.FILERAR))
                    bKetqua = bKetqua && Utilities.Instance.CopyFileToServer(cvSource.FILERAR, cvDest.FILERAR);

                return bKetqua;
            }
            return false;
        }

        public bool DeleteFilesOnServer(CongVan cv)
        {
            bool bKetqua = true;
            if (cv != null)
            {
                if (!string.IsNullOrEmpty(cv.FILEPDF))
                    bKetqua = bKetqua && Utilities.Instance.DeleteFileServer(cv.FILEPDF);

                if (!string.IsNullOrEmpty(cv.FILEOFFICE))
                    bKetqua = bKetqua && Utilities.Instance.DeleteFileServer(cv.FILEOFFICE);

                if (!string.IsNullOrEmpty(cv.FILERAR))
                    bKetqua = bKetqua && Utilities.Instance.DeleteFileServer(cv.FILERAR);

                return bKetqua;
            }
            return false;
        }

        public DataTable TimkiemCongvan(string stNOIDUNG, int? iMSLOAICV, int? iMSCQ, int? iMSGiaiDoan, DateTime? dNGAYCVTU, DateTime? dNGAYCVDEN, bool bTimkhongdau = false)
        {
            DataTable data = new DataTable();
            string stQuery = "exec USP_TimkiemCongvan @stNOIDUNG , @iMSLOAICV , @iMSCQ , @iMSGIAIDOAN , @dNGAYCVTU , @dNGAYCVDEN , @bTimkhongdau ";
            data = DataProvider.Instance.ExecuteQuery(stQuery, new object[] { stNOIDUNG, iMSLOAICV, iMSCQ, iMSGiaiDoan, dNGAYCVTU, dNGAYCVDEN, bTimkhongdau});
            return data;
        }

        public DataTable TimkiemCongvantheoCumtuNoidung(string stNoidung, bool bTimkhongdau = false) //Tìm kiếm công văn dựa trên các cụm từ được phân cách bằng dấu ';'
        {
            DataTable data = new DataTable();
            if (!string.IsNullOrEmpty(stNoidung))
            {
                string[] listPara = stNoidung.Split(';');
                string stQuery = "SELECT * FROM tCongvan WHERE";
                int i = 0;
                foreach (string item in listPara)
                {
                    if (i == (listPara.Length - 1))
                        if (bTimkhongdau)
                            stQuery += string.Format(" NOIDUNG_unsign Like '%{0}%'", Functions.ConvertToUnsign(item.Trim()));
                        else
                           stQuery += string.Format(" NOIDUNG Like N'%{0}%'", item.Trim());
                    else
                        if (bTimkhongdau)
                            stQuery += string.Format(" NOIDUNG_unsign Like '%{0}%' AND ", Functions.ConvertToUnsign(item.Trim()));
                        else
                            stQuery += string.Format(" NOIDUNG Like N'%{0}%' AND ", item.Trim());
                    i++;
                }
                data = DataProvider.Instance.ExecuteQuery(stQuery);
            }
            return data;
        }

        public DataTable GetSoCV(DateTime dNGAYCVTU, DateTime dNGAYCVDEN, string stLoaiCV)
        {
            DataTable data = new DataTable();
            string stQuery = "exec USP_SoCV @dNGAYCVTU , @dNGAYCVDEN , @bstLoaiCV ";
            data = DataProvider.Instance.ExecuteQuery(stQuery, new object[] { dNGAYCVTU, dNGAYCVDEN, stLoaiCV });
            return data;
        }

        #endregion

    }
}

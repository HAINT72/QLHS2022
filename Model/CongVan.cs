
using System;
using System.Data;
namespace Model
{
    public class CongVan
    {
        public long MSCV { get; set; }
        public string SOCV { get; set; }
        public bool CVDEN { get; set; }
        public DateTime NGAYCV { get; set; }
        public string NOIDUNG { get; set; }
        public string NOIDUNG_Unsign { get; set; }
        public int MSNV { get; set; }
        public int MSLOAICV { get; set; }
        public int MSCQ { get; set; }
        public int MSGIAIDOAN { get; set; }
        public long MSCVCHA { get; set; }
        public string FILEPDF { get; set; }
        public string FILEOFFICE { get; set; }
        public string FILERAR { get; set; }
        public bool PHEDUYET { get; set; }

        public CongVan()
        {
            this.MSCV = 0;
            this.SOCV = string.Empty;
            this.CVDEN = false;
            this.NOIDUNG = string.Empty;
            this.NOIDUNG_Unsign = string.Empty;
            this.NGAYCV = DateTime.Today;
            this.MSNV = 0;
            this.MSLOAICV = 0;
            this.MSCQ = 0;
            this.MSCVCHA = 0;
            this.MSGIAIDOAN = 0;
            this.FILEPDF = string.Empty;
            this.FILEOFFICE = string.Empty;
            this.FILERAR = string.Empty;
            this.PHEDUYET = false;
        }

        public CongVan(long lMSCV, string stSOCV, bool bCVDEN, DateTime dNGAYCV, string stNOIDUNG, int iMSNV, int iMSLOAICV, int iMSCQ, int iMSGIAIDOAN, long lMSCVCHA, string stFILEPDF, string stFILEOFFICE, string stFILERAR)
        {
            this.MSCV = lMSCV;
            this.SOCV = stSOCV;
            this.CVDEN = bCVDEN;
            this.NOIDUNG = stNOIDUNG;
            this.NOIDUNG_Unsign = string.Empty;
            this.NGAYCV = dNGAYCV;
            this.MSNV = iMSNV;
            this.MSLOAICV = iMSLOAICV;
            this.MSCQ = iMSCQ;
            this.MSCVCHA = lMSCVCHA;
            this.MSGIAIDOAN = iMSGIAIDOAN;
            this.FILEPDF = stFILEPDF;
            this.FILEOFFICE = stFILEOFFICE;
            this.FILERAR = stFILERAR;
            this.PHEDUYET = false;
        }

        public CongVan(DataRow row)
        {
            this.MSCV = Convert.ToInt64(row["MSCV"]);
            this.SOCV = row["SOCV"].ToString();
            this.CVDEN = Convert.ToBoolean(row["CVDEN"]);
            this.NOIDUNG = row["NOIDUNG"].ToString();
            this.NOIDUNG_Unsign = row["NOIDUNG_Unsign"].ToString();
            this.NGAYCV = Convert.ToDateTime(row["NGAYCV"]);
            this.MSNV = Convert.ToInt32(row["MSNV"]);
            this.MSLOAICV = Convert.ToInt32(row["MSLOAICV"]);
            this.MSCQ = Convert.ToInt32(row["MSCQ"]);
            this.MSCVCHA = Convert.ToInt64(row["MSCVCHA"]);
            this.MSGIAIDOAN = Convert.ToInt32(row["MSGIAIDOAN"]);
            this.FILEPDF = row["FILEPDF"].ToString();
            this.FILEOFFICE = row["FILEOFFICE"].ToString();
            this.FILERAR = row["FILERAR"].ToString();
            this.PHEDUYET = Convert.ToBoolean(row["PHEDUYET"]);
        }
    }
}

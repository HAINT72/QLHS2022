
using System;
using System.Data;
namespace Model
{
    public class CongVan
    {
        public string MSCV { get; set; }
        public string SOCV { get; set; }
        public DateTime NGAYCV { get; set; }
        public string NOIDUNG { get; set; }
        public string NOIDUNG_Unsign { get; set; }
        public string MSNV { get; set; }
        public int MSLOAICV { get; set; }
        public int MSCQ { get; set; }
        public int MSGIAIDOAN { get; set; }
        public string MSCVCHA { get; set; }
        public string FILEPDF { get; set; }
        public string FILEOFFICE { get; set; }
        public string FILERAR { get; set; }
        public bool PHEDUYET { get; set; }

        public CongVan()
        {
            this.MSCV = string.Empty;
            this.SOCV = string.Empty;
            this.NOIDUNG = string.Empty;
            this.NOIDUNG_Unsign = string.Empty;
            this.NGAYCV = DateTime.Today;
            this.MSNV = string.Empty;
            this.MSLOAICV = 0;
            this.MSCQ = 0;
            this.MSCVCHA = string.Empty;
            this.MSGIAIDOAN = 0;
            this.FILEPDF = string.Empty;
            this.FILEOFFICE = string.Empty;
            this.FILERAR = string.Empty;
            this.PHEDUYET = false;
        }

        public CongVan(string stMSCV, string stSOCV, DateTime dNGAYCV, string stNOIDUNG, string stMSNV, int iMSLOAICV, int iMSCQ, int iMSGIAIDOAN, string stMSCVCHA, string stFILEPDF, string stFILEOFFICE, string stFILERAR)
        {
            this.MSCV = stMSCV;
            this.SOCV = stSOCV;
            this.NOIDUNG = stNOIDUNG;
            this.NOIDUNG_Unsign = string.Empty;
            this.NGAYCV = dNGAYCV;
            this.MSNV = stMSNV;
            this.MSLOAICV = iMSLOAICV;
            this.MSCQ = iMSCQ;
            this.MSCVCHA = stMSCVCHA;
            this.MSGIAIDOAN = iMSGIAIDOAN;
            this.FILEPDF = stFILEPDF;
            this.FILEOFFICE = stFILEOFFICE;
            this.FILERAR = stFILERAR;
            this.PHEDUYET = false;
        }

        public CongVan(DataRow row)
        {
            this.MSCV = row["MSCV"].ToString();
            this.SOCV = row["SOCV"].ToString();
            this.NOIDUNG = row["NOIDUNG"].ToString();
            this.NOIDUNG_Unsign = row["NOIDUNG_Unsign"].ToString();
            this.NGAYCV = Convert.ToDateTime(row["NGAYCV"]);
            this.MSNV = row["MSNV"].ToString();
            this.MSLOAICV = Convert.ToInt32(row["MSLOAICV"]);
            this.MSCQ = Convert.ToInt32(row["MSCQ"]);
            this.MSCVCHA = row["MSCVCHA"].ToString();
            this.MSGIAIDOAN = Convert.ToInt32(row["MSGIAIDOAN"]);
            this.FILEPDF = row["FILEPDF"].ToString();
            this.FILEOFFICE = row["FILEOFFICE"].ToString();
            this.FILERAR = row["FILERAR"].ToString();
            this.PHEDUYET = Convert.ToBoolean(row["PHEDUYET"]);
        }
    }
}

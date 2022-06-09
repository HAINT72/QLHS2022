using System;
using System.Data;

namespace Model
{
    public class CongVanView
    {
        public string MSCV { get; set; }
        public string SOCV { get; set; }
        public DateTime NGAYCV { get; set; }
        public string NOIDUNG { get; set; }
        public string NOIDUNG_Unsign { get; set; }
        public string MSNV { get; set; }
        public string LOAICV { get; set; }
        public string TENCQ { get; set; }
        public string GIAIDOAN { get; set; }
        public string MSCVCHA { get; set; }
        public string FILEPDF { get; set; }
        public string FILEOFFICE { get; set; }
        public string FILERAR { get; set; }
        public bool PHEDUYET { get; set; }

        public CongVanView()
        {
            this.MSCV = string.Empty;
            this.SOCV = string.Empty;
            this.NOIDUNG = string.Empty;
            this.NOIDUNG_Unsign = string.Empty;
            this.NGAYCV = DateTime.Today;
            this.MSNV = string.Empty;
            this.LOAICV = string.Empty;
            this.TENCQ = string.Empty;
            this.MSCVCHA = string.Empty;
            this.GIAIDOAN = string.Empty;
            this.FILEPDF = string.Empty;
            this.FILEOFFICE = string.Empty;
            this.FILERAR = string.Empty;
            this.PHEDUYET = false;
        }

        public CongVanView(DataRow row)
        {
            this.MSCV = row["MSCV"].ToString();
            this.SOCV = row["SOCV"].ToString();
            this.NOIDUNG = row["NOIDUNG"].ToString();
            this.NOIDUNG_Unsign = row["NOIDUNG_Unsign"].ToString();
            this.NGAYCV = Convert.ToDateTime(row["NGAYCV"]);
            this.MSNV = row["MSNV"].ToString();
            this.LOAICV = row["LOAICV"].ToString();
            this.TENCQ = row["TENCQ"].ToString();
            this.GIAIDOAN = row["GIAIDOAN"].ToString();
            this.MSCVCHA = row["MSCVCHA"].ToString();
            this.FILEPDF = row["FILEPDF"].ToString();
            this.FILEOFFICE = row["FILEOFFICE"].ToString();
            this.FILERAR = row["FILERAR"].ToString();
            this.PHEDUYET = Convert.ToBoolean(row["PHEDUYET"]);
        }
    }
}

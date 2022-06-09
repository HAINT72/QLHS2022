
using System;
using System.Data;

namespace Model
{

    public class DuoiCV
    {
        public int MSDUOICV { get; set; }
        public string DUOICV { get; set; }

        public DuoiCV()
        {
            this.MSDUOICV = 0;
            this.DUOICV = string.Empty;
        }

        public DuoiCV(int iMSDUOICV, string stDUOICV)
        {
            this.MSDUOICV = iMSDUOICV;
            this.DUOICV = stDUOICV;
        }

        public DuoiCV(DataRow row)
        {
            this.MSDUOICV = (row["MSDUOICV"] != DBNull.Value) ? Convert.ToInt32(row["MSDUOICV"]):0;
            this.DUOICV = row["DUOICV"].ToString();
        }
    }
}

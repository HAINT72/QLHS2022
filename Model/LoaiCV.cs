
using System;
using System.Data;

namespace Model
{

    public class LoaiCV
    {
        public int MSLOAICV { get; set; }
        public string LOAICV { get; set; }

        public LoaiCV()
        {
            MSLOAICV = 1;
            LOAICV = string.Empty;
        }
        public LoaiCV(int iMSLOAICV, string stLOAICV)
        {
            this.MSLOAICV = iMSLOAICV;
            this.LOAICV = stLOAICV;
        }

        public LoaiCV(DataRow row)
        {
            this.MSLOAICV = (row["MSLOAICV"] != DBNull.Value)? Convert.ToInt32(row["MSLOAICV"]):0;
            this.LOAICV = row["LOAICV"].ToString();
        }
    }

}

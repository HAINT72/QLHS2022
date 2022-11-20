using System;
using System.Data;

namespace Model
{

    public class GiaiDoan
    {
        public int MSGIAIDOAN { get; set; }
        public string GIAIDOAN { get; set; }
        public long MSCVGOC { get; set; }

        public GiaiDoan()
        {
            this.MSGIAIDOAN = 0;
            this.GIAIDOAN = string.Empty;
            this.MSCVGOC = 0;
        }
        public GiaiDoan(int iMSGIAIDOAN, string stGIAIDOAN, long lMSCVGOC)
        {
            this.MSGIAIDOAN = iMSGIAIDOAN;
            this.GIAIDOAN = stGIAIDOAN;
            this.MSCVGOC = lMSCVGOC;
        }

        public GiaiDoan(DataRow row)
        {
            this.MSGIAIDOAN = (row["MSGIAIDOAN"] != DBNull.Value) ? Convert.ToInt32(row["MSGIAIDOAN"]):0;
            this.GIAIDOAN = row["GIAIDOAN"].ToString();
            this.MSCVGOC = (row["MSCVGOC"] != DBNull.Value) ? Convert.ToInt64(row["MSCVGOC"]) : 0;
        }
    }
}

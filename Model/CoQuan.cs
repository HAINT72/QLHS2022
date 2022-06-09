
using System;
using System.Data;

namespace Model
{

    public class CoQuan
    {
        public int MSCQ { get; set; }
        public string TENCQ { get; set; }

        public CoQuan()
        {
            this.MSCQ = 0;
            this.TENCQ = string.Empty;
        }


        public CoQuan(int iMSCQ, string stTENCQ)
        {
            this.MSCQ = iMSCQ;
            this.TENCQ = stTENCQ;
        }

        public CoQuan(DataRow row)
        {
            this.MSCQ = (row["MSCQ"] != DBNull.Value) ? Convert.ToInt32(row["MSCQ"]):0;
            this.TENCQ = row["TENCQ"].ToString();
        }
    }
}

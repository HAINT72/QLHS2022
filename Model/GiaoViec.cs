
using System;
using System.Data;

namespace Model
{
    public class GiaoViec
    {
        public long MSCVGIAOVIEC { get; set; }
        public int MSNVGIAOVIEC { get; set; }
        public string CHIDAO { get; set; }
        public DateTime NGAYGIO { get; set; }
        public bool THONGBAO { get; set; }

        public GiaoViec()
        {
            this.MSCVGIAOVIEC = 0;
            this.MSNVGIAOVIEC = 0;
            this.CHIDAO = string.Empty;
            this.NGAYGIO = DateTime.Now;
            this.THONGBAO = true;
        }

        public GiaoViec(DataRow row)
        {
            this.MSCVGIAOVIEC = Convert.ToInt64(row["MSCVGIAOVIEC"]);
            this.MSNVGIAOVIEC = Convert.ToInt32(row["MSNVGIAOVIEC"]);
            this.CHIDAO = row["CHIDAO"].ToString();
            this.NGAYGIO = Convert.ToDateTime(row["NGAYGIO"]);
            this.THONGBAO = Convert.ToBoolean(row["THONGBAO"]);
        }
    }
}

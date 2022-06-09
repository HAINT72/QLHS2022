
using System;
using System.Data;

namespace Model
{
    public class GiaoViec
    {
        public string MSCVGIAOVIEC { get; set; }
        public string MSNVGIAOVIEC { get; set; }
        public string CHIDAO { get; set; }
        public DateTime NGAYGIO { get; set; }
        public bool THONGBAO { get; set; }

        public GiaoViec()
        {
            this.MSCVGIAOVIEC = string.Empty;
            this.MSNVGIAOVIEC = string.Empty;
            this.CHIDAO = string.Empty;
            this.NGAYGIO = DateTime.Now;
            this.THONGBAO = true;
        }

        public GiaoViec(DataRow row)
        {
            this.MSCVGIAOVIEC = row["MSCVGIAOVIEC"].ToString();
            this.MSNVGIAOVIEC = row["MSNVGIAOVIEC"].ToString();
            this.CHIDAO = row["CHIDAO"].ToString();
            this.NGAYGIO = Convert.ToDateTime(row["NGAYGIO"]);
            this.THONGBAO = Convert.ToBoolean(row["THONGBAO"]);
        }
    }
}

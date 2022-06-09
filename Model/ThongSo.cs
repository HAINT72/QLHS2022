using System;
using System.Data;

namespace Model
{
    public class ThongSo
    {
        public string MSTS { get; set; }
        public string NOIDUNG { get; set; }
        public string STR_DATA { get; set; }
        public string STR_PATH { get; set; }
        public bool HIEULUC { get; set; }

        public ThongSo()
        {
            this.MSTS = string.Empty;
            this.NOIDUNG = string.Empty;
            this.STR_DATA = string.Empty;
            this.STR_PATH = string.Empty;
            this.HIEULUC = false;
        }

        public ThongSo(DataRow row)
        {
            this.MSTS = row["MSTS"].ToString();
            this.NOIDUNG = row["NOIDUNG"].ToString();
            this.STR_DATA = row["STR_DATA"].ToString();
            this.STR_PATH = row["STR_PATH"].ToString();
            this.HIEULUC = Convert.ToBoolean(row["HIEULUC"]);
        }

    }
}

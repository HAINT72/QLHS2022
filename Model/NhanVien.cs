
namespace Model
{
    using System;
    using System.Data;

    public partial class NhanVien
    {
        public string MSNV { get; set; }
        public string HOTEN { get; set; }
        public string QUYENTRUYCAP { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public bool HIEULUC { get; set; }

        public NhanVien()
        {
            this.MSNV = "USER";
            this.HOTEN = string.Empty;
            this.QUYENTRUYCAP = "OFFLINE";
            this.EMAIL = string.Empty;
            this.PASSWORD = string.Empty;
            this.HIEULUC = false;
        }

        public NhanVien(DataRow row)
        {
            this.MSNV           = row["MSNV"].ToString();
            this.HOTEN          = row["HOTEN"].ToString();
            this.QUYENTRUYCAP   = row["QUYENTRUYCAP"].ToString();
            this.EMAIL          = row["EMAIL"].ToString();
            this.PASSWORD       = row["PASSWORD"].ToString();
            this.HIEULUC        = Convert.ToBoolean(row["HIEULUC"]);
        }

    }
}

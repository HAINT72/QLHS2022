
namespace Model
{
    using System;
    using System.Data;

    public partial class NhanVien
    {
        public int MSNV { get; set; }
        public string USERNAME { get; set; }
        public string HOTEN { get; set; }
        public string QUYENTC { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public bool HIEULUC { get; set; }

        public NhanVien()
        {
            this.MSNV = 0;
            this.USERNAME = "USERNAME";
            this.HOTEN = string.Empty;
            this.QUYENTC = "OFFLINE";
            this.EMAIL = string.Empty;
            this.PASSWORD = string.Empty;
            this.HIEULUC = false;
        }

        public NhanVien(DataRow row)
        {
            this.MSNV           = Convert.ToInt32(row["MSNV"]);
            this.USERNAME       = row["USERNAME"].ToString();
            this.HOTEN          = row["HOTEN"].ToString();
            this.QUYENTC        = row["QUYENTC"].ToString();
            this.EMAIL          = row["EMAIL"].ToString();
            this.PASSWORD       = row["PASSWORD"].ToString();
            this.HIEULUC        = Convert.ToBoolean(row["HIEULUC"]);
        }

    }
}

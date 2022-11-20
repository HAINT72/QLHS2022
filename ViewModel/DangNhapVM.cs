using App;
using System;

namespace ViewModel
{
    public class DangNhapVM
    {
        private static DangNhapVM instance;

        public static DangNhapVM Instance
        {
            get { if (instance == null) instance = new DangNhapVM(); return instance; }
            private set { instance = value; }
        }

        private DangNhapVM() { }

        public void SaveLoginLogout(string stLog = "Login")
        {
            int iMSNV = ShareVar.Instance.NV.MSNV;
            string stQuery = null;
            if (stLog == "Login")
                stQuery = string.Format("INSERT INTO  dbo.tDangNhap (MSNVLOGIN, NGAYGIOVAO) VALUES ('{0}', CONVERT(datetime, '{1}', 103))", iMSNV, DateTime.Now.ToString());
            else
                stQuery = string.Format("UPDATE dbo.tDangNhap SET NGAYGIORA = CONVERT(datetime, '{0}', 103) WHERE MSNVLOGIN ='{1}' AND NGAYGIORA IS NULL", DateTime.Now.ToString(), iMSNV);
            DataProvider.Instance.ExecuteNonQuery(stQuery);
        }

    }
}

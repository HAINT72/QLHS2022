using App;
using Model;

namespace ViewModel
{
    public class ThongSoVM
    {
        private static ThongSoVM instance;

        public static ThongSoVM Instance
        {
            get { if (instance == null) instance = new ThongSoVM(); return instance; }
            private set { instance = value; }
        }

        private ThongSoVM() { }

        public bool CapnhatThongSo(ThongSo ts)
        {
            string stQuery = "exec USP_CapnhatThongSo @stMSTS , @stNOIDUNG , @stSTR_DATA , @stSTR_PATH , @stHIEULUC ";
            int result = DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { ts.MSTS, ts.NOIDUNG, ts.STR_DATA, ts.STR_PATH, ts.HIEULUC });
            return result > 0;
        }

        public bool XoaThongSo(ThongSo ts)
        {
            string stQuery = $"DELETE FROM tThongSo WHERE MSTS = '{ts.MSTS}";
            int result = DataProvider.Instance.ExecuteNonQuery(stQuery);
            return result > 0;
        }

        public void EditAppSetting(string stMSTS)
        {
            string stQuery = $"SELECT STR_DATA FROM tThongSo WHERE MSTS ='{stMSTS}'";
            object data = DataProvider.Instance.ExecuteScalar(stQuery);
            string stCnn = data.ToString();
            DataProvider.Instance.EditAppSetting("MSTS", stMSTS);
            DataProvider.Instance.EditAppSetting("stCnn", stCnn);
        }

    }
}

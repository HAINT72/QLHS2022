using App;
using Model;
using System.Data;

namespace ViewModel
{
    public class GiaiDoanVM
    {
        private static GiaiDoanVM instance;

        public static GiaiDoanVM Instance
        {
            get { if (instance == null) instance = new GiaiDoanVM(); return instance; }
            private set { instance = value; }
        }

        private GiaiDoanVM() { }

        public GiaiDoan GetGiaiDoanByMSGD(int iMSGIAIDOAN)
        {
            GiaiDoan gd = null;
            if (iMSGIAIDOAN !=0)
            {
                string stQuery = string.Format("SELECT * FROM tGIAIDOAN WHERE MSGIAIDOAN = {0}", iMSGIAIDOAN);
                DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
                gd = new GiaiDoan(data.Rows[0]);
            }
            return gd;
        }

        public string GetTenGiaiDoanByMSGD(int iMSGIAIDOAN)
        {
            GiaiDoan gd = null;
            if (iMSGIAIDOAN != 0)
            {
                string stQuery = string.Format("SELECT * FROM tGIAIDOAN WHERE MSGIAIDOAN = {0}", iMSGIAIDOAN);
                DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
                gd = new GiaiDoan(data.Rows[0]);
            }
            return gd.GIAIDOAN;
        }

        public bool CapNhatGiaiDoan(int iMSGIAIDOAN, string stGiaiDoan, string stMSCVGoc)
        {
            string stQuery = "exec USP_CapnhatGiaidoan @iID , @stNOIDUNG , @stMSCVGOC";
            return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { iMSGIAIDOAN , stGiaiDoan, stMSCVGoc })) > 0;
        }

        public bool XoaGiaiDoan(int iMSGIAIDOAN)
        {
            bool bKetqua = false;
            string stMsg = "Bạn có chắc chắn xóa dữ liệu này không?";
            string stQuery = $"DELETE FROM tGiaiDoan WHERE MSGIAIDOAN ={iMSGIAIDOAN}";
            Functions.MsgBox(stMsg, MessageType.Confirmation, () => { bKetqua = (DataProvider.Instance.ExecuteNonQuery(stQuery) > 0); });
            return bKetqua;
        }

        public bool CapNhatCayCV(string stMSCV_Source, string stMSCV_Dest)
        {
            bool bKetQua = false;
            if (!string.IsNullOrEmpty(stMSCV_Source) && !string.IsNullOrEmpty(stMSCV_Dest))
            {
                string stMsg = $"Bạn có chắc chắn muốn điều chỉnh MSCV gốc từ '{stMSCV_Source}' thành '{stMSCV_Dest}'?";
                string stQuery = "exec USP_CapnhatCayCV @stMSCV_SOURCE , @stMSCV_DEST";
                Functions.MsgBox(stMsg, MessageType.Confirmation, () => { bKetQua = (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { stMSCV_Source, stMSCV_Dest }) > 0); });
            }
            return bKetQua;
        }

        public bool ResetCayCV()
        {
            bool bKetQua = false;
            string stMsg = "Bạn có chắc chắn muốn tạo lại cây công văn theo thông số mới?";
            string stQuery = "exec USP_CapnhatCayCV";
            Functions.MsgBox(stMsg, MessageType.Confirmation, () => { bKetQua = (DataProvider.Instance.ExecuteNonQuery(stQuery) > 0); });
            return bKetQua;
        }
    }
}

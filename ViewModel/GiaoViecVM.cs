using App;
using Model;
using System.Collections.Generic;
using System.Data;

namespace ViewModel
{
    public class GiaoViecVM
    {
        private static GiaoViecVM instance;
        public static GiaoViecVM Instance
        {
            get { instance = instance ?? new GiaoViecVM(); return instance; } //{ if (instance == null) instance = new GiaoViecVM(); return instance; }
            private set { instance = value; }
        }
        private GiaoViecVM() { }

        private List<GiaoViec> GetListGiaoViecByMSCV(string stMSCV)
        {
            string stQuery = $"SELECT * FROM tGiaoViec WHERE MSCVGIAOVIEC ='{stMSCV}' AND CHIDAO !='@'";
            DataTable data = DataProvider.Instance.ExecuteQuery(stQuery);
            return DataProvider.Instance.DataTableToList<GiaoViec>(data);
        }

        private string GetEmailByMSNV(int iMSNV)
        {
            string stQuery = $"SELECT EMAIL FROM tNhanVien WHERE MSNV ={iMSNV}";
            object data = DataProvider.Instance.ExecuteScalar(stQuery);
            return data.ToString();
        }

        public void SendEmailGV(string stMSCV)
        {
            List<GiaoViec> lstGV = GetListGiaoViecByMSCV(stMSCV);
            foreach (GiaoViec gv in lstGV)
            {
                string stEmail = GetEmailByMSNV(gv.MSNVGIAOVIEC);
                CongVan cv = CongVanVM.Instance.GetCongVanByMSCV(gv.MSCVGIAOVIEC);
                string stSubject = $"{cv.NOIDUNG}, ({cv.SOCV}, ngày {cv.NGAYCV.ToShortDateString()})";
                string stComment = $"Nội dung chỉ đạo: {gv.CHIDAO}";
                Utilities.Instance.SendMail(stEmail, stSubject, stComment, cv.FILEPDF);
            }
            Functions.MsgBox("Đã gửi mail thành công", MessageType.Success);
        }

        public bool CapnhatGiaoViec(long lMSCV, int stMSNV, string stCHIDAO, bool bThongBao)
        {
            string stQuery = "exec USP_CapnhatGiaoViec @stMSCV , @stMSNV , @stCHIDAO , @bTHONGBAO ";
            return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { lMSCV, iMSNV, stCHIDAO, bThongBao })) > 0;
        }

        public bool XoaGiaoViec(GiaoViec gv)
        {
            string stQuery = $"DELETE FROM tGiaoViec WHERE MSCVGIAOVIEC = '{gv.MSCVGIAOVIEC}' AND MSNVGIAOVIEC ='{gv.MSNVGIAOVIEC}'";
            return (DataProvider.Instance.ExecuteNonQuery(stQuery)) > 0;
        }

    }
}

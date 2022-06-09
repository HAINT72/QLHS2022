using App;
using Model;
using System;

namespace ViewModel
{
    public class OtherVM
    {
        //Các hàm xử lý cho dtgvCRUD với 01 textbox dữ liệu nhập.
        //Áp dụng cho tLoaiCV, tDuoiCV, tGiaiDoan, tCoQuan, tGiaoViec, tNhanVien

        private static OtherVM instance;
        public static OtherVM Instance
        {
            get { if (instance == null) instance = new OtherVM(); return instance; }
            private set { instance = value; }
        }
        private OtherVM() { }

        public bool UpdateData<T>(T data) where T:class, new()
        {
            string stQuery = null;
            if (data.GetType() == typeof(LoaiCV))
            {
                stQuery = "exec USP_CapnhatLoaiCV @iID , @stNOIDUNG";
                LoaiCV lcv = data as LoaiCV;
                return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { lcv.MSLOAICV, lcv.LOAICV }))>0;                
            }
            else if (data.GetType() == typeof(DuoiCV))
            {
                stQuery = "exec USP_CapnhatDuoiCV @iID , @stNOIDUNG";
                DuoiCV dcv = data as DuoiCV;
                return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { dcv.MSDUOICV, dcv.DUOICV })) > 0;
            }
            else if (data.GetType() == typeof(GiaiDoan))
            {
                stQuery = "exec USP_CapnhatGiaidoan @iID , @stNOIDUNG";
                GiaiDoan gd = data as GiaiDoan;
                return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { gd.MSGIAIDOAN, gd.GIAIDOAN })) > 0;
            }
            else if (data.GetType() == typeof(CoQuan))
            {
                stQuery = "exec USP_CapnhatCoquan @iID , @stNOIDUNG";
                CoQuan cq = data as CoQuan;
                return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { cq.MSCQ, cq.TENCQ })) > 0;
            }
            else if (data.GetType() == typeof(GiaoViec))
            {
                GiaoViec gv = data as GiaoViec;
                return GiaoViecVM.Instance.CapnhatGiaoViec(gv.MSCVGIAOVIEC, gv.MSNVGIAOVIEC, gv.CHIDAO, true);
            }
            else if (data.GetType() == typeof(NhanVien))
            {
                NhanVien nv = data as NhanVien;
                return ThemNhanVien(nv.MSNV, nv.HOTEN);
            }
            return false;
        }

        public bool DeleteData(Type typeModel, string stId)
        {
            string stQuery = string.Empty;
            int id = 0;
            int.TryParse(stId, out id);

            if (typeModel == typeof(LoaiCV))
                stQuery = $"DELETE FROM tLoaiCV WHERE MSLOAICV ={id}";
            else if (typeModel == typeof(DuoiCV))
                stQuery = $"DELETE FROM tDuoiCV WHERE MSDUOICV ={id}";
            else if (typeModel == typeof(GiaiDoan))
                stQuery = $"DELETE FROM tGiaiDoan WHERE MSGIAIDOAN ={id}";
            else if (typeModel == typeof(CoQuan))
                stQuery = $"DELETE FROM tCoQuan WHERE MSCQ ={id}";
            else if (typeModel == typeof(NhanVien))
                stQuery = $"DELETE FROM tNhanVien WHERE MSNV ='{stId}'";

            bool bKetqua = false;
            string stMsg = "Bạn có chắc chắn xóa dữ liệu này không?";
            Functions.MsgBox(stMsg, MessageType.Confirmation, () => { bKetqua = (DataProvider.Instance.ExecuteNonQuery(stQuery) > 0); });
            return bKetqua;
        }

        public bool ThemNhanVien(string stMSNV, string stHOTEN = "New user")
        {
            string stQuery = "exec USP_ThemNhanVien @stMSNV , @stHOTEN";
            return (DataProvider.Instance.ExecuteNonQuery(stQuery, new object[] { stMSNV , stHOTEN } )) > 0;
        }
    }
}

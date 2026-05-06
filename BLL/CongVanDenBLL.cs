using DAL;
using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class CongVanDenBLL
    {
        private static CongVanDenBLL _Instance;
        public static CongVanDenBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CongVanDenBLL();
                return _Instance;
            }
        }

        public DataTable GetAll()
        {
            return DAL.CongVanDenDAL.Instance.GetAll();
        }

        public bool Insert(DTO.CongVanDen cv)
        {
            if (string.IsNullOrEmpty(cv.SoDen))
                return false;

            // Set trạng thái chuẩn
            cv.TrangThai = TrangThaiCongVanDen.DA_NHAP;

            LogBLL.Instance.WriteLog("Thêm công văn: " + cv.SoDen, Session.UserName);

            return DAL.CongVanDenDAL.Instance.Insert(cv) > 0;
        }

        public bool Update(DTO.CongVanDen cv)
        {
            if (string.IsNullOrEmpty(cv.SoDen) || cv.Id <= 0)
                return false;

            LogBLL.Instance.WriteLog("Cập nhật công văn: " + cv.SoDen, Session.UserName);

            return DAL.CongVanDenDAL.Instance.Update(cv) > 0;
        }

        public bool TrinhLanhDao(int id)
        {
            LogBLL.Instance.WriteLog("Trình lãnh đạo", Session.UserName);
            return DAL.CongVanDenDAL.Instance.UpdateTrangThai(id, TrangThaiCongVanDen.DA_TRINH) > 0;
        }
        public bool PhanCong(int congVanId, string maNguoiDung, string maPhongBan, string yKien)
        {
            var result = PhanCongDAL.Instance.Insert(congVanId, maNguoiDung, maPhongBan, yKien);

            if (result > 0)
            {
                DAL.CongVanDenDAL.Instance.UpdateTrangThai(congVanId, TrangThaiCongVanDen.DA_PHAN_CONG);
                return true;
            }

            return false;
        }
        public bool CapNhatXuLy(int congVanId, string trangThai)
        {
            return DAL.CongVanDenDAL.Instance.UpdateTrangThai(congVanId, trangThai) > 0;
        }
        public bool HoanThanh(int congVanId)
        {
            return DAL.CongVanDenDAL.Instance.UpdateTrangThai(congVanId, TrangThaiCongVanDen.HOAN_THANH) > 0;
        }

        public bool Delete(int id)
        {
            LogBLL.Instance.WriteLog("Xóa công văn ID: " + id, Session.UserName);
            return DAL.CongVanDenDAL.Instance.Delete(id) > 0;
        }
        public string GenerateSoDen()
        {
            int count = DAL.CongVanDenDAL.Instance.GetMaxId() + 1;
            return count.ToString();
        }
        public DataTable GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return DAL.CongVanDenDAL.Instance.GetByDateRange(fromDate, toDate);
        }
        public DataTable GetByTrangThai(string trangThai)
        {
            return DAL.CongVanDenDAL.Instance.GetByTrangThai(trangThai);
        }
    }
}
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
        public bool TrinhLanhDao(int id)
        {
            LogBLL.Instance.WriteLog("Trình lãnh đạo", Session.UserName);
            return DAL.CongVanDenDAL.Instance.UpdateTrangThai(id, TrangThaiCongVanDen.DA_TRINH) > 0;
        }
        public bool PhanCong(int congVanId, string maNguoiDung, string maPhongBan, string yKien)
        {
            if (!string.IsNullOrEmpty(maNguoiDung) && !string.IsNullOrEmpty(maPhongBan))
                throw new Exception("Chỉ được chọn 1 trong 2: User hoặc Phòng");

            if (string.IsNullOrEmpty(maNguoiDung) && string.IsNullOrEmpty(maPhongBan))
                throw new Exception("Phải chọn nơi phân công");

            string cap = "";
            string nguoiGiao = Session.UserName;

            if (Session.Role == "LanhDao")
            {
                if (string.IsNullOrEmpty(maPhongBan))
                    throw new Exception("Lãnh đạo chỉ được giao phòng ban");

                maNguoiDung = null;
                cap = "LANH_DAO";
            }
            else if (Session.Role == "TruongPhong")
            {
                if (string.IsNullOrEmpty(maNguoiDung))
                    throw new Exception("Trưởng phòng phải giao cho nhân viên");

                maPhongBan = null;
                cap = "TRUONG_PHONG";
            }

            var result = PhanCongDAL.Instance.Insert(
                congVanId,
                maNguoiDung,
                maPhongBan,
                yKien,
                nguoiGiao,
                cap
            );

            if (result > 0)
            {
                DAL.CongVanDenDAL.Instance.UpdateTrangThai(congVanId, TrangThaiCongVanDen.DA_PHAN_CONG);

                LogBLL.Instance.WriteLog(
                    $"Phân công CV {congVanId} - {cap}",
                    Session.UserName
                );

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
        public DataTable GetCongVanChoTruongPhong()
        {
            return CongVanDenDAL.Instance.GetCongVanTheoPhong(Session.PhongBan);
        }
    }
}
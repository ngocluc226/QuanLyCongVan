using DAL;
using DTO;
using System;
using System.Collections.Generic;
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

        public bool Insert(DTO.CongVanDen cv)
        {
            if (string.IsNullOrEmpty(cv.SoDen))
                return false;

            // Set trạng thái chuẩn
            cv.TrangThai = TrangThaiCongVanDen.DA_NHAP;

            LogBLL.Instance.WriteLog("Thêm công văn: " + cv.SoDen, Session.UserName);

            return DAL.CongVanDenDAL.Instance.Insert(cv) > 0;
        }
        public DataTable SearchInTab(string role, bool isTabChuaXuLy, string column, string value)
        {
            string sqlBase = "";
            List<SqlParameter> p = new List<SqlParameter>();

            // Xác định nguồn dữ liệu dựa vào Role và Tab
            switch (role)
            {
                case "VanThu":
                    sqlBase = isTabChuaXuLy ?
                        "SELECT * FROM CongVanDen WHERE TrangThai = N'Đã nhập' AND TrangThai <> N'Đã xóa'" :
                        "SELECT * FROM CongVanDen WHERE TrangThai <> N'Đã nhập' AND TrangThai <> N'Đã xóa'";
                    break;
                case "LanhDao":
                    sqlBase = isTabChuaXuLy ?
                        "SELECT cv.* FROM CongVanDen cv JOIN TrinhLanhDao t ON cv.Id = t.CongVanId WHERE t.LanhDaoId = @id AND t.TrangThai = N'ChoDuyet'" :
                        "SELECT DISTINCT cv.* FROM CongVanDen cv JOIN TrinhLanhDao t ON cv.Id = t.CongVanId WHERE t.LanhDaoId = @id AND t.TrangThai <> N'ChoDuyet'";
                    p.Add(new SqlParameter("@id", Session.UserId));
                    break;
                case "TruongPhong":
                    sqlBase = isTabChuaXuLy ?
                        "SELECT cv.* FROM CongVanDen cv JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId WHERE pc.MaPhongBan = @pb AND pc.CapPhanCong = 'LANH_DAO' AND cv.Id NOT IN (SELECT CongVanId FROM PhanCongCongVan WHERE CapPhanCong = 'TRUONG_PHONG')" :
                        "SELECT DISTINCT cv.* FROM CongVanDen cv JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId WHERE pc.NguoiGiao = (SELECT TenDangNhap FROM NguoiDung WHERE MaNguoiDung = @id) AND pc.CapPhanCong = 'TRUONG_PHONG'";
                    p.Add(new SqlParameter("@pb", Session.PhongBan));
                    p.Add(new SqlParameter("@id", Session.UserId));
                    break;
                case "NhanVien":
                    sqlBase = isTabChuaXuLy ?
                        "SELECT cv.* FROM CongVanDen cv JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId WHERE pc.MaNguoiDung = @id AND cv.TrangThai IN (N'Đã phân công', N'Đang xử lý')" :
                        "SELECT cv.* FROM CongVanDen cv JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId WHERE pc.MaNguoiDung = @id AND cv.TrangThai = N'Hoàn thành'";
                    p.Add(new SqlParameter("@id", Session.UserId));
                    break;
            }

            return DAL.CongVanDenDAL.Instance.SearchData(sqlBase, column, value, p.ToArray());
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
        public DataTable GetCongVanMoiNhap()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanMoiNhapVanThu();
        }

        public DataTable GetCongVanDaXuLyVanThu()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanDaXuLyVanThu();
        }

        public DataTable GetCongVanChoLanhDao()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanChoLanhDao(Session.UserId);
        }

        public DataTable GetCongVanDaXuLyLanhDao()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanDaXuLyLanhDao(Session.UserId);
        }

        public DataTable GetCongVanChoPhongBan()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanChoPhongBan(Session.PhongBan);
        }

        public DataTable GetCongVanDaXuLyTruongPhong()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanDaXuLyTruongPhong(Session.UserId);
        }

        public DataTable GetCongVanChoNhanVien()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanTheoNhanVien(Session.UserId);
        }

        public DataTable GetCongVanDaHoanThanhChoNhanVien()
        {
            return DAL.CongVanDenDAL.Instance.GetCongVanDaHoanThanhNhanVien(Session.UserId);
        }
        

        public int GetThongBaoNhanVien()
        {
            // Truyền đúng UserId của người đang đăng nhập vào bộ lọc
            return DAL.CongVanDenDAL.Instance.GetCountChoXuLyByNhanVien(Session.UserId);
        }

        public int GetThongBaoTruongPhong()
        {
            // Truyền đúng Mã phòng ban của Trưởng phòng đang đăng nhập để đếm việc tồn đọng
            return DAL.CongVanDenDAL.Instance.GetCountChoGiaoViecByPhongBan(Session.PhongBan);
        }

        public DataTable GetPaged(int pageNumber, int pageSize)
        {
            return DAL.CongVanDenDAL.Instance.GetPaged(pageNumber, pageSize);
        }

        public int GetTotalCount()
        {
            return DAL.CongVanDenDAL.Instance.GetTotalCount();
        }

    }
}
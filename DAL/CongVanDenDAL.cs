using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class CongVanDenDAL
    {
        private static CongVanDenDAL _Instance;
        public static CongVanDenDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CongVanDenDAL();
                return _Instance;
            }
        }

        public DataTable GetAll()
        {
            string query = "SELECT * FROM CongVanDen WHERE TrangThai <> N'Đã xóa' ORDER BY NgayDen DESC";
            return DBHelper.Instance.ExecuteQuery(query);
        }
        public int UpdateTrangThai(int id, string trangThai)
        {
            string query = "UPDATE CongVanDen SET TrangThai = @TrangThai WHERE Id = @Id";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@Id", id)
            );
        }
        // 🔹 Thêm công văn
        public int Insert(CongVanDen cv)
        {
            string query = @"INSERT INTO CongVanDen 
            (SoDen, SoVanBan, NgayDen, NgayBanHanh, NoiGui, NguoiKy, TrichYeu, DoKhan, DoMat, FileDinhKem, TrangThai)
            VALUES 
            (@SoDen, @SoVanBan, @NgayDen, @NgayBanHanh, @NoiGui, @NguoiKy, @TrichYeu, @DoKhan, @DoMat, @FileDinhKem, @TrangThai)";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@SoDen", cv.SoDen),
                new SqlParameter("@SoVanBan", (object)cv.SoVanBan ?? DBNull.Value),
                new SqlParameter("@NgayDen", cv.NgayDen),
                new SqlParameter("@NgayBanHanh", (object)cv.NgayBanHanh ?? DBNull.Value),
                new SqlParameter("@NoiGui", (object)cv.NoiGui ?? DBNull.Value),
                new SqlParameter("@NguoiKy", (object)cv.NguoiKy ?? DBNull.Value),
                new SqlParameter("@TrichYeu", cv.TrichYeu),
                new SqlParameter("@DoKhan", (object)cv.DoKhan ?? DBNull.Value),
                new SqlParameter("@DoMat", (object)cv.DoMat ?? DBNull.Value),
                new SqlParameter("@FileDinhKem", (object)cv.FileDinhKem ?? DBNull.Value),
                new SqlParameter("@TrangThai", (object)cv.TrangThai ?? "Chưa xử lý")
            );
        }

        // 🔹 Xóa công văn
        public int Delete(int id)
        {
            string query = "UPDATE CongVanDen SET TrangThai = @TrangThai WHERE Id = @Id";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@TrangThai", DTO.TrangThaiCongVanDen.DA_XOA),
                new SqlParameter("@Id", id)
            );
        }
        public DataTable SearchData(string sqlBase, string column, string value, SqlParameter[] roleParams)
        {
            // sqlBase là câu lệnh lấy dữ liệu theo Role/Tab đã viết ở câu trước
            // Chúng ta lồng câu sqlBase vào một Subquery để tìm kiếm
            string sql = $@"SELECT * FROM ({sqlBase}) AS Source 
                    WHERE {column} LIKE @value";

            List<SqlParameter> parameters = new SqlParameter[] {
        new SqlParameter("@value", "%" + value + "%")
    }.ToList();

            if (roleParams != null) parameters.AddRange(roleParams);

            return DBHelper.Instance.ExecuteQuery(sql, parameters.ToArray());
        }

        // 🔹 Kiểm tra trùng Số đến
        public int CountBySoDen(string soDen)
        {
            string query = "SELECT COUNT(*) FROM CongVanDen WHERE SoDen = @SoDen";

            object result = DBHelper.Instance.ExecuteScalar(
                query,
                new SqlParameter("@SoDen", soDen)
            );

            return (result != null) ? Convert.ToInt32(result) : 0;
        }

        public int GetMaxId()
        {
                       string query = "SELECT ISNULL(MAX(Id), 0) FROM CongVanDen";
            object result = DBHelper.Instance.ExecuteScalar(query);
            return (result != null) ? Convert.ToInt32(result) : 0;
        }
        public DataTable GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT * FROM CongVanDen
                     WHERE NgayDen BETWEEN @FromDate AND @ToDate
                     ORDER BY NgayDen DESC";

            return DBHelper.Instance.ExecuteQuery(
                query,
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            );
        }
        // --- VĂN THƯ: Xem toàn bộ công văn trong cơ quan ---
        public DataTable GetCongVanMoiNhapVanThu()
        {
            string query = "SELECT * FROM CongVanDen WHERE TrangThai = N'Đã nhập' AND TrangThai <> N'Đã xóa' ORDER BY NgayDen DESC";
            return DBHelper.Instance.ExecuteQuery(query);
        }

        public DataTable GetCongVanDaXuLyVanThu()
        {
            // Văn thư xem được tất cả các trạng thái còn lại để theo dõi luồng
            string query = "SELECT * FROM CongVanDen WHERE TrangThai <> N'Đã nhập' AND TrangThai <> N'Đã xóa' ORDER BY NgayDen DESC";
            return DBHelper.Instance.ExecuteQuery(query);
        }

        // --- LÃNH ĐẠO: Chỉ xem những gì được trình đích danh cho mình ---
        public DataTable GetCongVanChoLanhDao(string maLanhDao)
        {
            string sql = @"SELECT cv.* FROM CongVanDen cv
                   JOIN TrinhLanhDao t ON cv.Id = t.CongVanId
                   WHERE t.LanhDaoId = @ma AND t.TrangThai = N'ChoDuyet' AND cv.TrangThai <> N'Đã xóa'";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@ma", maLanhDao));
        }

        public DataTable GetCongVanDaXuLyLanhDao(string maLanhDao)
        {
            string sql = @"SELECT DISTINCT cv.* FROM CongVanDen cv
                   JOIN TrinhLanhDao t ON cv.Id = t.CongVanId
                   WHERE t.LanhDaoId = @ma AND t.TrangThai <> N'ChoDuyet' AND cv.TrangThai <> N'Đã xóa'";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@ma", maLanhDao));
        }

        // --- TRƯỞNG PHÒNG: Chỉ xem công văn lãnh đạo giao về phòng mình và mình đã giao cho NV ---
        public DataTable GetCongVanChoPhongBan(string maPhong)
        {
            string sql = @"SELECT cv.* FROM CongVanDen cv
                   JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
                   WHERE pc.MaPhongBan = @pb AND pc.CapPhanCong = 'LANH_DAO' 
                   AND cv.Id NOT IN (SELECT CongVanId FROM PhanCongCongVan WHERE CapPhanCong = 'TRUONG_PHONG')
                   AND cv.TrangThai <> N'Đã xóa'";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@pb", maPhong));
        }

        public DataTable GetCongVanDaXuLyTruongPhong(string maTruongPhong)
        {
            string sql = @"SELECT DISTINCT cv.* FROM CongVanDen cv
                   JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
                   WHERE pc.NguoiGiao = (SELECT TenDangNhap FROM NguoiDung WHERE MaNguoiDung = @ma)
                   AND pc.CapPhanCong = 'TRUONG_PHONG' AND cv.TrangThai <> N'Đã xóa'";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@ma", maTruongPhong));
        }

        // --- NHÂN VIÊN: Chỉ xem công văn đích danh mình được giao ---
        public DataTable GetCongVanTheoNhanVien(string maNV)
        {
            string sql = @"SELECT cv.* FROM CongVanDen cv
                   JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
                   WHERE pc.MaNguoiDung = @ma AND cv.TrangThai IN (N'Đã phân công', N'Đang xử lý')
                   AND cv.TrangThai <> N'Đã xóa'";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@ma", maNV));
        }

        public DataTable GetCongVanDaHoanThanhNhanVien(string maNV)
        {
            string sql = @"SELECT cv.* FROM CongVanDen cv
                   JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
                   WHERE pc.MaNguoiDung = @ma AND cv.TrangThai = N'Hoàn thành'";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@ma", maNV));
        }
        public DataTable GetByTrangThai(string trangThai)
        {
            string query = "SELECT * FROM CongVanDen WHERE TrangThai = @tt";

            return DBHelper.Instance.ExecuteQuery(query,
                new SqlParameter("@tt", trangThai));
        }
        public DataTable GetCongVanTheoPhong(string maPhongBan)
        {
            string sql = @"
        SELECT cv.*
        FROM CongVanDen cv
        JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
        WHERE pc.MaPhongBan = @pb
          AND pc.MaNguoiDung IS NULL
        ORDER BY pc.NgayPhanCong DESC";

            return DBHelper.Instance.ExecuteQuery(sql,
                new SqlParameter("@pb", maPhongBan)
            );
        }
        
        public int GetCountChoGiaoViecByPhongBan(string maPhongBan)
        {
            string query = @"
        SELECT COUNT(DISTINCT cv.Id) 
        FROM CongVanDen cv
        JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
        WHERE pc.MaPhongBan = @maPhongBan 
          AND cv.TrangThai = N'Ðã phân công'
          AND cv.Id NOT IN (SELECT CongVanId FROM PhanCongCongVan WHERE CapPhanCong = 'TRUONG_PHONG')";

            object result = DBHelper.Instance.ExecuteScalar(query, new SqlParameter("@maPhongBan", maPhongBan));
            return (result != null) ? Convert.ToInt32(result) : 0;
        }
        public int GetCountChoXuLyByNhanVien(string maNguoiDung)
        {
            string query = @"
        SELECT COUNT(DISTINCT cv.Id) 
        FROM CongVanDen cv
        JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
        WHERE pc.MaNguoiDung = @maNguoiDung 
          AND cv.TrangThai IN (N'Đã phân công', N'Đang xử lý')";

            // Sử dụng ExecuteScalar của DBHelper
            object result = DBHelper.Instance.ExecuteScalar(query,
                new SqlParameter("@maNguoiDung", maNguoiDung)
            );

            return (result != null) ? Convert.ToInt32(result) : 0;
        }
        // Hàm lấy dữ liệu theo số trang (Mỗi trang 20 dòng)
        public DataTable GetPaged(int pageNumber, int pageSize)
        {
            // SỬA TẠI ĐÂY: Thêm điều kiện lọc bỏ các văn bản đã xóa mềm khi phân trang
            string query = @"
        SELECT * FROM CongVanDen 
        WHERE TrangThai <> N'Đã xóa'
        ORDER BY NgayDen DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;";

            int offset = (pageNumber - 1) * pageSize;

            return DBHelper.Instance.ExecuteQuery(query,
                new SqlParameter("@Offset", offset),
                new SqlParameter("@PageSize", pageSize)
            );
        }

        // Hàm đếm tổng số dòng để tính tổng số trang
        public int GetTotalCount()
        {
            string query = "SELECT COUNT(*) FROM CongVanDen";
            object result = DBHelper.Instance.ExecuteScalar(query);
            return (result != null) ? Convert.ToInt32(result) : 0;
        }
        public DataTable GetCongVanDaHoanThanhTheoNhanVien(string maNguoiDung)
        {
            string sql = @"
        SELECT cv.*
        FROM CongVanDen cv
        JOIN PhanCongCongVan pc ON cv.Id = pc.CongVanId
        WHERE pc.MaNguoiDung = @maNguoiDung
          AND cv.TrangThai = @trangThai
        ORDER BY cv.NgayDen DESC";

            return DBHelper.Instance.ExecuteQuery(sql,
                new SqlParameter("@maNguoiDung", maNguoiDung),
                new SqlParameter("@trangThai", DTO.TrangThaiCongVanDen.HOAN_THANH)
            );
        }
        
        public DataTable GetCongVanDaXuLyLanhDao()
        {
            // Lấy các công văn đã được Lãnh đạo phê duyệt/phân công đi (Trạng thái khác Đã nhập và khác Đã trình)
            string query = @"SELECT * FROM CongVanDen 
                     WHERE TrangThai NOT IN (N'Đã nhập', N'Đã trình', N'Đã xóa') 
                     ORDER BY NgayDen DESC";
            return DBHelper.Instance.ExecuteQuery(query);
        }
        

    }
}
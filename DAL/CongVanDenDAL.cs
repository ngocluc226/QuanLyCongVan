using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

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

        // 🔹 Lấy toàn bộ danh sách
        public DataTable GetAll()
        {
            string query = "SELECT * FROM CongVanDen ORDER BY NgayDen DESC";
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
            string query = "DELETE FROM CongVanDen WHERE Id = @Id";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@Id", id)
            );
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
    }
}
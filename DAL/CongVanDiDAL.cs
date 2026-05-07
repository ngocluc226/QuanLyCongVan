using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CongVanDiDAL
    {
        private static CongVanDiDAL _Instance;
        public static CongVanDiDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CongVanDiDAL();
                return _Instance;
            }
        }

        // 🔹 Lấy toàn bộ danh sách
        public DataTable GetAll()
        {
            string query = "SELECT * FROM CongVanDi ORDER BY NgayDi DESC";
            return DBHelper.Instance.ExecuteQuery(query);
        }

        // 🔹 Thêm công văn
        public int Insert(CongVanDi cv)
        {
            string query = @"INSERT INTO CongVanDi 
            (SoDi, SoVanBan, NgayDi, NgayBanHanh, NoiNhan, NguoiKy, TrichYeu, DoKhan, DoMat, FileDinhKem, TrangThai, GhiChu, NguoiDuyetId)
            VALUES 
            (@SoDi, @SoVanBan, @NgayDi, @NgayBanHanh, @NoiNhan, @NguoiKy, @TrichYeu, @DoKhan, @DoMat, @FileDinhKem, @TrangThai, @GhiChu, @NguoiDuyetId)";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@SoDi", cv.SoDi),
                new SqlParameter("@SoVanBan", (object)cv.SoVanBan ?? DBNull.Value),
                new SqlParameter("@NgayDi", cv.NgayDi),
                new SqlParameter("@NgayBanHanh", (object)cv.NgayBanHanh ?? DBNull.Value),
                new SqlParameter("@NoiNhan", (object)cv.NoiNhan ?? DBNull.Value),
                new SqlParameter("@NguoiKy", (object)cv.NguoiKy ?? DBNull.Value),
                new SqlParameter("@TrichYeu", cv.TrichYeu),
                new SqlParameter("@DoKhan", (object)cv.DoKhan ?? DBNull.Value),
                new SqlParameter("@DoMat", (object)cv.DoMat ?? DBNull.Value),
                new SqlParameter("@FileDinhKem", (object)cv.FileDinhKem ?? DBNull.Value),
                new SqlParameter("@TrangThai", (object)cv.TrangThai ?? "Chưa xử lý"),
                new SqlParameter("@GhiChu", (object)cv.GhiChu ?? DBNull.Value),
                new SqlParameter("@NguoiDuyetId", (object)cv.NguoiDuyetId ?? DBNull.Value)
            );
        }

        // 🔹 Cập nhật công văn
        public int Update(CongVanDi cv)
        {
            string query = @"UPDATE CongVanDi SET
                SoDi = @SoDi, SoVanBan = @SoVanBan, NgayDi = @NgayDi, NgayBanHanh = @NgayBanHanh, 
                NoiNhan = @NoiNhan, NguoiKy = @NguoiKy, TrichYeu = @TrichYeu, DoKhan = @DoKhan, 
                DoMat = @DoMat, FileDinhKem = @FileDinhKem, TrangThai = @TrangThai, GhiChu = @GhiChu, NguoiDuyetId = @NguoiDuyetId
                WHERE Id = @Id";
            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@SoDi", cv.SoDi),
                new SqlParameter("@SoVanBan", (object)cv.SoVanBan ?? DBNull.Value),
                new SqlParameter("@NgayDi", cv.NgayDi),
                new SqlParameter("@NgayBanHanh", (object)cv.NgayBanHanh ?? DBNull.Value),
                new SqlParameter("@NoiNhan", (object)cv.NoiNhan ?? DBNull.Value),
                new SqlParameter("@NguoiKy", (object)cv.NguoiKy ?? DBNull.Value),
                new SqlParameter("@TrichYeu", cv.TrichYeu),
                new SqlParameter("@DoKhan", (object)cv.DoKhan ?? DBNull.Value),
                new SqlParameter("@DoMat", (object)cv.DoMat ?? DBNull.Value),
                new SqlParameter("@FileDinhKem", (object)cv.FileDinhKem ?? DBNull.Value),
                new SqlParameter("@TrangThai", (object)cv.TrangThai ?? DBNull.Value),
                new SqlParameter("@GhiChu", (object)cv.GhiChu ?? DBNull.Value),
                new SqlParameter("@NguoiDuyetId", (object)cv.NguoiDuyetId ?? DBNull.Value),
                new SqlParameter("@Id", cv.Id)
            );
        }

        // 🔹 Cập nhật trạng thái
        public int UpdateTrangThai(int id, string trangThai, string ghiChu = null)
        {
            string query = "UPDATE CongVanDi SET TrangThai = @TrangThai, GhiChu = @GhiChu WHERE Id = @Id";
            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@GhiChu", (object)ghiChu ?? DBNull.Value),
                new SqlParameter("@Id", id)
            );
        }

        // 🔹 Phát hành công văn (Cập nhật ngày ban hành và nơi nhận)
        public int UpdatePhatHanh(int id, DateTime ngayBanHanh, string noiNhan)
        {
            string query = "UPDATE CongVanDi SET TrangThai = N'Đã phát hành', NgayBanHanh = @NgayBanHanh, NoiNhan = @NoiNhan WHERE Id = @Id";
            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@NgayBanHanh", ngayBanHanh),
                new SqlParameter("@NoiNhan", noiNhan),
                new SqlParameter("@Id", id)
            );
        }

        // 🔹 Xóa công văn
        public int Delete(int id)
        {
            string query = "DELETE FROM CongVanDi WHERE Id = @Id";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@Id", id)
            );
        }

        // 🔹 Kiểm tra trùng Số đi
        public int CountBySoDi(string soDi)
        {
            string query = "SELECT COUNT(*) FROM CongVanDi WHERE SoDi = @SoDi";

            object result = DBHelper.Instance.ExecuteScalar(
                query,
                new SqlParameter("@SoDi", soDi)
            );

            return (result != null) ? Convert.ToInt32(result) : 0;
        }

        public int GetMaxId()
        {
            string query = "SELECT ISNULL(MAX(Id), 0) FROM CongVanDi";
            object result = DBHelper.Instance.ExecuteScalar(query);
            return (result != null) ? Convert.ToInt32(result) : 0;
        }

        public DataTable GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT * FROM CongVanDi
                             WHERE NgayDi BETWEEN @FromDate AND @ToDate
                             ORDER BY NgayDi DESC";

            return DBHelper.Instance.ExecuteQuery(
                query,
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            );
        }

        public DataTable GetById(int id)
        {
            string query = "SELECT * FROM CongVanDi WHERE Id = @Id";
            return DBHelper.Instance.ExecuteQuery(query, new SqlParameter("@Id", id));
        }
    }
}

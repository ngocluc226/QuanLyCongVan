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
            (SoDi, SoVanBan, NgayDi, NgayBanHanh, NoiNhan, NguoiKy, TrichYeu, DoKhan, DoMat, FileDinhKem, TrangThai)
            VALUES 
            (@SoDi, @SoVanBan, @NgayDi, @NgayBanHanh, @NoiNhan, @NguoiKy, @TrichYeu, @DoKhan, @DoMat, @FileDinhKem, @TrangThai)";

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
                new SqlParameter("@TrangThai", (object)cv.TrangThai ?? "Chưa xử lý")
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

        // 🔹 Cập nhật công văn
        public int Update(CongVanDi cv)
        {
            string query = @"UPDATE CongVanDi 
            SET SoDi = @SoDi, SoVanBan = @SoVanBan, NgayDi = @NgayDi, NgayBanHanh = @NgayBanHanh, 
                NoiNhan = @NoiNhan, NguoiKy = @NguoiKy, TrichYeu = @TrichYeu, DoKhan = @DoKhan, 
                DoMat = @DoMat, FileDinhKem = @FileDinhKem, TrangThai = @TrangThai
            WHERE Id = @Id";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@Id", cv.Id),
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
                new SqlParameter("@TrangThai", (object)cv.TrangThai ?? DBNull.Value)
            );
        }

        // 🔹 Cập nhật trạng thái
        public int UpdateStatus(int id, string trangThai)
        {
            string query = "UPDATE CongVanDi SET TrangThai = @TrangThai WHERE Id = @Id";
            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@Id", id),
                new SqlParameter("@TrangThai", trangThai)
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

        public DataTable GetByTrangThai(string trangThai)
        {
            string query = "SELECT * FROM CongVanDi WHERE TrangThai = @TrangThai ORDER BY NgayDi DESC";
            return DBHelper.Instance.ExecuteQuery(
                query,
                new SqlParameter("@TrangThai", trangThai)
            );
        }

        public DataTable GetByTrangThais(params string[] trangThais)
        {
            if (trangThais == null || trangThais.Length == 0)
                return GetAll().Clone();

            string placeholder = "";
            SqlParameter[] pars = new SqlParameter[trangThais.Length];
            for (int i = 0; i < trangThais.Length; i++)
            {
                placeholder += $"@t{i},";
                pars[i] = new SqlParameter($"@t{i}", trangThais[i]);
            }
            placeholder = placeholder.TrimEnd(',');

            string query = $"SELECT * FROM CongVanDi WHERE TrangThai IN ({placeholder}) ORDER BY NgayDi DESC";
            return DBHelper.Instance.ExecuteQuery(query, pars);
        }
    }
}

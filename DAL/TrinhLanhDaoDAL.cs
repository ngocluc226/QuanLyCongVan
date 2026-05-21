using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TrinhLanhDaoDAL
    {
        private static TrinhLanhDaoDAL _Instance;
        public static TrinhLanhDaoDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new TrinhLanhDaoDAL();
                return _Instance;
            }
        }

        // 🔹 Thêm mới trình lãnh đạo
        public int Insert(TrinhLanhDao t)
        {
            string query = @"INSERT INTO TrinhLanhDao
    (CongVanId, NguoiTrinhId, LanhDaoId, NgayTrinh, TrangThai)
    VALUES (@CongVanId, @NguoiTrinhId, @LanhDaoId, @NgayTrinh, @TrangThai)";

            return DBHelper.Instance.ExecuteNonQuery(
                query,
                new SqlParameter("@CongVanId", t.CongVanId),
                new SqlParameter("@NguoiTrinhId", t.NguoiTrinhId),
                new SqlParameter("@LanhDaoId", t.LanhDaoId),
                new SqlParameter("@NgayTrinh", t.NgayTrinh),
                new SqlParameter("@TrangThai", t.TrangThai)
            );
        }

        // 🔹 Lấy công văn theo lãnh đạo
        public DataTable GetByLanhDao(string lanhDaoId)
        {
            string query = @"
        SELECT cv.*, nd.TenNguoiDung
        FROM CongVanDen cv
        JOIN TrinhLanhDao t ON cv.Id = t.CongVanId
        JOIN NguoiDung nd ON t.NguoiTrinhId = nd.MaNguoiDung
        WHERE t.LanhDaoId = @LanhDaoId
        AND t.TrangThai = N'ChoDuyet'
        ORDER BY t.NgayTrinh DESC";

            return DBHelper.Instance.ExecuteQuery(
                query,
                new SqlParameter("@LanhDaoId", lanhDaoId)
            );
        }
        /// <summary>
        /// Đếm số lượng công văn đang trong trạng thái chờ duyệt của RIÊNG vị Lãnh đạo này
        /// </summary>
        public int GetCountChoDuyetByLanhDao(string lanhDaoId)
        {
            // Đếm chính xác số dòng trong bảng TrinhLanhDao khớp với mã Lãnh đạo đang đăng nhập
            string query = @"
        SELECT COUNT(*) 
        FROM TrinhLanhDao 
        WHERE LanhDaoId = @LanhDaoId 
          AND TrangThai = N'ChoDuyet'";

            // Gọi thông qua lớp tiện ích DBHelper an toàn của bạn
            object result = DBHelper.Instance.ExecuteScalar(query,
                new SqlParameter("@LanhDaoId", lanhDaoId)
            );

            return (result != null) ? Convert.ToInt32(result) : 0;
        }
    }
}
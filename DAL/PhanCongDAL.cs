using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhanCongDAL
    {
        private static PhanCongDAL _Instance;
        public static PhanCongDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new PhanCongDAL();
                return _Instance;
            }
            set { }
        }
        public int Insert(int congVanId, string maNguoiDung, string maPhongBan, string yKien, string nguoiGiao, string capPhanCong)
        {
            // 🚫 Validate tầng DAL (phòng lỗi từ BLL)
            if (!string.IsNullOrEmpty(maNguoiDung) && !string.IsNullOrEmpty(maPhongBan))
                throw new Exception("Không được insert cả user và phòng ban");

            if (string.IsNullOrEmpty(maNguoiDung) && string.IsNullOrEmpty(maPhongBan))
                throw new Exception("Phải có user hoặc phòng ban");

            string sql = @"INSERT INTO PhanCongCongVan
    (CongVanId, MaNguoiDung, MaPhongBan, YKienChiDao, TrangThai, NguoiGiao, CapPhanCong)
    VALUES (@cvId, @user, @pb, @ykien, @tt, @nguoiGiao, @cap)";

            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@cvId", congVanId),
                new SqlParameter("@user", (object)maNguoiDung ?? DBNull.Value),
                new SqlParameter("@pb", (object)maPhongBan ?? DBNull.Value),
                new SqlParameter("@ykien", yKien ?? ""),
                new SqlParameter("@tt", TrangThaiCongVanDen.DA_PHAN_CONG),
                new SqlParameter("@nguoiGiao", nguoiGiao),
                new SqlParameter("@cap", capPhanCong)
            );
        }
    }
}

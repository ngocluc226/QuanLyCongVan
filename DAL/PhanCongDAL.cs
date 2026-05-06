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
        public int Insert(int congVanId, string maNguoiDung, string maPhongBan, string yKien)
        {
            string sql = @"INSERT INTO PhanCongCongVan
    (CongVanId, MaNguoiDung, MaPhongBan, YKienChiDao, TrangThai)
    VALUES (@cvId, @user, @pb, @ykien, @tt)";

            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@cvId", congVanId),
                new SqlParameter("@user", (object)maNguoiDung ?? DBNull.Value),
                new SqlParameter("@pb", (object)maPhongBan ?? DBNull.Value),
                new SqlParameter("@ykien", yKien),
                new SqlParameter("@tt", TrangThaiCongVanDen.DANG_XU_LY)
            );
        }
    }
}

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhongBanDAL
    {
        private static PhongBanDAL _Instance;
        public static PhongBanDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new PhongBanDAL();
                return _Instance;
            }
        }

        private PhongBanDAL() { }

        public DataTable GetAll()
        {
            return DBHelper.Instance.ExecuteQuery(
                "SELECT MaPhongBan, TenPhongBan FROM PhongBan"
            );
        }
        public int Insert(string ma, string ten)
        {
            string sql = "INSERT INTO PhongBan (MaPhongBan, TenPhongBan) VALUES (@ma, @ten)";
            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@ma", ma),
                new SqlParameter("@ten", ten));
        }

        public int Update(string ma, string ten)
        {
            string sql = "UPDATE PhongBan SET TenPhongBan = @ten WHERE MaPhongBan = @ma";
            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@ma", ma),
                new SqlParameter("@ten", ten));
        }

        public int Delete(string ma)
        {
            string sql = "DELETE FROM PhongBan WHERE MaPhongBan = @ma";
            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@ma", ma));
        }
    }
}
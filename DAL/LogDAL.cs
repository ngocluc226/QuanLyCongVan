using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LogDAL
    {
        private static LogDAL _Instance;
        public static LogDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LogDAL();
                return _Instance;
            }
            private set { }
        }

        public DataTable GetAll()
        {
            return DBHelper.Instance.ExecuteQuery(
                "SELECT * FROM LogHeThong ORDER BY ThoiGian DESC"
            );
        }

        public int Insert(string hanhDong, string user)
        {
            string sql = @"INSERT INTO LogHeThong (HanhDong, NguoiThucHien)
                       VALUES (@hd, @user)";

            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@hd", hanhDong),
                new SqlParameter("@user", user));
        }
    }
}

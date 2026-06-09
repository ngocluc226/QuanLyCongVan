using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class UserDAL
    {
        private static UserDAL _instance;
        public static UserDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserDAL();
                return _instance;
            }
        }

        private UserDAL() { }

        public DataTable GetAll()
        {
            string sql = @"
                SELECT nd.*, pb.TenPhongBan
                FROM NguoiDung nd
                LEFT JOIN PhongBan pb ON nd.MaPhongBan = pb.MaPhongBan";

            return DBHelper.Instance.ExecuteQuery(sql);
        }

        public int Insert(User u)
        {
            string sql = @"INSERT INTO NguoiDung 
            (MaNguoiDung, TenNguoiDung, TenDangNhap, MatKhau, Quyen, MaPhongBan, SDT, Email)
            VALUES (@Ma, @Ten, @User, @Pass, @Quyen, @PhongBan, @SDT, @Email)";

            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@Ma", u.MaNguoiDung),
                new SqlParameter("@Ten", u.TenNguoiDung),
                new SqlParameter("@User", u.TenDangNhap),
                new SqlParameter("@Pass", u.MatKhau),
                new SqlParameter("@Quyen", u.Quyen),
                new SqlParameter("@PhongBan", u.MaPhongBan),
                new SqlParameter("@SDT", u.SDT),
                new SqlParameter("@Email", u.Email)
            );
        }

        public int Update(User u)
        {
            string sql = @"UPDATE NguoiDung SET 
                TenNguoiDung = @Ten,
                TenDangNhap = @User,
                MatKhau = @Pass,
                Quyen = @Quyen,
                MaPhongBan = @PhongBan,
                SDT = @SDT,
                Email = @Email
                WHERE MaNguoiDung = @Ma";

            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@Ma", u.MaNguoiDung),
                new SqlParameter("@Ten", u.TenNguoiDung),
                new SqlParameter("@User", u.TenDangNhap),
                new SqlParameter("@Pass", u.MatKhau),
                new SqlParameter("@Quyen", u.Quyen),
                new SqlParameter("@PhongBan", u.MaPhongBan),
                new SqlParameter("@SDT", u.SDT),
                new SqlParameter("@Email", u.Email)
            );
        }

        public int Delete(string ma)
        {
            string sql = "DELETE FROM NguoiDung WHERE MaNguoiDung = @Ma";

            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@Ma", ma));
        }

        public DataTable Search(string column, string value)
        {
            string[] allowedColumns =
            {
                "nd.MaNguoiDung",
                "nd.TenNguoiDung",
                "nd.TenDangNhap",
                "nd.Email",
                "nd.Quyen",
                "nd.SDT",
                "pb.TenPhongBan"
    };

            string sql = $@"
        SELECT nd.*, pb.TenPhongBan
        FROM NguoiDung nd
        LEFT JOIN PhongBan pb ON nd.MaPhongBan = pb.MaPhongBan
        WHERE {column} LIKE @value";

            return DBHelper.Instance.ExecuteQuery(sql,
                new SqlParameter("@value", "%" + value + "%"));
        }
        public User Login(string username, string password)
        {
            string sql = @"SELECT * FROM NguoiDung 
                   WHERE TenDangNhap = @user AND MatKhau = @pass";

            DataTable dt = DBHelper.Instance.ExecuteQuery(sql,
                new SqlParameter("@user", username),
                new SqlParameter("@pass", password));

            if (dt.Rows.Count == 0)
                return null;

            DataRow r = dt.Rows[0];

            return new DTO.User()
            {
                MaNguoiDung = r["MaNguoiDung"].ToString(),
                TenNguoiDung = r["TenNguoiDung"].ToString(),
                TenDangNhap = r["TenDangNhap"].ToString(),
                MatKhau = r["MatKhau"].ToString(),
                Quyen = r["Quyen"].ToString(),
                MaPhongBan = r["MaPhongBan"]?.ToString(),
                SDT = r["SDT"]?.ToString(),
                Email = r["Email"]?.ToString()
            };
        }
        public DataTable GetByRole(string role)
        {
            string query = "SELECT MaNguoiDung, TenNguoiDung FROM NguoiDung WHERE Quyen = @Role";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Role", role)
            };

            return DBHelper.Instance.ExecuteQuery(query, parameters);
        }
        public DataTable GetByPhongBan(string maPhongBan)
        {
            string query = @"
        SELECT MaNguoiDung, TenNguoiDung
        FROM NguoiDung
        WHERE MaPhongBan = @MaPhongBan";

            return DBHelper.Instance.ExecuteQuery(
                query,
                new SqlParameter("@MaPhongBan", maPhongBan)
            );
        }
    }
}
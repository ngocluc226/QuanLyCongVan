using System.Data;

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
    }
}
using DAL;
using System.Data;

namespace BLL
{
    public class PhongBanBLL
    {
        private static PhongBanBLL _Instance;
        public static PhongBanBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new PhongBanBLL();
                return _Instance;
            }
        }

        private PhongBanBLL() { }

        public DataTable GetAll()
        {
            return PhongBanDAL.Instance.GetAll();
        }
    }
}
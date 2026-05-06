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
        public bool Insert(string ma, string ten)
        {
            return PhongBanDAL.Instance.Insert(ma, ten) > 0;
        }

        public bool Update(string ma, string ten)
        {
            return PhongBanDAL.Instance.Update(ma, ten) > 0;
        }

        public bool Delete(string ma)
        {
            return PhongBanDAL.Instance.Delete(ma) > 0;
        }
    }
}
using System;
using System.Data;

namespace BLL
{
    public class CongVanDenBLL
    {
        private static CongVanDenBLL _Instance;
        public static CongVanDenBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CongVanDenBLL();
                return _Instance;
            }
        }

        public DataTable GetAll()
        {
            return DAL.CongVanDenDAL.Instance.GetAll();
        }

        public bool Insert(DTO.CongVanDen cv)
        {
            if (string.IsNullOrEmpty(cv.SoDen))
                return false;

            return DAL.CongVanDenDAL.Instance.Insert(cv) > 0;
        }

        public bool Delete(int id)
        {
            return DAL.CongVanDenDAL.Instance.Delete(id) > 0;
        }
        public string GenerateSoDen()
        {
            int count = DAL.CongVanDenDAL.Instance.GetMaxId() + 1;
            return count.ToString();
        }
        public DataTable GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return DAL.CongVanDenDAL.Instance.GetByDateRange(fromDate, toDate);
        }
    }
}
using System;
using System.Data;

namespace BLL
{
    public class CongVanDiBLL
    {
        private static CongVanDiBLL _Instance;
        public static CongVanDiBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CongVanDiBLL();
                return _Instance;
            }
        }

        public DataTable GetAll()
        {
            return DAL.CongVanDiDAL.Instance.GetAll();
        }

        public bool Insert(DTO.CongVanDi cv)
        {
            if (string.IsNullOrEmpty(cv.SoDi))
                return false;

            return DAL.CongVanDiDAL.Instance.Insert(cv) > 0;
        }

        public bool Update(DTO.CongVanDi cv)
        {
            if (string.IsNullOrEmpty(cv.SoDi))
                return false;

            return DAL.CongVanDiDAL.Instance.Update(cv) > 0;
        }

        public bool UpdateTrangThai(int id, string trangThai, string ghiChu = null)
        {
            return DAL.CongVanDiDAL.Instance.UpdateTrangThai(id, trangThai, ghiChu) > 0;
        }

        public bool UpdatePhatHanh(int id, DateTime ngayBanHanh, string noiNhan)
        {
            return DAL.CongVanDiDAL.Instance.UpdatePhatHanh(id, ngayBanHanh, noiNhan) > 0;
        }

        public bool Delete(int id)
        {
            return DAL.CongVanDiDAL.Instance.Delete(id) > 0;
        }
        
        public string GenerateSoDi()
        {
            int count = DAL.CongVanDiDAL.Instance.GetMaxId() + 1;
            return count.ToString();
        }
        
        public DataTable GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return DAL.CongVanDiDAL.Instance.GetByDateRange(fromDate, toDate);
        }
    }
}

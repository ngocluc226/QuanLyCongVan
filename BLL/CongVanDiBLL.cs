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

        public bool Delete(int id)
        {
            return DAL.CongVanDiDAL.Instance.Delete(id) > 0;
        }
        
        public bool Update(DTO.CongVanDi cv)
        {
            return DAL.CongVanDiDAL.Instance.Update(cv) > 0;
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

        public DataTable GetByTrangThai(string trangThai)
        {
            return DAL.CongVanDiDAL.Instance.GetByTrangThai(trangThai);
        }

        public DataTable GetByTrangThais(params string[] trangThais)
        {
            return DAL.CongVanDiDAL.Instance.GetByTrangThais(trangThais);
        }

        public bool ChuyenTrangThai(int id, string trangThaiMoi, string ghiChu = "")
        {
            bool result = DAL.CongVanDiDAL.Instance.UpdateStatus(id, trangThaiMoi) > 0;
            if (result)
            {
                string user = DTO.Session.CurrentUser?.MaNguoiDung ?? "Unknown";
                string hanhDong = $"Chuyển trạng thái: {trangThaiMoi} cho CV ID {id}";
                if (!string.IsNullOrEmpty(ghiChu))
                {
                    hanhDong += $" - Ghi chú: {ghiChu}";
                }
                LogBLL.Instance.WriteLog(hanhDong, user);
            }
            return result;
        }
    }
}

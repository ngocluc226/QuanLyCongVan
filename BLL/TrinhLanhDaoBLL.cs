using DAL;
using DTO;
using System;
using System.Data;

namespace BLL
{
    public class TrinhLanhDaoBLL
    {
        private static TrinhLanhDaoBLL _Instance;
        public static TrinhLanhDaoBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new TrinhLanhDaoBLL();
                return _Instance;
            }
        }

        public bool Trinh(int congVanId, string nguoiTrinhId, string lanhDaoId)
        {
            var obj = new TrinhLanhDao
            {
                CongVanId = congVanId,
                NguoiTrinhId = nguoiTrinhId,
                LanhDaoId = lanhDaoId,
                NgayTrinh = DateTime.Now,
                TrangThai = "ChoDuyet"
            };

            int result = TrinhLanhDaoDAL.Instance.Insert(obj);

            if (result > 0)
            {
                CongVanDenDAL.Instance.UpdateTrangThai(congVanId, TrangThaiCongVanDen.DA_TRINH);
                LogBLL.Instance.WriteLog("Trình lãnh đạo", Session.UserName);
                return true;
            }

            return false;
        }
    }
}
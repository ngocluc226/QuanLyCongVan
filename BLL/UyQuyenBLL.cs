using DTO;
using DAL;
using System.Data;
using System;

namespace BLL
{
    public class UyQuyenBLL
    {
        private static UyQuyenBLL _Instance;
        public static UyQuyenBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UyQuyenBLL();
                return _Instance;
            }
        }

        public DataTable GetAllActive()
        {
            return UyQuyenDAL.Instance.GetAllActive();
        }

        public DataTable GetByNguoiDuocUyQuyen(string maNguoiDung)
        {
            return UyQuyenDAL.Instance.GetByNguoiDuocUyQuyen(maNguoiDung);
        }

        public bool CheckHasActiveUyQuyenLanhDao(string maNguoiDung)
        {
            var dt = GetByNguoiDuocUyQuyen(maNguoiDung);
            if (dt.Rows.Count > 0)
            {
                // Giả sử có ít nhất 1 dòng có QuyenHan = 'ALL' hoặc 'LanhDao'
                return true; 
            }
            return false;
        }

        public bool Insert(UyQuyen uq)
        {
            if (uq.TuNgay >= uq.DenNgay)
            {
                throw new Exception("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày.");
            }
            return UyQuyenDAL.Instance.Insert(uq) > 0;
        }

        public bool Disable(int id)
        {
            return UyQuyenDAL.Instance.Disable(id) > 0;
        }
    }
}

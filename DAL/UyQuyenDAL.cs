using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UyQuyenDAL
    {
        private static UyQuyenDAL _Instance;
        public static UyQuyenDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UyQuyenDAL();
                return _Instance;
            }
        }

        public DataTable GetAllActive()
        {
            string sql = "SELECT * FROM UyQuyen WHERE TrangThai = 1";
            return DBHelper.Instance.ExecuteQuery(sql);
        }

        public DataTable GetByNguoiDuocUyQuyen(string maNguoiDung)
        {
            string sql = "SELECT * FROM UyQuyen WHERE NguoiDuocUyQuyen = @Ma AND TrangThai = 1 AND getDate() BETWEEN TuNgay AND DenNgay";
            return DBHelper.Instance.ExecuteQuery(sql, new SqlParameter("@Ma", maNguoiDung));
        }

        public int Insert(UyQuyen uq)
        {
            string sql = @"INSERT INTO UyQuyen(NguoiUyQuyen, NguoiDuocUyQuyen, TuNgay, DenNgay, QuyenHan, TrangThai) 
                           VALUES(@NguoiUyQuyen, @NguoiDuocUyQuyen, @TuNgay, @DenNgay, @QuyenHan, @TrangThai)";
            return DBHelper.Instance.ExecuteNonQuery(sql,
                new SqlParameter("@NguoiUyQuyen", uq.NguoiUyQuyen),
                new SqlParameter("@NguoiDuocUyQuyen", uq.NguoiDuocUyQuyen),
                new SqlParameter("@TuNgay", uq.TuNgay),
                new SqlParameter("@DenNgay", uq.DenNgay),
                new SqlParameter("@QuyenHan", uq.QuyenHan),
                new SqlParameter("@TrangThai", uq.TrangThai));
        }

        public int Disable(int id)
        {
            string sql = "UPDATE UyQuyen SET TrangThai = 0 WHERE Id = @Id";
            return DBHelper.Instance.ExecuteNonQuery(sql, new SqlParameter("@Id", id));
        }
    }
}

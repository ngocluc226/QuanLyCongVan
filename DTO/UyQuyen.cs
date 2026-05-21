using System;

namespace DTO
{
    public class UyQuyen
    {
        public int Id { get; set; }
        public string NguoiUyQuyen { get; set; }
        public string NguoiDuocUyQuyen { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string QuyenHan { get; set; }
        public bool TrangThai { get; set; }
    }
}

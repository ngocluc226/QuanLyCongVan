using System;
using System.Collections.Generic;

namespace DTO
{
    public class KetQuaKiemTraAI
    {
        public int DiemSo { get; set; } // Thang điểm 100
        public bool HopLe { get; set; } // True nếu điểm > 80 
        public List<string> DanhSachLoi { get; set; } 
        public string DeXuatChinhSua { get; set; } 
    }
}
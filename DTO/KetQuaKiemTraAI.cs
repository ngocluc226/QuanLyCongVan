using System;
using System.Collections.Generic;

namespace DTO
{
    public class KetQuaKiemTraAI
    {
        public int DiemSo { get; set; } // Thang điểm 100
        public bool HopLe { get; set; } // True nếu điểm > 80 (được phép trình)
        public List<string> DanhSachLoi { get; set; } // Danh sách chi tiết các lỗi thể thức phát hiện được
        public string DeXuatChinhSua { get; set; } // Lời khuyên tổng quan từ AI
    }
}
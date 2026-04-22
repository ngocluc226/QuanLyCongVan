using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongVanDen
    {
        public int Id { get; set; }
        public string SoDen { get; set; }
        public string SoVanBan { get; set; }
        public DateTime NgayDen { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string NoiGui { get; set; }
        public string NguoiKy { get; set; }
        public string TrichYeu { get; set; }
        public string DoKhan { get; set; }
        public string DoMat { get; set; }
        public string FileDinhKem { get; set; }
        public string TrangThai { get; set; }
    }
}
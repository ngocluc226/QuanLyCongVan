using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongVanDi
    {
        public int Id { get; set; }
        public string SoDi { get; set; }
        public string SoVanBan { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string NoiNhan { get; set; }
        public string NguoiKy { get; set; }
        public string TrichYeu { get; set; }
        public string DoKhan { get; set; }
        public string DoMat { get; set; }
        public string FileDinhKem { get; set; }
        public string TrangThai { get; set; }
        public int? LienKetCongVanDenId { get; set; }
    }
}

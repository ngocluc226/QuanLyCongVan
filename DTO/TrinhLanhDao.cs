using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrinhLanhDao
    {
        public int Id { get; set; }
        public int CongVanId { get; set; }
        public string NguoiTrinhId { get; set; }
        public string LanhDaoId { get; set; }
        public DateTime NgayTrinh { get; set; }
        public string TrangThai { get; set; }
    }
}

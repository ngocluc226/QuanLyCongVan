using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class Session
    {
        public static User CurrentUser { get; private set; }

        public static bool IsLogin => CurrentUser != null;

        public static string UserName => CurrentUser?.TenNguoiDung;
        public static string Role => CurrentUser?.Quyen;
        public static string UserId => CurrentUser?.MaNguoiDung;
        public static string PhongBan => CurrentUser?.MaPhongBan;

        // 🎯 THÊM CÁI NÀY
        public static bool IsLanhDao => Role == "LanhDao";
        public static bool IsTruongPhong => Role == "TruongPhong";
        public static bool IsNhanVien => Role == "NhanVien";

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}

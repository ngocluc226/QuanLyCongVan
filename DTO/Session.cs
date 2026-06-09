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

        public static bool IsLogin
        {
            get { return CurrentUser != null; }
        }
        public static string UserName
        {
            get { return CurrentUser != null ? CurrentUser.TenNguoiDung : null; }
        }
        public static string Role
        {
            get { return CurrentUser != null ? CurrentUser.Quyen : null; }
        }
        public static string UserId
        {
            get { return CurrentUser != null ? CurrentUser.MaNguoiDung : null; }
        }
        public static string PhongBan
        {
            get { return CurrentUser != null ? CurrentUser.MaPhongBan : null; }
        }
        public static bool IsLanhDao
        {
            get { return Role == "LanhDao"; }
        }
        public static bool IsTruongPhong
        {
            get { return Role == "TruongPhong"; }
        }
        public static bool IsNhanVien
        {
            get { return Role == "NhanVien"; }
        }
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
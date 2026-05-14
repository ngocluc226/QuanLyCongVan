using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserService();
                return _instance;
            }
        }

        private UserService() { }

        public DataTable GetAllUsers()
        {
            return UserDAL.Instance.GetAll();
        }

        public DataTable GetAllPhongBan()
        {
            return PhongBanBLL.Instance.GetAll();
        }

        public void AddUser(User u)
        {
            UserDAL.Instance.Insert(u);
        }

        public void UpdateUser(User u)
        {
            UserDAL.Instance.Update(u);
        }

        public void DeleteUser(string id)
        {
            UserDAL.Instance.Delete(id);
        }

        public DataTable SearchUsers(string column, string text)
        {
            return UserDAL.Instance.Search(column, text);
        }
        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return UserDAL.Instance.Login(username, password);
        }
        public DataTable GetByRole(string role)
        {
            return UserDAL.Instance.GetByRole(role);
        }
        public DataTable GetByPhongBan(string maPhongBan)
        {
            return UserDAL.Instance.GetByPhongBan(maPhongBan);
        }
    }
}
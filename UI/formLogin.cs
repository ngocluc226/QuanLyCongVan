using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // 1. Validate
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nhập tài khoản và mật khẩu!");
                return;
            }

            // 2. Gọi BLL
            var user = BLL.UserService.Instance.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                return;
            }

            // 3. Lưu session
            Session.SetUser(user);

            // 4. Ghi log
            BLL.LogBLL.Instance.WriteLog("Đăng nhập", Session.UserName);

            // 5. Mở form theo quyền
            this.Hide();
            OpenFormByRole();
        }
        private void OpenFormByRole()
        {
            Form f;

            switch (Session.Role)
            {
                case "Admin":
                    f = new formAdmin();
                    break;
                case "VanThu":
                    f = new formVanThu();
                    break;
                case "LanhDao":
                    f = new formLanhDao();
                    break;
                case "NhanVien":
                     f = new formNhanVien();
                    break;
                case "TruongPhong":
                     f = new formTruongPhong();
                    break;
                default:
                    f = new formNhanVien();
                    break;
            }

            f.FormClosed += (s, e) => Application.Exit();
            f.Show();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}

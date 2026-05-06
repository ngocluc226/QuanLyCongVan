using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public static class Utils
    {
        public static void Logout(Form currentForm)
        {
            var result = MessageBox.Show(
                "Bạn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            Session.Clear();

            // Mở login trước
            formLogin login = new formLogin();
            login.Show();

            // Đóng form hiện tại
            currentForm.Hide();
        }
        public static void LoadForm(Form childForm, Panel container)
        {
            container.Controls.Clear();

            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;

            container.Controls.Add(childForm);
            childForm.Show();
        }
    }
}

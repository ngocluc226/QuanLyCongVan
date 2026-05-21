using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        public static string HashSHA256(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Chuyển sang dạng Hex chuỗi 64 ký tự
                }
                return builder.ToString();
            }
        }
        public static void FormatDataGridView(DataGridView dgv)
        {
            // 1. Cấu hình chung cho Grid
            dgv.EnableHeadersVisualStyles = false; // Bắt buộc phải False thì mới đổi màu Header được
            dgv.BackgroundColor = Color.FromArgb(245, 248, 251); // Màu nền Grid mịn, sáng
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 230, 242); // Màu đường kẻ mờ, tinh tế
            dgv.RowHeadersVisible = false; // Ẩn cột trống thừa ngoài cùng bên trái
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Luôn chọn cả dòng
            dgv.MultiSelect = true;

            // 2. Định dạng thanh Tiêu đề (Header) - Màu xanh Deep Blue chuyên nghiệp
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(16, 106, 177); // Khớp với màu các nút bấm của bạn
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // 3. Định dạng các dòng dữ liệu mặc định (Dòng lẻ)
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            defaultStyle.BackColor = Color.White;
            defaultStyle.ForeColor = Color.FromArgb(40, 40, 40);
            defaultStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            defaultStyle.SelectionBackColor = Color.FromArgb(205, 223, 237); // Màu xanh nhạt khi được chọn
            defaultStyle.SelectionForeColor = Color.FromArgb(16, 106, 177);
            dgv.DefaultCellStyle = defaultStyle;

            // 4. Định dạng các dòng xen kẽ (Dòng chẵn) - Tạo hiệu ứng dễ đọc
            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = Color.FromArgb(240, 244, 248); // Màu xám xanh cực nhẹ
            alternatingStyle.ForeColor = Color.FromArgb(40, 40, 40);
            alternatingStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            alternatingStyle.SelectionBackColor = Color.FromArgb(205, 223, 237);
            alternatingStyle.SelectionForeColor = Color.FromArgb(16, 106, 177);
            dgv.AlternatingRowsDefaultCellStyle = alternatingStyle;

            // 5. Tăng chiều cao các dòng để dữ liệu "thở" được, không bị dính chặt vào nhau
            dgv.RowTemplate.Height = 32;
        }
        // 1. Hàm định dạng riêng cho từng nút bấm đơn lẻ
        public static void FormatButton(Button btn, bool isDanger = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; // Bỏ đường viền đen thô mặc định
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; // Đổi con trỏ chuột thành hình bàn tay khi rê vào
            btn.Height = 35; // Chiều cao tiêu chuẩn cho nút bấm hiện đại

            if (isDanger)
            {
                // Định dạng cho các nút có tính rủi ro (Xóa, Đăng xuất, Hủy)
                btn.BackColor = Color.FromArgb(217, 83, 79); // Màu đỏ Coral sáng, dịu mắt
                btn.ForeColor = Color.White;
            }
            else
            {
                // Định dạng cho các nút thông thường (Thêm, Sửa, Lưu, Tìm kiếm, Làm mới)
                btn.BackColor = Color.FromArgb(16, 106, 177); // Màu xanh Deep Blue đồng bộ thương hiệu
                btn.ForeColor = Color.White;
            }

            // Tạo hiệu ứng đổi màu nhẹ khi di chuột vào (Hover) giúp tăng trải nghiệm UI
            btn.MouseEnter += (s, e) => {
                btn.BackColor = isDanger ? Color.FromArgb(201, 48, 44) : Color.FromArgb(12, 84, 142);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = isDanger ? Color.FromArgb(217, 83, 79) : Color.FromArgb(16, 106, 177);
            };
        }

        // 2. Hàm tự động quét và đồng bộ TOÀN BỘ nút bấm có trên một Form hoặc một Panel
        public static void SyncAllButtons(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                // Nếu là Button thì tiến hành định dạng màu sắc
                if (ctrl is Button btn)
                {
                    // Kiểm tra tên nút để phân loại màu (nút Xóa/Đăng xuất/Hủy sẽ có màu đỏ, còn lại màu xanh)
                    string name = btn.Name.ToLower();
                    if (name.Contains("delete") || name.Contains("xoa") ||
                        name.Contains("logout") || name.Contains("dangxuat") ||
                        name.Contains("cancel") || name.Contains("huy"))
                    {
                        FormatButton(btn, isDanger: true);
                    }
                    else
                    {
                        FormatButton(btn, isDanger: false);
                    }
                }

                // Đệ quy: Nếu nút bấm nằm sâu bên trong GroupBox hoặc Panel khác, tiếp tục quét
                if (ctrl.HasChildren)
                {
                    SyncAllButtons(ctrl);
                }
            }
        }
    }
}

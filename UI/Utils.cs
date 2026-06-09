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
                    builder.Append(bytes[i].ToString("x2")); 
                }
                return builder.ToString();
            }
        }
        public static void FormatDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false; 
            dgv.BackgroundColor = Color.FromArgb(245, 248, 251); 
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 230, 242); 
            dgv.RowHeadersVisible = false; 
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgv.MultiSelect = true;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(16, 106, 177); 
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            defaultStyle.BackColor = Color.White;
            defaultStyle.ForeColor = Color.FromArgb(40, 40, 40);
            defaultStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            defaultStyle.SelectionBackColor = Color.FromArgb(205, 223, 237); 
            defaultStyle.SelectionForeColor = Color.FromArgb(16, 106, 177);
            dgv.DefaultCellStyle = defaultStyle;

            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = Color.FromArgb(240, 244, 248); 
            alternatingStyle.ForeColor = Color.FromArgb(40, 40, 40);
            alternatingStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            alternatingStyle.SelectionBackColor = Color.FromArgb(205, 223, 237);
            alternatingStyle.SelectionForeColor = Color.FromArgb(16, 106, 177);
            dgv.AlternatingRowsDefaultCellStyle = alternatingStyle;

            dgv.RowTemplate.Height = 32;
        }

        public static void FormatCongVanDiGrid(DataGridView dgv)
        {
            FormatDataGridView(dgv);

            dgv.DataBindingComplete -= DgvCongVanDi_DataBindingComplete;
            dgv.DataBindingComplete += DgvCongVanDi_DataBindingComplete;
        }

        private static void DgvCongVanDi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            if (dgv.Columns["SoVanBan"] != null)
            {
                dgv.Columns["SoVanBan"].Visible = true;
                dgv.Columns["SoVanBan"].HeaderText = "Số văn bản";
                dgv.Columns["SoVanBan"].DisplayIndex = 0;
            }
            
            if (dgv.Columns["TrichYeu"] != null)
            {
                dgv.Columns["TrichYeu"].Visible = true;
                dgv.Columns["TrichYeu"].HeaderText = "Nội dung trích yếu";
                dgv.Columns["TrichYeu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["TrichYeu"].DisplayIndex = 1;
            }
            
            if (dgv.Columns["DoKhan"] != null)
            {
                dgv.Columns["DoKhan"].Visible = true;
                dgv.Columns["DoKhan"].HeaderText = "Độ khẩn";
                dgv.Columns["DoKhan"].DisplayIndex = 2;
            }
            
            if (dgv.Columns["NguoiKy"] != null)
            {
                dgv.Columns["NguoiKy"].Visible = true;
                dgv.Columns["NguoiKy"].HeaderText = "Người ký";
                dgv.Columns["NguoiKy"].DisplayIndex = 3;
            }
        }

        public static void FormatButton(Button btn, bool isDanger = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; 
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; 
            btn.Height = 35; 

            if (isDanger)
            {
                btn.BackColor = Color.FromArgb(217, 83, 79); 
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.FromArgb(16, 106, 177); 
                btn.ForeColor = Color.White;
            }

            btn.MouseEnter += (s, e) => {
                btn.BackColor = isDanger ? Color.FromArgb(201, 48, 44) : Color.FromArgb(12, 84, 142);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = isDanger ? Color.FromArgb(217, 83, 79) : Color.FromArgb(16, 106, 177);
            };
        }

        public static void SyncAllButtons(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Button btn)
                {
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

                if (ctrl.HasChildren)
                {
                    SyncAllButtons(ctrl);
                }
            }
        }
    }
}

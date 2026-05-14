using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class formQuanLyUser : Form
    {
        private bool _isAdding;

        public formQuanLyUser()
        {
            InitializeComponent();
        }

        private void formQuanLyUser_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            LoadSearchCombo();
            LoadPhongBan();
            // Load users into the grid when the form loads
            LoadUsers();
            ResetState();
        }

        private void ResetState()
        {
            _isAdding = false;
            txtManguoidung.Enabled = true;
        }
        private void LoadSearchCombo()
        {
            cbSearch.DataSource = null;

            var list = new[]
            {
        new { Text = "Mã người dùng", Value = "nd.MaNguoiDung" },
        new { Text = "Tên người dùng", Value = "nd.TenNguoiDung" },
        new { Text = "Tên đăng nhập", Value = "nd.TenDangNhap" },
        new { Text = "Email", Value = "nd.Email" },
        new { Text = "Quyền", Value = "nd.Quyen" },
        new { Text = "SĐT", Value = "nd.SDT" },
        new { Text = "Phòng ban", Value = "pb.TenPhongBan" }
    };

            cbSearch.DataSource = list;
            cbSearch.DisplayMember = "Text";
            cbSearch.ValueMember = "Value";
            cbSearch.SelectedIndex = -1;
        }
        private void LoadPhongBan()
        {
            var dt = PhongBanBLL.Instance.GetAll();

            cbPhongBan.DataSource = null;
            cbPhongBan.DataSource = dt;
            cbPhongBan.DisplayMember = "TenPhongBan";
            cbPhongBan.ValueMember = "MaPhongBan";

            cbPhongBan.SelectedIndex = -1;
        }

        private void LoadUsers()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.DataSource = UserService.Instance.GetAllUsers();
        }

        private void ClearInputs()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox) ((TextBox)c).Clear();
            }

            cbQuyen.SelectedIndex = -1;
            cbPhongBan.SelectedIndex = -1;
        }

        private User GetUserFromForm()
        {
            return new User
            {
                MaNguoiDung = txtManguoidung.Text.Trim(),
                TenNguoiDung = txtfullname.Text.Trim(),
                TenDangNhap = txtUsername.Text.Trim(),
                MatKhau = txtPassword.Text.Trim(),

                // 👉 lấy trực tiếp từ combobox
                Quyen = cbQuyen.SelectedItem?.ToString(),

                MaPhongBan = cbPhongBan.SelectedValue?.ToString(),

                SDT = txtSdt.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }

        // ================= EVENT =================

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvTaiKhoan.Rows[e.RowIndex];
            PopulateFormFromRow(r);
        }

        private void PopulateFormFromRow(DataGridViewRow r)
        {
            if (r == null) return;

            txtManguoidung.Text = r.Cells["colMaNguoiDung"].Value?.ToString();
            txtfullname.Text = r.Cells["colTenNguoiDung"].Value?.ToString();
            txtUsername.Text = r.Cells["colTenDangNhap"].Value?.ToString();
            //txtPassword.Text = r.Cells["colMatKhau"].Value?.ToString();

            cbQuyen.SelectedItem = r.Cells["colQuyen"].Value?.ToString();

            cbPhongBan.SelectedItem = r.Cells["colTenPhongBan"].Value?.ToString();

            txtSdt.Text = r.Cells["colSDT"].Value?.ToString();
            txtEmail.Text = r.Cells["colEmail"].Value?.ToString();

            // When editing, lock the id field and mark as editing mode
            txtManguoidung.Enabled = false;
            _isAdding = false;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            ClearInputs();
            txtManguoidung.Enabled = true;
            txtManguoidung.Focus();
            LoadUsers();
            ResetState();
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Populate the form from the currently selected row so user can edit
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Chọn người dùng cần sửa");
                return;
            }

            PopulateFormFromRow(dgvTaiKhoan.CurrentRow);

            // Ensure we're in update mode
            _isAdding = false;
            LoadUsers();
            ResetState();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string id = null;

            if (dgvTaiKhoan.CurrentRow != null)
            {
                var row = dgvTaiKhoan.CurrentRow;

                foreach (DataGridViewColumn col in dgvTaiKhoan.Columns)
                {
                    if (col.DataPropertyName == "MaNguoiDung" || col.Name == "colMaNguoiDung" || col.Name == "MaNguoiDung")
                    {
                        id = row.Cells[col.Index].Value?.ToString()?.Trim();
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(id)) return;

            if (MessageBox.Show("Xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserService.Instance.DeleteUser(id);

                var col = cbSearch.SelectedValue?.ToString();
                var text = txtSearch.Text.Trim();

                if (!string.IsNullOrEmpty(col) && !string.IsNullOrEmpty(text))
                {
                    dgvTaiKhoan.DataSource = UserService.Instance.SearchUsers(col, text);
                }
                else
                {
                    dgvTaiKhoan.DataSource = null;
                }

                ClearInputs();
                LoadUsers();
                ResetState();
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var user = GetUserFromForm();

            // ===== VALIDATE =====
            if (string.IsNullOrEmpty(user.MaNguoiDung))
            {
                MessageBox.Show("Thiếu mã người dùng");
                return;
            }

            if (string.IsNullOrEmpty(user.Quyen))
            {
                MessageBox.Show("Chưa chọn quyền");
                return;
            }

            if (cbPhongBan.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn phòng ban");
                return;
            }

            // ===== SAVE =====
            if (_isAdding)
                UserService.Instance.AddUser(user);
            else
                UserService.Instance.UpdateUser(user);

            LoadUsers();
            ClearInputs();
            LoadUsers();
            ResetState();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ResetState();
            ClearInputs();
            LoadUsers();
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            var col = cbSearch.SelectedValue?.ToString();
            var text = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(col))
            {
                MessageBox.Show("Chọn thuộc tính tìm kiếm");
                return;
            }

            if (string.IsNullOrEmpty(text))
            {
                LoadUsers();
                return;
            }

            dgvTaiKhoan.DataSource =
                UserService.Instance.SearchUsers(col, text);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadUsers();
        }
    }
}
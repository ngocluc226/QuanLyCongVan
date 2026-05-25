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
            InitDataGridView();
            Utils.FormatDataGridView(dgvTaiKhoan);
            Utils.SyncAllButtons(this);
            LoadSearchCombo();
            LoadPhongBan();
            LoadUsers();
            ResetState();
        }
        private void InitDataGridView()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.AllowUserToAddRows = false;

            // 1. Mã người dùng
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colMaNguoiDung", HeaderText = "Mã số", DataPropertyName = "MaNguoiDung", Width = 90 });

            // 2. Tên người dùng
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colTenNguoiDung", HeaderText = "Họ và tên", DataPropertyName = "TenNguoiDung", Width = 150 });

            // 3. Tên đăng nhập
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colTenDangNhap", HeaderText = "Tài khoản", DataPropertyName = "TenDangNhap", Width = 110 });

            // 4. Quyền
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colQuyen", HeaderText = "Quyền hạn", DataPropertyName = "Quyen", Width = 110 });

            // 5. Số điện thoại
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colSDT", HeaderText = "Số ĐT", DataPropertyName = "SDT", Width = 100 });

            // 6. Email
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colEmail", HeaderText = "Email", DataPropertyName = "Email", Width = 160 });

            // 7. Tên phòng ban trực thuộc (Kéo giãn phủ lưới)
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colTenPhongBan",
                HeaderText = "Phòng ban",
                DataPropertyName = "TenPhongBan",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 8. CỘT THÊM MỚI (ẨN): Mã phòng ban phục vụ logic đổ ngược dữ liệu khi click Sửa
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMaPhongBan",
                DataPropertyName = "MaPhongBan",
                Visible = false
            });
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
            string rawPassword = txtPassword.Text.Trim();
            string hashedPassword = "";

            // Nếu đang thêm mới, hoặc người dùng có nhập mật khẩu mới vào ô TextBox thì tiến hành băm
            if (!string.IsNullOrEmpty(rawPassword))
            {
                hashedPassword = Utils.HashSHA256(rawPassword);
            }
            return new User
            {
                MaNguoiDung = txtManguoidung.Text.Trim(),
                TenNguoiDung = txtfullname.Text.Trim(),
                TenDangNhap = txtUsername.Text.Trim(),
                MatKhau = hashedPassword,

                Quyen = cbQuyen.SelectedItem?.ToString(),
                MaPhongBan = cbPhongBan.SelectedValue?.ToString(),
                SDT = txtSdt.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }

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

            if (r.Cells["colMaPhongBan"] != null && r.Cells["colMaPhongBan"].Value != DBNull.Value)
            {
                cbPhongBan.SelectedValue = r.Cells["colMaPhongBan"].Value?.ToString();
            }
            else
            {
               cbPhongBan.SelectedIndex = cbPhongBan.FindStringExact(r.Cells["colTenPhongBan"].Value?.ToString());
            }

            string quyenText = r.Cells["colQuyen"].Value?.ToString();
            cbQuyen.SelectedIndex = cbQuyen.FindStringExact(quyenText);

            txtSdt.Text = r.Cells["colSDT"].Value?.ToString();
            txtEmail.Text = r.Cells["colEmail"].Value?.ToString();

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
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Chọn người dùng cần sửa");
                return;
            }

            PopulateFormFromRow(dgvTaiKhoan.CurrentRow);

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


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadUsers();
        }
    }
}
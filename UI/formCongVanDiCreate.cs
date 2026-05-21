using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class formCongVanDiCreate : Form
    {
        private CongVanDi _cvEdit = null;

        public formCongVanDiCreate() : this(null)
        {
        }

        public formCongVanDiCreate(CongVanDi cv)
        {
            InitializeComponent();
            _cvEdit = cv;
            if (cv != null && cv.Id > 0) this.Tag = cv.Id;

            // Gán sự kiện cho các nút điều khiển
            this.Load += new System.EventHandler(this.formCongVanDiCreate_Load);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            this.btnMoFile.Click += new System.EventHandler(this.btnMoFile_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        private void formCongVanDiCreate_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu cboCongVanDen
            DataTable dtCVDen = CongVanDenBLL.Instance.GetAll();
            DataTable dtCVDenClone = dtCVDen.Clone();
            
            // Bỏ ràng buộc NotNull cho DataTable clone dùng để binding lên giao diện
            foreach (DataColumn col in dtCVDenClone.Columns)
            {
                col.AllowDBNull = true;
            }
            
            dtCVDenClone.Rows.Add(dtCVDenClone.NewRow()); // Dòng trống đầu tiên
            foreach (DataRow r in dtCVDen.Rows) dtCVDenClone.ImportRow(r);
            
            cboCongVanDen.DataSource = dtCVDenClone;
            cboCongVanDen.ValueMember = "Id";
            cboCongVanDen.DisplayMember = "TrichYeu";
            cboCongVanDen.SelectedIndex = 0; // Trống thay vì chọn dòng đầu tiên

            // Kiểm tra Role để tối ưu hóa UI
            bool isNhanVien = (Session.CurrentUser != null && Session.CurrentUser.Quyen == "NhanVien");

            if (isNhanVien)
            {
                txtSoDi.Text = CongVanDiBLL.Instance.GenerateSoDi();
                txtSoDi.Enabled = false;

                // Cấu hình giao diện cho Nhân viên lập dự thảo
                label1.Text = "DỰ THẢO CÔNG VĂN ĐI";
                txtSoVanBan.Enabled = false;
                dtpNgayBanHanh.Enabled = false;
                cbTrangThai.Enabled = false;
                
                // Ẩn phần tìm kiếm và Grid bên dưới vì NV chỉ tập trung vào Form
                txtSearch.Visible = false;
                cbSearch.Visible = false;
                btnSearch.Visible = false;
                label52.Visible = false;
                
                // Đổ dữ liệu nếu ở chế độ Sửa
                if (_cvEdit != null)
                {
                    txtSoDi.Text = _cvEdit.SoDi;
                    dtpNgayDi.Value = _cvEdit.NgayDi;
                    cbNoiNhan.Text = _cvEdit.NoiNhan;
                    txtNguoiKy.Text = _cvEdit.NguoiKy;
                    txtTrichYeu.Text = _cvEdit.TrichYeu;
                    cbDoKhan.Text = _cvEdit.DoKhan;
                    cbDoMat.Text = _cvEdit.DoMat;
                    txtFile.Text = _cvEdit.FileDinhKem;
                    
                    if (_cvEdit.LienKetCongVanDenId.HasValue)
                        cboCongVanDen.SelectedValue = _cvEdit.LienKetCongVanDenId.Value;
                }
            }
            else
            {
                // Vai trò Văn Thư: Cần load Grid danh sách chờ ban hành
                // Mở khóa cho Văn thư tự nhập số đi và số văn bản bằng tay (không tự tăng)
                txtSoDi.Enabled = true;
                txtSoVanBan.Enabled = true;
                txtSoDi.Text = ""; // Để trống cho Văn thư tự nhập
                
                LoadData();

                dgvChoBanHanh.Visible = true;
                dgvChoBanHanh.CellClick += (s, ev) => {
                    if (dgvChoBanHanh.SelectedRows.Count > 0)
                    {
                        var row = dgvChoBanHanh.SelectedRows[0];
                        txtSoDi.Text = row.Cells["SoDi"].Value?.ToString();
                        txtSoVanBan.Text = row.Cells["SoVanBan"].Value?.ToString();
                        txtTrichYeu.Text = row.Cells["TrichYeu"].Value?.ToString();
                        txtNguoiKy.Text = row.Cells["NguoiKy"].Value?.ToString();
                        cbNoiNhan.Text = row.Cells["NoiNhan"].Value?.ToString();
                        cbDoKhan.Text = row.Cells["DoKhan"].Value?.ToString();
                        cbDoMat.Text = row.Cells["DoMat"].Value?.ToString();
                        txtFile.Text = row.Cells["FileDinhKem"].Value?.ToString();
                        dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);

                        // Load liên kết công văn đến nếu có
                        if (row.Cells["LienKetCongVanDenId"] != null && row.Cells["LienKetCongVanDenId"].Value != DBNull.Value)
                        {
                            cboCongVanDen.SelectedValue = Convert.ToInt32(row.Cells["LienKetCongVanDenId"].Value);
                        }
                        else
                        {
                            cboCongVanDen.SelectedIndex = 0;
                        }

                        // Lưu Id vào tag
                        this.Tag = row.Cells["Id"].Value;
                    }
                };
                
                // Cập nhật datasource ban đầu cho dgv vừa thêm
                dgvChoBanHanh.DataSource = CongVanDiBLL.Instance.GetByTrangThai(DTO.TrangThaiCongVanDi.CHO_BAN_HANH);
            }
        }

        private void LoadData()
        {
            if (dgvChoBanHanh != null)
            {
                dgvChoBanHanh.DataSource = CongVanDiBLL.Instance.GetByTrangThai(DTO.TrangThaiCongVanDi.CHO_BAN_HANH);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNhanVien = (Session.CurrentUser != null && Session.CurrentUser.Quyen == "NhanVien");

            // 1. Validate
            if (string.IsNullOrWhiteSpace(txtSoDi.Text))
            {
                MessageBox.Show("Vui lòng nhập Số đi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDi.Focus();
                return;
            }

            // Nếu không phải Nhân viên (tức là Văn thư), bắt buộc có Số văn bản khi ban hành
            if (!isNhanVien && string.IsNullOrWhiteSpace(txtSoVanBan.Text))
            {
                MessageBox.Show("Vui lòng nhập Số văn bản khi ban hành", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoVanBan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNguoiKy.Text))
            {
                MessageBox.Show("Vui lòng nhập Người ký", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiKy.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cbNoiNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Nơi nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbNoiNhan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTrichYeu.Text))
            {
                MessageBox.Show("Vui lòng nhập Trích yếu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrichYeu.Focus();
                return;
            }

            // Định vị trạng thái và dữ liệu theo quyền
            string targetTrangThai = isNhanVien ? DTO.TrangThaiCongVanDi.DU_THAO : DTO.TrangThaiCongVanDi.DA_BAN_HANH;
            
            int? lienKetId = null;
            // Bỏ qua dòng trắng mặc định (SelectedIndex == 0)
            if (cboCongVanDen.SelectedIndex > 0 && cboCongVanDen.SelectedValue != null && cboCongVanDen.SelectedValue != DBNull.Value)
            {
                if (int.TryParse(cboCongVanDen.SelectedValue.ToString(), out int parsedId) && parsedId > 0)
                {
                    lienKetId = parsedId;
                }
            }

            // 2. Cập nhật hoặc Thêm
            if (this.Tag != null) // Sửa dự thảo hoặc Cập nhật ban hành
            {
                int id = Convert.ToInt32(this.Tag);
                CongVanDi cv = new CongVanDi()
                {
                    Id = id,
                    SoDi = txtSoDi.Text.Trim(), 
                    SoVanBan = isNhanVien ? null : txtSoVanBan.Text.Trim(),
                    NgayDi = dtpNgayDi.Value,
                    NgayBanHanh = isNhanVien ? (DateTime?)null : dtpNgayBanHanh.Value,
                    NoiNhan = cbNoiNhan.Text,
                    NguoiKy = txtNguoiKy.Text.Trim(),
                    TrichYeu = txtTrichYeu.Text.Trim(),
                    DoKhan = cbDoKhan.Text,
                    DoMat = cbDoMat.Text,
                    FileDinhKem = txtFile.Text,
                    TrangThai = targetTrangThai,
                    LienKetCongVanDenId = lienKetId
                };

                bool result = CongVanDiBLL.Instance.Update(cv);
                if (result)
                {
                    if (!isNhanVien)
                    {
                        CongVanDiBLL.Instance.ChuyenTrangThai(id, DTO.TrangThaiCongVanDi.DA_BAN_HANH, "Văn thư cấp số, ban hành");
                        MessageBox.Show("Ban hành công văn đi thành công!");
                        ClearForm();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thay đổi dự thảo thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close(); // Đóng form khi lưu xong ở chế độ Dialog
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra khi lưu!");
                }
            }
            else // Thêm mới
            {
                CongVanDi cv = new CongVanDi()
                {
                    SoDi = txtSoDi.Text.Trim(), 
                    SoVanBan = isNhanVien ? null : txtSoVanBan.Text.Trim(),
                    NgayDi = dtpNgayDi.Value,
                    NgayBanHanh = isNhanVien ? (DateTime?)null : dtpNgayBanHanh.Value,
                    NoiNhan = cbNoiNhan.Text,
                    NguoiKy = txtNguoiKy.Text.Trim(),
                    TrichYeu = txtTrichYeu.Text.Trim(),
                    DoKhan = cbDoKhan.Text,
                    DoMat = cbDoMat.Text,
                    FileDinhKem = txtFile.Text,
                    TrangThai = targetTrangThai,
                    LienKetCongVanDenId = lienKetId
                };

                bool result = CongVanDiBLL.Instance.Insert(cv);

                if (result)
                {
                    MessageBox.Show(isNhanVien ? "Lưu dự thảo thành công!" : "Thêm công văn đi thành công!");
                    if (isNhanVien)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ClearForm();   
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }

        private void ClearForm()
        {
            txtSoVanBan.Clear();
            txtNguoiKy.Clear();
            txtTrichYeu.Clear();
            txtFile.Clear();

            cbNoiNhan.Text = "";
            cbDoKhan.SelectedIndex = -1;
            cbDoMat.SelectedIndex = -1;

            dtpNgayDi.Value = DateTime.Now;
            dtpNgayBanHanh.Value = DateTime.Now;

            // Generate số đi tiếp theo
            txtSoDi.Text = CongVanDiBLL.Instance.GenerateSoDi();
            txtSoVanBan.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn file công văn";
            ofd.Filter = "Tất cả file (*.*)|*.*|PDF (*.pdf)|*.pdf|Word (*.doc;*.docx)|*.doc;*.docx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = ofd.FileName;

                // Thư mục lưu file trong project
                string folderPath = Path.Combine(Application.StartupPath, "Files");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Tạo tên file tránh trùng
                string fileName = DateTime.Now.Ticks + "_" + Path.GetFileName(sourcePath);
                string destPath = Path.Combine(folderPath, fileName);

                // Copy file
                File.Copy(sourcePath, destPath, true);

                // Gán vào textbox (lưu DB)
                txtFile.Text = destPath;
            }
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFile.Text))
            {
                System.Diagnostics.Process.Start(txtFile.Text);
            }
            else
            {
                MessageBox.Show("File không tồn tại hoặc chưa được lưu!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}

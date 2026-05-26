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

            txtSoDi.Text = CongVanDiBLL.Instance.GenerateSoDi();
            txtSoDi.Enabled = false;

            label1.Text = "DỰ THẢO CÔNG VĂN ĐI";
            txtSoVanBan.Enabled = false;
            dtpNgayBanHanh.Enabled = false;
            cbTrangThai.Enabled = false;
            
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

        private void LoadData()
        {
            // Do nothing as dgvChoBanHanh does not exist in this form
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

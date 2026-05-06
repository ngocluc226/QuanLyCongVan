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
        private ComboBox cbNguoiDuyet;
        private Label lblNguoiDuyet;
        private Button btnGuiDuyet;

        public formCongVanDiCreate()
        {
            InitializeComponent();

            InitializeApprovalControls();

            // Gán sự kiện cho các nút điều khiển
            this.Load += new System.EventHandler(this.formCongVanDiCreate_Load);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            this.btnMoFile.Click += new System.EventHandler(this.btnMoFile_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        private void InitializeApprovalControls()
        {
            this.lblNguoiDuyet = new Label();
            this.lblNguoiDuyet.Text = "Người phê duyệt:";
            this.lblNguoiDuyet.Location = new Point(btnAdd.Location.X - 250, btnAdd.Location.Y - 40); // Tạm đặt vị trí tương đối
            this.lblNguoiDuyet.AutoSize = true;

            this.cbNguoiDuyet = new ComboBox();
            this.cbNguoiDuyet.Location = new Point(this.lblNguoiDuyet.Location.X + 120, this.lblNguoiDuyet.Location.Y - 3);
            this.cbNguoiDuyet.Width = 150;
            this.cbNguoiDuyet.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnGuiDuyet = new Button();
            this.btnGuiDuyet.Text = "Gửi duyệt";
            this.btnGuiDuyet.Location = new Point(this.cbNguoiDuyet.Location.X + 160, this.cbNguoiDuyet.Location.Y - 2);
            this.btnGuiDuyet.Click += BtnGuiDuyet_Click;

            // Them vao form
            this.dtgvvbdi.Controls.Add(lblNguoiDuyet);
            this.dtgvvbdi.Controls.Add(cbNguoiDuyet);
            this.dtgvvbdi.Controls.Add(btnGuiDuyet);
        }

        private void loadDanhSachLanhDao()
        {
            DataTable dt = UserService.Instance.GetDanhSachLanhDao();
            cbNguoiDuyet.DataSource = dt;
            cbNguoiDuyet.DisplayMember = "TenNguoiDung";
            cbNguoiDuyet.ValueMember = "MaNguoiDung";
            cbNguoiDuyet.SelectedIndex = -1;
        }

        private void formCongVanDiCreate_Load(object sender, EventArgs e)
        {
            txtSoDi.Text = CongVanDiBLL.Instance.GenerateSoDi();
            txtSoDi.Enabled = false;
            loadDanhSachLanhDao();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (string.IsNullOrWhiteSpace(txtSoDi.Text))
            {
                MessageBox.Show("Vui lòng nhập Số đi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoVanBan.Text))
            {
                MessageBox.Show("Vui lòng nhập Số văn bản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (string.IsNullOrWhiteSpace(txtFile.Text))
            {
                MessageBox.Show("Vui lòng chọn File đính kèm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChonFile.Focus();
                return;
            }

            // 2. Tạo DTO
            CongVanDi cv = new CongVanDi()
            {
                SoDi = txtSoDi.Text.Trim(), 
                SoVanBan = txtSoVanBan.Text.Trim(),
                NgayDi = dtpNgayDi.Value,
                NgayBanHanh = dtpNgayBanHanh.Value,
                NoiNhan = cbNoiNhan.Text,
                NguoiKy = txtNguoiKy.Text.Trim(),
                TrichYeu = txtTrichYeu.Text.Trim(),
                DoKhan = cbDoKhan.Text,
                DoMat = cbDoMat.Text,
                FileDinhKem = txtFile.Text,
                TrangThai = "Soạn thảo"
            };

            // 3. Gọi BLL
            bool result = CongVanDiBLL.Instance.Insert(cv);

            // 4. Kết quả
            if (result)
            {
                MessageBox.Show("Thêm công văn đi thành công!");
                ClearForm();   // reset form để nhập tiếp
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
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

        private void BtnGuiDuyet_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường
            if (string.IsNullOrWhiteSpace(txtSoDi.Text)) return;
            if (cbNguoiDuyet.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người lãnh đạo để gửi duyệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi insert (nếu mới) hoặc update. Ở đây giả sử form này lúc lưu chỉ tạo mới, nên ta tạo mới với trạng thái Chờ duyệt.
            // Nếu cv đã lưu rồi (nằm ở DB) thì update. Ta sẽ insert luôn.
            CongVanDi cv = new CongVanDi()
            {
                SoDi = txtSoDi.Text.Trim(),
                SoVanBan = txtSoVanBan.Text.Trim(),
                NgayDi = dtpNgayDi.Value,
                NgayBanHanh = dtpNgayBanHanh.Value,
                NoiNhan = cbNoiNhan.Text,
                NguoiKy = txtNguoiKy.Text.Trim(),
                TrichYeu = txtTrichYeu.Text.Trim(),
                DoKhan = cbDoKhan.Text,
                DoMat = cbDoMat.Text,
                FileDinhKem = txtFile.Text,
                TrangThai = "Chờ duyệt",
                NguoiDuyetId = cbNguoiDuyet.SelectedValue.ToString()
            };

            bool result = CongVanDiBLL.Instance.Insert(cv);
            if (result)
            {
                MessageBox.Show("Đã gửi duyệt thành công!");
                // (Bỏ qua gửi email lúc này)
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lỗi gửi duyệt!");
            }
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

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
        private int editingId = -1;

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

        public formCongVanDiCreate(int id) : this()
        {
            this.editingId = id;
            this.label1.Text = "CHỈNH SỬA CÔNG VĂN ĐI";
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
            
            // Load cho cbNguoiDuyet (giữ nguyên logic cũ)
            cbNguoiDuyet.DataSource = dt;
            cbNguoiDuyet.DisplayMember = "TenNguoiDung";
            cbNguoiDuyet.ValueMember = "MaNguoiDung";
            cbNguoiDuyet.SelectedIndex = -1;

            // Load cho cbNguoiKy (mới)
            // Tạo bản sao của DataTable để tránh xung đột DataSource nếu cần, 
            // hoặc gán thẳng nếu ComboBox không bị reset. 
            // Ở đây tôi dùng chung nhưng gán DisplayMember là TenNguoiDung.
            DataTable dt2 = dt.Copy();
            cbNguoiKy.DataSource = dt2;
            cbNguoiKy.DisplayMember = "TenNguoiDung";
            cbNguoiKy.ValueMember = "TenNguoiDung"; // Lưu tên vào NguoiKy thay vì ID
            cbNguoiKy.SelectedIndex = -1;
        }

        private void formCongVanDiCreate_Load(object sender, EventArgs e)
        {
            loadDanhSachLanhDao();
            
            if (editingId > 0)
            {
                DataTable dt = CongVanDiBLL.Instance.GetById(editingId);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtSoDi.Text = dr["SoDi"].ToString();
                    txtSoVanBan.Text = dr["SoVanBan"]?.ToString();
                    dtpNgayDi.Value = Convert.ToDateTime(dr["NgayDi"]);
                    if (dr["NgayBanHanh"] != DBNull.Value) dtpNgayBanHanh.Value = Convert.ToDateTime(dr["NgayBanHanh"]);
                    cbNoiNhan.Text = dr["NoiNhan"]?.ToString();
                    cbNguoiKy.Text = dr["NguoiKy"]?.ToString();
                    txtTrichYeu.Text = dr["TrichYeu"]?.ToString();
                    cbDoKhan.Text = dr["DoKhan"]?.ToString();
                    cbDoMat.Text = dr["DoMat"]?.ToString();
                    txtFile.Text = dr["FileDinhKem"]?.ToString();
                    cbNguoiDuyet.SelectedValue = dr["NguoiDuyetId"]?.ToString();
                }
            }
            else
            {
                txtSoDi.Text = CongVanDiBLL.Instance.GenerateSoDi();
            }
            txtSoDi.Enabled = false;
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

            if (string.IsNullOrWhiteSpace(cbNguoiKy.Text))
            {
                MessageBox.Show("Vui lòng chọn Người ký", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbNguoiKy.Focus();
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
                Id = editingId,
                SoDi = txtSoDi.Text.Trim(), 
                SoVanBan = txtSoVanBan.Text.Trim(),
                NgayDi = dtpNgayDi.Value,
                NgayBanHanh = dtpNgayBanHanh.Value,
                NoiNhan = cbNoiNhan.Text,
                NguoiKy = cbNguoiKy.Text.Trim(),
                TrichYeu = txtTrichYeu.Text.Trim(),
                DoKhan = cbDoKhan.Text,
                DoMat = cbDoMat.Text,
                FileDinhKem = txtFile.Text,
                TrangThai = "Soạn thảo",
                NguoiDuyetId = cbNguoiDuyet.SelectedValue?.ToString()
            };

            // 3. Gọi BLL
            bool result;
            if (editingId > 0)
                result = CongVanDiBLL.Instance.Update(cv);
            else
                result = CongVanDiBLL.Instance.Insert(cv);

            // 4. Kết quả
            if (result)
            {
                MessageBox.Show("Lưu công văn đi thành công!");
                if (editingId > 0) this.Close();
                else ClearForm();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }

        private void ClearForm()
        {
            txtSoVanBan.Clear();
            cbNguoiKy.SelectedIndex = -1;
            cbNguoiKy.Text = "";
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

            // Gọi insert (nếu mới) hoặc update.
            CongVanDi cv = new CongVanDi()
            {
                Id = editingId,
                SoDi = txtSoDi.Text.Trim(),
                SoVanBan = txtSoVanBan.Text.Trim(),
                NgayDi = dtpNgayDi.Value,
                NgayBanHanh = dtpNgayBanHanh.Value,
                NoiNhan = cbNoiNhan.Text,
                NguoiKy = cbNguoiKy.Text.Trim(),
                TrichYeu = txtTrichYeu.Text.Trim(),
                DoKhan = cbDoKhan.Text,
                DoMat = cbDoMat.Text,
                FileDinhKem = txtFile.Text,
                TrangThai = "Chờ duyệt",
                NguoiDuyetId = cbNguoiDuyet.SelectedValue.ToString()
            };

            bool result;
            if (editingId > 0)
                result = CongVanDiBLL.Instance.Update(cv);
            else
                result = CongVanDiBLL.Instance.Insert(cv);

            if (result)
            {
                MessageBox.Show("Đã gửi duyệt thành công!");
                
                // Gửi email tự động
                var leader = UserService.Instance.GetUserById(cv.NguoiDuyetId);
                if (leader != null && !string.IsNullOrWhiteSpace(leader.Email))
                {
                    EmailService.SendMailToLeader(leader.Email, cv.SoDi, cv.TrichYeu);
                }

                if (editingId > 0) this.Close();
                else ClearForm();
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

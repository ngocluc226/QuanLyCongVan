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

namespace UI
{
    public partial class formCongVanDenCreate : Form
    {
        public formCongVanDenCreate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (string.IsNullOrWhiteSpace(txtSoDen.Text))
            {
                MessageBox.Show("Vui lòng nhập Số đến", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDen.Focus();
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

            if (string.IsNullOrWhiteSpace(cbNoiGui.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Nơi gửi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbNoiGui.Focus();
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
            DTO.CongVanDen cv = new DTO.CongVanDen()
            {
                SoDen = txtSoDen.Text.Trim(),
                SoVanBan = txtSoVanBan.Text.Trim(),
                NgayDen = dtpNgayDen.Value,
                NgayBanHanh = dtpNgayBanHanh.Value,
                NoiGui = cbNoiGui.Text,
                NguoiKy = txtNguoiKy.Text.Trim(),
                TrichYeu = txtTrichYeu.Text.Trim(),
                DoKhan = cbDoKhan.Text,
                DoMat = cbDoMat.Text,
                FileDinhKem = txtFile.Text,
                TrangThai = "Chưa xử lý"
            };

            // 3. Gọi BLL
            bool result = BLL.CongVanDenBLL.Instance.Insert(cv);

            // 4. Kết quả
            if (result)
            {
                MessageBox.Show("Thêm công văn thành công!");

                ClearForm();   // reset form để nhập tiếp
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }
        private void ClearForm()
        {
            txtSoDen.Clear();
            txtSoVanBan.Clear();
            txtNguoiKy.Clear();
            txtTrichYeu.Clear();
            txtFile.Clear();

            cbNoiGui.Text = "";
            cbDoKhan.SelectedIndex = -1;
            cbDoMat.SelectedIndex = -1;

            dtpNgayDen.Value = DateTime.Now;
            dtpNgayBanHanh.Value = DateTime.Now;

            txtSoDen.Focus();
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

                // Tạo thư mục nếu chưa có
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
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void formCongVanDenCreate_Load(object sender, EventArgs e)
        {
            txtSoDen.Text = BLL.CongVanDenBLL.Instance.GenerateSoDen();
            txtSoDen.Enabled = false;
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

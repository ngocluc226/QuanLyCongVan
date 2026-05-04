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
        public formCongVanDiCreate()
        {
            InitializeComponent();

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
            txtSoDi.Text = CongVanDiBLL.Instance.GenerateSoDi();
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
                TrangThai = "Chưa xử lý"
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

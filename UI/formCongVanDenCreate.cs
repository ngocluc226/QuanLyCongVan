using BLL;
using DTO;
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
                TrangThai = "Mới nhập"
            };

            bool result = BLL.CongVanDenBLL.Instance.Insert(cv);

            if (result)
            {
                LogBLL.Instance.WriteLog("Thêm công văn", Session.UserName);
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

                string folderPath = Path.Combine(Application.StartupPath, "Files");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = DateTime.Now.Ticks + "_" + Path.GetFileName(sourcePath);
                string destPath = Path.Combine(folderPath, fileName);

                File.Copy(sourcePath, destPath, true);

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
            Utils.SyncAllButtons(this);

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class formNhanVienCVDi : Form
    {
        public formNhanVienCVDi()
        {
            InitializeComponent();
            
            // Đăng ký sự kiện
            this.Load += (s, e) => {
                dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                cbTrangThai.SelectedIndex = 0; // "Tất cả"
                LoadData();
            };

            btnTimKiem.Click += (s, e) => LoadData();
            btnThem.Click += (s, e) => {
                formCongVanDiCreate f = new formCongVanDiCreate();
                f.ShowDialog();
                LoadData();
            };
            btnSua.Click += (s, e) => SuaCongVan();
            btnXoa.Click += (s, e) => XoaCongVan();
            btnTrinh.Click += (s, e) => TrinhLanhDao();
            btnXemFile.Click += (s, e) => XemFile();
        }

        private void LoadData()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            string keyword = txtTimKiem.Text.Trim().ToLower();
            string selectedStatus = cbTrangThai.SelectedItem?.ToString();

            DataTable dt = CongVanDiBLL.Instance.GetByDateRange(tuNgay, denNgay);
            DataView dv = dt.DefaultView;
            
            string filter = "1=1"; // Mặc định luôn đúng
            
            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Tất cả")
            {
                filter += string.Format(" AND TrangThai = '{0}'", selectedStatus);
            }

            // Lọc theo từ khóa
            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (SoDi LIKE '%{0}%' OR SoVanBan LIKE '%{0}%' OR TrichYeu LIKE '%{0}%' OR NguoiKy LIKE '%{0}%')", keyword);
            }

            dv.RowFilter = filter;
            dgvCVDi.DataSource = dv.ToTable();

            if (dgvCVDi.Columns["Id"] != null) dgvCVDi.Columns["Id"].Visible = false;
            if (dgvCVDi.Columns["FileDinhKem"] != null) dgvCVDi.Columns["FileDinhKem"].Visible = false;
        }

        private void XemFile()
        {
            if (dgvCVDi.SelectedRows.Count == 0) return;
            string filePath = dgvCVDi.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại hoặc chưa được đính kèm!");
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở file: " + ex.Message);
            }
        }

        private void SuaCongVan()
        {
            if (dgvCVDi.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCVDi.SelectedRows[0].Cells["Id"].Value);
            string tt = dgvCVDi.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (tt == "Đã phát hành" || tt == "Đã duyệt")
            {
                MessageBox.Show("Không thể sửa công văn đã được duyệt hoặc phát hành!");
                return;
            }

            formCongVanDiCreate f = new formCongVanDiCreate(id);
            f.ShowDialog();
            LoadData();
        }

        private void XoaCongVan()
        {
            if (dgvCVDi.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCVDi.SelectedRows[0].Cells["Id"].Value);
            string tt = dgvCVDi.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (tt == "Đã phát hành" || tt == "Đã duyệt")
            {
                MessageBox.Show("Không thể xóa công văn đã được duyệt hoặc phát hành!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa công văn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CongVanDiBLL.Instance.Delete(id))
                {
                    MessageBox.Show("Đã xóa!");
                    LoadData();
                }
            }
        }

        private void TrinhLanhDao()
        {
            if (dgvCVDi.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvCVDi.SelectedRows[0];
            string trangThai = row.Cells["TrangThai"].Value?.ToString();
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            if (trangThai != "Soạn thảo" && trangThai != "Yêu cầu chỉnh sửa" && trangThai != "Bị từ chối")
            {
                MessageBox.Show("Chỉ có thể trình các công văn đang ở trạng thái 'Soạn thảo', 'Yêu cầu chỉnh sửa' hoặc 'Bị từ chối'!");
                return;
            }

            if (MessageBox.Show("Trình công văn này lên lãnh đạo?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CongVanDiBLL.Instance.UpdateTrangThai(id, "Chờ duyệt"))
                {
                    MessageBox.Show("Đã trình lãnh đạo thành công!");
                    
                    // Gửi email thông báo cho lãnh đạo
                    var dtCv = CongVanDiBLL.Instance.GetById(id);
                    if (dtCv.Rows.Count > 0)
                    {
                        string nDuyetId = dtCv.Rows[0]["NguoiDuyetId"]?.ToString();
                        string soDi = dtCv.Rows[0]["SoDi"]?.ToString();
                        string trichYeu = dtCv.Rows[0]["TrichYeu"]?.ToString();
                        
                        if (!string.IsNullOrEmpty(nDuyetId))
                        {
                            var leader = UserService.Instance.GetUserById(nDuyetId);
                            if (leader != null && !string.IsNullOrWhiteSpace(leader.Email))
                            {
                                EmailService.SendMailToLeader(leader.Email, soDi, trichYeu);
                            }
                        }
                    }

                    LoadData();
                }
            }
        }
    }
}

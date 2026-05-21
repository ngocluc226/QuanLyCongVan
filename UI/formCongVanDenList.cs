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
    public partial class formCongVanDenList : Form
    {
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;
        public formCongVanDenList()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // 1. Lấy dữ liệu trang hiện tại
            DataTable dt = BLL.CongVanDenBLL.Instance.GetPaged(currentPage, pageSize);
            dgvVanBan.DataSource = dt;

            // 2. Tính toán tổng số trang
            int totalRows = BLL.CongVanDenBLL.Instance.GetTotalCount();
            totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
            if (totalPages == 0) totalPages = 1;

            // 3. Hiển thị thông tin lên giao diện
            lblPageInfo.Text = $"{currentPage}/{totalPages}";
            lblTong.Text = "Tổng số dòng: " + totalRows.ToString();

            // 4. Trạng thái ẩn/hiện nút điều hướng
            btnPrev.Enabled = (currentPage > 1);
            btnNext.Enabled = (currentPage < totalPages);
        }
        private void InitDataGridView()
        {
            dgvVanBan.AutoGenerateColumns = false;
            dgvVanBan.Columns.Clear();

            // Cấu hình hành vi chọn dòng
            dgvVanBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVanBan.MultiSelect = true;
            dgvVanBan.AllowUserToAddRows = false;

            // 1. Cột Id (Ẩn danh sách nhưng giữ lại để lấy dữ liệu khi Xóa/Mở file)
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // 2. Cột Số đến
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoDen",
                HeaderText = "Số đến",
                DataPropertyName = "SoDen",
                Width = 80
            });

            // 3. Cột Số văn bản
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoVanBan",
                HeaderText = "Số văn bản",
                DataPropertyName = "SoVanBan",
                Width = 110
            });

            // 4. Cột Ngày đến (Định dạng ngày/tháng/năm)
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayDen",
                HeaderText = "Ngày đến",
                DataPropertyName = "NgayDen",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 100
            });

            // 5. Cột Ngày ban hành
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayBanHanh",
                HeaderText = "Ngày ban hành",
                DataPropertyName = "NgayBanHanh",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 110
            });

            // 6. Cột Nơi gửi
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NoiGui",
                HeaderText = "Nơi gửi",
                DataPropertyName = "NoiGui",
                Width = 130
            });

            // 7. Cột Người ký
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NguoiKy",
                HeaderText = "Người ký",
                DataPropertyName = "NguoiKy",
                Width = 120
            });

            // 8. Cột Trích yếu (Tự động kéo giãn chiếm hết khoảng trống)
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Trích yếu nội dung",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 9. Cột Độ khẩn
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoKhan",
                HeaderText = "Độ khẩn",
                DataPropertyName = "DoKhan",
                Width = 90
            });

            // 10. Cột Độ mật
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoMat",
                HeaderText = "Độ mật",
                DataPropertyName = "DoMat",
                Width = 90
            });

            // 11. Cột Trạng thái
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 120
            });

            // 12. Cột Tên File đính kèm (Ẩn đường dẫn thô, chỉ giữ để gọi hàm xem file)
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FileDinhKem",
                DataPropertyName = "FileDinhKem",
                Visible = false
            });
        }

        private void formCongVanDenList_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            Utils.FormatDataGridView(dgvVanBan);
            Utils.SyncAllButtons(this);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVanBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa các công văn đã chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No) return;

            int success = 0;

            foreach (DataGridViewRow row in dgvVanBan.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);

                if (BLL.CongVanDenBLL.Instance.Delete(id))
                {
                    success++;
                }
            }

            MessageBox.Show($"Đã xóa {success} công văn!");

            LoadData();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            // Fix lỗi mất dữ liệu trong ngày cuối
            toDate = toDate.AddDays(1).AddSeconds(-1);

            if (fromDate > toDate)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày!");
                return;
            }

            DataTable dt = BLL.CongVanDenBLL.Instance.GetByDateRange(fromDate, toDate);

            dgvVanBan.DataSource = dt;

            lblTong.Text = "Tổng: " + dt.Rows.Count.ToString();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvVanBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn!");
                return;
            }

            string path = dgvVanBan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Không có file!");
                return;
            }

            // Nếu bạn lưu relative path
            string fullPath = Path.Combine(Application.StartupPath, path);

            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }
    }
}

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
    public partial class formNhanVienCVDen : Form
    {
        public formNhanVienCVDen()
        {
            InitializeComponent();
            InitDataGridView();   
            InitDataGridDaXuLy();
            InitSearchCombo();

            Utils.FormatDataGridView(dgvCongVan);
            Utils.FormatDataGridView(dgvDaXuly);
            Utils.SyncAllButtons(this);

        }

        private void formNhanVienCVDen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanChoNhanVien(); // Việc đích danh mình
            dgvDaXuly.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanDaHoanThanhChoNhanVien(); // Việc mình làm xong
        }
        private void InitDataGridDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaXuly.AllowUserToAddRows = false;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung văn bản đã làm", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }
        private void InitDataGridView()
        {
            // 1. Tắt chế độ tự tạo cột lộn xộn từ CSDL
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();

            // 2. Cấu hình hành vi hiển thị và chọn dòng của bảng
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng khi click
            dgvCongVan.MultiSelect = false; // Chỉ cho chọn 1 công văn mỗi lần xử lý
            dgvCongVan.AllowUserToAddRows = false; // Ẩn dòng trống dưới cùng của bảng

            // 3. Cột Id (Ẩn đi, nhưng bắt buộc phải có để lấy Id công văn khi bấm Xử lý/Hoàn thành)
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // 4. Cột Số văn bản
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoVanBan",
                HeaderText = "Số văn bản",
                DataPropertyName = "SoVanBan",
                Width = 120
            });

            // 5. Cột Ngày đến (Định dạng ngày/tháng/năm gọn gàng)
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayDen",
                HeaderText = "Ngày đến",
                DataPropertyName = "NgayDen",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 100
            });

            // 6. Cột Nội dung văn bản (Tự động giãn rộng hết cỡ để dễ đọc trích yếu)
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Nội dung văn bản được giao",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 7. Cột Độ khẩn
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoKhan",
                HeaderText = "Độ khẩn",
                DataPropertyName = "DoKhan",
                Width = 100
            });

            // 8. Cột Trạng thái xử lý
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái xử lý",
                DataPropertyName = "TrangThai",
                Width = 140
            });

            // 9. Cột File đính kèm (Ẩn đường dẫn thô, giữ lại để bấm nút Mở file)
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FileDinhKem",
                DataPropertyName = "FileDinhKem",
                Visible = false
            });
        }
        private int GetSelectedId()
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
        }

        // THÊM MỚI/SỬA ĐỔI: Logic kiểm tra trạng thái để Ẩn/Hiện nút bấm
        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                btnXuLy.Enabled = false;
                btnHoanThanh.Enabled = false;
                return;
            }

            // Lấy ra trạng thái của dòng đang chọn
            string trangThai = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (trangThai == DTO.TrangThaiCongVanDen.DA_PHAN_CONG)
            {
                btnXuLy.Enabled = true;       // Cho phép bấm Xử lý
                btnHoanThanh.Enabled = false; // Khóa nút Hoàn thành
            }
            else if (trangThai == DTO.TrangThaiCongVanDen.DANG_XU_LY)
            {
                btnXuLy.Enabled = false;      // Khóa nút Xử lý (vì đang xử lý rồi)
                btnHoanThanh.Enabled = true;  // Cho phép bấm Hoàn thành
            }
            else
            {
                btnXuLy.Enabled = false;
                btnHoanThanh.Enabled = false;
            }
        }

        // SỬA ĐỔI: Nút Xử lý
        private void btnXuLy_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            // Chuyển trạng thái công văn sang ĐANG_XU_LY
            bool res = BLL.CongVanDenBLL.Instance.CapNhatXuLy(id, DTO.TrangThaiCongVanDen.DANG_XU_LY);

            if (res)
            {
                MessageBox.Show("Đã tiếp nhận công văn. Trạng thái hiện tại: Đang xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại lưới để cập nhật trạng thái mới và đổi màu chữ
            }
        }

        // SỬA ĐỔI: Nút Hoàn thành
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn đã hoàn thành mọi xử lý cho công văn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            // Chuyển trạng thái công văn sang HOAN_THANH
            bool res = BLL.CongVanDenBLL.Instance.HoanThanh(id);

            if (res)
            {
                MessageBox.Show("Chúc mừng! Đã hoàn thành và đóng công văn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Công văn này sẽ tự biến mất khỏi lưới vì hàm GetCongVanChoNhanVien loại bỏ trạng thái HOAN_THANH
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = "";

            // 1. Kiểm tra xem người dùng đang đứng ở Tab nào dựa vào thuộc tính SelectedTab
            // (Bạn nhớ kiểm tra xem tên Tab của bạn trên Designer đặt là gì nhé, ví dụ: tabChoXuLy và tabDaXuLy)
            if (tabControl1.SelectedTab == tabChoXuLy)
            {
                // Nếu ở Tab "Chờ xử lý" -> Lấy đường dẫn file từ lưới dgvCongVan
                if (dgvCongVan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn công văn cần xem từ danh sách chờ xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }
            else if (tabControl1.SelectedTab == tabDaXuLy)
            {
                // Nếu ở Tab "Đã xử lý" -> Lấy đường dẫn file từ lưới dgvDaXuly
                if (dgvDaXuly.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn công văn cần xem từ danh sách đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                path = dgvDaXuly.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }

            // 2. Logic kiểm tra và tiến hành mở file Viewer chung cho cả 2 bảng
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Công văn này không có file đính kèm để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ghép đường dẫn tương đối với thư mục chạy phần mềm
            string fullPath = Path.Combine(Application.StartupPath, path);

            // Mở Form hiển thị nội dung File (PDF, Hình ảnh...) của bạn
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string column = cbSearchCol.SelectedValue.ToString();
            string value = txtSearchValue.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                LoadData(); // Nếu để trống thì hiện tất cả như cũ
                return;
            }

            // Kiểm tra đang ở tab nào
            bool isTab1 = (tabControl1.SelectedTab == tabChoXuLy);

            // Gọi BLL tìm kiếm (Ví dụ này cho Role Lãnh đạo, các form khác thay tương ứng)
            DataTable dtResult = BLL.CongVanDenBLL.Instance.SearchInTab("NhanVien", isTab1, column, value);

            // Hiển thị kết quả lên đúng lưới của tab đó
            if (isTab1)
                dgvCongVan.DataSource = dtResult;
            else
                dgvDaXuly.DataSource = dtResult;
        }
        private void InitSearchCombo()
        {
            var searchFields = new[] {
        new { Text = "Số văn bản", Value = "SoVanBan" },
        new { Text = "Trích yếu", Value = "TrichYeu" },
        new { Text = "Nơi gửi/nhận", Value = "NoiGui" }
    };
            cbSearchCol.DataSource = searchFields;
            cbSearchCol.DisplayMember = "Text";
            cbSearchCol.ValueMember = "Value";
        }

        
    }
}
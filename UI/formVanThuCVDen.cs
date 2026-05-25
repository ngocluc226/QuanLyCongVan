using BLL;
using DAL;
using DTO;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class formVanThuCVDen : Form
    {
        public formVanThuCVDen()
        {
            InitializeComponent();
            InitDataGridView();
            InitDataGridDaXuLy();
            InitSearchCombo();
            Utils.FormatDataGridView(dgvDaXuly);
            Utils.FormatDataGridView(dgvCongVan);
            Utils.SyncAllButtons(this);
            LoadData();
        }

        private void LoadData()
        {
            dgvCongVan.DataSource = null;
            dgvDaXuly.DataSource = null;

            // Tab 1 (tabChoXuLy): Công văn mới nhập, trạng thái là 'Đã nhập'
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanMoiNhap();

            // Tab 2 (tabDaXuLy): Lịch sử các công văn đã trình đi
            dgvDaXuly.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanDaXuLyVanThu();

            LoadLanhDao();
        }

        private void InitDataGridDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaXuly.AllowUserToAddRows = false;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu văn bản", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái hiện tại", DataPropertyName = "TrangThai", Width = 130 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }

        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongVan.AllowUserToAddRows = false;

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDen", HeaderText = "Số đến", DataPropertyName = "SoDen", Width = 80 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 110 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDen", HeaderText = "Ngày đến", DataPropertyName = "NgayDen", DefaultCellStyle = { Format = "dd/MM/yyyy" }, Width = 100 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiGui", HeaderText = "Nơi gửi", DataPropertyName = "NoiGui", Width = 130 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", Width = 120 });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Trích yếu",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 130 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }

        private int GetSelectedId()
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn từ danh sách chờ xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
        }

        private void LoadLanhDao()
        {
            var dt = UserService.Instance.GetByRole("LanhDao");
            cboLanhDao.DataSource = dt;
            cboLanhDao.DisplayMember = "TenNguoiDung";
            cboLanhDao.ValueMember = "MaNguoiDung";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            formCongVanDenCreate f = new formCongVanDenCreate();
            f.ShowDialog();
            LoadData();
        }

        private void btnTrinh_Click(object sender, EventArgs e)
        {
            int congVanId = GetSelectedId();
            if (congVanId == -1) return;

            if (cboLanhDao.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một Lãnh đạo để trình duyệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string lanhDaoId = cboLanhDao.SelectedValue.ToString();
            string nguoiTrinhId = Session.UserId;

            bool result = TrinhLanhDaoBLL.Instance.Trinh(congVanId, nguoiTrinhId, lanhDaoId);

            if (result)
            {
                MessageBox.Show("Trình lãnh đạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình trình văn bản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                btnTrinh.Enabled = false;
                return;
            }

            string tt = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();
            btnTrinh.Enabled = (tt == DTO.TrangThaiCongVanDen.DA_NHAP);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = "";
            // Sử dụng chính xác biến tabChoXuLy của bạn
            if (tabControl1.SelectedTab == tabChoXuLy)
            {
                if (dgvCongVan.SelectedRows.Count == 0) return;
                path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }
            else
            {
                if (dgvDaXuly.SelectedRows.Count == 0) return;
                path = dgvDaXuly.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Công văn này không đính kèm tệp văn bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string fullPath = Path.Combine(Application.StartupPath, path);
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sử dụng chính xác biến tabChoXuLy của bạn
            if (tabControl1.SelectedTab == tabChoXuLy)
            {
                btnTrinh.Visible = true;
                cboLanhDao.Visible = true;
            }
            else
            {
                btnTrinh.Visible = false;
                cboLanhDao.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearchCol.SelectedValue == null) return;

            string column = cbSearchCol.SelectedValue.ToString();
            string value = txtSearchValue.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                LoadData();
                return;
            }

            // Đồng bộ kiểm tra tabChoXuLy cho chức năng tìm kiếm phân vùng
            bool isTabChoXuLy = (tabControl1.SelectedTab == tabChoXuLy);

            DataTable dtResult = BLL.CongVanDenBLL.Instance.SearchInTab("VanThu", isTabChoXuLy, column, value);

            if (isTabChoXuLy)
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
            cbSearchCol.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchValue.Clear();
            LoadData();
        }

        private void btnKiemTraAI_Click(object sender, EventArgs e)
        {
            string path = "";

            // 1. Xác định tệp tin đính kèm của công văn cần quét dựa trên Tab người dùng đang chọn
            if (tabControl1.SelectedTab == tabChoXuLy)
            {
                if (dgvCongVan.SelectedRows.Count == 0) return;
                path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }
            else
            {
                if (dgvDaXuly.SelectedRows.Count == 0) return;
                path = dgvDaXuly.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Văn bản này không có tệp đính kèm (PDF/Word/Image) để AI thực hiện phân tích thể thức!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi Form xử lý AI bất đồng bộ mã hóa OpenRouter mà chúng ta đã xây dựng
            formKiemTraAI frmAI = new formKiemTraAI(path);
            frmAI.ShowDialog();

            // 3. Cập nhật lại giao diện sau khi tắt hộp thoại kiểm tra
            LoadData();
        }
    }
}
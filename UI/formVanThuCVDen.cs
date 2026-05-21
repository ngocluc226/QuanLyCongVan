//using DAL;
using BLL;
using DAL;
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
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanMoiNhap(); // Tab 1
            dgvDaXuly.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanDaXuLyVanThu(); // Tab 2
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
                MessageBox.Show("Chọn công văn!");
                return -1;
            }

            return Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
        }
        private void LoadLanhDao()
        {
            var dt = UserService.Instance.GetByRole("LanhDao");

            cboLanhDao.DataSource = dt;
            cboLanhDao.DisplayMember = "TenNguoiDung";   // hoặc TenNguoiDung
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

            string lanhDaoId = cboLanhDao.SelectedValue.ToString();
            string nguoiTrinhId = Session.UserId;

            bool result = TrinhLanhDaoBLL.Instance.Trinh(congVanId, nguoiTrinhId, lanhDaoId);

            MessageBox.Show(result ? "Trình thành công!" : "Lỗi!");
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0) return;

            string tt = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            btnTrinh.Enabled = tt == DTO.TrangThaiCongVanDen.DA_NHAP;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = "";
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

            if (string.IsNullOrEmpty(path)) return;
            string fullPath = Path.Combine(Application.StartupPath, path);
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabChoXuLy)
                btnTrinh.Visible = true; // Chỉ cho phép trình ở tab chờ xử lý
            else if (tabControl1.SelectedTab == tabDaXuLy)
                btnTrinh.Visible = false;
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
            DataTable dtResult = BLL.CongVanDenBLL.Instance.SearchInTab("VanThu", isTab1, column, value);

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

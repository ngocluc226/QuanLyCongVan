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
    public partial class formLanhDaoCVDen : Form
    {
        public formLanhDaoCVDen()
        {
            InitializeComponent();
            LoadData();
            InitDataGridView();
            InitDataGridDaXuLy();
            InitSearchCombo();
            Utils.SyncAllButtons(this);
            Utils.FormatDataGridView(dgvDaXuly);
            Utils.FormatDataGridView(dgvCongVan);
        }
        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanChoLanhDao(); 
            dgvDaXuly.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanDaXuLyLanhDao(); 
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
        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            formPhanCong f = new formPhanCong(id);
            f.ShowDialog();

            LoadData();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(); 
            MessageBox.Show("Đã cập nhật danh sách công văn mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formLanhDaoCVDen_Load(object sender, EventArgs e)
        {
            Utils.SyncAllButtons(this);
        }
        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongVan.AllowUserToAddRows = false;

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDen", HeaderText = "Ngày đến", DataPropertyName = "NgayDen", DefaultCellStyle = { Format = "dd/MM/yyyy" }, Width = 100 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiGui", HeaderText = "Nơi gửi", DataPropertyName = "NoiGui", Width = 140 });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Trích yếu công văn",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", Width = 90 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", HeaderText = "Độ mật", DataPropertyName = "DoMat", Width = 90 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }
        private void InitDataGridDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaXuly.AllowUserToAddRows = false;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiGui", HeaderText = "Nơi gửi", DataPropertyName = "NoiGui", Width = 130 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung chỉ đạo", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Tiến độ xử lý", DataPropertyName = "TrangThai", Width = 130 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabChoXuLy)
                btnPhanCong.Visible = true;
            else if (tabControl1.SelectedTab == tabDaXuLy)
                btnPhanCong.Visible = false; 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string column = cbSearchCol.SelectedValue.ToString();
            string value = txtSearchValue.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                LoadData(); 
                return;
            }

            bool isTab1 = (tabControl1.SelectedTab == tabChoXuLy);

            DataTable dtResult = BLL.CongVanDenBLL.Instance.SearchInTab("LanhDao", isTab1, column, value);

            if (isTab1)
                dgvCongVan.DataSource = dtResult;
            else
                dgvDaXuly.DataSource = dtResult;
        }
    }
}

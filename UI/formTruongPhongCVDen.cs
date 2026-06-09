using BLL;
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
    public partial class formTruongPhongCVDen : Form
    {
        public formTruongPhongCVDen()
        {
            InitializeComponent();
        }

        private void formTruongPhongCVDen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            InitDataGridView();
            InitDataGridDaXuLy();
            InitSearchCombo();
            LoadData();
            Utils.FormatDataGridView(dgvCongVan);
            Utils.FormatDataGridView(dgvDaXuly);
            Utils.SyncAllButtons(this);

            int soLuong = BLL.CongVanDenBLL.Instance.GetThongBaoTruongPhong();
            if (soLuong > 0)
            {
                MessageBox.Show(
                    $"Phòng của bạn có {soLuong} công văn mới do Lãnh đạo giao về, vui lòng phân công nhân viên xử lý!",
                    "Thông báo Phòng ban",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        private void InitDataGridDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaXuly.AllowUserToAddRows = false;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung giao việc nhân viên", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", Width = 100 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái thực hiện", DataPropertyName = "TrangThai", Width = 140 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }
        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongVan.AllowUserToAddRows = false;

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Nội dung trích yếu",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", Width = 100 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", Width = 120 });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }
        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanChoPhongBan();
            dgvDaXuly.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanDaXuLyTruongPhong(); 
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

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (dgvCongVan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn công văn!");
                return;
            }

            int congVanId = Convert.ToInt32(dgvCongVan.CurrentRow.Cells["Id"].Value);

            formPhanCong f = new formPhanCong(congVanId);
            f.ShowDialog();

            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabChoXuLy)
                btnPhanCong.Visible = true;
            else if (tabControl1.SelectedTab == tabDaXuLy)
                btnPhanCong.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Utils.Logout(this);
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

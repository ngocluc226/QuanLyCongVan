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
    public partial class formVanThuCVDi : Form
    {
        public formVanThuCVDi()
        {
            InitializeComponent();
            InitEvents();
            InitDataGridView();
            Utils.FormatDataGridView(dgvCongVan);
            Utils.SyncAllButtons(this);
        }

        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", DataPropertyName = "SoDi", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", DataPropertyName = "NgayDi", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiNhan", DataPropertyName = "NoiNhan", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", DataPropertyName = "DoMat", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", DataPropertyName = "TrangThai", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan" });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan" });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy" });
        }

        private void InitEvents()
        {
            this.Load += (s, e) => LoadData();
            this.btnBanHanh.Click += (s, e) => BanHanh();
            this.btnXem.Click += (s, e) => XemFile();
            this.dgvCongVan.SelectionChanged += (s, e) => BindDataToControls();
        }

        private void LoadData()
        {
            dgvCongVan.DataSource = CongVanDiBLL.Instance.GetByTrangThai(TrangThaiCongVanDi.CHO_BAN_HANH);
            if (dgvCongVan.Rows.Count == 0)
            {
                txtSoVanBan.Clear();
                dtpNgayBanHanh.Value = DateTime.Now;
            }
        }
        
        private void BindDataToControls()
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                var row = dgvCongVan.SelectedRows[0];
                txtSoVanBan.Text = ""; // Để trống cho cán bộ điền
                dtpNgayBanHanh.Value = DateTime.Now;
            }
        }

        private void BanHanh()
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn chờ ban hành!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoVanBan.Text))
            {
                MessageBox.Show("Vui lòng nhập Số văn bản!");
                txtSoVanBan.Focus();
                return;
            }

            int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
            var row = dgvCongVan.SelectedRows[0];

            CongVanDi cv = new CongVanDi()
            {
                Id = id,
                SoDi = row.Cells["SoDi"].Value?.ToString(),
                SoVanBan = txtSoVanBan.Text.Trim(),
                NgayDi = Convert.ToDateTime(row.Cells["NgayDi"].Value),
                NgayBanHanh = dtpNgayBanHanh.Value,
                NoiNhan = row.Cells["NoiNhan"].Value?.ToString(),
                NguoiKy = row.Cells["NguoiKy"].Value?.ToString(),
                TrichYeu = row.Cells["TrichYeu"].Value?.ToString(),
                DoKhan = row.Cells["DoKhan"].Value?.ToString(),
                DoMat = row.Cells["DoMat"].Value?.ToString(),
                FileDinhKem = row.Cells["FileDinhKem"].Value?.ToString(),
                TrangThai = TrangThaiCongVanDi.DA_BAN_HANH
            };

            if (CongVanDiBLL.Instance.Update(cv))
            {
                CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.DA_BAN_HANH, "Văn thư cấp số văn bản và ban hành.");
                MessageBox.Show("Ban hành thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Gặp lỗi trong quá trình ban hành!");
            }
        }

        private void XemFile()
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn!");
                return;
            }

            string path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Không có file đính kèm!");
                return;
            }

            string fullPath = Path.Combine(Application.StartupPath, path);
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void formVanThuCVDi_Load(object sender, EventArgs e)
        {

        }
    }
}

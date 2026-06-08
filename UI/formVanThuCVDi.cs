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
            InitDataGridDaXuLy();
            Utils.FormatDataGridView(dgvCongVan);
            Utils.FormatDataGridView(dgvDaXuly);
            Utils.SyncAllButtons(this);
        }

        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", HeaderText = "Số đi", DataPropertyName = "SoDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", HeaderText = "Ngày đi", DataPropertyName = "NgayDi", DefaultCellStyle = { Format = "dd/MM/yyyy" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiNhan", HeaderText = "Nơi nhận", DataPropertyName = "NoiNhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", HeaderText = "Độ mật", DataPropertyName = "DoMat", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void InitDataGridDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", HeaderText = "Số đi", DataPropertyName = "SoDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", HeaderText = "Ngày đi", DataPropertyName = "NgayDi", DefaultCellStyle = { Format = "dd/MM/yyyy" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayBanHanh", HeaderText = "Ngày ban hành", DataPropertyName = "NgayBanHanh", DefaultCellStyle = { Format = "dd/MM/yyyy" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiNhan", HeaderText = "Nơi nhận", DataPropertyName = "NoiNhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", HeaderText = "Độ mật", DataPropertyName = "DoMat", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
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
            try
            {
                dgvCongVan.DataSource = CongVanDiBLL.Instance.GetByTrangThai(TrangThaiCongVanDi.CHO_BAN_HANH);
                dgvDaXuly.DataSource = CongVanDiBLL.Instance.GetByTrangThai(TrangThaiCongVanDi.DA_BAN_HANH);
                
                if (dgvCongVan.Rows.Count == 0)
                {
                    txtSoVanBan.Clear();
                    dtpNgayBanHanh.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToControls()
        {
            try
            {
                if (dgvCongVan.SelectedRows.Count > 0)
                {
                    var row = dgvCongVan.SelectedRows[0];
                    txtSoVanBan.Text = ""; // Để trống cho cán bộ điền
                    dtpNgayBanHanh.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gán dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BanHanh()
        {
            try
            {
                if (dgvCongVan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn công văn chờ ban hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoVanBan.Text))
                {
                    MessageBox.Show("Vui lòng nhập Số văn bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Ban hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gặp lỗi trong quá trình ban hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XemFile()
        {
            try
            {
                DataGridView dgv = tabControl1.SelectedTab == tabChoXuLy ? dgvCongVan : dgvDaXuly;
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn công văn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string path = dgv.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("Không có file đính kèm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fullPath = Path.Combine(Application.StartupPath, path);
                formFileViewer f = new formFileViewer(fullPath);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isChoXuLy = (tabControl1.SelectedTab == tabChoXuLy);
            btnBanHanh.Visible = isChoXuLy;
            txtSoVanBan.Visible = isChoXuLy;
            dtpNgayBanHanh.Visible = isChoXuLy;
            label1.Visible = isChoXuLy;
            label2.Visible = isChoXuLy;
        }

        private void formVanThuCVDi_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class formNhanVienCVDi : Form
    {
        private Dictionary<int, string> _dictCvDen = new Dictionary<int, string>();

        public formNhanVienCVDi()
        {
            InitializeComponent();
            InitEvents();
            InitDataGridView();
            InitDataGridChoDuyet();
            InitDataGridTuChoi();
            Utils.FormatDataGridView(dgvCongVan);
            Utils.FormatDataGridView(dgvChoDuyet);
            Utils.FormatDataGridView(dgvTuChoi);
        }

        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();
            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TraLoiChoCVDen", HeaderText = "Trả lời cho CV", DataPropertyName = "LienKetCongVanDenId", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", HeaderText = "Số đi", DataPropertyName = "SoDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Visible = false });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", HeaderText = "Ngày đi", DataPropertyName = "NgayDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiNhan", HeaderText = "Nơi nhận", DataPropertyName = "NoiNhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", HeaderText = "Độ mật", DataPropertyName = "DoMat", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void InitDataGridChoDuyet()
        {
            dgvChoDuyet.AutoGenerateColumns = false;
            dgvChoDuyet.Columns.Clear();
            dgvChoDuyet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TraLoiChoCVDen", HeaderText = "Trả lời cho CV", DataPropertyName = "LienKetCongVanDenId", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", HeaderText = "Số đi", DataPropertyName = "SoDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Visible = false });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", HeaderText = "Ngày đi", DataPropertyName = "NgayDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiNhan", HeaderText = "Nơi nhận", DataPropertyName = "NoiNhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", HeaderText = "Độ mật", DataPropertyName = "DoMat", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvChoDuyet.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void InitDataGridTuChoi()
        {
            dgvTuChoi.AutoGenerateColumns = false;
            dgvTuChoi.Columns.Clear();
            dgvTuChoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TraLoiChoCVDen", HeaderText = "Trả lời cho CV", DataPropertyName = "LienKetCongVanDenId", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", HeaderText = "Số đi", DataPropertyName = "SoDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Visible = false });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", HeaderText = "Ngày đi", DataPropertyName = "NgayDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung trích yếu", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NoiNhan", HeaderText = "Nơi nhận", DataPropertyName = "NoiNhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiKy", HeaderText = "Người ký", DataPropertyName = "NguoiKy", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoKhan", HeaderText = "Độ khẩn", DataPropertyName = "DoKhan", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DoMat", HeaderText = "Độ mật", DataPropertyName = "DoMat", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvTuChoi.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void InitEvents()
        {
            this.Load += (s, e) => LoadData();
            this.btnThemDraft.Click += (s, e) => ThemDraft();
            this.btnSuaDraft.Click += (s, e) => SuaDraft();
            this.btnNopDuyet.Click += (s, e) => NopDuyet();
            this.btnXemLyDo.Click += btnXemLyDo_Click;
            this.dgvCongVan.SelectionChanged += dgvCongVan_SelectionChanged;
            dgvCongVan.CellFormatting += dgvCongVan_CellFormatting;
            dgvChoDuyet.CellFormatting += dgvCongVan_CellFormatting;
            dgvTuChoi.CellFormatting += dgvCongVan_CellFormatting;
        }

        private void dgvCongVan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            if (e.RowIndex >= 0 && dgv.Columns.Contains("TraLoiChoCVDen") && e.ColumnIndex == dgv.Columns["TraLoiChoCVDen"].Index)
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (int.TryParse(e.Value.ToString(), out int id))
                    {
                        if (_dictCvDen.ContainsKey(id))
                        {
                            e.Value = _dictCvDen[id];
                            e.FormattingApplied = true;
                        }
                    }
                }
            }
        }

        private void LoadData()
        {
            try
            {
                _dictCvDen.Clear();
                DataTable dtCVDen = BLL.CongVanDenBLL.Instance.GetAll();
                foreach (DataRow r in dtCVDen.Rows)
                {
                    int id = Convert.ToInt32(r["Id"]);
                    string trichYeu = r["TrichYeu"] != DBNull.Value ? r["TrichYeu"].ToString() : "";
                    _dictCvDen[id] = trichYeu;
                }

                if (DTO.Session.CurrentUser != null)
                {
                    dgvCongVan.DataSource = BLL.CongVanDiBLL.Instance.GetByNguoiTaoId(
                        DTO.Session.CurrentUser.MaNguoiDung,
                        DTO.TrangThaiCongVanDi.DU_THAO
                    );

                    dgvChoDuyet.DataSource = BLL.CongVanDiBLL.Instance.GetByNguoiTaoId(
                        DTO.Session.CurrentUser.MaNguoiDung,
                        DTO.TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG, 
                        DTO.TrangThaiCongVanDi.CHO_KY_LANH_DAO,
                        DTO.TrangThaiCongVanDi.CHO_BAN_HANH
                    );

                    dgvTuChoi.DataSource = BLL.CongVanDiBLL.Instance.GetByNguoiTaoId(
                        DTO.Session.CurrentUser.MaNguoiDung,
                        DTO.TrangThaiCongVanDi.TU_CHOI
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemDraft()
        {
            try
            {
                var cv = new DTO.CongVanDi()
                {
                    SoDi = BLL.CongVanDiBLL.Instance.GenerateSoDi(),
                    NgayDi = DateTime.Now,
                    TrangThai = DTO.TrangThaiCongVanDi.DU_THAO
                };

                using (var f = new formCongVanDiCreate(cv))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaDraft()
        {
            try
            {
                DataGridView activeDgv = null;
                if (tabControl1.SelectedTab == tabDuThao) activeDgv = dgvCongVan;
                else if (tabControl1.SelectedTab == tabTuChoi) activeDgv = dgvTuChoi;

                if (activeDgv != null && activeDgv.SelectedRows.Count > 0)
                {
                    var row = activeDgv.SelectedRows[0];
                    var cv = new DTO.CongVanDi()
                    {
                        Id = Convert.ToInt32(row.Cells["Id"].Value),
                        SoDi = row.Cells["SoDi"].Value?.ToString(),
                        NgayDi = Convert.ToDateTime(row.Cells["NgayDi"].Value),
                        NoiNhan = row.Cells["NoiNhan"].Value?.ToString(),
                        NguoiKy = row.Cells["NguoiKy"].Value?.ToString(),
                        TrichYeu = row.Cells["TrichYeu"].Value?.ToString(),
                        DoKhan = row.Cells["DoKhan"].Value?.ToString(),
                        DoMat = row.Cells["DoMat"].Value?.ToString(),
                        FileDinhKem = row.Cells["FileDinhKem"].Value?.ToString(),
                        TrangThai = row.Cells["TrangThai"].Value?.ToString(),
                        LienKetCongVanDenId = row.Cells["LienKetCongVanDenId"]?.Value != DBNull.Value ? (int?)Convert.ToInt32(row.Cells["LienKetCongVanDenId"].Value) : null
                    };

                    using (var f = new formCongVanDiCreate(cv))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bản dự thảo cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NopDuyet()
        {
            try
            {
                if (dgvCongVan.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                    if(BLL.CongVanDiBLL.Instance.ChuyenTrangThai(id, DTO.TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG, "Nhân viên nộp"))
                    {
                        MessageBox.Show("Đã nộp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bản thảo cần nộp duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            // Function no longer needed for btnXemLyDo toggling on tabDuThao
            // because TU_CHOI is now in its own tab.
        }

        private void btnXemLyDo_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != tabTuChoi || dgvTuChoi.SelectedRows.Count == 0) return;
            var row = dgvTuChoi.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string keyword = $"Từ chối cho CV ID {id}";
            
            DataTable dtLogs = BLL.LogBLL.Instance.GetAll();
            foreach (DataRow logRow in dtLogs.Rows)
            {
                string hanhDong = logRow["HanhDong"].ToString();
                if (hanhDong.Contains(keyword))
                {
                    string[] parts = hanhDong.Split(new string[] { "Ghi chú: " }, StringSplitOptions.None);
                    string lyDo = parts.Length > 1 ? parts[1] : hanhDong;
                    MessageBox.Show("Lý do từ chối:\n\n" + lyDo, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy lý do từ chối chi tiết trong lịch sử.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabDuThao)
            {
                btnThemDraft.Visible = true;
                btnSuaDraft.Visible = true;
                btnNopDuyet.Visible = true;
                btnXemLyDo.Visible = false;
            }
            else if (tabControl1.SelectedTab == tabTuChoi)
            {
                btnThemDraft.Visible = false;
                btnSuaDraft.Visible = true;
                btnNopDuyet.Visible = false;
                btnXemLyDo.Visible = true;
            }
            else
            {
                btnThemDraft.Visible = false;
                btnSuaDraft.Visible = false;
                btnNopDuyet.Visible = false;
                btnXemLyDo.Visible = false;
            }
        }

        private void btnKiemTraAI_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";

                if (tabControl1.SelectedTab == tabDuThao)
                {
                    if (dgvCongVan.SelectedRows.Count == 0) return;
                    path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
                }
                else if (tabControl1.SelectedTab == tabChoDuyet)
                {
                    if (dgvChoDuyet.SelectedRows.Count == 0) return;
                    path = dgvChoDuyet.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
                }
                else if (tabControl1.SelectedTab == tabTuChoi)
                {
                    if (dgvTuChoi.SelectedRows.Count == 0) return;
                    path = dgvTuChoi.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
                }

                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("Văn bản này không có tệp đính kèm (PDF/Word/Image) để AI thực hiện phân tích thể thức!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                formKiemTraAI frmAI = new formKiemTraAI(path);
                frmAI.ShowDialog();
                LoadData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = "";
            if (tabControl1.SelectedTab == tabDuThao)
            {
                if (dgvCongVan.SelectedRows.Count == 0) return;
                path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }
            else if (tabControl1.SelectedTab == tabChoDuyet)
            {
                if (dgvChoDuyet.SelectedRows.Count == 0) return;
                path = dgvChoDuyet.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }
            else if (tabControl1.SelectedTab == tabTuChoi)
            {
                if (dgvTuChoi.SelectedRows.Count == 0) return;
                path = dgvTuChoi.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }

            if (string.IsNullOrEmpty(path)) return;
            string fullPath = Path.Combine(Application.StartupPath, path);
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }
    }
}

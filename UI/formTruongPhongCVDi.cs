using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using BLL;
using DTO;

namespace UI
{
    public partial class formTruongPhongCVDi : Form
    {
        public formTruongPhongCVDi()
        {
            InitializeComponent();
            InitEvents();
            InitDataGridView();
            InitDataGridViewDaXuLy();
            Utils.FormatDataGridView(dgvCongVan);
            Utils.FormatDataGridView(dgvDaXuly);
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

        private void InitDataGridViewDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LienKetCongVanDenId", DataPropertyName = "LienKetCongVanDenId", Visible = false });

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoDi", HeaderText = "Số đi", DataPropertyName = "SoDi", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayDi", HeaderText = "Ngày đi", DataPropertyName = "NgayDi", DefaultCellStyle = { Format = "dd/MM/yyyy" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
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
            this.Load += (s, e) => LoadLanhDao();
            this.btnDuyet.Click += (s, e) => DuyetCV();
            this.btnTuChoi.Click += (s, e) => TuChoiCV();
            this.btnXem.Click += (s, e) => XemFile();
            this.dgvCongVan.SelectionChanged += dgvCongVan_SelectionChanged;
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                var row = dgvCongVan.SelectedRows[0];
                string nguoiKy = row.Cells["NguoiKy"].Value?.ToString();
                if (!string.IsNullOrEmpty(nguoiKy))
                {
                    cboLanhDao.Text = nguoiKy; // Auto pre-select the leader chosen by employee
                }
            }
        }

        private void LoadLanhDao()
        {
            try
            {
                DataTable dt = UserService.Instance.GetByRole("LanhDao");
                cboLanhDao.DataSource = dt;
                cboLanhDao.DisplayMember = "TenNguoiDung";
                cboLanhDao.ValueMember = "MaNguoiDung";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Lãnh đạo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (Session.CurrentUser != null)
                {
                    // Cho Xu Ly
                    DataTable dt = CongVanDiBLL.Instance.GetByPhongBanTao(Session.CurrentUser.MaPhongBan, TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG);

                    if (UyQuyenBLL.Instance.CheckHasActiveUyQuyenLanhDao(Session.CurrentUser.MaNguoiDung))
                    {
                        DataTable dtUyQuyen = UyQuyenBLL.Instance.GetByNguoiDuocUyQuyen(Session.CurrentUser.MaNguoiDung);
                        foreach (DataRow row in dtUyQuyen.Rows)
                        {
                            string lanhDaoId = row["MaNguoiUyQuyen"].ToString();
                            DataTable dtLanhDao = CongVanDiBLL.Instance.GetByLanhDaoDuyetId(lanhDaoId, TrangThaiCongVanDi.CHO_KY_LANH_DAO);
                            dt.Merge(dtLanhDao);
                        }
                    }

                    dgvCongVan.DataSource = dt;

                    // Da Xu Ly
                    DataTable dtDaXuLy = CongVanDiBLL.Instance.GetByPhongBanTao(Session.CurrentUser.MaPhongBan, TrangThaiCongVanDi.CHO_KY_LANH_DAO, TrangThaiCongVanDi.TU_CHOI, TrangThaiCongVanDi.CHO_BAN_HANH, TrangThaiCongVanDi.DA_BAN_HANH);
                    if (UyQuyenBLL.Instance.CheckHasActiveUyQuyenLanhDao(Session.CurrentUser.MaNguoiDung))
                    {
                        DataTable dtUyQuyen = UyQuyenBLL.Instance.GetByNguoiDuocUyQuyen(Session.CurrentUser.MaNguoiDung);
                        foreach (DataRow row in dtUyQuyen.Rows)
                        {
                            string lanhDaoId = row["MaNguoiUyQuyen"].ToString();
                            DataTable dtLanhDao = CongVanDiBLL.Instance.GetByLanhDaoDuyetId(lanhDaoId, TrangThaiCongVanDi.TU_CHOI, TrangThaiCongVanDi.CHO_BAN_HANH, TrangThaiCongVanDi.DA_BAN_HANH);
                            dtDaXuLy.Merge(dtLanhDao);
                        }
                    }
                    dgvDaXuly.DataSource = dtDaXuLy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DuyetCV()
        {
            try
            {
                if (dgvCongVan.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                    string trangThai = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

                    if (trangThai == TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG)
                    {
                        if (cboLanhDao.SelectedValue == null)
                        {
                            MessageBox.Show("Vui lòng chọn Lãnh đạo duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Update LanhDaoDuyetId first
                        var cv = CongVanDiBLL.Instance.GetById(id);
                        if (cv != null)
                        {
                            cv.LanhDaoDuyetId = cboLanhDao.SelectedValue.ToString();
                            cv.NguoiKy = cboLanhDao.Text; // Override NguoiKy to ensure consistency!
                            CongVanDiBLL.Instance.Update(cv);

                            if (CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.CHO_KY_LANH_DAO, "Trưởng phòng đã duyệt"))
                            {
                                MessageBox.Show("Duyệt và chuyển Lãnh đạo ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                    else if (trangThai == TrangThaiCongVanDi.CHO_KY_LANH_DAO)
                    {
                        if (CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.CHO_BAN_HANH, "Ký thay Lãnh đạo bởi " + Session.CurrentUser.TenNguoiDung))
                        {
                            MessageBox.Show("Duyệt (Ký thay) thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn công văn cần duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TuChoiCV()
        {
            try
            {
                if (dgvCongVan.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                    string trangThai = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

                    var result = MessageBox.Show("Bạn có chắc chắn muốn TỪ CHỐI công văn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string lyDo = ShowPromptDialog("Nhập lý do từ chối:", "Lý do");
                        if (string.IsNullOrEmpty(lyDo)) lyDo = "Không đạt yêu cầu";

                        string trangThaiMoi = (trangThai == TrangThaiCongVanDi.CHO_KY_LANH_DAO) 
                                            ? TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG 
                                            : TrangThaiCongVanDi.TU_CHOI;

                        if (CongVanDiBLL.Instance.ChuyenTrangThai(id, trangThaiMoi, "Từ chối: " + lyDo))
                        {
                            MessageBox.Show("Từ chối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn công văn cần từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (tabControl1.SelectedTab == tabChoXuLy)
            {
                btnDuyet.Visible = true;
                btnTuChoi.Visible = true;
                cboLanhDao.Visible = true;
                lblLanhDao.Visible = true;
            }
            else
            {
                btnDuyet.Visible = false;
                btnTuChoi.Visible = false;
                cboLanhDao.Visible = false;
                lblLanhDao.Visible = false;
            }
        }

        private string ShowPromptDialog(string text, string caption)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 500;
                prompt.Height = 150;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = caption;
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 440 };
                Button confirmation = new Button() { Text = "Xác nhận", Left = 360, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }
}

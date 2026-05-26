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
        private System.Windows.Forms.ComboBox cboLanhDao;
        private System.Windows.Forms.Label lblLanhDao;

        public formTruongPhongCVDi()
        {
            InitializeComponent();
            InitDynamicControls();
            InitEvents();
            InitDataGridView();
            Utils.FormatDataGridView(dgvCongVan);
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

        private void InitDynamicControls()
        {
            lblLanhDao = new System.Windows.Forms.Label();
            lblLanhDao.Text = "Chọn Lãnh đạo:";
            lblLanhDao.Location = new System.Drawing.Point(450, 108);
            lblLanhDao.AutoSize = true;

            cboLanhDao = new System.Windows.Forms.ComboBox();
            cboLanhDao.Location = new System.Drawing.Point(550, 105);
            cboLanhDao.Size = new System.Drawing.Size(200, 24);
            cboLanhDao.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Controls.Add(lblLanhDao);
            this.Controls.Add(cboLanhDao);
        }

        private void InitEvents()
        {
            this.Load += (s, e) => LoadData();
            this.Load += (s, e) => LoadLanhDao();
            this.btnDuyet.Click += (s, e) => DuyetCV();
            this.btnTuChoi.Click += (s, e) => TuChoiCV();
            this.btnXem.Click += (s, e) => XemFile();
        }

        private void LoadLanhDao()
        {
            DataTable dt = UserService.Instance.GetByRole("LanhDao");
            cboLanhDao.DataSource = dt;
            cboLanhDao.DisplayMember = "TenNguoiDung";
            cboLanhDao.ValueMember = "MaNguoiDung";
        }

        private void LoadData()
        {
            if (Session.CurrentUser != null)
            {
                DataTable dt = CongVanDiBLL.Instance.GetByPhongBanTao(Session.CurrentUser.MaPhongBan, TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG);

                if (UyQuyenBLL.Instance.CheckHasActiveUyQuyenLanhDao(Session.CurrentUser.MaNguoiDung))
                {
                    // Lấy ra danh sách lãnh đạo đã ủy quyền cho người này
                    DataTable dtUyQuyen = UyQuyenBLL.Instance.GetByNguoiDuocUyQuyen(Session.CurrentUser.MaNguoiDung);
                    foreach (DataRow row in dtUyQuyen.Rows)
                    {
                        string lanhDaoId = row["MaNguoiUyQuyen"].ToString();
                        DataTable dtLanhDao = CongVanDiBLL.Instance.GetByLanhDaoDuyetId(lanhDaoId, TrangThaiCongVanDi.CHO_KY_LANH_DAO);
                        dt.Merge(dtLanhDao);
                    }
                }

                dgvCongVan.DataSource = dt;
            }
        }

        private void DuyetCV()
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                string trangThai = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();
                
                if (trangThai == TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG)
                {
                    if (cboLanhDao.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn Lãnh đạo duyệt!");
                        return;
                    }

                    // Update LanhDaoDuyetId first
                    var cv = CongVanDiBLL.Instance.GetById(id);
                    if (cv != null)
                    {
                        cv.LanhDaoDuyetId = cboLanhDao.SelectedValue.ToString();
                        CongVanDiBLL.Instance.Update(cv);
                        
                        if (CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.CHO_KY_LANH_DAO, "Trưởng phòng đã duyệt"))
                        {
                            MessageBox.Show("Duyệt và chuyển Lãnh đạo ký thành công!");
                            LoadData();
                        }
                    }
                }
                else if (trangThai == TrangThaiCongVanDi.CHO_KY_LANH_DAO)
                {
                    if (CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.CHO_BAN_HANH, "Ký thay Lãnh đạo bởi " + Session.CurrentUser.TenNguoiDung))
                    {
                        MessageBox.Show("Duyệt (Ký thay) thành công!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công văn cần duyệt!");
            }
        }

        private void TuChoiCV()
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
                        MessageBox.Show("Từ chối thành công!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công văn cần từ chối!");
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

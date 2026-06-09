using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class formUyQuyen : Form
    {
        private Dictionary<string, string> _dictUserNames = new Dictionary<string, string>();

        public formUyQuyen()
        {
            InitializeComponent();
            InitEvents();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            dgvUyQuyen.AutoGenerateColumns = false;
            dgvUyQuyen.Columns.Clear();

            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiUyQuyen", HeaderText = "Người ủy quyền", DataPropertyName = "NguoiUyQuyen", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NguoiDuocUyQuyen", HeaderText = "Người được ủy quyền", DataPropertyName = "NguoiDuocUyQuyen", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TuNgay", HeaderText = "Từ ngày", DataPropertyName = "TuNgay", DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DenNgay", HeaderText = "Đến ngày", DataPropertyName = "DenNgay", DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "QuyenHan", DataPropertyName = "QuyenHan", Visible = false });
            dgvUyQuyen.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", DataPropertyName = "TrangThai", Visible = false });
        }

        private void InitEvents()
        {
            this.Load += FormUyQuyen_Load;
            this.btnLuu.Click += BtnLuu_Click;
            this.btnHuyUyQuyen.Click += BtnHuyUyQuyen_Click;
            this.dgvUyQuyen.CellFormatting += dgvUyQuyen_CellFormatting;
        }

        private void dgvUyQuyen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvUyQuyen.Columns["NguoiUyQuyen"].Index || e.ColumnIndex == dgvUyQuyen.Columns["NguoiDuocUyQuyen"].Index))
            {
                if (e.Value != null)
                {
                    string maNguoiDung = e.Value.ToString();
                    if (_dictUserNames.ContainsKey(maNguoiDung))
                    {
                        e.Value = _dictUserNames[maNguoiDung];
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void FormUyQuyen_Load(object sender, EventArgs e)
        {
            LoadUserNames();
            LoadLanhDao();
            LoadData();
        }

        private void LoadUserNames()
        {
            _dictUserNames.Clear();
            DataTable dtUsers = UserService.Instance.GetAllUsers();
            foreach (DataRow r in dtUsers.Rows)
            {
                string id = r["MaNguoiDung"].ToString();
                string ten = r["TenNguoiDung"].ToString();
                _dictUserNames[id] = ten;
            }
        }

        private void LoadLanhDao()
        {
            // Lấy danh sách Lãnh đạo khác để ủy quyền thay vì Trưởng phòng
            var dt = UserService.Instance.GetByRole("LanhDao"); 
            
            DataView dv = new DataView(dt);
            dv.RowFilter = $"MaNguoiDung <> '{Session.CurrentUser.MaNguoiDung}'"; // Loại bỏ chính mình
            
            cmbNguoiNhan.DataSource = dv;
            cmbNguoiNhan.DisplayMember = "TenNguoiDung";
            cmbNguoiNhan.ValueMember = "MaNguoiDung";
            cmbNguoiNhan.SelectedIndex = -1;
        }

        private void LoadData()
        {
            DataTable dt = UyQuyenBLL.Instance.GetAllActive();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"NguoiUyQuyen = '{Session.CurrentUser.MaNguoiDung}' OR NguoiDuocUyQuyen = '{Session.CurrentUser.MaNguoiDung}'";
            dgvUyQuyen.DataSource = dv;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (cmbNguoiNhan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn người được ủy quyền!");
                return;
            }

            try
            {
                string nguoiNhan = cmbNguoiNhan.SelectedValue.ToString();

                // Kiểm tra chống ủy quyền chéo/tròn: Nếu người nhận đang ủy quyền cho ai đó khác (người nhận vắng mặt)
                DataTable dtActive = UyQuyenBLL.Instance.GetAllActive();
                DataRow[] drCheck = dtActive.Select($"NguoiUyQuyen = '{nguoiNhan}'");
                if (drCheck.Length > 0)
                {
                    MessageBox.Show("Người này hiện đang ủy quyền công việc cho người khác. Không thể ủy quyền cho họ lúc này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UyQuyen uq = new UyQuyen
                {
                    NguoiUyQuyen = Session.CurrentUser.MaNguoiDung,
                    NguoiDuocUyQuyen = nguoiNhan,
                    TuNgay = dtpTuNgay.Value,
                    DenNgay = dtpDenNgay.Value,
                    QuyenHan = "ALL", // Có thể mở rộng sau nếu cần cấp quyền chi tiết
                    TrangThai = true
                };

                if (UyQuyenBLL.Instance.Insert(uq))
                {
                    MessageBox.Show("Thêm ủy quyền thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnHuyUyQuyen_Click(object sender, EventArgs e)
        {
            if (dgvUyQuyen.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUyQuyen.SelectedRows[0].Cells["Id"].Value);
                string nguoiUyQuyen = dgvUyQuyen.SelectedRows[0].Cells["NguoiUyQuyen"].Value.ToString();

                if (nguoiUyQuyen != Session.CurrentUser.MaNguoiDung)
                {
                    MessageBox.Show("Bạn không thể hủy vì bạn không phải là người tạo ra ủy quyền này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (UyQuyenBLL.Instance.Disable(id))
                {
                    MessageBox.Show("Đã hủy ủy quyền!");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục để hủy!");
            }
        }
    }
}

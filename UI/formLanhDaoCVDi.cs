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
    public partial class formLanhDaoCVDi : Form
    {
        public formLanhDaoCVDi()
        {
            InitializeComponent();
            InitEvents();
            InitDataGridView();
            InitDataGridDaXuLy();
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

        private void InitDataGridDaXuLy()
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
            this.btnDuyet.Click += (s, e) => DuyetCV();
            this.btnTuChoi.Click += (s, e) => TuChoiCV();
        }

        private void LoadData()
        {
            try
            {
                if (DTO.Session.CurrentUser != null)
                {
                    dgvCongVan.DataSource = BLL.CongVanDiBLL.Instance.GetByLanhDaoDuyetId(DTO.Session.CurrentUser.MaNguoiDung, DTO.TrangThaiCongVanDi.CHO_KY_LANH_DAO);
                    dgvDaXuly.DataSource = BLL.CongVanDiBLL.Instance.GetByLanhDaoDuyetId(DTO.Session.CurrentUser.MaNguoiDung, DTO.TrangThaiCongVanDi.CHO_BAN_HANH, DTO.TrangThaiCongVanDi.TU_CHOI, DTO.TrangThaiCongVanDi.DA_BAN_HANH);
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
                    if (BLL.CongVanDiBLL.Instance.ChuyenTrangThai(id, DTO.TrangThaiCongVanDi.CHO_BAN_HANH, "Lãnh đạo đã duyệt"))
                    {
                        MessageBox.Show("Đã duyệt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
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
                    var result = MessageBox.Show("Bạn có chắc chắn muốn TỪ CHỐI công văn này không?", "Xác nhận từ chối", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string lyDo = ShowPromptDialog("Nhập lý do từ chối (bắt buộc):", "Từ chối văn bản");
                        if (string.IsNullOrWhiteSpace(lyDo))
                        {
                            MessageBox.Show("Vui lòng nhập lý do từ chối để nhân viên khắc phục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (BLL.CongVanDiBLL.Instance.ChuyenTrangThai(id, DTO.TrangThaiCongVanDi.TU_CHOI, "Lãnh đạo từ chối: " + lyDo))
                        {
                            MessageBox.Show("Đã từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabChoXuLy)
            {
                btnDuyet.Visible = true;
                btnTuChoi.Visible = true;
            }
            else
            {
                btnDuyet.Visible = false;
                btnTuChoi.Visible = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string path = null;
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
    }
}

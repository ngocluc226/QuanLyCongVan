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

        private void InitEvents()
        {
            this.Load += (s, e) => LoadData();
            this.btnDuyet.Click += (s, e) => DuyetCV();
            this.btnTuChoi.Click += (s, e) => TuChoiCV();
        }

        private void LoadData()
        {
            if (DTO.Session.CurrentUser != null)
            {
                dgvCongVan.DataSource = BLL.CongVanDiBLL.Instance.GetByLanhDaoDuyetId(DTO.Session.CurrentUser.MaNguoiDung, DTO.TrangThaiCongVanDi.CHO_KY_LANH_DAO);
            }
        }

        private void DuyetCV()
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                if (BLL.CongVanDiBLL.Instance.ChuyenTrangThai(id, DTO.TrangThaiCongVanDi.CHO_BAN_HANH, "Lãnh đạo đã duyệt"))
                {
                    MessageBox.Show("Đã duyệt thành công!");
                    LoadData();
                }
            }
        }

        private void TuChoiCV()
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
                        MessageBox.Show("Đã từ chối!");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công văn cần từ chối!");
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path  = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            
            if (string.IsNullOrEmpty(path)) return;
            string fullPath = Path.Combine(Application.StartupPath, path);
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }
    }
}

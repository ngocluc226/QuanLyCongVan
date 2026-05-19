using System;
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
        }

        private void InitEvents()
        {
            this.Load += (s, e) => LoadData();
            this.btnDuyet.Click += (s, e) => DuyetCV();
            this.btnTuChoi.Click += (s, e) => TuChoiCV();
            this.btnXem.Click += (s, e) => XemFile();
        }

        private void LoadData()
        {
            dgvCongVan.DataSource = CongVanDiBLL.Instance.GetByTrangThai(TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG);
        }

        private void DuyetCV()
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                if (CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.CHO_KY_LANH_DAO, "Trưởng phòng đã duyệt"))
                {
                    MessageBox.Show("Đã duyệt và chuyển Lãnh đạo ký thành công!");
                    LoadData();
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
                var result = MessageBox.Show("Bạn có chắc chắn muốn TỪ CHỐI công văn này không?", "Xác nhận từ chối", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string lyDo = ShowPromptDialog("Nhập lý do từ chối (bắt buộc):", "Từ chối văn bản");
                    if (string.IsNullOrWhiteSpace(lyDo))
                    {
                        MessageBox.Show("Vui lòng nhập lý do từ chối để nhân viên khắc phục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (CongVanDiBLL.Instance.ChuyenTrangThai(id, TrangThaiCongVanDi.TU_CHOI, "Trưởng phòng từ chối: " + lyDo))
                    {
                        MessageBox.Show("Đã từ chối thành công!");
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

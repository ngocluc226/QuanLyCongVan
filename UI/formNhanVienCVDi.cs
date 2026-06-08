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
        public formNhanVienCVDi()
        {
            InitializeComponent();
            InitEvents();
            Utils.FormatDataGridView(dgvCongVan);
        }

        private void InitEvents()
        {
            this.Load += (s, e) => LoadData();
            this.btnThemDraft.Click += (s, e) => ThemDraft();
            this.btnSuaDraft.Click += (s, e) => SuaDraft();
            this.btnNopDuyet.Click += (s, e) => NopDuyet();
        }

        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDiBLL.Instance.GetByTrangThais(
                DTO.TrangThaiCongVanDi.DU_THAO, 
                DTO.TrangThaiCongVanDi.TU_CHOI
            );
        }

        private void ThemDraft()
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

        private void SuaDraft()
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                var row = dgvCongVan.SelectedRows[0];
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
                MessageBox.Show("Vui lòng chọn bản dự thảo cần sửa!");
            }
        }

        private void NopDuyet()
        {
            if (dgvCongVan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
                if(BLL.CongVanDiBLL.Instance.ChuyenTrangThai(id, DTO.TrangThaiCongVanDi.CHO_DUYET_TRUONG_PHONG, "Nhân viên nộp"))
                {
                    MessageBox.Show("Đã nộp thành công!");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản thảo cần nộp duyệt!");
            }
        }

        private void btnKiemTraAI_Click(object sender, EventArgs e)
        {
            string path = "";

            //// 1. Xác định tệp tin đính kèm của công văn cần quét dựa trên Tab người dùng đang chọn
            //if (tabControl1.SelectedTab == tabChoXuLy)
            //{
            //    if (dgvCongVan.SelectedRows.Count == 0) return;
                path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            //}
            //else
            //{
            //    if (dgvDaXuly.SelectedRows.Count == 0) return;
            //    path = dgvDaXuly.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            //}

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Văn bản này không có tệp đính kèm (PDF/Word/Image) để AI thực hiện phân tích thể thức!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi Form xử lý AI bất đồng bộ mã hóa OpenRouter mà chúng ta đã xây dựng
            formKiemTraAI frmAI = new formKiemTraAI(path);
            frmAI.ShowDialog();

            // 3. Cập nhật lại giao diện sau khi tắt hộp thoại kiểm tra
            LoadData(); 
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

            if (string.IsNullOrEmpty(path)) return;
            string fullPath = Path.Combine(Application.StartupPath, path);
            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }
    }
}

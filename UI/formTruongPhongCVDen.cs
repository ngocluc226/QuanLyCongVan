using BLL;
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
    public partial class formTruongPhongCVDen : Form
    {
        public formTruongPhongCVDen()
        {
            InitializeComponent();
        }

        private void formTruongPhongCVDen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadData();
        }
        private void LoadData()
        {
            var dt = CongVanDenBLL.Instance.GetCongVanChoTruongPhong();

            dgvCongVan.DataSource = dt;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn!");
                return;
            }

            string path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Không có file!");
                return;
            }

            // Nếu bạn lưu relative path
            string fullPath = Path.Combine(Application.StartupPath, path);

            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (dgvCongVan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn công văn!");
                return;
            }

            // 👉 Lấy Id công văn (đảm bảo tên cột đúng với DataTable)
            int congVanId = Convert.ToInt32(dgvCongVan.CurrentRow.Cells["Id"].Value);

            // 👉 Mở form phân công
            formPhanCong f = new formPhanCong(congVanId);
            f.ShowDialog();

            // 👉 Sau khi đóng form → reload lại danh sách
            LoadData();
        }
    }
}

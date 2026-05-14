//using DAL;
using BLL;
using DAL;
using DTO;
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
    public partial class formVanThuCVDen : Form
    {
        public formVanThuCVDen()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetAll();
            LoadLanhDao();

        }
        private int GetSelectedId()
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn công văn!");
                return -1;
            }

            return Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
        }
        private void LoadLanhDao()
        {
            var dt = UserService.Instance.GetByRole("LanhDao");

            cboLanhDao.DataSource = dt;
            cboLanhDao.DisplayMember = "TenNguoiDung";   // hoặc TenNguoiDung
            cboLanhDao.ValueMember = "MaNguoiDung";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            formCongVanDenCreate f = new formCongVanDenCreate();
            f.ShowDialog();
            LoadData();
        }

        private void btnTrinh_Click(object sender, EventArgs e)
        {
            int congVanId = GetSelectedId();
            if (congVanId == -1) return;

            string lanhDaoId = cboLanhDao.SelectedValue.ToString();
            string nguoiTrinhId = Session.UserId;

            bool result = TrinhLanhDaoBLL.Instance.Trinh(congVanId, nguoiTrinhId, lanhDaoId);

            MessageBox.Show(result ? "Trình thành công!" : "Lỗi!");
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0) return;

            string tt = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            btnTrinh.Enabled = tt == DTO.TrangThaiCongVanDen.DA_NHAP;
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
    }
}

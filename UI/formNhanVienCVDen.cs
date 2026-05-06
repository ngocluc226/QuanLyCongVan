using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class formNhanVienCVDen : Form
    {
        public formNhanVienCVDen()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvCongVan.DataSource =
                BLL.CongVanDenBLL.Instance.GetByTrangThai(DTO.TrangThaiCongVanDen.DA_PHAN_CONG);
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
        private void btnXuLy_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            BLL.CongVanDenBLL.Instance.CapNhatXuLy(id, DTO.TrangThaiCongVanDen.DANG_XU_LY);

            LoadData();
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            BLL.CongVanDenBLL.Instance.HoanThanh(id);

            LoadData();
        }
    }
}

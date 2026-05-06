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
    public partial class formVanThuCVDen : Form
    {
        public formVanThuCVDen()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetAll();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            formCongVanDenCreate f = new formCongVanDenCreate();
            f.ShowDialog();
            LoadData();
        }

        private void btnTrinh_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            var result = BLL.CongVanDenBLL.Instance.TrinhLanhDao(id);

            if (result)
            {
                MessageBox.Show("Đã trình!");
                LoadData();
            }
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0) return;

            string tt = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            btnTrinh.Enabled = tt == DTO.TrangThaiCongVanDen.DA_NHAP;
        }
    }
}

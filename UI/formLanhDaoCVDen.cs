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
    public partial class formLanhDaoCVDen : Form
    {
        public formLanhDaoCVDen()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvCongVan.DataSource =
                BLL.CongVanDenBLL.Instance.GetByTrangThai(DTO.TrangThaiCongVanDen.DA_TRINH);
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
        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            formPhanCong f = new formPhanCong(id);
            f.ShowDialog();

            LoadData();
        }
    }
}

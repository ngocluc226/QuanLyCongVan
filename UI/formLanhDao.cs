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
    public partial class formLanhDao : Form
    {
        public formLanhDao()
        {
            InitializeComponent();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Utils.Logout(this);
        }

        private void btnCVDen_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formLanhDaoCVDen(), pnlContent);
        }

        private void btnCVDi_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formLanhDaoCVDi(), pnlContent);
        }

        private void formLanhDao_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Đếm số lượng công văn đang chờ duyệt
            DataTable dt = BLL.CongVanDiBLL.Instance.GetAll();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "TrangThai = 'Chờ duyệt'";
            int count = dv.Count;

            if (count > 0)
            {
                MessageBox.Show($"Bạn có {count} công văn đi đang chờ phê duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

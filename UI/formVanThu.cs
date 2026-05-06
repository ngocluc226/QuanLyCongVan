using DAL;
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
    public partial class formVanThu : Form
    {
        public formVanThu()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Utils.Logout(this);
        }

        private void btnCVDen_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formVanThuCVDen(), pnlContent);
        }

        private void btnCVDi_Click(object sender, EventArgs e)
        {
           Utils.LoadForm(new formVanThuCVDi(), pnlContent);
        }

        private void formVanThu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

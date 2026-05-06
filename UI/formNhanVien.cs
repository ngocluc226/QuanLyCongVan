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
    public partial class formNhanVien : Form
    {
        public formNhanVien()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Utils.Logout(this);
        }

        private void btnCVDen_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formNhanVienCVDen(), pnlContent);
        }

        private void btnCVDi_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formNhanVienCVDi(), pnlContent);
        }

        private void formNhanVien_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

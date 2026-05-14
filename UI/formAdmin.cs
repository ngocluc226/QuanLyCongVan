using DAL;
using DTO;
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
    public partial class formAdmin : Form
    {
        public formAdmin()
        {
            InitializeComponent();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formQuanLyUser(), pnlContent);
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formPhongBan(), pnlContent);
        }

        private void btnCongVan_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formCongVanDenList(), pnlContent);
        }


        private void btnLog_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formLogHethong(), pnlContent);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Utils.Logout(this);
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnCongVanDi_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(new formCongVanDiList(), pnlContent);
        }
    }
}

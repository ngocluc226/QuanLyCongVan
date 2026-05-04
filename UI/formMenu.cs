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
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void btnCVDENCreate_Click(object sender, EventArgs e)
        {
            formCongVanDenCreate f = new formCongVanDenCreate();
            f.Show();
        }

        private void btnCVDENList_Click(object sender, EventArgs e)
        {
            formCongVanDenList f = new formCongVanDenList();
            f.Show();
        }

        private void btnCVDICreate_Click(object sender, EventArgs e)
        {
            formCongVanDiCreate f = new formCongVanDiCreate();
            f.Show();
        }

        private void btnCVDiList_Click(object sender, EventArgs e)
        {
            formCongVanDiList f = new formCongVanDiList();
            f.Show();
        }
    }
}

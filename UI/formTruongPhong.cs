using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class formTruongPhong : Form
    {
        public formTruongPhong()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            // Events
            btnCVDen.Click += (s, e) => Utils.LoadForm(new formTruongPhongCVDen(), pnlContent);
            btnCVDi.Click += (s, e) => Utils.LoadForm(new formTruongPhongCVDi(), pnlContent);
            btnLogout.Click += (s, e) => Utils.Logout(this);

            // Default load
            this.Load += (s, e) => Utils.LoadForm(new formTruongPhongCVDen(), pnlContent);
        }
    }
}

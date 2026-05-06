using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class formPhanCong : Form
    {
        private int _congVanId;

        public formPhanCong(int congVanId)
        {
            InitializeComponent();
            _congVanId = congVanId;
        }

        private void formPhanCong_Load(object sender, EventArgs e)
        {
            cbUser.DataSource = BLL.UserService.Instance.GetAllUsers();
            cbUser.DisplayMember = "TenNguoiDung";
            cbUser.ValueMember = "MaNguoiDung";

            cbPhongBan.DataSource = BLL.PhongBanBLL.Instance.GetAll();
            cbPhongBan.DisplayMember = "TenPhongBan";
            cbPhongBan.ValueMember = "MaPhongBan";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string user = cbUser.SelectedValue?.ToString();
            string pb = cbPhongBan.SelectedValue?.ToString();
            string yKien = txtYKien.Text;

            var result = BLL.CongVanDenBLL.Instance.PhanCong(_congVanId, user, pb, yKien);

            if (result)
            {
                LogBLL.Instance.WriteLog("Phân công công văn", Session.UserName);
                MessageBox.Show("Phân công thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thất bại!");
            }
        }
    }
}

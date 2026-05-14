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
            cbPhongBan.DataSource = PhongBanBLL.Instance.GetAll();
            cbPhongBan.DisplayMember = "TenPhongBan";
            cbPhongBan.ValueMember = "MaPhongBan";

            cbPhongBan.SelectedIndexChanged += CbPhongBan_SelectedIndexChanged;

            // 🎯 PHÂN QUYỀN
            if (Session.IsTruongPhong)
            {
                // Trưởng phòng
                rdPhongBan.Visible = false;
                rdCaNhan.Visible = false;

                cbPhongBan.SelectedValue = Session.PhongBan;
                cbPhongBan.Enabled = false;

                LoadUsersByPhongBan(Session.PhongBan);
            }
            else if (Session.IsLanhDao)
            {
                // Lãnh đạo
                rdPhongBan.Checked = true;
                cbUser.Enabled = false; // mặc định giao phòng
            }

            // load user lần đầu
            if (cbPhongBan.SelectedValue != null)
            {
                LoadUsersByPhongBan(cbPhongBan.SelectedValue.ToString());
            }
        }

        private void CbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhongBan.SelectedValue == null) return;

            LoadUsersByPhongBan(cbPhongBan.SelectedValue.ToString());
        }

        private void LoadUsersByPhongBan(string maPhongBan)
        {
            if (string.IsNullOrEmpty(maPhongBan))
            {
                cbUser.DataSource = null;
                return;
            }

            var dt = UserService.Instance.GetByPhongBan(maPhongBan);

            cbUser.DataSource = dt;
            cbUser.DisplayMember = "TenNguoiDung";
            cbUser.ValueMember = "MaNguoiDung";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string user = null;
            string pb = null;
            string yKien = txtYKien.Text;

            if (Session.IsTruongPhong)
            {
                // chỉ giao user trong phòng mình
                user = cbUser.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(user))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên");
                    return;
                }
            }
            else if (Session.IsLanhDao)
            {
                if (rdPhongBan.Checked)
                {
                    pb = cbPhongBan.SelectedValue?.ToString();

                    if (string.IsNullOrEmpty(pb))
                    {
                        MessageBox.Show("Vui lòng chọn phòng ban");
                        return;
                    }
                }
                else if (rdCaNhan.Checked)
                {
                    pb = cbPhongBan.SelectedValue?.ToString();
                    user = cbUser.SelectedValue?.ToString();

                    if (string.IsNullOrEmpty(user))
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên");
                        return;
                    }
                }
            }

            var result = CongVanDenBLL.Instance.PhanCong(_congVanId, user, pb, yKien);

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

        private void rdPhongBan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPhongBan.Checked)
            {
                cbUser.Enabled = false;
            }
        }

        private void rdCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCaNhan.Checked)
            {
                cbUser.Enabled = true;

                if (cbPhongBan.SelectedValue != null)
                {
                    LoadUsersByPhongBan(cbPhongBan.SelectedValue.ToString());
                }
            }
        }

        private void cbPhongBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbPhongBan.SelectedValue == null) return;

            if (Session.IsLanhDao && rdCaNhan.Checked)
            {
                LoadUsersByPhongBan(cbPhongBan.SelectedValue.ToString());
            }
        }
    }
}

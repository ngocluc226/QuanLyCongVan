using BLL;
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
    public partial class formPhongBan : Form
    {
        private bool isAdd = false;
        public formPhongBan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvPhongBan.DataSource = BLL.PhongBanBLL.Instance.GetAll();
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMa.Text = dgvPhongBan.Rows[e.RowIndex].Cells["MaPhongBan"].Value.ToString();
            txtTen.Text = dgvPhongBan.Rows[e.RowIndex].Cells["TenPhongBan"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtMa.Clear();
            txtTen.Clear();
            txtMa.Enabled = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            txtMa.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Nhập đầy đủ!");
                return;
            }

            bool result;

            if (isAdd)
                result = BLL.PhongBanBLL.Instance.Insert(ma, ten);
            else
                result = BLL.PhongBanBLL.Instance.Update(ma, ten);

            if (result)
            {
                MessageBox.Show("Thành công!");
                LoadData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;

            if (MessageBox.Show("Xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (BLL.PhongBanBLL.Instance.Delete(ma))
            {
                LogBLL.Instance.WriteLog("Xóa phòng ban: " + ma, Session.UserName);
                MessageBox.Show("Đã xóa!");
                LoadData();
            }
        }
    }
}

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
        public formPhongBan()
        {
            InitializeComponent();
            Utils.FormatDataGridView(dgvPhongBan);
            Utils.SyncAllButtons(this);
            LoadData();
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
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Nh?p d?y d?!");
                return;
            }

            bool result;
            bool doInsert = txtMa.Enabled; 

            if (doInsert)
                result = BLL.PhongBanBLL.Instance.Insert(ma, ten);
            else
                result = BLL.PhongBanBLL.Instance.Update(ma, ten);

            if (result)
            {
                MessageBox.Show("Th�nh c�ng!");
                LoadData();

                txtMa.Enabled = true;
                txtMa.Clear();
                txtTen.Clear();
                txtMa.Focus();
                // isAdd = false;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPhongBan.CurrentRow == null)
            {
                MessageBox.Show("Ch?n ph�ng ban c?n s?a");
                return;
            }

            txtMa.Enabled = false;
            txtTen.Focus();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;

            if (MessageBox.Show("X�a?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (BLL.PhongBanBLL.Instance.Delete(ma))
            {
                LogBLL.Instance.WriteLog("X�a ph�ng ban: " + ma, Session.UserName);
                MessageBox.Show("�� x�a!");
                LoadData();
            }
        }
    }
}

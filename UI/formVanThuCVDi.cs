using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class formVanThuCVDi : Form
    {
        private DataGridView dtgDanhSach;
        private Button btnPhatHanh;
        private TextBox txtNoiNhan;
        private Label lblNoiNhan;
        private DateTimePicker dtpNgayPhatHanh;
        private Label lblNgayPhatHanh;

        public formVanThuCVDi()
        {
            InitializeComponent();
            InitUI();
            this.Load += FormVanThuCVDi_Load;
        }

        private void InitUI()
        {
            this.dtgDanhSach = new DataGridView();
            this.dtgDanhSach.Location = new Point(12, 12);
            this.dtgDanhSach.Size = new Size(760, 300);
            this.dtgDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgDanhSach.AllowUserToAddRows = false;
            this.dtgDanhSach.CellClick += DtgDanhSach_CellClick;
            this.Controls.Add(this.dtgDanhSach);

            this.lblNgayPhatHanh = new Label { Text = "Ngày phát hành:", Location = new Point(12, 335), AutoSize = true };
            this.Controls.Add(this.lblNgayPhatHanh);

            this.dtpNgayPhatHanh = new DateTimePicker { Location = new Point(110, 332), Width = 150 };
            this.Controls.Add(this.dtpNgayPhatHanh);

            this.lblNoiNhan = new Label { Text = "Nơi nhận:", Location = new Point(280, 335), AutoSize = true };
            this.Controls.Add(this.lblNoiNhan);

            this.txtNoiNhan = new TextBox { Location = new Point(340, 332), Width = 200 };
            this.Controls.Add(this.txtNoiNhan);

            this.btnPhatHanh = new Button { Text = "Phát hành", Location = new Point(560, 330) };
            this.btnPhatHanh.Click += BtnPhatHanh_Click;
            this.Controls.Add(this.btnPhatHanh);
        }

        private void FormVanThuCVDi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = CongVanDiBLL.Instance.GetAll();
            DataView dv = dt.DefaultView;
            // Chỉ thấy những công văn Đã duyệt
            dv.RowFilter = "TrangThai = 'Đã duyệt'"; 
            this.dtgDanhSach.DataSource = dv;
        }

        private void DtgDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgDanhSach.Rows[e.RowIndex];
                txtNoiNhan.Text = row.Cells["NoiNhan"].Value?.ToString();
                if (row.Cells["NgayBanHanh"].Value != DBNull.Value && row.Cells["NgayBanHanh"].Value != null)
                {
                    dtpNgayPhatHanh.Value = Convert.ToDateTime(row.Cells["NgayBanHanh"].Value);
                }
            }
        }

        private void BtnPhatHanh_Click(object sender, EventArgs e)
        {
            if (this.dtgDanhSach.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(this.dtgDanhSach.SelectedRows[0].Cells["Id"].Value);

            DateTime ngayBanHanh = dtpNgayPhatHanh.Value;
            string noiNhan = txtNoiNhan.Text.Trim();

            bool kq = CongVanDiBLL.Instance.UpdatePhatHanh(id, ngayBanHanh, noiNhan);
            if (kq)
            {
                MessageBox.Show("Phát hành công văn thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }
    }
}

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
        private Button btnThem;
        private Button btnTrinh;
        private Button btnSua;
        private Button btnXoa;
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
            this.dtgDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDanhSach.CellClick += DtgDanhSach_CellClick;
            this.dtgDanhSach.ReadOnly = true;
            this.Controls.Add(this.dtgDanhSach);

            // Nút Thêm mới
            this.btnThem = new Button { Text = "Thêm mới", Location = new Point(12, 370), Width = 100, Height = 30, BackColor = Color.LightBlue, FlatStyle = FlatStyle.Flat };
            this.btnThem.Click += (s, e) => {
                formCongVanDiCreate f = new formCongVanDiCreate();
                f.ShowDialog();
                LoadData();
            };
            this.Controls.Add(this.btnThem);

            // Nút Sửa
            this.btnSua = new Button { Text = "Sửa", Location = new Point(120, 370), Width = 100, Height = 30, BackColor = Color.LightYellow, FlatStyle = FlatStyle.Flat };
            this.btnSua.Click += (s, e) => SuaCongVan();
            this.Controls.Add(this.btnSua);

            // Nút Xóa
            this.btnXoa = new Button { Text = "Xóa", Location = new Point(230, 370), Width = 100, Height = 30, BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            this.btnXoa.Click += (s, e) => XoaCongVan();
            this.Controls.Add(this.btnXoa);

            // Nút Trình
            this.btnTrinh = new Button { Text = "Trình lãnh đạo", Location = new Point(340, 370), Width = 120, Height = 30, BackColor = Color.LightGreen, FlatStyle = FlatStyle.Flat };
            this.btnTrinh.Click += (s, e) => TrinhLanhDao();
            this.Controls.Add(this.btnTrinh);

            this.lblNgayPhatHanh = new Label { Text = "Ngày phát hành:", Location = new Point(12, 335), AutoSize = true };
            this.Controls.Add(this.lblNgayPhatHanh);

            this.dtpNgayPhatHanh = new DateTimePicker { Location = new Point(110, 332), Width = 150 };
            this.Controls.Add(this.dtpNgayPhatHanh);

            this.lblNoiNhan = new Label { Text = "Nơi nhận:", Location = new Point(280, 335), AutoSize = true };
            this.Controls.Add(this.lblNoiNhan);

            this.txtNoiNhan = new TextBox { Location = new Point(340, 332), Width = 200 };
            this.Controls.Add(this.txtNoiNhan);

            this.btnPhatHanh = new Button { Text = "Phát hành", Location = new Point(560, 330), Width = 100, Height = 30, BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
            this.btnPhatHanh.Click += BtnPhatHanh_Click;
            this.Controls.Add(this.btnPhatHanh);
        }

        private void SuaCongVan()
        {
            if (dtgDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dtgDanhSach.SelectedRows[0].Cells["Id"].Value);
            string tt = dtgDanhSach.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (tt == "Đã phát hành" || tt == "Đã duyệt")
            {
                MessageBox.Show("Không thể sửa công văn đã được duyệt hoặc phát hành!");
                return;
            }

            formCongVanDiCreate f = new formCongVanDiCreate(id);
            f.ShowDialog();
            LoadData();
        }

        private void XoaCongVan()
        {
            if (dtgDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dtgDanhSach.SelectedRows[0].Cells["Id"].Value);
            string tt = dtgDanhSach.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (tt == "Đã phát hành" || tt == "Đã duyệt")
            {
                MessageBox.Show("Không thể xóa công văn đã được duyệt hoặc phát hành!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CongVanDiBLL.Instance.Delete(id))
                {
                    MessageBox.Show("Đã xóa!");
                    LoadData();
                }
            }
        }

        private void TrinhLanhDao()
        {
            if (this.dtgDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(this.dtgDanhSach.SelectedRows[0].Cells["Id"].Value);
            string trangThai = this.dtgDanhSach.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (trangThai != "Soạn thảo" && trangThai != "Yêu cầu chỉnh sửa" && trangThai != "Bị từ chối")
            {
                MessageBox.Show("Chỉ trình các bản soạn thảo, yêu cầu sửa hoặc bị từ chối!");
                return;
            }

            if (CongVanDiBLL.Instance.UpdateTrangThai(id, "Chờ duyệt"))
            {
                MessageBox.Show("Đã trình!");
                LoadData();
            }
        }

        private void FormVanThuCVDi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = CongVanDiBLL.Instance.GetAll();
            this.dtgDanhSach.DataSource = dt;
            if (dtgDanhSach.Columns["Id"] != null) dtgDanhSach.Columns["Id"].Visible = false;
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

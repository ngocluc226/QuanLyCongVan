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
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblTimKiem;

        public formVanThuCVDi()
        {
            InitializeComponent();
            InitUI();
            this.Load += FormVanThuCVDi_Load;
        }

        private void InitUI()
        {
            this.Text = "VĂN THƯ - PHÁT HÀNH CÔNG VĂN ĐI";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Group lọc và tìm kiếm
            GroupBox gbFilter = new GroupBox { Text = "Bộ lọc & Tìm kiếm", Location = new Point(12, 10), Size = new Size(1060, 70) };
            this.Controls.Add(gbFilter);

            lblTuNgay = new Label { Text = "Từ ngày:", Location = new Point(15, 30), AutoSize = true };
            dtpTuNgay = new DateTimePicker { Location = new Point(75, 27), Width = 110, Format = DateTimePickerFormat.Short };
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            
            lblDenNgay = new Label { Text = "Đến ngày:", Location = new Point(195, 30), AutoSize = true };
            dtpDenNgay = new DateTimePicker { Location = new Point(260, 27), Width = 110, Format = DateTimePickerFormat.Short };
            
            lblTimKiem = new Label { Text = "Tìm kiếm:", Location = new Point(385, 30), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(445, 27), Width = 200 };
            
            btnTimKiem = new Button { Text = "Lọc", Location = new Point(660, 24), Width = 80, Height = 30 };
            btnTimKiem.Click += (s, e) => LoadData();

            gbFilter.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, lblTimKiem, txtTimKiem, btnTimKiem });

            this.dtgDanhSach = new DataGridView();
            this.dtgDanhSach.Location = new Point(12, 90);
            this.dtgDanhSach.Size = new Size(1060, 320);
            this.dtgDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgDanhSach.AllowUserToAddRows = false;
            this.dtgDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDanhSach.CellClick += DtgDanhSach_CellClick;
            this.dtgDanhSach.ReadOnly = true;
            this.dtgDanhSach.BackgroundColor = Color.White;
            this.Controls.Add(this.dtgDanhSach);

            // Group thao tác phát hành
            GroupBox gbPhatHanh = new GroupBox { Text = "Thông tin Phát hành", Location = new Point(12, 420), Size = new Size(1060, 100) };
            this.Controls.Add(gbPhatHanh);

            this.lblNgayPhatHanh = new Label { Text = "Ngày phát hành:", Location = new Point(15, 40), AutoSize = true };
            gbPhatHanh.Controls.Add(this.lblNgayPhatHanh);

            this.dtpNgayPhatHanh = new DateTimePicker { Location = new Point(120, 37), Width = 150 };
            gbPhatHanh.Controls.Add(this.dtpNgayPhatHanh);

            this.lblNoiNhan = new Label { Text = "Nơi nhận chính thức:", Location = new Point(300, 40), AutoSize = true };
            gbPhatHanh.Controls.Add(this.lblNoiNhan);

            this.txtNoiNhan = new TextBox { Location = new Point(420, 37), Width = 300 };
            gbPhatHanh.Controls.Add(this.txtNoiNhan);

            this.btnPhatHanh = new Button { Text = "XÁC NHẬN PHÁT HÀNH", Location = new Point(750, 32), Width = 180, Height = 40, BackColor = Color.DarkBlue, ForeColor = Color.White, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            this.btnPhatHanh.Click += BtnPhatHanh_Click;
            gbPhatHanh.Controls.Add(this.btnPhatHanh);

            // Các nút chức năng khác
            this.btnThem = new Button { Text = "Thêm mới", Location = new Point(12, 540), Width = 120, Height = 40, BackColor = Color.LightBlue, FlatStyle = FlatStyle.Flat };
            this.btnThem.Click += (s, e) => {
                formCongVanDiCreate f = new formCongVanDiCreate();
                f.ShowDialog();
                LoadData();
            };
            this.Controls.Add(this.btnThem);

            this.btnSua = new Button { Text = "Sửa CV", Location = new Point(140, 540), Width = 120, Height = 40, BackColor = Color.LightYellow, FlatStyle = FlatStyle.Flat };
            this.btnSua.Click += (s, e) => SuaCongVan();
            this.Controls.Add(this.btnSua);

            this.btnXoa = new Button { Text = "Xóa CV", Location = new Point(270, 540), Width = 120, Height = 40, BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            this.btnXoa.Click += (s, e) => XoaCongVan();
            this.Controls.Add(this.btnXoa);

            this.btnTrinh = new Button { Text = "Trình Lãnh Đạo", Location = new Point(400, 540), Width = 140, Height = 40, BackColor = Color.LightGreen, FlatStyle = FlatStyle.Flat };
            this.btnTrinh.Click += (s, e) => TrinhLanhDao();
            this.Controls.Add(this.btnTrinh);
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
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            string keyword = txtTimKiem.Text.Trim().ToLower();

            DataTable dt = CongVanDiBLL.Instance.GetByDateRange(tuNgay, denNgay);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("SoDi LIKE '%{0}%' OR SoVanBan LIKE '%{0}%' OR TrichYeu LIKE '%{0}%' OR NguoiKy LIKE '%{0}%' OR TrangThai LIKE '%{0}%'", keyword);
                this.dtgDanhSach.DataSource = dv.ToTable();
            }
            else
            {
                this.dtgDanhSach.DataSource = dt;
            }

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
            int id = Convert.ToInt32(this.dtgDanhSach.SelectedRows[0].Cells["Id"].Value);
            string trangThaiHienTai = this.dtgDanhSach.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (trangThaiHienTai != "Đã duyệt")
            {
                MessageBox.Show("Chỉ có thể phát hành các công văn đã được lãnh đạo phê duyệt!");
                return;
            }

            DateTime ngayBanHanh = dtpNgayPhatHanh.Value;
            string noiNhan = txtNoiNhan.Text.Trim();

            bool kq = CongVanDiBLL.Instance.UpdatePhatHanh(id, ngayBanHanh, noiNhan);
            if (kq)
            {
                CongVanDiBLL.Instance.UpdateTrangThai(id, "Đã phát hành");
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

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

namespace UI
{
    public partial class formLanhDaoCVDi : Form
    {
        private DataGridView dtgDanhSach;
        private Button btnDuyet;
        private Button btnTuChoi;
        private Button btnYeuCauSua;
        private TextBox txtGhiChu;
        private Label lblGhiChu;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblTimKiem;

        public formLanhDaoCVDi()
        {
            InitializeComponent();
            InitUI();
            this.Load += FormLanhDaoCVDi_Load;
        }

        private void InitUI()
        {
            this.Text = "LÃNH ĐẠO - PHÊ DUYỆT CÔNG VĂN";
            this.Size = new Size(1100, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Group lọc và tìm kiếm
            GroupBox gbFilter = new GroupBox { Text = "Bộ lọc & Tìm kiếm", Location = new Point(12, 10), Size = new Size(1060, 70) };
            this.Controls.Add(gbFilter);

            lblTuNgay = new Label { Text = "Từ ngày:", Location = new Point(15, 30), AutoSize = true };
            dtpTuNgay = new DateTimePicker { Location = new Point(75, 27), Width = 110, Format = DateTimePickerFormat.Short };
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            
            lblDenNgay = new Label { Text = "Đến ngày:", Location = new Point(195, 30), AutoSize = true };
            dtpDenNgay = new DateTimePicker { Location = new Point(260, 27), Width = 110, Format = DateTimePickerFormat.Short };
            
            lblTimKiem = new Label { Text = "Từ khóa:", Location = new Point(385, 30), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(445, 27), Width = 200 };
            
            btnTimKiem = new Button { Text = "Lọc dữ liệu", Location = new Point(660, 24), Width = 100, Height = 30 };
            btnTimKiem.Click += (s, e) => LoadData();

            gbFilter.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, lblTimKiem, txtTimKiem, btnTimKiem });

            this.dtgDanhSach = new DataGridView();
            this.dtgDanhSach.Location = new Point(12, 90);
            this.dtgDanhSach.Size = new Size(1060, 320);
            this.dtgDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgDanhSach.AllowUserToAddRows = false;
            this.dtgDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDanhSach.BackgroundColor = Color.White;
            this.dtgDanhSach.ReadOnly = true;
            this.Controls.Add(this.dtgDanhSach);

            // Group Thao tác
            GroupBox gbAction = new GroupBox { Text = "Xử lý Công văn", Location = new Point(12, 420), Size = new Size(1060, 100) };
            this.Controls.Add(gbAction);

            this.lblGhiChu = new Label { Text = "Ghi chú/Lý do:", Location = new Point(15, 40), AutoSize = true };
            gbAction.Controls.Add(this.lblGhiChu);

            this.txtGhiChu = new TextBox { Location = new Point(110, 37), Width = 400 };
            gbAction.Controls.Add(this.txtGhiChu);

            this.btnDuyet = new Button { Text = "PHÊ DUYỆT", Location = new Point(530, 32), Width = 120, Height = 40, BackColor = Color.Green, ForeColor = Color.White, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            this.btnDuyet.Click += BtnDuyet_Click;
            gbAction.Controls.Add(this.btnDuyet);

            this.btnYeuCauSua = new Button { Text = "Y/C SỬA LẠI", Location = new Point(660, 32), Width = 120, Height = 40, BackColor = Color.Orange, ForeColor = Color.Black, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            this.btnYeuCauSua.Click += BtnYeuCauSua_Click;
            gbAction.Controls.Add(this.btnYeuCauSua);

            this.btnTuChoi = new Button { Text = "TỪ CHỐI", Location = new Point(790, 32), Width = 120, Height = 40, BackColor = Color.Red, ForeColor = Color.White, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            this.btnTuChoi.Click += BtnTuChoi_Click;
            gbAction.Controls.Add(this.btnTuChoi);
        }

        private void FormLanhDaoCVDi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            string keyword = txtTimKiem.Text.Trim().ToLower();

            DataTable dt = CongVanDiBLL.Instance.GetByDateRange(tuNgay, denNgay);
            DataView dv = dt.DefaultView;
            
            // Lọc các CV đang chờ duyệt
            string filter = "TrangThai = 'Chờ duyệt'";
            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (SoDi LIKE '%{0}%' OR SoVanBan LIKE '%{0}%' OR TrichYeu LIKE '%{0}%')", keyword);
            }
            dv.RowFilter = filter;
            
            this.dtgDanhSach.DataSource = dv.ToTable();
            if (dtgDanhSach.Columns["Id"] != null) dtgDanhSach.Columns["Id"].Visible = false;
        }

        private void BtnDuyet_Click(object sender, EventArgs e)
        {
            UpdateTrangThaiCV("Đã duyệt");
        }

        private void BtnTuChoi_Click(object sender, EventArgs e)
        {
            UpdateTrangThaiCV("Bị từ chối");
        }

        private void BtnYeuCauSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do yêu cầu chỉnh sửa!");
                return;
            }
            UpdateTrangThaiCV("Yêu cầu chỉnh sửa");
        }

        private void UpdateTrangThaiCV(string trangThai)
        {
            if (this.dtgDanhSach.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(this.dtgDanhSach.SelectedRows[0].Cells["Id"].Value);
            bool kq = CongVanDiBLL.Instance.UpdateTrangThai(id, trangThai, txtGhiChu.Text);
            if (kq)
            {
                MessageBox.Show($"Đã cập nhật trạng thái CV thành {trangThai}");
                LoadData();
                txtGhiChu.Clear();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }
    }
}

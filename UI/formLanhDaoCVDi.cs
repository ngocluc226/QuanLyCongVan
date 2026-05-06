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

        public formLanhDaoCVDi()
        {
            InitializeComponent();
            InitUI();
            this.Load += FormLanhDaoCVDi_Load;
        }

        private void InitUI()
        {
            this.dtgDanhSach = new DataGridView();
            this.dtgDanhSach.Location = new Point(12, 12);
            this.dtgDanhSach.Size = new Size(760, 300);
            this.dtgDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgDanhSach.AllowUserToAddRows = false;
            this.Controls.Add(this.dtgDanhSach);

            this.btnDuyet = new Button { Text = "Phê duyệt", Location = new Point(12, 330) };
            this.btnDuyet.Click += BtnDuyet_Click;
            this.Controls.Add(this.btnDuyet);

            this.btnTuChoi = new Button { Text = "Từ chối", Location = new Point(100, 330) };
            this.btnTuChoi.Click += BtnTuChoi_Click;
            this.Controls.Add(this.btnTuChoi);

            this.btnYeuCauSua = new Button { Text = "Y/C chỉnh sửa", Location = new Point(188, 330) };
            this.btnYeuCauSua.Click += BtnYeuCauSua_Click;
            this.Controls.Add(this.btnYeuCauSua);

            this.lblGhiChu = new Label { Text = "Ghi chú/Lý do:", Location = new Point(300, 335), AutoSize = true };
            this.Controls.Add(this.lblGhiChu);

            this.txtGhiChu = new TextBox { Location = new Point(390, 332), Width = 300 };
            this.Controls.Add(this.txtGhiChu);
        }

        private void FormLanhDaoCVDi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = CongVanDiBLL.Instance.GetAll();
            DataView dv = dt.DefaultView;
            // Lọc ra các công văn chờ duyệt
            dv.RowFilter = "TrangThai = 'Chờ duyệt'"; 
            // Cần lọc theo userId nữa tuy nhiên hiện tại session giả định
            this.dtgDanhSach.DataSource = dv;
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

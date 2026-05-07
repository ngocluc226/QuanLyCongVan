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
    public partial class formNhanVienCVDi : Form
    {
        private DataGridView dgvCVDi;
        private Button btnThem;
        private Button btnTrinh;
        private Button btnSua;
        private Button btnXoa;

        public formNhanVienCVDi()
        {
            InitializeComponent();
            InitUI();
            this.Load += (s, e) => LoadData();
        }

        private void InitUI()
        {
            // Thiết kế bảng danh sách
            dgvCVDi = new DataGridView 
            { 
                Location = new Point(10, 10), 
                Size = new Size(780, 350), 
                SelectionMode = DataGridViewSelectionMode.FullRowSelect, 
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true
            };
            this.Controls.Add(dgvCVDi);

            // Nút Thêm mới
            btnThem = new Button { Text = "Thêm mới", Location = new Point(10, 370), Width = 100, Height = 35, BackColor = Color.LightBlue, FlatStyle = FlatStyle.Flat };
            btnThem.Click += (s, e) => {
                formCongVanDiCreate f = new formCongVanDiCreate();
                f.ShowDialog();
                LoadData();
            };
            this.Controls.Add(btnThem);

            // Nút Sửa
            btnSua = new Button { Text = "Sửa", Location = new Point(120, 370), Width = 100, Height = 35, BackColor = Color.LightYellow, FlatStyle = FlatStyle.Flat };
            btnSua.Click += (s, e) => SuaCongVan();
            this.Controls.Add(btnSua);

            // Nút Xóa
            btnXoa = new Button { Text = "Xóa", Location = new Point(230, 370), Width = 100, Height = 35, BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat };
            btnXoa.Click += (s, e) => XoaCongVan();
            this.Controls.Add(btnXoa);

            // Nút Trình lãnh đạo
            btnTrinh = new Button { Text = "Trình lãnh đạo", Location = new Point(340, 370), Width = 130, Height = 35, BackColor = Color.LightGreen, FlatStyle = FlatStyle.Flat };
            btnTrinh.Click += (s, e) => TrinhLanhDao();
            this.Controls.Add(btnTrinh);
        }

        private void LoadData()
        {
            DataTable dt = CongVanDiBLL.Instance.GetAll();
            dgvCVDi.DataSource = dt;
            if (dgvCVDi.Columns["Id"] != null) dgvCVDi.Columns["Id"].Visible = false;
        }

        private void SuaCongVan()
        {
            if (dgvCVDi.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCVDi.SelectedRows[0].Cells["Id"].Value);
            string tt = dgvCVDi.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

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
            if (dgvCVDi.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvCVDi.SelectedRows[0].Cells["Id"].Value);
            string tt = dgvCVDi.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (tt == "Đã phát hành" || tt == "Đã duyệt")
            {
                MessageBox.Show("Không thể xóa công văn đã được duyệt hoặc phát hành!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa công văn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            if (dgvCVDi.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvCVDi.SelectedRows[0];
            string trangThai = row.Cells["TrangThai"].Value?.ToString();
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            if (trangThai != "Soạn thảo" && trangThai != "Yêu cầu chỉnh sửa" && trangThai != "Bị từ chối")
            {
                MessageBox.Show("Chỉ có thể trình các công văn đang ở trạng thái 'Soạn thảo', 'Yêu cầu chỉnh sửa' hoặc 'Bị từ chối'!");
                return;
            }

            if (MessageBox.Show("Trình công văn này lên lãnh đạo?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CongVanDiBLL.Instance.UpdateTrangThai(id, "Chờ duyệt"))
                {
                    MessageBox.Show("Đã trình lãnh đạo thành công!");
                    LoadData();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class formCongVanDenList : Form
    {
        public formCongVanDenList()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            DataTable dt = BLL.CongVanDenBLL.Instance.GetAll();

            dgvVanBan.DataSource = dt;

            lblTong.Text = "Tổng: " + dt.Rows.Count.ToString();
        }
        private void InitDataGridView()
        {
            dgvVanBan.AutoGenerateColumns = false;
            dgvVanBan.Columns.Clear();

            // Cho phép chọn nhiều dòng
            dgvVanBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVanBan.MultiSelect = true;

            // Id (ẩn)
            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoDen",
                HeaderText = "Số đến",
                DataPropertyName = "SoDen"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoVanBan",
                HeaderText = "Số văn bản",
                DataPropertyName = "SoVanBan"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayDen",
                HeaderText = "Ngày đến",
                DataPropertyName = "NgayDen",
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayBanHanh",
                HeaderText = "Ngày ban hành",
                DataPropertyName = "NgayBanHanh",
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NoiGui",
                HeaderText = "Nơi gửi",
                DataPropertyName = "NoiGui"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NguoiKy",
                HeaderText = "Người ký",
                DataPropertyName = "NguoiKy"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Trích yếu",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoKhan",
                HeaderText = "Độ khẩn",
                DataPropertyName = "DoKhan"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoMat",
                HeaderText = "Độ mật",
                DataPropertyName = "DoMat"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FileDinhKem",
                HeaderText = "File",
                DataPropertyName = "FileDinhKem"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayTao",
                HeaderText = "Ngày tạo",
                DataPropertyName = "NgayTao",
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });
        }

        private void formCongVanDenList_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVanBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa các công văn đã chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No) return;

            int success = 0;

            foreach (DataGridViewRow row in dgvVanBan.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);

                if (BLL.CongVanDenBLL.Instance.Delete(id))
                {
                    success++;
                }
            }

            MessageBox.Show($"Đã xóa {success} công văn!");

            LoadData();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            // Fix lỗi mất dữ liệu trong ngày cuối
            toDate = toDate.AddDays(1).AddSeconds(-1);

            if (fromDate > toDate)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày!");
                return;
            }

            DataTable dt = BLL.CongVanDenBLL.Instance.GetByDateRange(fromDate, toDate);

            dgvVanBan.DataSource = dt;

            lblTong.Text = "Tổng: " + dt.Rows.Count.ToString();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvVanBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn!");
                return;
            }

            string path = dgvVanBan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Không có file!");
                return;
            }

            // Nếu bạn lưu relative path
            string fullPath = Path.Combine(Application.StartupPath, path);

            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }
    }
}

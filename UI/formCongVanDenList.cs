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
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;
        public formCongVanDenList()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            DataTable dt = BLL.CongVanDenBLL.Instance.GetPaged(currentPage, pageSize);
            dgvVanBan.DataSource = dt;

            int totalRows = BLL.CongVanDenBLL.Instance.GetTotalCount();
            totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
            if (totalPages == 0) totalPages = 1;

            lblPageInfo.Text = $"{currentPage}/{totalPages}";
            lblTong.Text = "Tổng số dòng: " + totalRows.ToString();

            btnPrev.Enabled = (currentPage > 1);
            btnNext.Enabled = (currentPage < totalPages);
        }
        private void InitDataGridView()
        {
            dgvVanBan.AutoGenerateColumns = false;
            dgvVanBan.Columns.Clear();

            dgvVanBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVanBan.MultiSelect = true;
            dgvVanBan.AllowUserToAddRows = false;

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
                DataPropertyName = "SoDen",
                Width = 80
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoVanBan",
                HeaderText = "Số văn bản",
                DataPropertyName = "SoVanBan",
                Width = 110
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayDen",
                HeaderText = "Ngày đến",
                DataPropertyName = "NgayDen",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 100
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayBanHanh",
                HeaderText = "Ngày ban hành",
                DataPropertyName = "NgayBanHanh",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 110
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NoiGui",
                HeaderText = "Nơi gửi",
                DataPropertyName = "NoiGui",
                Width = 130
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NguoiKy",
                HeaderText = "Người ký",
                DataPropertyName = "NguoiKy",
                Width = 120
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Trích yếu nội dung",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoKhan",
                HeaderText = "Độ khẩn",
                DataPropertyName = "DoKhan",
                Width = 90
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoMat",
                HeaderText = "Độ mật",
                DataPropertyName = "DoMat",
                Width = 90
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 120
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FileDinhKem",
                DataPropertyName = "FileDinhKem",
                Visible = false
            });
        }

        private void formCongVanDenList_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            Utils.FormatDataGridView(dgvVanBan);
            Utils.SyncAllButtons(this);
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

            string fullPath = Path.Combine(Application.StartupPath, path);

            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }
    }
}

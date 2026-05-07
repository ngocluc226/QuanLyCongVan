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
using BLL;

namespace UI
{
    public partial class formCongVanDiList : Form
    {
        public formCongVanDiList()
        {
            InitializeComponent();

            // Gán sự kiện
            this.Load += new System.EventHandler(this.formCongVanDiList_Load);
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            
            // Xoá btnRefresh để fix lỗi CS1061 do Designer không có biến này
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (dgvVanBan.DataSource is DataView dv)
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    dv.RowFilter = "";
                }
                else
                {
                    dv.RowFilter = $"SoDi LIKE '%{keyword}%' OR SoVanBan LIKE '%{keyword}%' OR TrichYeu LIKE '%{keyword}%'";
                }
                lblTong.Text = "Tổng: " + dv.Count.ToString();
            }
            else if (dgvVanBan.DataSource is DataTable dt)
            {
                DataView newDv = dt.DefaultView;
                if (string.IsNullOrEmpty(keyword))
                {
                    newDv.RowFilter = "";
                }
                else
                {
                    newDv.RowFilter = $"SoDi LIKE '%{keyword}%' OR SoVanBan LIKE '%{keyword}%' OR TrichYeu LIKE '%{keyword}%'";
                }
                dgvVanBan.DataSource = newDv;
                lblTong.Text = "Tổng: " + newDv.Count.ToString();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = CongVanDiBLL.Instance.GetAll();

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
                Name = "SoDi",
                HeaderText = "Số đi",
                DataPropertyName = "SoDi"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoVanBan",
                HeaderText = "Số văn bản",
                DataPropertyName = "SoVanBan"
            });

            dgvVanBan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayDi",
                HeaderText = "Ngày đi",
                DataPropertyName = "NgayDi",
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
                Name = "NoiNhan",
                HeaderText = "Nơi nhận",
                DataPropertyName = "NoiNhan"
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
        }

        private void formCongVanDiList_Load(object sender, EventArgs e)
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
                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                if (trangThai == "Đã phát hành" || trangThai == "Đã duyệt")
                {
                    MessageBox.Show($"Không thể xoá công văn [{row.Cells["SoDi"].Value}] vì đang ở trạng thái {trangThai}!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                int id = Convert.ToInt32(row.Cells["Id"].Value);

                if (CongVanDiBLL.Instance.Delete(id))
                {
                    success++;
                }
            }

            MessageBox.Show($"Đã xóa {success} công văn!");

            LoadData();
        }

        // Khôi phục lại btnShow_Click
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

            DataTable dt = CongVanDiBLL.Instance.GetByDateRange(fromDate, toDate);
            DataView dv = dt.DefaultView;
            
            dgvVanBan.DataSource = dv;
            lblTong.Text = "Tổng: " + dv.Count.ToString();
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
    }
}


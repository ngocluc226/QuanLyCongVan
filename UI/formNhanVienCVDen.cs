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
    public partial class formNhanVienCVDen : Form
    {
        public formNhanVienCVDen()
        {
            InitializeComponent();
            InitDataGridView();   
            InitDataGridDaXuLy();
            InitSearchCombo();

            Utils.FormatDataGridView(dgvCongVan);
            Utils.FormatDataGridView(dgvDaXuly);
            Utils.SyncAllButtons(this);

        }

        private void formNhanVienCVDen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvCongVan.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanChoNhanVien(); 
            dgvDaXuly.DataSource = BLL.CongVanDenBLL.Instance.GetCongVanDaHoanThanhChoNhanVien(); 
        }
        private void InitDataGridDaXuLy()
        {
            dgvDaXuly.AutoGenerateColumns = false;
            dgvDaXuly.Columns.Clear();
            dgvDaXuly.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaXuly.AllowUserToAddRows = false;

            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoVanBan", HeaderText = "Số văn bản", DataPropertyName = "SoVanBan", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrichYeu", HeaderText = "Nội dung văn bản đã làm", DataPropertyName = "TrichYeu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 120 });
            dgvDaXuly.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FileDinhKem", DataPropertyName = "FileDinhKem", Visible = false });
        }
        private void InitDataGridView()
        {
            dgvCongVan.AutoGenerateColumns = false;
            dgvCongVan.Columns.Clear();

            dgvCongVan.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgvCongVan.MultiSelect = false; 
            dgvCongVan.AllowUserToAddRows = false; 
            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoVanBan",
                HeaderText = "Số văn bản",
                DataPropertyName = "SoVanBan",
                Width = 120
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NgayDen",
                HeaderText = "Ngày đến",
                DataPropertyName = "NgayDen",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 100
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrichYeu",
                HeaderText = "Nội dung văn bản được giao",
                DataPropertyName = "TrichYeu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DoKhan",
                HeaderText = "Độ khẩn",
                DataPropertyName = "DoKhan",
                Width = 100
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái xử lý",
                DataPropertyName = "TrangThai",
                Width = 140
            });

            dgvCongVan.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FileDinhKem",
                DataPropertyName = "FileDinhKem",
                Visible = false
            });
        }
        private int GetSelectedId()
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công văn từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return Convert.ToInt32(dgvCongVan.SelectedRows[0].Cells["Id"].Value);
        }

        private void dgvCongVan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongVan.SelectedRows.Count == 0)
            {
                btnXuLy.Enabled = false;
                btnHoanThanh.Enabled = false;
                return;
            }

            string trangThai = dgvCongVan.SelectedRows[0].Cells["TrangThai"].Value?.ToString();

            if (trangThai == DTO.TrangThaiCongVanDen.DA_PHAN_CONG)
            {
                btnXuLy.Enabled = true;       
                btnHoanThanh.Enabled = false; 
            }
            else if (trangThai == DTO.TrangThaiCongVanDen.DANG_XU_LY)
            {
                btnXuLy.Enabled = false;      
                btnHoanThanh.Enabled = true;  
            }
            else
            {
                btnXuLy.Enabled = false;
                btnHoanThanh.Enabled = false;
            }
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            bool res = BLL.CongVanDenBLL.Instance.CapNhatXuLy(id, DTO.TrangThaiCongVanDen.DANG_XU_LY);

            if (res)
            {
                MessageBox.Show("Đã tiếp nhận công văn. Trạng thái hiện tại: Đang xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); 
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id == -1) return;

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn đã hoàn thành mọi xử lý cho công văn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            bool res = BLL.CongVanDenBLL.Instance.HoanThanh(id);

            if (res)
            {
                MessageBox.Show("Chúc mừng! Đã hoàn thành và đóng công văn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); 
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = "";

            if (tabControl1.SelectedTab == tabChoXuLy)
            {
               
                if (dgvCongVan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn công văn cần xem từ danh sách chờ xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                path = dgvCongVan.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }
            else if (tabControl1.SelectedTab == tabDaXuLy)
            {
                if (dgvDaXuly.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn công văn cần xem từ danh sách đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                path = dgvDaXuly.SelectedRows[0].Cells["FileDinhKem"].Value?.ToString();
            }

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Công văn này không có file đính kèm để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fullPath = Path.Combine(Application.StartupPath, path);

            formFileViewer f = new formFileViewer(fullPath);
            f.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string column = cbSearchCol.SelectedValue.ToString();
            string value = txtSearchValue.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                LoadData(); 
                return;
            }

            bool isTab1 = (tabControl1.SelectedTab == tabChoXuLy);

            DataTable dtResult = BLL.CongVanDenBLL.Instance.SearchInTab("NhanVien", isTab1, column, value);

            if (isTab1)
                dgvCongVan.DataSource = dtResult;
            else
                dgvDaXuly.DataSource = dtResult;
        }
        private void InitSearchCombo()
        {
            var searchFields = new[] {
        new { Text = "Số văn bản", Value = "SoVanBan" },
        new { Text = "Trích yếu", Value = "TrichYeu" },
        new { Text = "Nơi gửi/nhận", Value = "NoiGui" }
    };
            cbSearchCol.DataSource = searchFields;
            cbSearchCol.DisplayMember = "Text";
            cbSearchCol.ValueMember = "Value";
        }

        
    }
}
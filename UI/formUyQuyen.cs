using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class formUyQuyen : Form
    {
        public formUyQuyen()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += FormUyQuyen_Load;
            this.btnLuu.Click += BtnLuu_Click;
            this.btnHuyUyQuyen.Click += BtnHuyUyQuyen_Click;
        }

        private void FormUyQuyen_Load(object sender, EventArgs e)
        {
            LoadTruongPhong();
            LoadData();
        }

        private void LoadTruongPhong()
        {
            // Lấy danh sách Trưởng phòng để combobox
            var dt = UserService.Instance.GetByRole("TruongPhong"); 
            
            DataView dv = new DataView(dt);
            
            cmbNguoiNhan.DataSource = dv;
            cmbNguoiNhan.DisplayMember = "TenNguoiDung";
            cmbNguoiNhan.ValueMember = "MaNguoiDung";
            cmbNguoiNhan.SelectedIndex = -1;
        }

        private void LoadData()
        {
            dgvUyQuyen.DataSource = UyQuyenBLL.Instance.GetAllActive();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (cmbNguoiNhan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn người được ủy quyền!");
                return;
            }

            try
            {
                UyQuyen uq = new UyQuyen
                {
                    NguoiUyQuyen = Session.CurrentUser.MaNguoiDung,
                    NguoiDuocUyQuyen = cmbNguoiNhan.SelectedValue.ToString(),
                    TuNgay = dtpTuNgay.Value,
                    DenNgay = dtpDenNgay.Value,
                    QuyenHan = "ALL", // Có thể mở rộng sau nếu cần cấp quyền chi tiết
                    TrangThai = true
                };

                if (UyQuyenBLL.Instance.Insert(uq))
                {
                    MessageBox.Show("Thêm ủy quyền thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnHuyUyQuyen_Click(object sender, EventArgs e)
        {
            if (dgvUyQuyen.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUyQuyen.SelectedRows[0].Cells["Id"].Value);
                if (UyQuyenBLL.Instance.Disable(id))
                {
                    MessageBox.Show("Đã hủy ủy quyền!");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục để hủy!");
            }
        }
    }
}

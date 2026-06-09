using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DTO;

namespace UI
{
    public partial class formKiemTraAI : Form
    {
        private string _duongDanFileCanQuet;

        public formKiemTraAI(string filePath)
        {
            InitializeComponent();
            _duongDanFileCanQuet = filePath;
        }

        private async void btnQuetAI_Click(object sender, EventArgs e)
        {
            btnQuetAI.Enabled = false;
            btnQuetAI.Text = "Đang quét...";

            txtKetQuaLoi.Clear();
            txtDeXuat.Clear();
            lblDiemSo.Text = "--/100";

            try
            {
                KetQuaKiemTraAI ketQua = await AIServiceBLL.Instance.KiemTraTheThucVanBanAsync(_duongDanFileCanQuet);

                lblDiemSo.Text = $"{ketQua.DiemSo}/100 Điểm";
                if (ketQua.HopLe)
                {
                    lblThongBao.Text = "Văn bản hợp lệ!";
                    lblThongBao.ForeColor = Color.Green;
                }
                else
                {
                    lblThongBao.Text = "Văn bản không đạt thể thức!";
                    lblThongBao.ForeColor = Color.Red;
                }

                foreach (string loi in ketQua.DanhSachLoi)
                {
                    txtKetQuaLoi.AppendText("• " + loi + "\n\n");
                }
                txtDeXuat.Text = ketQua.DeXuatChinhSua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblThongBao.Text = "Yêu cầu kiểm tra cấu hình.";
                lblThongBao.ForeColor = Color.Orange;
            }
            finally
            {
                btnQuetAI.Enabled = true;
                btnQuetAI.Text = "Kiểm tra thể thức hành chính (AI)";
            }
        }

        private void formKiemTraAI_Load(object sender, EventArgs e)
        {
            Utils.SyncAllButtons(this); 
            lblFilePath.Text = _duongDanFileCanQuet; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
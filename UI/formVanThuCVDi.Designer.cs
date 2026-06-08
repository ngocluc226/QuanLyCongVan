namespace UI
{
    partial class formVanThuCVDi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvCongVan = new System.Windows.Forms.DataGridView();
            this.btnBanHanh = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtSoVanBan = new System.Windows.Forms.TextBox();
            this.dtpNgayBanHanh = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChoXuLy = new System.Windows.Forms.TabPage();
            this.tabDaXuLy = new System.Windows.Forms.TabPage();
            this.dgvDaXuly = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabChoXuLy.SuspendLayout();
            this.tabDaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeight = 29;
            this.dgvCongVan.Location = new System.Drawing.Point(6, 6);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(1489, 400);
            this.dgvCongVan.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChoXuLy);
            this.tabControl1.Controls.Add(this.tabDaXuLy);
            this.tabControl1.Location = new System.Drawing.Point(49, 119);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1509, 440);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabChoXuLy
            // 
            this.tabChoXuLy.Controls.Add(this.dgvCongVan);
            this.tabChoXuLy.Location = new System.Drawing.Point(4, 25);
            this.tabChoXuLy.Name = "tabChoXuLy";
            this.tabChoXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoXuLy.Size = new System.Drawing.Size(1501, 411);
            this.tabChoXuLy.TabIndex = 0;
            this.tabChoXuLy.Text = "Chưa xử lý";
            this.tabChoXuLy.UseVisualStyleBackColor = true;
            // 
            // tabDaXuLy
            // 
            this.tabDaXuLy.Controls.Add(this.dgvDaXuly);
            this.tabDaXuLy.Location = new System.Drawing.Point(4, 25);
            this.tabDaXuLy.Name = "tabDaXuLy";
            this.tabDaXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaXuLy.Size = new System.Drawing.Size(1501, 411);
            this.tabDaXuLy.TabIndex = 1;
            this.tabDaXuLy.Text = "Đã xử lý";
            this.tabDaXuLy.UseVisualStyleBackColor = true;
            // 
            // dgvDaXuly
            // 
            this.dgvDaXuly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaXuly.ColumnHeadersHeight = 29;
            this.dgvDaXuly.Location = new System.Drawing.Point(6, 6);
            this.dgvDaXuly.MultiSelect = false;
            this.dgvDaXuly.Name = "dgvDaXuly";
            this.dgvDaXuly.RowHeadersWidth = 51;
            this.dgvDaXuly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaXuly.Size = new System.Drawing.Size(1489, 400);
            this.dgvDaXuly.TabIndex = 0;
            // 
            // btnBanHanh
            // 
            this.btnBanHanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBanHanh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBanHanh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBanHanh.Location = new System.Drawing.Point(49, 38);
            this.btnBanHanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBanHanh.Name = "btnBanHanh";
            this.btnBanHanh.Size = new System.Drawing.Size(217, 42);
            this.btnBanHanh.TabIndex = 5;
            this.btnBanHanh.Text = "Cấp số && Ban Hành";
            this.btnBanHanh.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(1419, 38);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(140, 42);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem File";
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // txtSoVanBan
            // 
            this.txtSoVanBan.Location = new System.Drawing.Point(426, 54);
            this.txtSoVanBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoVanBan.Name = "txtSoVanBan";
            this.txtSoVanBan.Size = new System.Drawing.Size(128, 22);
            this.txtSoVanBan.TabIndex = 2;
            // 
            // dtpNgayBanHanh
            // 
            this.dtpNgayBanHanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBanHanh.Location = new System.Drawing.Point(741, 55);
            this.dtpNgayBanHanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayBanHanh.Name = "dtpNgayBanHanh";
            this.dtpNgayBanHanh.Size = new System.Drawing.Size(151, 22);
            this.dtpNgayBanHanh.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(316, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Văn Bản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(599, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày ban hành:";
            // 
            // formVanThuCVDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 586);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnBanHanh);
            this.Controls.Add(this.dtpNgayBanHanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoVanBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formVanThuCVDi";
            this.Text = "Văn Thư - Ban Hành Công Văn Đi";
            this.Load += new System.EventHandler(this.formVanThuCVDi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabChoXuLy.ResumeLayout(false);
            this.tabDaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnBanHanh;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TextBox txtSoVanBan;
        private System.Windows.Forms.DateTimePicker dtpNgayBanHanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChoXuLy;
        private System.Windows.Forms.TabPage tabDaXuLy;
        private System.Windows.Forms.DataGridView dgvDaXuly;
    }
}
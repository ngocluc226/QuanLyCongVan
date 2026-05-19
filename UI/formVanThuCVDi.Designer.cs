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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeight = 29;
            this.dgvCongVan.Location = new System.Drawing.Point(49, 119);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(1509, 400);
            this.dgvCongVan.TabIndex = 0;
            // 
            // btnBanHanh
            // 
            this.btnBanHanh.Location = new System.Drawing.Point(49, 38);
            this.btnBanHanh.Name = "btnBanHanh";
            this.btnBanHanh.Size = new System.Drawing.Size(180, 42);
            this.btnBanHanh.TabIndex = 5;
            this.btnBanHanh.Text = "Cấp số && Ban Hành";
            this.btnBanHanh.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(1419, 38);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(140, 42);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem File";
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // txtSoVanBan
            // 
            this.txtSoVanBan.Location = new System.Drawing.Point(360, 48);
            this.txtSoVanBan.Name = "txtSoVanBan";
            this.txtSoVanBan.Size = new System.Drawing.Size(150, 22);
            this.txtSoVanBan.TabIndex = 2;
            // 
            // dtpNgayBanHanh
            // 
            this.dtpNgayBanHanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBanHanh.Location = new System.Drawing.Point(660, 48);
            this.dtpNgayBanHanh.Name = "dtpNgayBanHanh";
            this.dtpNgayBanHanh.Size = new System.Drawing.Size(150, 22);
            this.dtpNgayBanHanh.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Văn Bản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
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
            this.Controls.Add(this.dgvCongVan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVanThuCVDi";
            this.Text = "Văn Thư - Ban Hành Công Văn Đi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
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
    }
}
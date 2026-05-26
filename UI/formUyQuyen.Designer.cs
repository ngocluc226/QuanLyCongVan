namespace UI
{
    partial class formUyQuyen
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNguoiNhan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvUyQuyen = new System.Windows.Forms.DataGridView();
            this.btnHuyUyQuyen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUyQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ủy quyền cho KH:";
            // 
            // cmbNguoiNhan
            // 
            this.cmbNguoiNhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNguoiNhan.FormattingEnabled = true;
            this.cmbNguoiNhan.Location = new System.Drawing.Point(166, 35);
            this.cmbNguoiNhan.Name = "cmbNguoiNhan";
            this.cmbNguoiNhan.Size = new System.Drawing.Size(262, 24);
            this.cmbNguoiNhan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(166, 80);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(262, 22);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(166, 126);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(262, 22);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuu.Location = new System.Drawing.Point(461, 114);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(181, 46);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu Ủy Quyền";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // dgvUyQuyen
            // 
            this.dgvUyQuyen.AllowUserToAddRows = false;
            this.dgvUyQuyen.AllowUserToDeleteRows = false;
            this.dgvUyQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUyQuyen.Location = new System.Drawing.Point(37, 185);
            this.dgvUyQuyen.Name = "dgvUyQuyen";
            this.dgvUyQuyen.ReadOnly = true;
            this.dgvUyQuyen.RowHeadersWidth = 51;
            this.dgvUyQuyen.RowTemplate.Height = 24;
            this.dgvUyQuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUyQuyen.Size = new System.Drawing.Size(725, 237);
            this.dgvUyQuyen.TabIndex = 7;
            // 
            // btnHuyUyQuyen
            // 
            this.btnHuyUyQuyen.BackColor = System.Drawing.Color.Red;
            this.btnHuyUyQuyen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuyUyQuyen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHuyUyQuyen.Location = new System.Drawing.Point(581, 442);
            this.btnHuyUyQuyen.Name = "btnHuyUyQuyen";
            this.btnHuyUyQuyen.Size = new System.Drawing.Size(181, 43);
            this.btnHuyUyQuyen.TabIndex = 8;
            this.btnHuyUyQuyen.Text = "Hủy Ủy Quyền";
            this.btnHuyUyQuyen.UseVisualStyleBackColor = false;
            // 
            // formUyQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.btnHuyUyQuyen);
            this.Controls.Add(this.dgvUyQuyen);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNguoiNhan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formUyQuyen";
            this.Text = "Quản Lý Ủy Quyền";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUyQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNguoiNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvUyQuyen;
        private System.Windows.Forms.Button btnHuyUyQuyen;
    }
}

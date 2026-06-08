namespace UI
{
    partial class formTruongPhongCVDi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCongVan = new System.Windows.Forms.DataGridView();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLanhDao = new System.Windows.Forms.ComboBox();
            this.lblLanhDao = new System.Windows.Forms.Label();
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
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongVan.Location = new System.Drawing.Point(3, 3);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(1545, 536);
            this.dgvCongVan.TabIndex = 0;
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnDuyet.Location = new System.Drawing.Point(43, 123);
            this.btnDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(239, 41);
            this.btnDuyet.TabIndex = 1;
            this.btnDuyet.Text = "Duyệt cấp phòng";
            this.btnDuyet.UseVisualStyleBackColor = false;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.BackColor = System.Drawing.Color.Red;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTuChoi.Location = new System.Drawing.Point(700, 127);
            this.btnTuChoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(160, 41);
            this.btnTuChoi.TabIndex = 2;
            this.btnTuChoi.Text = "Từ Chối";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.Blue;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXem.Location = new System.Drawing.Point(897, 127);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(160, 41);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem File";
            this.btnXem.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(156, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(579, 41);
            this.label4.TabIndex = 66;
            this.label4.Text = "DANH SÁCH CÔNG VĂN ĐI CHỜ DUYỆT";
            // 
            // cboLanhDao
            // 
            this.cboLanhDao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanhDao.FormattingEnabled = true;
            this.cboLanhDao.Location = new System.Drawing.Point(465, 137);
            this.cboLanhDao.Name = "cboLanhDao";
            this.cboLanhDao.Size = new System.Drawing.Size(200, 24);
            this.cboLanhDao.TabIndex = 68;
            // 
            // lblLanhDao
            // 
            this.lblLanhDao.AutoSize = true;
            this.lblLanhDao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLanhDao.Location = new System.Drawing.Point(301, 138);
            this.lblLanhDao.Name = "lblLanhDao";
            this.lblLanhDao.Size = new System.Drawing.Size(134, 23);
            this.lblLanhDao.TabIndex = 67;
            this.lblLanhDao.Text = "Chọn Lãnh đạo:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChoXuLy);
            this.tabControl1.Controls.Add(this.tabDaXuLy);
            this.tabControl1.Location = new System.Drawing.Point(43, 190);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1559, 571);
            this.tabControl1.TabIndex = 69;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabChoXuLy
            // 
            this.tabChoXuLy.Controls.Add(this.dgvCongVan);
            this.tabChoXuLy.Location = new System.Drawing.Point(4, 25);
            this.tabChoXuLy.Name = "tabChoXuLy";
            this.tabChoXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoXuLy.Size = new System.Drawing.Size(1551, 542);
            this.tabChoXuLy.TabIndex = 0;
            this.tabChoXuLy.Text = "Chờ xử lý";
            this.tabChoXuLy.UseVisualStyleBackColor = true;
            // 
            // tabDaXuLy
            // 
            this.tabDaXuLy.Controls.Add(this.dgvDaXuly);
            this.tabDaXuLy.Location = new System.Drawing.Point(4, 25);
            this.tabDaXuLy.Name = "tabDaXuLy";
            this.tabDaXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaXuLy.Size = new System.Drawing.Size(1551, 542);
            this.tabDaXuLy.TabIndex = 1;
            this.tabDaXuLy.Text = "Đã xử lý";
            this.tabDaXuLy.UseVisualStyleBackColor = true;
            // 
            // dgvDaXuly
            // 
            this.dgvDaXuly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaXuly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaXuly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaXuly.Location = new System.Drawing.Point(3, 3);
            this.dgvDaXuly.MultiSelect = false;
            this.dgvDaXuly.Name = "dgvDaXuly";
            this.dgvDaXuly.RowHeadersWidth = 51;
            this.dgvDaXuly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaXuly.Size = new System.Drawing.Size(1545, 536);
            this.dgvDaXuly.TabIndex = 0;
            // 
            // formTruongPhongCVDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 751);
            this.Controls.Add(this.cboLanhDao);
            this.Controls.Add(this.lblLanhDao);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDuyet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formTruongPhongCVDi";
            this.Text = "Trưởng Phòng - Duyệt Công Văn Đi";
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
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLanhDao;
        private System.Windows.Forms.Label lblLanhDao;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChoXuLy;
        private System.Windows.Forms.TabPage tabDaXuLy;
        private System.Windows.Forms.DataGridView dgvDaXuly;
    }
}

namespace UI
{
    partial class formVanThuCVDen
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTrinh = new System.Windows.Forms.Button();
            this.dgvCongVan = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cboLanhDao = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChoXuLy = new System.Windows.Forms.TabPage();
            this.tabDaXuLy = new System.Windows.Forms.TabPage();
            this.dgvDaXuly = new System.Windows.Forms.DataGridView();
            this.cbSearchCol = new System.Windows.Forms.ComboBox();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnKiemTraAI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabChoXuLy.SuspendLayout();
            this.tabDaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(38, 23);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(136, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm công văn đến";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTrinh
            // 
            this.btnTrinh.Location = new System.Drawing.Point(618, 58);
            this.btnTrinh.Name = "btnTrinh";
            this.btnTrinh.Size = new System.Drawing.Size(130, 34);
            this.btnTrinh.TabIndex = 1;
            this.btnTrinh.Text = "Trình lãnh đạo";
            this.btnTrinh.UseVisualStyleBackColor = true;
            this.btnTrinh.Click += new System.EventHandler(this.btnTrinh_Click);
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(6, 26);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.Size = new System.Drawing.Size(1132, 582);
            this.dgvCongVan.TabIndex = 2;
            this.dgvCongVan.SelectionChanged += new System.EventHandler(this.dgvCongVan_SelectionChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(223, 23);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 32);
            this.btnOpen.TabIndex = 53;
            this.btnOpen.Text = "Xem văn bản";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cboLanhDao
            // 
            this.cboLanhDao.FormattingEnabled = true;
            this.cboLanhDao.Location = new System.Drawing.Point(596, 23);
            this.cboLanhDao.Name = "cboLanhDao";
            this.cboLanhDao.Size = new System.Drawing.Size(183, 21);
            this.cboLanhDao.TabIndex = 54;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChoXuLy);
            this.tabControl1.Controls.Add(this.tabDaXuLy);
            this.tabControl1.Location = new System.Drawing.Point(38, 168);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1158, 647);
            this.tabControl1.TabIndex = 55;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabChoXuLy
            // 
            this.tabChoXuLy.Controls.Add(this.dgvCongVan);
            this.tabChoXuLy.Location = new System.Drawing.Point(4, 22);
            this.tabChoXuLy.Name = "tabChoXuLy";
            this.tabChoXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoXuLy.Size = new System.Drawing.Size(1150, 621);
            this.tabChoXuLy.TabIndex = 0;
            this.tabChoXuLy.Text = "Chưa xử lý";
            this.tabChoXuLy.UseVisualStyleBackColor = true;
            // 
            // tabDaXuLy
            // 
            this.tabDaXuLy.Controls.Add(this.dgvDaXuly);
            this.tabDaXuLy.Location = new System.Drawing.Point(4, 22);
            this.tabDaXuLy.Name = "tabDaXuLy";
            this.tabDaXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaXuLy.Size = new System.Drawing.Size(1150, 621);
            this.tabDaXuLy.TabIndex = 1;
            this.tabDaXuLy.Text = "Đã xử lý";
            this.tabDaXuLy.UseVisualStyleBackColor = true;
            // 
            // dgvDaXuly
            // 
            this.dgvDaXuly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaXuly.Location = new System.Drawing.Point(6, 15);
            this.dgvDaXuly.Name = "dgvDaXuly";
            this.dgvDaXuly.Size = new System.Drawing.Size(1138, 600);
            this.dgvDaXuly.TabIndex = 0;
            // 
            // cbSearchCol
            // 
            this.cbSearchCol.FormattingEnabled = true;
            this.cbSearchCol.Items.AddRange(new object[] {
            "Số văn bản",
            "Nơi gửi",
            "Trích yếu"});
            this.cbSearchCol.Location = new System.Drawing.Point(909, 37);
            this.cbSearchCol.Name = "cbSearchCol";
            this.cbSearchCol.Size = new System.Drawing.Size(145, 21);
            this.cbSearchCol.TabIndex = 56;
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(909, 80);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(145, 20);
            this.txtSearchValue.TabIndex = 57;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(853, 123);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 23);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(827, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(850, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Nội dung:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1087, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 32);
            this.btnRefresh.TabIndex = 61;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnKiemTraAI
            // 
            this.btnKiemTraAI.Location = new System.Drawing.Point(352, 23);
            this.btnKiemTraAI.Name = "btnKiemTraAI";
            this.btnKiemTraAI.Size = new System.Drawing.Size(207, 32);
            this.btnKiemTraAI.TabIndex = 62;
            this.btnKiemTraAI.Text = "Kiểm tra thể thức bằng AI";
            this.btnKiemTraAI.UseVisualStyleBackColor = true;
            this.btnKiemTraAI.Click += new System.EventHandler(this.btnKiemTraAI_Click);
            // 
            // formVanThuCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 834);
            this.Controls.Add(this.btnKiemTraAI);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.cbSearchCol);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cboLanhDao);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnTrinh);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVanThuCVDen";
            this.Text = "formVanThu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabChoXuLy.ResumeLayout(false);
            this.tabDaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTrinh;
        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cboLanhDao;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChoXuLy;
        private System.Windows.Forms.TabPage tabDaXuLy;
        private System.Windows.Forms.DataGridView dgvDaXuly;
        private System.Windows.Forms.ComboBox cbSearchCol;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnKiemTraAI;
    }
}
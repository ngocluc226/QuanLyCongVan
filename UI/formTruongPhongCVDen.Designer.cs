namespace UI
{
    partial class formTruongPhongCVDen
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCongVan = new System.Windows.Forms.DataGridView();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChoXuLy = new System.Windows.Forms.TabPage();
            this.tabDaXuLy = new System.Windows.Forms.TabPage();
            this.dgvDaXuly = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.cbSearchCol = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabChoXuLy.SuspendLayout();
            this.tabDaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(217, 123);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(140, 41);
            this.btnOpen.TabIndex = 67;
            this.btnOpen.Text = "Xem văn bản";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(156, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 32);
            this.label4.TabIndex = 66;
            this.label4.Text = "DANH SÁCH CÔNG VĂN ";
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(17, 7);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.Size = new System.Drawing.Size(1551, 665);
            this.dgvCongVan.TabIndex = 65;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(43, 123);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(125, 41);
            this.btnPhanCong.TabIndex = 64;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(411, 123);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 41);
            this.btnRefresh.TabIndex = 68;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChoXuLy);
            this.tabControl1.Controls.Add(this.tabDaXuLy);
            this.tabControl1.Location = new System.Drawing.Point(43, 183);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1537, 726);
            this.tabControl1.TabIndex = 69;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabChoXuLy
            // 
            this.tabChoXuLy.Controls.Add(this.dgvCongVan);
            this.tabChoXuLy.Location = new System.Drawing.Point(4, 25);
            this.tabChoXuLy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabChoXuLy.Name = "tabChoXuLy";
            this.tabChoXuLy.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabChoXuLy.Size = new System.Drawing.Size(1529, 697);
            this.tabChoXuLy.TabIndex = 0;
            this.tabChoXuLy.Text = "Chờ xử lý";
            this.tabChoXuLy.UseVisualStyleBackColor = true;
            // 
            // tabDaXuLy
            // 
            this.tabDaXuLy.Controls.Add(this.dgvDaXuly);
            this.tabDaXuLy.Location = new System.Drawing.Point(4, 25);
            this.tabDaXuLy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabDaXuLy.Name = "tabDaXuLy";
            this.tabDaXuLy.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabDaXuLy.Size = new System.Drawing.Size(1529, 697);
            this.tabDaXuLy.TabIndex = 1;
            this.tabDaXuLy.Text = "Đã xử lý";
            this.tabDaXuLy.UseVisualStyleBackColor = true;
            // 
            // dgvDaXuly
            // 
            this.dgvDaXuly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaXuly.Location = new System.Drawing.Point(8, 34);
            this.dgvDaXuly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDaXuly.Name = "dgvDaXuly";
            this.dgvDaXuly.Size = new System.Drawing.Size(1497, 725);
            this.dgvDaXuly.TabIndex = 66;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1435, 937);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(181, 46);
            this.btnLogout.TabIndex = 70;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1167, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "Nội dung:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1136, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 74;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1457, 101);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 73;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(1245, 156);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(192, 22);
            this.txtSearchValue.TabIndex = 72;
            // 
            // cbSearchCol
            // 
            this.cbSearchCol.FormattingEnabled = true;
            this.cbSearchCol.Items.AddRange(new object[] {
            "Số văn bản",
            "Nơi gửi",
            "Trích yếu"});
            this.cbSearchCol.Location = new System.Drawing.Point(1245, 103);
            this.cbSearchCol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSearchCol.Name = "cbSearchCol";
            this.cbSearchCol.Size = new System.Drawing.Size(192, 24);
            this.cbSearchCol.TabIndex = 71;
            // 
            // formTruongPhongCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 997);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.cbSearchCol);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPhanCong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formTruongPhongCVDen";
            this.Text = "formTruongPhongCVDen";
            this.Load += new System.EventHandler(this.formTruongPhongCVDen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabChoXuLy.ResumeLayout(false);
            this.tabDaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChoXuLy;
        private System.Windows.Forms.TabPage tabDaXuLy;
        private System.Windows.Forms.DataGridView dgvDaXuly;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.ComboBox cbSearchCol;
    }
}
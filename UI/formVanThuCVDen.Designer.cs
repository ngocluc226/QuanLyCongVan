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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(49, 38);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(181, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm công văn đến";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTrinh
            // 
            this.btnTrinh.Location = new System.Drawing.Point(652, 38);
            this.btnTrinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTrinh.Name = "btnTrinh";
            this.btnTrinh.Size = new System.Drawing.Size(125, 42);
            this.btnTrinh.TabIndex = 1;
            this.btnTrinh.Text = "Trình lãnh đạo";
            this.btnTrinh.UseVisualStyleBackColor = true;
            this.btnTrinh.Click += new System.EventHandler(this.btnTrinh_Click);
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(49, 119);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.Size = new System.Drawing.Size(1509, 364);
            this.dgvCongVan.TabIndex = 2;
            this.dgvCongVan.SelectionChanged += new System.EventHandler(this.dgvCongVan_SelectionChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1419, 38);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(140, 39);
            this.btnOpen.TabIndex = 53;
            this.btnOpen.Text = "Xem văn bản";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cboLanhDao
            // 
            this.cboLanhDao.FormattingEnabled = true;
            this.cboLanhDao.Location = new System.Drawing.Point(801, 53);
            this.cboLanhDao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLanhDao.Name = "cboLanhDao";
            this.cboLanhDao.Size = new System.Drawing.Size(179, 24);
            this.cboLanhDao.TabIndex = 54;
            // 
            // formVanThuCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 586);
            this.Controls.Add(this.cboLanhDao);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dgvCongVan);
            this.Controls.Add(this.btnTrinh);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formVanThuCVDen";
            this.Text = "formVanThu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTrinh;
        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cboLanhDao;
    }
}
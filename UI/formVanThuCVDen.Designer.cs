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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(37, 31);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm công văn";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTrinh
            // 
            this.btnTrinh.Location = new System.Drawing.Point(155, 31);
            this.btnTrinh.Name = "btnTrinh";
            this.btnTrinh.Size = new System.Drawing.Size(94, 34);
            this.btnTrinh.TabIndex = 1;
            this.btnTrinh.Text = "Trình lãnh đạo";
            this.btnTrinh.UseVisualStyleBackColor = true;
            this.btnTrinh.Click += new System.EventHandler(this.btnTrinh_Click);
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(37, 97);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.Size = new System.Drawing.Size(751, 296);
            this.dgvCongVan.TabIndex = 2;
            this.dgvCongVan.SelectionChanged += new System.EventHandler(this.dgvCongVan_SelectionChanged);
            // 
            // formVanThuCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCongVan);
            this.Controls.Add(this.btnTrinh);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVanThuCVDen";
            this.Text = "formVanThu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTrinh;
        private System.Windows.Forms.DataGridView dgvCongVan;
    }
}
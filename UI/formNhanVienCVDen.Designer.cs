namespace UI
{
    partial class formNhanVienCVDen
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
            this.btnXuLy = new System.Windows.Forms.Button();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.dgvCongVan = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXuLy
            // 
            this.btnXuLy.Location = new System.Drawing.Point(64, 106);
            this.btnXuLy.Name = "btnXuLy";
            this.btnXuLy.Size = new System.Drawing.Size(83, 32);
            this.btnXuLy.TabIndex = 0;
            this.btnXuLy.Text = "Xử lý";
            this.btnXuLy.UseVisualStyleBackColor = true;
            this.btnXuLy.Click += new System.EventHandler(this.btnXuLy_Click);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Location = new System.Drawing.Point(181, 106);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(83, 32);
            this.btnHoanThanh.TabIndex = 1;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = true;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(64, 176);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.Size = new System.Drawing.Size(1132, 316);
            this.dgvCongVan.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(215, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(422, 32);
            this.label4.TabIndex = 44;
            this.label4.Text = "DANH SÁCH CÔNG VĂN CẦN XỬ LÝ";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(657, 106);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 32);
            this.btnOpen.TabIndex = 52;
            this.btnOpen.Text = "Xem văn bản";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // formNhanVienCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 533);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCongVan);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.btnXuLy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formNhanVienCVDen";
            this.Text = "formNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXuLy;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpen;
    }
}
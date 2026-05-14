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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(653, 100);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 33);
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
            this.label4.Location = new System.Drawing.Point(117, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(594, 32);
            this.label4.TabIndex = 66;
            this.label4.Text = "DANH SÁCH CÔNG VĂN CHƯA ĐƯỢC PHÂN CÔNG";
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(32, 154);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.Size = new System.Drawing.Size(1163, 440);
            this.dgvCongVan.TabIndex = 65;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(32, 100);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(94, 33);
            this.btnPhanCong.TabIndex = 64;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // formTruongPhongCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 610);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCongVan);
            this.Controls.Add(this.btnPhanCong);
            this.Name = "formTruongPhongCVDen";
            this.Text = "formTruongPhongCVDen";
            this.Load += new System.EventHandler(this.formTruongPhongCVDen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnPhanCong;
    }
}
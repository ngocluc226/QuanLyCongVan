namespace UI
{
    partial class formLanhDaoCVDen
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
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.dgvCongVan = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.Blue;
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnPhanCong.Location = new System.Drawing.Point(53, 117);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(4);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(163, 58);
            this.btnPhanCong.TabIndex = 0;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(53, 183);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.Size = new System.Drawing.Size(1551, 542);
            this.dgvCongVan.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(410, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(741, 41);
            this.label4.TabIndex = 44;
            this.label4.Text = "DANH SÁCH CÔNG VĂN CHƯA ĐƯỢC PHÂN CÔNG";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Blue;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(881, 117);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(178, 58);
            this.btnOpen.TabIndex = 63;
            this.btnOpen.Text = "Xem văn bản";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // formLanhDaoCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 775);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCongVan);
            this.Controls.Add(this.btnPhanCong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formLanhDaoCVDen";
            this.Text = "formLanhDao";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpen;
    }
}
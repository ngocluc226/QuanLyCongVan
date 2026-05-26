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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(43, 190);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.RowHeadersWidth = 51;
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(1551, 542);
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
            this.btnTuChoi.Location = new System.Drawing.Point(310, 123);
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
            this.btnXem.Location = new System.Drawing.Point(588, 127);
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
            this.label4.Text = "DANH SÁCH CÔNG VĂN ĐI CHO DUYỆT";
            // 
            // formTruongPhongCVDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 751);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.dgvCongVan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formTruongPhongCVDi";
            this.Text = "Trưởng Phòng - Duyệt Công Văn Đi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label4;
    }
}

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
            this.dgvCongVan.Location = new System.Drawing.Point(32, 154);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(1163, 440);
            this.dgvCongVan.TabIndex = 0;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Location = new System.Drawing.Point(32, 100);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(120, 33);
            this.btnDuyet.TabIndex = 1;
            this.btnDuyet.Text = "Duyệt cấp phòng";
            this.btnDuyet.UseVisualStyleBackColor = true;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Location = new System.Drawing.Point(170, 100);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(120, 33);
            this.btnTuChoi.TabIndex = 2;
            this.btnTuChoi.Text = "Từ Chối";
            this.btnTuChoi.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(310, 100);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(120, 33);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem File";
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(117, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(434, 32);
            this.label4.TabIndex = 66;
            this.label4.Text = "DANH SÁCH CÔNG VĂN ĐI CHO DUYỆT";
            // 
            // formTruongPhongCVDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 610);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.dgvCongVan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

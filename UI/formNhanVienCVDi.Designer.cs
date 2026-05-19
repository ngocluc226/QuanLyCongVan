namespace UI
{
    partial class formNhanVienCVDi
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
            this.btnThemDraft = new System.Windows.Forms.Button();
            this.btnSuaDraft = new System.Windows.Forms.Button();
            this.btnNopDuyet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Location = new System.Drawing.Point(64, 176);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(1132, 316);
            this.dgvCongVan.TabIndex = 0;
            // 
            // btnThemDraft
            // 
            this.btnThemDraft.Location = new System.Drawing.Point(64, 106);
            this.btnThemDraft.Name = "btnThemDraft";
            this.btnThemDraft.Size = new System.Drawing.Size(83, 32);
            this.btnThemDraft.TabIndex = 1;
            this.btnThemDraft.Text = "Thêm Mới";
            this.btnThemDraft.UseVisualStyleBackColor = true;
            // 
            // btnSuaDraft
            // 
            this.btnSuaDraft.Location = new System.Drawing.Point(181, 106);
            this.btnSuaDraft.Name = "btnSuaDraft";
            this.btnSuaDraft.Size = new System.Drawing.Size(95, 32);
            this.btnSuaDraft.TabIndex = 2;
            this.btnSuaDraft.Text = "Sửa Bản Nháp";
            this.btnSuaDraft.UseVisualStyleBackColor = true;
            // 
            // btnNopDuyet
            // 
            this.btnNopDuyet.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNopDuyet.Location = new System.Drawing.Point(310, 106);
            this.btnNopDuyet.Name = "btnNopDuyet";
            this.btnNopDuyet.Size = new System.Drawing.Size(120, 32);
            this.btnNopDuyet.TabIndex = 3;
            this.btnNopDuyet.Text = "Nộp Trưởng Phòng";
            this.btnNopDuyet.UseVisualStyleBackColor = false;
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
            this.label4.Text = "DANH SÁCH CÔNG VĂN ĐI DO TÔI SOẠN THẢO";
            // 
            // formNhanVienCVDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 533);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNopDuyet);
            this.Controls.Add(this.btnSuaDraft);
            this.Controls.Add(this.btnThemDraft);
            this.Controls.Add(this.dgvCongVan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formNhanVienCVDi";
            this.Text = "Nhân Viên - Công Văn Đi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnThemDraft;
        private System.Windows.Forms.Button btnSuaDraft;
        private System.Windows.Forms.Button btnNopDuyet;
        private System.Windows.Forms.Label label4;
    }
}
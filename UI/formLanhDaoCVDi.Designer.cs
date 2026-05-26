namespace UI
{
    partial class formLanhDaoCVDi
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChoXuLy = new System.Windows.Forms.TabPage();
            this.tabDaXuLy = new System.Windows.Forms.TabPage();
            this.dgvDaXuly = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabChoXuLy.SuspendLayout();
            this.tabDaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCongVan
            // 
            this.dgvCongVan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongVan.Location = new System.Drawing.Point(3, 3);
            this.dgvCongVan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCongVan.MultiSelect = false;
            this.dgvCongVan.Name = "dgvCongVan";
            this.dgvCongVan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongVan.Size = new System.Drawing.Size(894, 332);
            this.dgvCongVan.TabIndex = 0;
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabChoXuLy);
            this.tabControl1.Controls.Add(this.tabDaXuLy);
            this.tabControl1.Location = new System.Drawing.Point(30, 122);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 358);
            this.tabControl1.TabIndex = 46;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            //
            // tabChoXuLy
            //
            this.tabChoXuLy.Controls.Add(this.dgvCongVan);
            this.tabChoXuLy.Location = new System.Drawing.Point(4, 22);
            this.tabChoXuLy.Name = "tabChoXuLy";
            this.tabChoXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoXuLy.Size = new System.Drawing.Size(892, 332);
            this.tabChoXuLy.TabIndex = 0;
            this.tabChoXuLy.Text = "Chờ xử lý";
            this.tabChoXuLy.UseVisualStyleBackColor = true;
            //
            // tabDaXuLy
            //
            this.tabDaXuLy.Controls.Add(this.dgvDaXuly);
            this.tabDaXuLy.Location = new System.Drawing.Point(4, 22);
            this.tabDaXuLy.Name = "tabDaXuLy";
            this.tabDaXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaXuLy.Size = new System.Drawing.Size(892, 332);
            this.tabDaXuLy.TabIndex = 1;
            this.tabDaXuLy.Text = "Đã xử lý";
            this.tabDaXuLy.UseVisualStyleBackColor = true;
            //
            // dgvDaXuly
            //
            this.dgvDaXuly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaXuly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaXuly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaXuly.Location = new System.Drawing.Point(3, 3);
            this.dgvDaXuly.MultiSelect = false;
            this.dgvDaXuly.Name = "dgvDaXuly";
            this.dgvDaXuly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaXuly.Size = new System.Drawing.Size(886, 326);
            this.dgvDaXuly.TabIndex = 0;
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.Blue;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Location = new System.Drawing.Point(30, 73);
            this.btnDuyet.Margin = new System.Windows.Forms.Padding(2);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(112, 39);
            this.btnDuyet.TabIndex = 1;
            this.btnDuyet.Text = "Duyệt / Ký";
            this.btnDuyet.UseVisualStyleBackColor = false;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.BackColor = System.Drawing.Color.Red;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(158, 73);
            this.btnTuChoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(112, 39);
            this.btnTuChoi.TabIndex = 2;
            this.btnTuChoi.Text = "Từ Chối";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(225, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(409, 32);
            this.label4.TabIndex = 44;
            this.label4.Text = "DANH SÁCH CÔNG VĂN TRÌNH KÝ";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Blue;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(779, 73);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(151, 39);
            this.btnOpen.TabIndex = 45;
            this.btnOpen.Text = "Xem văn bản";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // formLanhDaoCVDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formLanhDaoCVDi";
            this.Text = "formLanhDaoCVDi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabChoXuLy.ResumeLayout(false);
            this.tabDaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXuly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCongVan;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChoXuLy;
        private System.Windows.Forms.TabPage tabDaXuLy;
        private System.Windows.Forms.DataGridView dgvDaXuly;
    }
}
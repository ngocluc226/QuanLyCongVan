namespace UI
{
    partial class formKiemTraAI
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
            this.lblDiemSo = new System.Windows.Forms.Label();
            this.btnQuetAI = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.txtDeXuat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKetQuaLoi = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiemSo
            // 
            this.lblDiemSo.AutoSize = true;
            this.lblDiemSo.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemSo.Location = new System.Drawing.Point(105, 64);
            this.lblDiemSo.Name = "lblDiemSo";
            this.lblDiemSo.Size = new System.Drawing.Size(131, 50);
            this.lblDiemSo.TabIndex = 1;
            this.lblDiemSo.Text = "--/100";
            // 
            // btnQuetAI
            // 
            this.btnQuetAI.Location = new System.Drawing.Point(308, 533);
            this.btnQuetAI.Name = "btnQuetAI";
            this.btnQuetAI.Size = new System.Drawing.Size(127, 53);
            this.btnQuetAI.TabIndex = 2;
            this.btnQuetAI.Text = "Quét thể thức";
            this.btnQuetAI.UseVisualStyleBackColor = true;
            this.btnQuetAI.Click += new System.EventHandler(this.btnQuetAI_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(21, 190);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(181, 20);
            this.lblThongBao.TabIndex = 3;
            this.lblThongBao.Text = "Đang chờ quét văn bản...";
            // 
            // txtDeXuat
            // 
            this.txtDeXuat.Location = new System.Drawing.Point(6, 289);
            this.txtDeXuat.Multiline = true;
            this.txtDeXuat.Name = "txtDeXuat";
            this.txtDeXuat.ReadOnly = true;
            this.txtDeXuat.Size = new System.Drawing.Size(503, 72);
            this.txtDeXuat.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Đề xuất từ AI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(208, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 32);
            this.label4.TabIndex = 44;
            this.label4.Text = "KIỂM TRA THỂ THỨC VĂN BẢN TỰ ĐỘNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(29, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tập tin văn bản:";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.ForeColor = System.Drawing.Color.Blue;
            this.lblFilePath.Location = new System.Drawing.Point(148, 76);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(60, 17);
            this.lblFilePath.TabIndex = 46;
            this.lblFilePath.Text = "File path";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(502, 533);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 53);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Trạng thái:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDiemSo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblThongBao);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 378);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AI PHÂN TÍCH";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKetQuaLoi);
            this.groupBox2.Controls.Add(this.txtDeXuat);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(450, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 378);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KẾT QUẢ ĐÁNH GIÁ CHI TIẾT";
            // 
            // txtKetQuaLoi
            // 
            this.txtKetQuaLoi.Location = new System.Drawing.Point(6, 26);
            this.txtKetQuaLoi.Name = "txtKetQuaLoi";
            this.txtKetQuaLoi.Size = new System.Drawing.Size(500, 237);
            this.txtKetQuaLoi.TabIndex = 6;
            this.txtKetQuaLoi.Text = "";
            // 
            // formKiemTraAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 624);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnQuetAI);
            this.Name = "formKiemTraAI";
            this.Text = "Kiểm tra thể thức bằng AI";
            this.Load += new System.EventHandler(this.formKiemTraAI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDiemSo;
        private System.Windows.Forms.Button btnQuetAI;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.TextBox txtDeXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtKetQuaLoi;
    }
}
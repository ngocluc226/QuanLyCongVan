namespace UI
{
    partial class formPhanCong
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
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.cbPhongBan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYKien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rdPhongBan = new System.Windows.Forms.RadioButton();
            this.rdCaNhan = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cbUser
            // 
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(552, 201);
            this.cbUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(160, 24);
            this.cbUser.TabIndex = 0;
            // 
            // cbPhongBan
            // 
            this.cbPhongBan.FormattingEnabled = true;
            this.cbPhongBan.Location = new System.Drawing.Point(188, 204);
            this.cbPhongBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPhongBan.Name = "cbPhongBan";
            this.cbPhongBan.Size = new System.Drawing.Size(187, 24);
            this.cbPhongBan.TabIndex = 1;
            this.cbPhongBan.SelectedIndexChanged += new System.EventHandler(this.cbPhongBan_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 210);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phòng ban";
            // 
            // txtYKien
            // 
            this.txtYKien.Location = new System.Drawing.Point(188, 263);
            this.txtYKien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYKien.Multiline = true;
            this.txtYKien.Name = "txtYKien";
            this.txtYKien.Size = new System.Drawing.Size(524, 61);
            this.txtYKien.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ý kiến chỉ đạo";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(343, 348);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(225, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(456, 41);
            this.label4.TabIndex = 44;
            this.label4.Text = "PHÂN CÔNG XỬ LÝ CÔNG VĂN";
            // 
            // rdPhongBan
            // 
            this.rdPhongBan.AutoSize = true;
            this.rdPhongBan.Location = new System.Drawing.Point(85, 110);
            this.rdPhongBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdPhongBan.Name = "rdPhongBan";
            this.rdPhongBan.Size = new System.Drawing.Size(123, 20);
            this.rdPhongBan.TabIndex = 45;
            this.rdPhongBan.TabStop = true;
            this.rdPhongBan.Text = "Giao cho phòng";
            this.rdPhongBan.UseVisualStyleBackColor = true;
            this.rdPhongBan.CheckedChanged += new System.EventHandler(this.rdPhongBan_CheckedChanged);
            // 
            // rdCaNhan
            // 
            this.rdCaNhan.AutoSize = true;
            this.rdCaNhan.Location = new System.Drawing.Point(298, 110);
            this.rdCaNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdCaNhan.Name = "rdCaNhan";
            this.rdCaNhan.Size = new System.Drawing.Size(132, 20);
            this.rdCaNhan.TabIndex = 46;
            this.rdCaNhan.TabStop = true;
            this.rdCaNhan.Text = "Giao cho cá nhân";
            this.rdCaNhan.UseVisualStyleBackColor = true;
            this.rdCaNhan.CheckedChanged += new System.EventHandler(this.rdCaNhan_CheckedChanged);
            // 
            // formPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 404);
            this.Controls.Add(this.rdCaNhan);
            this.Controls.Add(this.rdPhongBan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYKien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPhongBan);
            this.Controls.Add(this.cbUser);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formPhanCong";
            this.Text = "formPhanCong";
            this.Load += new System.EventHandler(this.formPhanCong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.ComboBox cbPhongBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYKien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdPhongBan;
        private System.Windows.Forms.RadioButton rdCaNhan;
    }
}
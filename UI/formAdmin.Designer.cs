namespace UI
{
    partial class formAdmin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCongVanDi = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnCongVanDen = new System.Windows.Forms.Button();
            this.btnPhongBan = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.btnCongVanDi);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnCongVanDen);
            this.panel1.Controls.Add(this.btnPhongBan);
            this.panel1.Controls.Add(this.btnUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 566);
            this.panel1.TabIndex = 0;
            // 
            // btnCongVanDi
            // 
            this.btnCongVanDi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnCongVanDi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCongVanDi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongVanDi.ForeColor = System.Drawing.Color.White;
            this.btnCongVanDi.Location = new System.Drawing.Point(0, 141);
            this.btnCongVanDi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCongVanDi.Name = "btnCongVanDi";
            this.btnCongVanDi.Size = new System.Drawing.Size(264, 47);
            this.btnCongVanDi.TabIndex = 6;
            this.btnCongVanDi.Text = "CÔNG VĂN ĐI";
            this.btnCongVanDi.UseVisualStyleBackColor = false;
            this.btnCongVanDi.Click += new System.EventHandler(this.btnCongVanDi_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(0, 517);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(264, 47);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "ĐĂNG XUẤT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.Location = new System.Drawing.Point(0, 188);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(264, 47);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "LỊCH SỬ";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnCongVanDen
            // 
            this.btnCongVanDen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnCongVanDen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCongVanDen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongVanDen.ForeColor = System.Drawing.Color.White;
            this.btnCongVanDen.Location = new System.Drawing.Point(0, 94);
            this.btnCongVanDen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCongVanDen.Name = "btnCongVanDen";
            this.btnCongVanDen.Size = new System.Drawing.Size(264, 47);
            this.btnCongVanDen.TabIndex = 2;
            this.btnCongVanDen.Text = "CÔNG VĂN ĐẾN";
            this.btnCongVanDen.UseVisualStyleBackColor = false;
            this.btnCongVanDen.Click += new System.EventHandler(this.btnCongVan_Click);
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnPhongBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhongBan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhongBan.ForeColor = System.Drawing.Color.White;
            this.btnPhongBan.Location = new System.Drawing.Point(0, 47);
            this.btnPhongBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.Size = new System.Drawing.Size(264, 47);
            this.btnPhongBan.TabIndex = 1;
            this.btnPhongBan.Text = "PHÒNG BAN";
            this.btnPhongBan.UseVisualStyleBackColor = false;
            this.btnPhongBan.Click += new System.EventHandler(this.btnPhongBan_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(0, 0);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(264, 47);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "NGƯỜI DÙNG";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(266, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(954, 566);
            this.pnlContent.TabIndex = 1;
            // 
            // formAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(223)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1220, 566);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formAdmin";
            this.Text = "formAdmin";
            this.Load += new System.EventHandler(this.formAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnCongVanDen;
        private System.Windows.Forms.Button btnPhongBan;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCongVanDi;
    }
}
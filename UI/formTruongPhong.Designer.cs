namespace UI
{
    partial class formTruongPhong
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnCVDi = new System.Windows.Forms.Button();
            this.btnCVDen = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panelSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSide.Controls.Add(this.btnCVDi);
            this.panelSide.Controls.Add(this.btnCVDen);
            this.panelSide.Controls.Add(this.btnLogout);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(220, 700);
            this.panelSide.TabIndex = 0;
            // 
            // btnCVDi
            // 
            this.btnCVDi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnCVDi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCVDi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCVDi.ForeColor = System.Drawing.Color.White;
            this.btnCVDi.Location = new System.Drawing.Point(0, 50);
            this.btnCVDi.Name = "btnCVDi";
            this.btnCVDi.Size = new System.Drawing.Size(218, 50);
            this.btnCVDi.TabIndex = 1;
            this.btnCVDi.Text = "Công văn đi";
            this.btnCVDi.UseVisualStyleBackColor = false;
            // 
            // btnCVDen
            // 
            this.btnCVDen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnCVDen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCVDen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCVDen.ForeColor = System.Drawing.Color.White;
            this.btnCVDen.Location = new System.Drawing.Point(0, 0);
            this.btnCVDen.Name = "btnCVDen";
            this.btnCVDen.Size = new System.Drawing.Size(218, 50);
            this.btnCVDen.TabIndex = 0;
            this.btnCVDen.Text = "Công văn đến";
            this.btnCVDen.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 648);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(218, 50);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(980, 700);
            this.pnlContent.TabIndex = 1;
            // 
            // formTruongPhong
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panelSide);
            this.Name = "formTruongPhong";
            this.Text = "Trưởng Phòng - Quản Lý Công Văn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnCVDen;
        private System.Windows.Forms.Button btnCVDi;
        private System.Windows.Forms.Button btnLogout;
    }
}

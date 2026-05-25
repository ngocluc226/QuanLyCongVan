namespace UI
{
    partial class formNhanVien
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCVDi = new System.Windows.Forms.Button();
            this.btnCVDen = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(266, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(801, 554);
            this.pnlContent.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnCVDi);
            this.panel1.Controls.Add(this.btnCVDen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 554);
            this.panel1.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Location = new System.Drawing.Point(0, 506);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(264, 46);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCVDi
            // 
            this.btnCVDi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCVDi.Location = new System.Drawing.Point(0, 46);
            this.btnCVDi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCVDi.Name = "btnCVDi";
            this.btnCVDi.Size = new System.Drawing.Size(264, 46);
            this.btnCVDi.TabIndex = 1;
            this.btnCVDi.Text = "Công văn đi";
            this.btnCVDi.UseVisualStyleBackColor = true;
            this.btnCVDi.Click += new System.EventHandler(this.btnCVDi_Click);
            // 
            // btnCVDen
            // 
            this.btnCVDen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCVDen.Location = new System.Drawing.Point(0, 0);
            this.btnCVDen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCVDen.Name = "btnCVDen";
            this.btnCVDen.Size = new System.Drawing.Size(264, 46);
            this.btnCVDen.TabIndex = 0;
            this.btnCVDen.Text = "Công văn đến";
            this.btnCVDen.UseVisualStyleBackColor = true;
            this.btnCVDen.Click += new System.EventHandler(this.btnCVDen_Click);
            // 
            // formNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formNhanVien";
            this.Text = "Quản lý công văn";
            this.Load += new System.EventHandler(this.formNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCVDi;
        private System.Windows.Forms.Button btnCVDen;
    }
}
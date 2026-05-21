namespace UI
{
    partial class formLanhDao
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
            this.btnUyQuyen = new System.Windows.Forms.Button();
            this.btnCVDen = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(600, 450);
            this.pnlContent.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnUyQuyen);
            this.panel1.Controls.Add(this.btnCVDi);
            this.panel1.Controls.Add(this.btnCVDen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 411);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(198, 37);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
                        // 
            // btnUyQuyen
            // 
            this.btnUyQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnUyQuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUyQuyen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUyQuyen.ForeColor = System.Drawing.Color.White;
            this.btnUyQuyen.Location = new System.Drawing.Point(0, 92);
            this.btnUyQuyen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUyQuyen.Name = "btnUyQuyen";
            this.btnUyQuyen.Size = new System.Drawing.Size(264, 46);
            this.btnUyQuyen.TabIndex = 2;
            this.btnUyQuyen.Text = "Ủy quyền xử lý";
            this.btnUyQuyen.UseVisualStyleBackColor = false;
            this.btnUyQuyen.Click += new System.EventHandler(this.btnUyQuyen_Click);
            // 
            // btnCVDi
            // 
            this.btnCVDi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnCVDi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCVDi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCVDi.ForeColor = System.Drawing.Color.White;
            this.btnCVDi.Location = new System.Drawing.Point(0, 37);
            this.btnCVDi.Name = "btnCVDi";
            this.btnCVDi.Size = new System.Drawing.Size(198, 37);
            this.btnCVDi.TabIndex = 1;
            this.btnCVDi.Text = "Công văn đi";
            this.btnCVDi.UseVisualStyleBackColor = false;
            this.btnCVDi.Click += new System.EventHandler(this.btnCVDi_Click);
            // 
            // btnCVDen
            // 
            this.btnCVDen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(106)))), ((int)(((byte)(177)))));
            this.btnCVDen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCVDen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCVDen.ForeColor = System.Drawing.Color.White;
            this.btnCVDen.Location = new System.Drawing.Point(0, 0);
            this.btnCVDen.Name = "btnCVDen";
            this.btnCVDen.Size = new System.Drawing.Size(198, 37);
            this.btnCVDen.TabIndex = 0;
            this.btnCVDen.Text = "Công văn đến";
            this.btnCVDen.UseVisualStyleBackColor = false;
            this.btnCVDen.Click += new System.EventHandler(this.btnCVDen_Click);
            // 
            // formLanhDao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Name = "formLanhDao";
            this.Text = "formLanhDao";
            this.Load += new System.EventHandler(this.formLanhDao_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCVDi;
        private System.Windows.Forms.Button btnUyQuyen;
        private System.Windows.Forms.Button btnCVDen;
    }
}

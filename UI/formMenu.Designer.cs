namespace UI
{
    partial class formMenu
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
            this.btnCVDENCreate = new System.Windows.Forms.Button();
            this.btnCVDiList = new System.Windows.Forms.Button();
            this.btnCVDENList = new System.Windows.Forms.Button();
            this.btnCVDICreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCVDENCreate
            // 
            this.btnCVDENCreate.Location = new System.Drawing.Point(181, 76);
            this.btnCVDENCreate.Name = "btnCVDENCreate";
            this.btnCVDENCreate.Size = new System.Drawing.Size(137, 41);
            this.btnCVDENCreate.TabIndex = 0;
            this.btnCVDENCreate.Text = "Thêm CV đến";
            this.btnCVDENCreate.UseVisualStyleBackColor = true;
            this.btnCVDENCreate.Click += new System.EventHandler(this.btnCVDENCreate_Click);
            // 
            // btnCVDiList
            // 
            this.btnCVDiList.Location = new System.Drawing.Point(371, 145);
            this.btnCVDiList.Name = "btnCVDiList";
            this.btnCVDiList.Size = new System.Drawing.Size(134, 46);
            this.btnCVDiList.TabIndex = 1;
            this.btnCVDiList.Text = "Danh sách CV đi";
            this.btnCVDiList.UseVisualStyleBackColor = true;
            this.btnCVDiList.Click += new System.EventHandler(this.btnCVDiList_Click);
            // 
            // btnCVDENList
            // 
            this.btnCVDENList.Location = new System.Drawing.Point(181, 145);
            this.btnCVDENList.Name = "btnCVDENList";
            this.btnCVDENList.Size = new System.Drawing.Size(137, 46);
            this.btnCVDENList.TabIndex = 2;
            this.btnCVDENList.Text = "Danh sách CV đến";
            this.btnCVDENList.UseVisualStyleBackColor = true;
            this.btnCVDENList.Click += new System.EventHandler(this.btnCVDENList_Click);
            // 
            // btnCVDICreate
            // 
            this.btnCVDICreate.Location = new System.Drawing.Point(371, 76);
            this.btnCVDICreate.Name = "btnCVDICreate";
            this.btnCVDICreate.Size = new System.Drawing.Size(134, 41);
            this.btnCVDICreate.TabIndex = 3;
            this.btnCVDICreate.Text = "Thêm CV đi";
            this.btnCVDICreate.UseVisualStyleBackColor = true;
            this.btnCVDICreate.Click += new System.EventHandler(this.btnCVDICreate_Click);
            // 
            // formMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCVDICreate);
            this.Controls.Add(this.btnCVDENList);
            this.Controls.Add(this.btnCVDiList);
            this.Controls.Add(this.btnCVDENCreate);
            this.Name = "formMenu";
            this.Text = "formMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCVDENCreate;
        private System.Windows.Forms.Button btnCVDiList;
        private System.Windows.Forms.Button btnCVDENList;
        private System.Windows.Forms.Button btnCVDICreate;
    }
}
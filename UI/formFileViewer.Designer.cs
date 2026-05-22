namespace UI
{
    partial class formFileViewer
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
            this.picViewer = new System.Windows.Forms.PictureBox();
            this.webViewer = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // picViewer
            // 
            this.picViewer.Location = new System.Drawing.Point(29, 15);
            this.picViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picViewer.Name = "picViewer";
            this.picViewer.Size = new System.Drawing.Size(736, 719);
            this.picViewer.TabIndex = 0;
            this.picViewer.TabStop = false;
            this.picViewer.Visible = false;
            // 
            // webViewer
            // 
            this.webViewer.Location = new System.Drawing.Point(16, -6);
            this.webViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webViewer.MinimumSize = new System.Drawing.Size(27, 25);
            this.webViewer.Name = "webViewer";
            this.webViewer.Size = new System.Drawing.Size(760, 740);
            this.webViewer.TabIndex = 1;
            this.webViewer.Visible = false;
            // 
            // formFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 748);
            this.Controls.Add(this.webViewer);
            this.Controls.Add(this.picViewer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formFileViewer";
            this.Text = "Xem file";
            this.Load += new System.EventHandler(this.formFileViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picViewer;
        private System.Windows.Forms.WebBrowser webViewer;
    }
}
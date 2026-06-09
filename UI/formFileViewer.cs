using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class formFileViewer : Form
    {
        private string _filePath;

        public formFileViewer(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;
        }

        private void formFileViewer_Load(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void LoadFile()
        {
            if (!File.Exists(_filePath))
            {
                MessageBox.Show("File không tồn tại!");
                return;
            }

            string ext = Path.GetExtension(_filePath).ToLower();

            picViewer.Visible = false;
            webViewer.Visible = false;

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                picViewer.Image = Image.FromFile(_filePath);
                picViewer.SizeMode = PictureBoxSizeMode.Zoom;
                picViewer.Visible = true;
            }
            else if (ext == ".pdf")
            {
                webViewer.Navigate(_filePath);
                webViewer.Visible = true;
            }
            else if (ext == ".doc" || ext == ".docx")
            {
                System.Diagnostics.Process.Start(_filePath);
                this.Close();
            }
            else
            {
                System.Diagnostics.Process.Start(_filePath);
                this.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class formLogHethong : Form
    {
        public formLogHethong()
        {
            InitializeComponent();
            Utils.FormatDataGridView(dgvLog);
            LoadData();
        }
        private void LoadData()
        {
            dgvLog.DataSource = BLL.LogBLL.Instance.GetAll();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

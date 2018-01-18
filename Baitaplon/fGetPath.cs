using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fGetPath : Form
    {
        public string newpath = null;
        public fGetPath(string loai)
        {
            newpath = null;
            InitializeComponent();
            if (loai == "Rename")
            {
                label1.Text = "Tên mới";
                btn_choose.Visible = false;
            }
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            newpath = txtFolderPath.Text;
            this.Close();
        }
    }
}

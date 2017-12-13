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
    public partial class fMainform : Form
    {
        public fMainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fTimkiemthucong f = new fTimkiemthucong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fTimkiemnhap f = new fTimkiemnhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btn_findinfile_Click(object sender, EventArgs e)
        {
            fTimkiemInTxt f = new fTimkiemInTxt();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        
    }
}

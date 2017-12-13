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
    public partial class fThongbao : Form
    {
        public fThongbao()
        {
            InitializeComponent();
            XWord.ConventRTF += XWord_Convent;
            XWord.Docfile += XWord_Docfile;
        }
        
        private void XWord_Docfile(object sender, EventArgs e)
        {
            label1.Text = "đang đọc file word";
            label1.BackColor = Color.Yellow;
        }

        private void XWord_Convent(object sender, EventArgs e)
        {
            label1.Text = "đang chuyển file word";
            label1.BackColor = Color.Red;
        }
    }
}

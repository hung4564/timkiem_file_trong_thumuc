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
    public partial class Form2 : Form
    {
        public Form2(string path)
        {
            InitializeComponent();
            Bitmap bm = new Bitmap(path);
            Bitmap bm1 = new Bitmap(bm, new Size(pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = bm1;
            //pictureBox1.ImageLocation = path;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}

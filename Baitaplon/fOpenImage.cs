using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fOpenImage : Form
    {
        public fOpenImage()
        {
            InitializeComponent();
        }


        private void fOpenImage_Load(object sender, EventArgs e)
        {

        }


        //Mở ảnh với APP bên ngoài, ví dụ Open With PhotoViewer
        private void photoViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Title = "Chọn file ảnh có đuôi .jpg; .bmp; .jpeg; .gif";
            openf.Filter = "All Files|*.*";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                Process photoViewer = new Process();
                photoViewer.StartInfo.FileName = openf.FileName;
                photoViewer.StartInfo.Arguments = @"Your image file path";
                photoViewer.Start();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Title = "Chọn file ảnh có đuôi .jpg; .bmp; .jpeg; .gif";
            openf.Filter = "All Files|*.*";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = new Bitmap(openf.FileName);
                pictureBox1.Image = bm;
                // Cách 2 là: pictureBox1.ImageLocation = openf.FileName;
                //Lưu ý là phải cmt 2 dòng phía trên để dùng cách 2.
            }

        }
    }
}

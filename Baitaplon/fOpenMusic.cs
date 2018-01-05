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
    public partial class fOpenMusic : Form
    {
        public fOpenMusic()
        {
            InitializeComponent();
            MediaPlayer.uiMode = "none";  // Ẩn thanh điều khiển của control MediaPlayer
            //MediaPlayer.settings.mute = true;   //Thanh âm lượng
        }

        private void fOpenMusic_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)  //click button ...
        {
            OpenFileDialog openfile = new OpenFileDialog();
            //openfile.Filter = "All file|*.*"; 
            openfile.FileName = "Chọn 1 media";
            openfile.Filter = "File Nhạc(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MediaPlayer.URL = openfile.FileName;
                    label1.Text = "Bạn đang nghe:" + XPath.GetFileNameWithoutExtension(openfile.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  //Click Stop
        {
            MediaPlayer.Ctlcontrols.stop();
        }

        private void button2_Click(object sender, EventArgs e)  //Click Start
        {
            MediaPlayer.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)  //fullscreen
        {
            if (MediaPlayer.URL.Length > 0)
            {
                MediaPlayer.fullScreen = true;
            }

        }

        private void MediaPlayer_Enter(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.pause();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

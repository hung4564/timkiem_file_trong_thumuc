using System;
using System.Windows.Forms;

namespace Baitaplon
{
    public enum Loaifile
    {
        Txt,
        Word
    }
    public partial class fOpenText : Form
    {
        string path = null;
        string Boldstring;
        int vitri = 0;
        public fOpenText()
        {
            InitializeComponent();
        }
        public fOpenText(string path, string tuboiden, Loaifile loai)
        {
            InitializeComponent();
            this.path = path;
            if (loai == Loaifile.Txt)
                richTextBox1.Text = XTxt.ReadText(path);
            else if (loai == Loaifile.Word)
            {
                richTextBox1.Rtf = XWord.ReadWord(path);
            }
            //boi dam tu tim kiem
            this.Boldstring = tuboiden;
            textBox1.Text = Boldstring;
            boiden();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp = richTextBox1.Rtf;
            richTextBox1.Rtf = "";
            richTextBox1.Rtf = temp;
            Reset();
            boiden();
        }
        void boiden()
        {
            string[] words = textBox1.Text.Split(',');
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < richTextBox1.TextLength)
                {
                    int wordStartInex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);
                    if (wordStartInex != -1)
                    {
                        richTextBox1.SelectionStart = wordStartInex;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionBackColor = System.Drawing.Color.Yellow;
                    }
                    else
                        break;
                    startIndex = wordStartInex + word.Length;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
        }
        void Reset()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = System.Drawing.Color.White;
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.Title = "Chọn file text đuôi .txt";
            open.Filter = "All Files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (open.FileName.Contains(".doc") || open.FileName.Contains(".docx"))
                        richTextBox1.Rtf = XWord.ReadWord(open.FileName);
                    else
                        richTextBox1.Text = XTxt.ReadText(open.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi" + ex.Message);
                }
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            string timkiem = textBox1.Text;
            if (vitri <= 0) vitri = 0;
            else vitri = vitri + timkiem.Length;
            vitri = richTextBox1.Text.IndexOf(timkiem, vitri);
            if (vitri >= 0)
            {
                richTextBox1.SelectionStart = vitri;
                richTextBox1.SelectionLength = timkiem.Length;
                richTextBox1.Focus(); ;
            }
            else
            {
                MessageBox.Show(string.Format("Không tìm thấy từ \"{0}\"", timkiem));
            }
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            string timkiem = textBox1.Text;
            if (vitri <= 0) vitri = vitri = richTextBox1.TextLength;
            else
            if (vitri > timkiem.Length) vitri = vitri - timkiem.Length;
            vitri = richTextBox1.Text.LastIndexOf(timkiem, vitri);
            if (vitri >= 0)
            {
                richTextBox1.SelectionStart = vitri;
                richTextBox1.SelectionLength = timkiem.Length;
                richTextBox1.Focus();
            }
            else
            {
                MessageBox.Show(string.Format("Không tìm thấy từ \"{0}\"", timkiem));
            }

        }
    }
}

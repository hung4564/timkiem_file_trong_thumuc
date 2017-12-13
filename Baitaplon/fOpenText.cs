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
        public fOpenText()
        {
            InitializeComponent();
        }
        public fOpenText(string path, Loaifile loai)
        {
            InitializeComponent();
            this.path = path;
            if (loai == Loaifile.Txt)
                richTextBox1.Text = XTxt.ReadText(path);
            else if (loai == Loaifile.Word)
            {
                richTextBox1.Rtf = XWord.ReadWord(path);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string temp = richTextBox1.Rtf;
            richTextBox1.Rtf = "";
            richTextBox1.Rtf = temp;
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
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = System.Drawing.Color.White;
        }
    }
}

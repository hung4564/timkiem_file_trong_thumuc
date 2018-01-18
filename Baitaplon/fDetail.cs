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
    public partial class fDetail : Form
    {
        string path;
        public fDetail(string path)
        {
            InitializeComponent();
            this.path = path;
            load();
        }
        void load()
        {
            if ((System.IO.File.GetAttributes(path).HasFlag(System.IO.FileAttributes.Directory)))
            {
                System.IO.DirectoryInfo temp = new System.IO.DirectoryInfo(path);
                txt_name.Text = temp.Name;
                txt_lengh.Text = "không xác định";
                txt_ext.Text = temp.Extension.ToLower();
                txt_createtime.Text = temp.CreationTime.ToString();
                txt_lastaccess.Text = temp.LastAccessTime.ToString();
            }
            else
            {
                System.IO.FileInfo temp = new System.IO.FileInfo(path);
                txt_name.Text = temp.Name;
                txt_lengh.Text = temp.Length.ToString();
                txt_ext.Text = temp.Extension.ToLower();
                txt_createtime.Text = temp.CreationTime.ToString();
                txt_lastaccess.Text = temp.LastAccessTime.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fGetPath f = new fGetPath("Xuly");
            f.ShowDialog();
            string newpath = f.newpath;
            if (newpath != null)
                if (System.IO.File.GetAttributes(path).HasFlag(System.IO.FileAttributes.Directory))
                XFolder.MoveFolderTo(path, newpath);
            else
                XFile.MoveTo(path, newpath);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fGetPath f = new fGetPath("Xuly");
            f.ShowDialog();
            string newpath = f.newpath;
            if(newpath!=null)
            if (System.IO.File.GetAttributes(path).HasFlag(System.IO.FileAttributes.Directory))
                XFolder.CopyFolderTo(path, newpath);
            else
                XFile.CopyTo(path, newpath);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fGetPath f = new fGetPath("Rename");
            f.ShowDialog();
            string newname = f.newpath;
            if(newname!=null)
            if (System.IO.File.GetAttributes(path).HasFlag(System.IO.FileAttributes.Directory))
                XFolder.RenameFolder(path, newname);
            else
                XFile.CopyTo(path, newname);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (System.IO.File.GetAttributes(path).HasFlag(System.IO.FileAttributes.Directory))
                XFolder.DeleteFolder(path);
            else
                XFile.Delete(path);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string info = string.Format("Tên:{0}\nKích thước:{1}\nĐịnh dạng:{2}\nThời gian tạo:{3}\nTHời gian truy cập cuối:{4}", txt_name.Text, txt_lengh.Text, txt_ext.Text, txt_createtime.Text, txt_lastaccess.Text);
            MessageBox.Show(info);
            XFile.CopyInfo(path);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] txt = new string[] { ".txt" };
            string[] word = new string[] { ".docx", ".doc" };
            string[] music = new string[] { ".mp3", ".mp4" };
            string[] image = new string[] { ".jpg", ".png" ,".ico"};
            if (txt.Contains(txt_ext.Text))
            {
                fOpenText f = new fOpenText(path, Loaifile.Txt);
                f.ShowDialog();
            }
            else if (word.Contains(txt_ext.Text))
            {
                fOpenText f = new fOpenText(path, Loaifile.Word);
                f.ShowDialog();
            }
            else if (music.Contains(txt_ext.Text))
            {
                fOpenMusic f = new fOpenMusic(path);
                f.ShowDialog();
            }
            else if(image.Contains(txt_ext.Text))
            {
                Form2 f = new Form2(path);
                f.ShowDialog();

            }
            else MessageBox.Show("Không hỗ trợ mở");

        }
    }
}

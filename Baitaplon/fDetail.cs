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
            if (System.IO.File.GetAttributes(path) == System.IO.FileAttributes.Directory)
            {
                System.IO.DirectoryInfo temp = new System.IO.DirectoryInfo(path);
                txt_name.Text = temp.Name;
                txt_lengh.Text = "không xác định";
                txt_ext.Text = temp.Extension;
                txt_createtime.Text = temp.CreationTime.ToString();
                txt_lastaccess.Text = temp.LastAccessTime.ToString();
            }
            else
            {
                System.IO.FileInfo temp = new System.IO.FileInfo(path);
                txt_name.Text = temp.Name;
                txt_lengh.Text = temp.Length.ToString();
                txt_ext.Text = temp.Extension;
                txt_createtime.Text = temp.CreationTime.ToString();
                txt_lastaccess.Text = temp.LastAccessTime.ToString();

            }
        }
    }
}

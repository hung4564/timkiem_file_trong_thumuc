using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fTimkiemthucong : Form
    {
        public fTimkiemthucong()
        {
            InitializeComponent();
        }
        #region Thuộc tính
        private string dirCurrent
        {
            get
            {
                if (treeView2.Tag != null)
                    return treeView2.Tag.ToString();
                else return "";
            }
        }
        private Stack<string> dirBack = new Stack<string>();
        private Stack<string> dirForward = new Stack<string>();
        #endregion
        #region Phương thức
        void GetBack(string dir)
        {
            if (dirCurrent != "")
            {
                dirBack.Push(dir);
            }

        }
        void LoadBack_tree(TreeView treeView)
        {
            treeView.Nodes.Clear();
            foreach (string item in dirBack.ToList())
            {
                treeView.Nodes.Add(item);
            }
        }
        void LoadForward_tree(TreeView treeView)
        {
            treeView.Nodes.Clear();
            foreach (string item in dirForward.ToList())
            {
                treeView.Nodes.Add(item);
            }
        }
        /// <summary>
        /// Load anh ico vao imagelit
        /// </summary>
        /// <param name="list"></param>
        void LoadIco(ImageList list)
        {
            XImage.LoadImageToList(list);
        }

        #endregion
        #region Sự kiện
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadIco(listIcon);
            treeView2.ImageList = listIcon;
            XDriveInfo.LoadDrives(treeView1);
            txt_current.Text = dirCurrent;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();
                    string dirnode = e.Node.Tag.ToString();
                    List<TreeNode> listNode = XFolder.LoadFolder(dirnode);
                    foreach (TreeNode item in listNode)
                    {
                        e.Node.Nodes.Add(item);
                    }
                }
            }
            txt_current.Text = dirCurrent;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetBack(dirCurrent);
            dirForward.Clear();
            if (e.Node.Tag != null)
            {
                treeView2.Nodes.Clear();
                XFile.LoadFileandFolded(e.Node.Tag.ToString(), treeView2);
            }
            txt_current.Text = dirCurrent;
        }

        private void treeView2_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string dirnode = e.Node.Tag.ToString();
            treeView2.Nodes.Clear();
            XFile.LoadFileandFolded(dirnode, treeView2);
            txt_current.Text = dirCurrent;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string dirnode = e.Node.Tag.ToString();
            if (File.GetAttributes(dirnode) == FileAttributes.Directory)
            {
                GetBack(dirCurrent);
                XFile.LoadFileandFolded(dirnode, treeView2);
                txt_current.Text = dirCurrent;
            }
            else
            {
                fDetail f = new fDetail(dirnode);
                f.ShowDialog();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            XFile.LoadFileandFolded(treeView2.Tag.ToString(), treeView2);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (dirBack.Count == 0) return;
            dirForward.Push(dirCurrent);
            string dir = dirBack.Pop();
            XFile.LoadFileandFolded(dir, treeView2);
            txt_current.Text = dirCurrent;
        }

        private void btn_Forward_Click(object sender, EventArgs e)
        {
            if (dirForward.Count == 0) return;
            dirBack.Push(dirCurrent);
            string dir = dirForward.Pop();
            XFile.LoadFileandFolded(dir, treeView2);
            txt_current.Text = dirCurrent;
        }
        #endregion

    }
}

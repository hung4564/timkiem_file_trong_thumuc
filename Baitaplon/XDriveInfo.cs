using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    class XDriveInfo
    {
        //Lấy ra toàn bộ dirve vào trong treeview
        public static void LoadDrives(TreeView treeview)
        {
            string[] drives = XDriveInfo.LoadDrive();
            int index = (int)XImage.listIndex[(int)IndexImage.Drive];
            foreach (string drive in drives)
            {
                //Tạo node cho drive
                DriveInfo di = new DriveInfo(drive);
                TreeNode node = new TreeNode(drive.Substring(0, 1), index, index);
                //tag của node lưu đường dẫn của fileMO
                node.Tag = drive;
                if (di.IsReady == true)
                    node.Nodes.Add("...");
                //gắn node vào tree
                treeview.Nodes.Add(node);
            }
        }
        //Lấy ra danh sách toàn bộ dirve
        public static string[] LoadDrive()
        {
            return Directory.GetLogicalDrives();
        }
    }
}


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
        public static void LoadDrives(TreeView treeNode)
        {
            string[] drives = XDriveInfo.LoadDrive();
            int index = (int)XImage.listIndex[(int)IndexImage.Drive];
            foreach (string drive in drives)
            {
                //Tạo node cho drive
                DriveInfo di = new DriveInfo(drive);
                TreeNode node = new TreeNode(drive.Substring(0, 1), index, index);
                //tag của node lưu đường dẫn của file
                node.Tag = drive;
                if (di.IsReady == true)
                    node.Nodes.Add("...");
                //gắn node vào tree
                treeNode.Nodes.Add(node);
            }
        }

        public static string[] LoadDrive()
        {
            return Directory.GetLogicalDrives();
        }
    }
}


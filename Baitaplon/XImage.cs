using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public enum IndexImage
    {
        Drive,
        Folder,
        Lock,
        File
    }
    public class XImage
    {
        #region Thuộc tính
        public static System.Collections.Generic.Dictionary<int, int> listIndex = new Dictionary<int, int>();

        public XImage()
        {
        }


        #endregion
        #region Phương thức

        /// <summary>
        /// load anh vao imagelist, gan key tuong ung vs loai key trong IndexImage, ko thi tang dan
        /// </summary>
        /// <param name="list"></param>
        public static void LoadImageToList(ImageList list)
        {
            List<Image> temp = GetIconList();
            foreach (Image item in temp)
            {
                int index = list.Images.Count;
                list.Images.Add(item);
                list.Images.SetKeyName(index, item.Tag.ToString());
                int key = GetIndexFromName(item.Tag.ToString());
                if (key == -1)
                {
                    if (list.Images.Count < 4) key = list.Images.Count + 4;
                }
                listIndex[key] = index;
            }
        }

        /// <summary>
        /// Lay ra ma so ung vs loai file trong IndexImage, neu ko co thi tra ve -1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetIndexFromName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '.') { name = name.Remove(i); break; }
            }
            name = name.ToLower();
            switch (name)
            {
                case "drive":
                    return (int)IndexImage.Drive;
                case "folder":
                    return (int)IndexImage.Folder;
                case "lock":
                    return (int)IndexImage.Lock;
                case "file":
                    return (int)IndexImage.File;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Lay danh sach anh
        /// </summary>
        /// <returns></returns>
        public static List<Image> GetIconList()
        {
            List<Image> temp = new List<Image>();
            string filePath = Application.StartupPath + "\\Resource\\Icon";
            try
            {
                DirectoryInfo dir = new DirectoryInfo(filePath);
                FileInfo[] dirs = dir.GetFiles();
                foreach (FileInfo item in dirs)
                {
                    Image image = Image.FromFile(item.FullName);
                    temp.Add(image);
                    image.Tag = item.Name;
                }
            }
            catch (DirectoryNotFoundException) { MessageBox.Show("Đường dẫn ko hợp lê"); }
            catch (SecurityException) { MessageBox.Show("Thư mục ko đc phép truy cập"); }
            catch (ArgumentNullException) { MessageBox.Show("Không load thư mục chứa icon"); }
            catch (PathTooLongException) { MessageBox.Show("Đường dấn quá dài"); }
            catch (Exception) { }
            return temp;
        }
        //Lấy ảnh từ resources dựa theo đuôi của đường dẫn
        public static Image LoadImagebyExt(string path)
        {
            //lấy ra đuôi của đường dẫn
            string ext = XPath.GetExtention(path);      
            switch (ext)        
            {
                case ".txt":
                    return Properties.Resources.txt;
                case ".pdf":
                    return Properties.Resources.pdf;
                case ".doc":
                    return Properties.Resources.doc;
                case ".docx":
                    return Properties.Resources.docx;
                case ".xls":
                    return Properties.Resources.xls;
                case ".xlsx":
                    return Properties.Resources.xlsx;
                case ".exe":
                    return Properties.Resources.exe;
                case ".jpeg":
                    return Properties.Resources.jpeg;
                case ".png":
                    return Properties.Resources.png;
                default:
                    break;
            }
            return Properties.Resources.file;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    static class XFile
    {
        #region Xử lý

        // sourcefilename là đường dấn link của file được copy
        // destPath là đường dấn tới nơi copy tới
        public static void CopyTo(string sourceFileName, string destPath)
        {
            try
            {
                FileInfo f = new FileInfo(sourceFileName);
                string destFileName = destPath + "\\" + f.Name;
                Copy(sourceFileName, destFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void Copy(string sourceFileName, string destFileName)
        {
            try
            {
                if (File.Exists(destFileName))
                {
                    DialogResult result = MessageBox.Show("File đã tồn tại, bạn có muốn ghi đè lên không", "Chú ý", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(destFileName);
                        File.Copy(sourceFileName, destFileName);
                    }
                }
                else
                {
                    File.Copy(sourceFileName, destFileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        // path là đường dấn của file xóa
        public static void Delete(string path)
        {
            if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                fi.Delete();
            }
        }

        // sourcefilename là đường dấn link của file được move
        // destPath là đường dấn tới nơi move tới
        public static void MoveTo(string sourceFileName, string destPath)
        {
            try
            {
                FileInfo f = new FileInfo(sourceFileName);
                string destFileName = destPath + "\\" + f.Name;
                Move(sourceFileName, destFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void Move(string sourceFileName, string destFileName)
        {
            try
            {
                if (File.Exists(destFileName))
                {
                    DialogResult result = MessageBox.Show("File đã tồn tại, bạn có muốn ghi đè lên không", "Chú ý", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(destFileName);
                        File.Move(sourceFileName, destFileName);
                    }
                }
                else
                {
                    File.Move(sourceFileName, destFileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        //path là đường dấn của file đổi tên, newname là tên mới ko gồm đuôi
        public static void Rename(string path, string newname)
        {
            if (File.Exists(path))
            {
                string rootpath = XPath.DirRoot_Info(path);
                string ext = XPath.GetExtention(path);
                string newpath = rootpath + "\\" + newname + ext;
                Move(path, newpath);
            }
        }

        //Lưu info của file có đường dẫn path vào fileinfo.txt
        public static void CopyInfo(string path)
        {
            FileInfo f = new FileInfo(path);
            string name = f.Name;
            string kichthuoc = f.Length.ToString();
            string dinhdang = f.Extension;
            DateTime thoigiantao = f.CreationTime;
            DateTime truycapcuoi = f.LastAccessTime;
            string result = string.Format("Tên:{0}\nĐịnh dạng:{1}\nThời gian tạo:{2}\nTHời gian truy cập lần cuối:{3}\nKích thước:{4}", name, dinhdang, thoigiantao.ToString(), truycapcuoi.ToString(), kichthuoc);
            File.WriteAllText(@"FIleinfo.txt", result, Encoding.Unicode);
        }

        #endregion

        //trả về danh sách file trong thư mục có đường dẫn dirRoot vào List<treenode>
        public static List<TreeNode> LoadFile(string dirRoot)
        {
            List<TreeNode> listFile = new List<TreeNode>();
            try
            {
                string[] dirs = XFolder.GetFiles(dirRoot).ToArray();
                foreach (string dir in dirs)
                {
                    int index = XImage.listIndex[(int)IndexImage.File];
                    DirectoryInfo di = new DirectoryInfo(dir);
                    TreeNode node = new TreeNode(di.Name, index, index);
                    node.Tag = dir;
                    listFile.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listFile;
        }

        //Trả về danh sách toàn bộ file và folder có trong đường dẫn dirRoot vào treview
        public static void LoadFileandFolded(string dirRoot, TreeView treeView)
        {
            try
            {
                treeView.Nodes.Clear();
                treeView.Tag = dirRoot;
                List<TreeNode> listFolder = XFolder.LoadFolder(dirRoot);
                foreach (TreeNode item in listFolder)
                {
                    treeView.Nodes.Add(item);
                }
                List<TreeNode> listFile = LoadFile(dirRoot);
                foreach (TreeNode item in listFile)
                {
                    treeView.Nodes.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Trả về danh sách path chứa đuôi thỏa mãn các từ trong ext ở trong folder có đường dẫn là root
        public static IEnumerable<string> GetFilebyExt_DFS(string root, string[] ext)//tìm kiếm theo chiều sâu
        {
            //load danh sách theo chiêu sâu
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
                    foreach (var subdir in next) pending.Push(subdir);  //cho vào trong stack
                }
                catch { }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa đuôi cần tìm
                    {
                        if (XPath.IsEqualExt(item, ext))
                        {
                            yield return item;
                        }
                    }
            }
        }
        public static IEnumerable<string> GetFilebyExt_BFS(string root, string[] ext)//tìm kiếm theo chiều rộng
        {
            //load danh sách theo chiêu sâu
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(root);
            while (pending.Count != 0)
            {
                var path = pending.Dequeue();
                string[] next = null;
                try
                {
                    next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
                    foreach (var subdir in next) pending.Enqueue(subdir);  //cho vào trong stack
                }
                catch { }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa đuôi cần tìm
                    {
                        if (XPath.IsEqualExt(item, ext))
                        {
                            yield return item;
                        }
                    }
            }
        }

        public static void GetbyExt_DFS(Queue<string> queue_result, string root, string[] ext, bool IsSearchAllFolder)
        {
            if (IsSearchAllFolder)
            {
                GetAllFilebyExt_DFS(queue_result, root, ext);
            }
            else
            {
                GetFilebyExt_DFS(queue_result, root, ext);
            }
        }
        public static void GetbyExt_BFS(Queue<string> queue_result, string root, string[] ext, bool IsSearchAllFolder)
        {
            if (IsSearchAllFolder)
            {
                GetAllFilebyExt_BFS(queue_result, root, ext);
            }
            else
            {
                GetFilebyExt_BFS(queue_result, root, ext);
            }
        }
        //Trả kết quả về queus result
        //Lấy kết quả trong tất cả folder con
        public static void GetAllFilebyExt_DFS(Queue<string> queue_result, string root, string[] ext)//tìm kiếm theo chiều sâu
        {
            //load danh sách theo chiêu sâu
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
                    foreach (var subdir in next) pending.Push(subdir);  //cho vào trong stack
                }
                catch { }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa đuôi cần tìm
                    {
                        if (XPath.IsEqualExt(item, ext))
                        {
                            queue_result.Enqueue(item);
                        }
                    }
            }
        }
        public static void GetAllFilebyExt_BFS(Queue<string> queue_result, string root, string[] ext)//tìm kiếm theo chiều rộng
        {
            //load danh sách theo chiêu rộng

            Queue<string> pending = new Queue<string>();
            pending.Enqueue(root);
            while (pending.Count != 0)
            {
                var path = pending.Dequeue();
                string[] next = null;
                try
                {
                    next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
                    foreach (var subdir in next) pending.Enqueue(subdir);  //cho vào trong stack
                }
                catch { }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa đuôi cần tìm
                    {
                        if (XPath.IsEqualExt(item, ext))
                        {
                            queue_result.Enqueue(item);
                        }
                    }
            }
        }
        //Lấy kết quả trong 1 forder
        public static void GetFilebyExt_DFS(Queue<string> queue_result, string root, string[] ext)//tìm kiếm theo chiều sâu
        {
            var path = root;
            string[] next = null;
            try
            {
                next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
            }
            catch { }
            try
            {
                next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
            }
            catch { }
            if (next != null)
                foreach (string item in next)                       //kiếm tra trong các file tên có chứa đuôi cần tìm
                {
                    if (XPath.IsEqualExt(item, ext))
                    {
                        queue_result.Enqueue(item);
                    }
                }
        }
        public static void GetFilebyExt_BFS(Queue<string> queue_result, string root, string[] ext)//tìm kiếm theo chiều rộng
        {

            var path = root;
            string[] next = null;
            try
            {
                next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
            }
            catch { }
            try
            {
                next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
            }
            catch { }
            if (next != null)
                foreach (string item in next)                       //kiếm tra trong các file tên có chứa đuôi cần tìm
                {
                    if (XPath.IsEqualExt(item, ext))
                    {
                        queue_result.Enqueue(item);
                    }
                }
        }
    }
}

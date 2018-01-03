﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    static class XFolder
    {
        #region Thuộc tính
        //Chứa thông tin cần lọc
        static XFilter boloc;
        //Hàng đợi lưu đường dẫn chứa kết quả tìm thấy
        public static Queue<string> queue_result;
        #endregion
        #region Phương thức
        #region Xử lý

        //Copyfolder ở từ sourcefolder sang destFolder(có tên folder)
        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                try
                {
                    File.Copy(file, dest);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
        //COpy folder ở sourfolder sang địa chỉ destPath
        static public void CopyFolderTo(string sourceFolder, string destPath)
        {
            string destFolder = destPath + "\\" + XPath.GetFileNameWithoutExtension(sourceFolder);
            CopyFolder(sourceFolder, destFolder);
        }

        //Movefolder ở từ sourcefoler sang destFolderstatic 
        static public void MoveFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                try
                {
                    File.Move(file, dest);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                MoveFolder(folder, dest);
            }
        }
        //Move folder ở sourfolder sang địa chỉ destPath
        static public void MoveFolderTo(string sourceFolder, string destPath)
        {
            string destFolder = destPath + "\\" + XPath.GetFileNameWithoutExtension(sourceFolder);
            MoveFolder(sourceFolder, destFolder);
        }

        public static void RenameFolder(string sourceFolder, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("New name cannot be null or blank", "name");
            }
            if (Directory.Exists(sourceFolder))
            {
                string destFolder = Path.GetPathRoot(sourceFolder) + "\\" + newName;
                Directory.Move(sourceFolder, destFolder);
            }
        }

        public static void DeleteFolder(string sourceFolder)
        {
            if(Directory.Exists(sourceFolder))
            {
                Directory.Delete(sourceFolder, true);
            }
        }
        #endregion

        //trả về danh sách folder trong thư mục có đường dirRoot vào treenode
        public static List<TreeNode> LoadFolder(string dirRoot)
        {
            string[] dirs = Directory.GetDirectories(dirRoot);
            List<TreeNode> listFolder = new List<TreeNode>();
            int index;
            foreach (string dir in dirs)
            {
                index = (int)XImage.listIndex[(int)IndexImage.Folder];
                DirectoryInfo di = new DirectoryInfo(dir);
                TreeNode node = new TreeNode(di.Name, index, index);
                try
                {
                    //keep the directory's full path in the tag for use later
                    node.Tag = dir;

                    //if the directory has sub directories add the place holder
                    if (di.GetDirectories().Count() > 0)
                        node.Nodes.Add(null, "...", 0, 0);
                }
                catch (UnauthorizedAccessException)
                {
                    index = (int)XImage.listIndex[(int)IndexImage.Lock];
                    //display a locked folder icon
                    node.ImageIndex = index;
                    node.SelectedImageIndex = index;
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    listFolder.Add(node);
                }
            }
            return listFolder;
        }


        public static void GetAll_DFS(string root, string search,XFilter loc)
        {
            boloc = loc;
            switch (loc.loailoc)
            {
                case Loailoc.Loctheotungtu:
                    string[] keyword = search.Split(',');
                    GetAll_DFS(root, keyword);
                    break;
                case Loailoc.Loctheochuoi:
                    GetAll_DFS(root, search);
                    break;
                default:
                    break;
            }
        }

        //Trả về danh sách path thỏa mãn vào hàng đợi chứa 1 chuỗi
        public static void GetAll_DFS(string root, string search)//tìm kiếm theo chiều sâu
        {
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
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các folder tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item)&&XPath.IsEqualName(item, search))
                        {
                            queue_result.Enqueue(item);
                        }
                    }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, search))
                        {
                            queue_result.Enqueue(item);
                        }
                    }

            }
        }

        //Trả về danh sách path thỏa mãn vào hàng đợi chứa 1 từ trong số các từ tìm kiếm
        public static void GetAll_DFS(string root, string[] keyword)//tìm kiếm theo chiều sâu
        {
            int i = 0;
            int all = 1;
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                i++;
                try
                {
                    next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
                    foreach (var subdir in next) pending.Push(subdir);  //cho vào trong stack
                    if (next != null) all += next.Count();
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các folder tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, keyword))
                        {
                            queue_result.Enqueue(item);

                        }
                    }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, keyword))
                        {
                            queue_result.Enqueue(item);
                        }
                    }

            }
        }

        public static void GetAll_BFS(string root, string search, XFilter loc)
        {
            boloc = loc;
            switch (loc.loailoc)
            {
                case Loailoc.Loctheotungtu:
                    string[] keyword = search.Split(',');
                    GetAll_BFS(root, keyword);
                    break;
                case Loailoc.Loctheochuoi:
                    GetAll_BFS(root, search);
                    break;
                default:
                    break;
            }
        }
        //Trả về danh sách path thỏa mãn vào hàng đợi chứa 1 chuỗi

        public static void GetAll_BFS(string root, string search)//tìm kiếm theo chiều rộng
        {
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
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các folder tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, search))
                        {
                            queue_result.Enqueue(item);
                        }
                    }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, search))
                        {
                            queue_result.Enqueue(item);
                        }
                    }

            }
        }
        
        //Trả về danh sách path thỏa mãn vào hàng đợi chứa 1 từ trong số các từ tìm kiếm
        public static void GetAll_BFS(string root, string[] keyword)//tìm kiếm theo chiều rộng
        {
            int i = 0;
            int all = 1;
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(root);
            while (pending.Count != 0)
            {
                var path = pending.Dequeue();
                string[] next = null;
                i++;
                try
                {
                    next = Directory.GetDirectories(path);              //lấy ra toàn bộ folder con
                    foreach (var subdir in next) pending.Enqueue(subdir);  //cho vào trong stack
                    if (next != null) all += next.Count();
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các folder tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, keyword))
                        {
                            queue_result.Enqueue(item);

                        }
                    }
                try
                {
                    next = Directory.GetFiles(path);                    //lấy ra toàn bộ file trong folder đấy
                }
                catch { }
                if (next != null)
                    foreach (string item in next)                       //kiếm tra trong các file tên có chứa chuối cần tìm
                    {
                        if (boloc.IsSatisfy(item) && XPath.IsEqualName(item, keyword))
                        {
                            queue_result.Enqueue(item);
                        }
                    }

            }
        }

        #endregion
    }
}

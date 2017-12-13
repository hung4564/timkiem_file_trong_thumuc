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
        public static ListBox list;
        public static Label lblProgress;
        public static BackgroundWorker backgroundWorker1;
        //Copyfolder ở từ sourcefoler sang destFolder
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

        static public void CopyFolderTo(string sourceFolder, string destPath)
        {
            string destFolder = destPath + "\\" + XPath.GetFileNameWithoutExtension(sourceFolder);
            CopyFolder(sourceFolder, destFolder);
        }

        //Movefolder ở từ sourcefoler sang destFolderstatic public void CopyFolder(string sourceFolder, string destFolder)
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

        static public void MoveFolderTo(string sourceFolder, string destPath)
        {
            string destFolder = destPath + "\\" + XPath.GetFileNameWithoutExtension(sourceFolder);
            MoveFolder(sourceFolder, destFolder);
        }
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    listFolder.Add(node);
                }
            }
            return listFolder;
        }
        //Trả về danh sách path thỏa man vào listbox
        public static void GetAll_DFS(string root, string search)//tìm kiếm theo chiều sâu
        {
            int i = 0;
            int all = 1;
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                
                backgroundWorker1.ReportProgress(i / all * 100);
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
                        if (backgroundWorker1.CancellationPending)
                        {
                            return;
                        }
                        lblProgress.Invoke((Action)(() => lblProgress.Text = item));
                        if (XPath.IsEqualName(item, search))
                        {
                            AddFolderToListBox(item);

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
                        if (backgroundWorker1.CancellationPending)
                        {
                            return;
                        }
                        lblProgress.Invoke((Action)(() => lblProgress.Text = item));
                        if (XPath.IsEqualName(item, search))
                        {
                            AddFileToListBox(item);
                        }
                    }

            }
        }

        static void AddFolderToListBox(string item)
        {
            XInfo listitem = new XInfo(Properties.Resources.folder, XPath.GetFileNameWithoutExtension(item), item);

            list.Invoke((Action)(() =>
            {
                list.BeginUpdate();
                list.Items.Add(listitem);
                list.EndUpdate();
            }));

        }
        static void AddFileToListBox(string item)
        {
            XInfo listitem = new XInfo(XImage.LoadImagebyExt(item), XPath.GetFileNameWithoutExtension(item), item);

            list.Invoke((Action)(() =>
            {
                list.BeginUpdate();
                list.Items.Add(listitem);
                list.EndUpdate();
            }));

        }
    }
}
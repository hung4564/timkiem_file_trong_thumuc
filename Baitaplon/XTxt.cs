using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baitaplon
{
    class XTxt
    {
        public static ListBox list;
        public static Label lblProgress;
        public static BackgroundWorker backgroundWorker1;
        public static ProgressBar progressBar1;
        //Tím kiếm từ trong tất cả các file ở thư mục root;
        public static void SearchALL(string root, string keyword)
        {
            lblProgress.Invoke((Action)(() => lblProgress.Text = "Đang tìm kiếm file txt trong " + root));
            List<string> path = XFile.GetFilebyExt_DFS(root, new string[] { ".txt" }).ToList();
            for (int i = 0; i < path.Count; i++)
            {
                lblProgress.Invoke((Action)(() => lblProgress.Text = path[i]));
                backgroundWorker1.ReportProgress((int)(i / path.Count * 100));
                if (backgroundWorker1.CancellationPending)
                {
                    return;
                }
                string lineresult = SearchTextInFile(path[i], keyword);
                if (lineresult != null)
                {
                    AddFileToListBox(path[i], lineresult);
                }
            }
        }

        //đọc file txt tra về nội dung file
        public static string ReadText(string path)
        {
            try
            {
                using (StreamReader rd = new StreamReader(path))
                {
                    string read = rd.ReadToEnd();
                    return read;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mở file lỗi:\n" + ex.Message);
                return "Không đọc được file";
            }

        }

        static void AddFileToListBox(string path, string lineresult)
        {
            XTextInfo listitem = new XTextInfo(XImage.LoadImagebyExt(path), XPath.GetFileNameWithoutExtension(path), path, lineresult);

            list.Invoke((Action)(() =>
            {
                list.BeginUpdate();
                list.Items.Add(listitem);
                list.EndUpdate();
            }));
        }

        //đọc từng dòng của txt
        public static IEnumerable<string> ReadLineText(string path)
        {
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(inFile))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    yield return line;
                }
            }
        }

        //Ghi từng dòng vào file
        public static void WriteFirstLine(string filename, string writetex)
        {
            string tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(filename))
            {
                writer.WriteLine(writetex);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, filename, true);
        }

        //tìm kiếm từ trong file, nó trả về dòng chứa từ đó       
        public static string SearchTextInFile(string path, string keyword)
        {
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(inFile))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    if (line.IndexOf((string)keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        return line;
                    }
                }
            }
            return null;
        }
    }
}

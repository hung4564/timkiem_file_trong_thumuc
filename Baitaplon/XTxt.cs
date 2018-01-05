using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Baitaplon
{
    class XTxt
    {
        #region Thuộc tính
        //thông báo là đã tìm kiếm file đuôi xong
        private static event EventHandler timkiem;
        public static event EventHandler Timkiem
        {
            add { timkiem += value; }
            remove { timkiem -= value; }
        }
        //thông bao là tìm kiếm trong file xong
        private static event EventHandler done;
        public static event EventHandler Done
        {
            add { done += value; }
            remove { done -= value; }
        }
        #endregion
        #region Phương thức

        //Tím kiếm từ trong tất cả các file ở thư mục root chưa key word
        public static void SearchALL(string root, string keyword, Queue<string> queue_result)
        {
            List<string> path = XFile.GetFilebyExt_DFS(root, new string[] { ".txt" }).ToList();
            if (timkiem != null)
                timkiem(null, EventArgs.Empty);
            for (int i = 0; i < path.Count; i++)
            {
                string lineresult = GetLineHaveKeyWord(path[i], keyword);
                if (lineresult != null)
                {
                    queue_result.Enqueue(path[i]);
                }
            }
            if (done != null)
                done(null, EventArgs.Empty);
        }

        //đọc file txt, có đường dẫn là path, tra về nội dung file
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
            catch (Exception)
            {
                return null;
            }

        }

        //add file, có đường dẫn là path, vào trong listbox list


        //đọc từng dòng của txt có đường dẫn là path
        public static IEnumerable<string> ReadLineText(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }
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

        //Ghi từ writetx vào dòng đầu tiên vào file có đường dẫn là path
        public static void WriteFirstLine(string path, string writetex)
        {
            string tempfile = Path.GetTempFileName();
            string templine;
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(path))
            {
                writer.WriteLine(writetex);
                while (!reader.EndOfStream)
                {
                    templine = reader.ReadLine();
                    if (!templine.Contains(writetex)) writer.WriteLine(templine);
                }
            }
            File.Copy(tempfile, path, true);
        }

        //tìm kiếm từ keyword trong file có đường dẫn path, trả về dòng chứa từ đó       
        public static string GetLineHaveKeyWord(string path, string keyword)
        {
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            keyword = RemoveSign4VietnameseString(keyword);
            using (var sr = new StreamReader(inFile))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    if (RemoveSign4VietnameseString(line).IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        return line;
                    }
                }
            }
            return null;
        }

        private static readonly string[] VietnameseSigns = new string[]{

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"

   };

        public static string RemoveSign4VietnameseString(string str)
        {
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }
        #endregion
    }
}

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
        #region Phương thức

        //Tím kiếm từ trong tất cả các file ở thư mục root chưa key word
        public static bool  Search(string root, string keyword)
        {
            string lineresult = GetLineHaveKeyWord(root, keyword);
            if (lineresult != null)
            {
                return true;
            }
            return false;
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

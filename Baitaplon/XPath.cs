using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public static class XPath
    {
        //đường dẫn các file cần thiết
        #region Thuộc tính
        //file lưu danh sách các từ tìm kiếm
        public static string pathfile_history_name = Application.StartupPath + "\\history_name.txt";
        //file lưu danh sách các đường dấn của file đã được mở
        public static string pathfile_history_file = Application.StartupPath + "\\history_file.txt";
        //đường dẫn của file rác tạo mở word
        public static string pathfile_rft = Application.StartupPath + "\\temp.rtf";
        //đường dấn của các file ảnh cho icon của load tim kiếm thủ công
        public static string pathfile_Image = Application.StartupPath + "\\Resource\\Icon";
        #endregion
        #region Các phương thức
        //Tên file mà không có phần mở rộng
        public static string GetFileNameWithoutExtension(string path)
        {
            string name;

            //Tìm ra vị trị cuối cùng của \\ trong đường dẫn
            int dau = path.LastIndexOf("\\") + 1;
            if (path.LastIndexOf(".") > dau - 1) // nếu tồn tại dấu . sau dấu \\ cuối cùng thì cắt từ vị trị +1 của \\ đến vị trị dấu chấm
            {
                int dodai = path.LastIndexOf(".") - dau;       // xác định độ dài của name
                name = path.Substring(dau, dodai);          //cắt từ vị trị đầu, vs số lượng là độ dài
            }
            else
            {
                name = path.Substring(dau);
            }
            return name;
        }

        //Phần mở rộng của file, trả về mở rộng nếu tìm thấy, null nếu ko tìm thấy
        public static string GetExtention(string path)
        {
            string extention;
            //lấy ra vị trí cuối cúng của \ trong đường dẫn
            int dau = path.LastIndexOf("\\") + 1;
            //kiếm tra xem trong đường dẫn chứa dấu . không và có nằm đằng sau dấu \ cuối cùng không
            if (path.Contains(".") && path.LastIndexOf(".") > dau - 1)
            {
                //có thì cắt từ vị trí đấy
                int vitri = path.LastIndexOf(".");
                extention = path.Substring(vitri);
            }
            else extention = null;
            return extention;
        }

        //Lấy thông tin thư mục gốc
        public static string DirRoot_Info(string path)
        {
            string name;
            //xác định vị trí \ cuối cùng
            int dau = path.LastIndexOf("\\");
            //lấy từ đầu tiên
            name = path.Substring(0, dau + 1);
            return name;
        }

        //so sánh tên file trong path vs từ search
        public static bool IsEqualName(string path, string search)
        {
            return XPath.GetFileNameWithoutExtension(path).Contains(search);
        }

        //so sánh tên file trong path vs nhiều từ
        public static bool IsEqualName(string path, string[] keyword)
        {
            bool check = false;
            //chuyển tất cả kí tự về kí tự thường
            //lấy ra từng đuôi một để so sánh
            for (int i = 0; i < keyword.Length; i++)
            {
                keyword[i] = keyword[i];
                if (XPath.GetFileNameWithoutExtension(path).Contains(keyword[i])) return true;// nếu tm 1 đuôi trong chỗ đuỗi thi thoát
            }
            return check;
        }

        //so sánh đuôi file trong path vs ext,ext chứa đuôi cần so sánh
        public static bool IsEqualExt(string path, string ext)
        {
            if (!ext.Contains(".")) ext = "." + ext;
            if (XPath.GetExtention(path) == null) return false;
            else
            if (XPath.GetExtention(path)== ext) return true;
            else
                return false;
        }

        //so sánh đuôi file trong path vs ext,ext chứa các đuôi cần so sánh
        public static bool IsEqualExt(string path, string[] ext)
        {
            if (XPath.GetExtention(path) == null) return false;
            bool check = false;
            //lấy ra từng đuôi một để so sánh
            for (int i = 0; i < ext.Length; i++)
            {
                //thêm dấu chấm vs chuyển thành chữ thường đề phòng
                if (!ext[i].Contains(".")) ext[i] = "." + ext[i];
                if (XPath.GetExtention(path) == ext[i]) return true;// nếu tm 1 đuôi trong chỗ đuỗi thi thoát
            }
            return check;
        }
        #endregion
    }
}

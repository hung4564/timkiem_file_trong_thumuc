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
        public static string pathfile_history_name = Application.StartupPath + "\\history_name.txt";
        public static string pathfile_history_file = Application.StartupPath + "\\history_file.txt";
        public static string pathfilerft = Application.StartupPath + "\\temp.rtf";
        #region Các phương thức
        public static string GetFileNameWithoutExtension(string path)  //Tên file mà không có phần mở rộng
        {
            string name ;
            
            //Tìm ra vị trị cuối cùng của \\ trong đường dẫn
            int dau = path.LastIndexOf("\\") + 1;
            if (path.LastIndexOf(".") > dau-1) // nếu tồn tại dấu . sau dấu \\ cuối cùng thì cắt từ vị trị +1 của \\ đến vị trị dấu chấm
            {
                int dodai =path.LastIndexOf(".")-dau;       // xác định độ dài của name
                name = path.Substring(dau, dodai);          //cắt từ vị trị đầu, vs số lượng là độ dài
            }
            else
            {
                name = path.Substring(dau);             
            }
            return name;
        }
        public static string GetExtention(string path) //Phần mở rộng của file, trả về mở rộng nếu tìm thấy, null nếu ko tìm thấy
        {
            string extention;
            //lấy ra vị trí cuối cúng của \ trong đường dẫn
            int dau = path.LastIndexOf("\\") + 1;
            //kiếm tra xem trong đường dẫn chứa dấu . không và có nằm đằng sau dấu \ cuối cùng không
            if (path.Contains(".")&& path.LastIndexOf(".") > dau - 1)
            {
                //có thì cắt từ vị trí đấy
                int vitri = path.LastIndexOf(".");
                extention = path.Substring(vitri);
            }
            else extention = null;
            return extention;
        }
        public static string DirRoot_Info(string path)  //Lấy thông tin thư mục gốc
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
            //chuyển tất cả kí tự về kí tự thường
            search = search.ToLower();
            return XPath.GetFileNameWithoutExtension(path).ToLower().Contains(search);
        }
        //so sánh đuôi file trong path vs ext
        //ext chứa các đuôi cần so sánh
        public static bool IsEqualExt(string path, string[] ext) 
        {
            if (XPath.GetExtention(path) == null) return false;
            bool check=false;
            //lấy ra từng đuôi một để so sánh
            for (int i = 0; i < ext.Length; i++)
            {
                //thêm dấu chấm vs chuyển thành chữ thường đề phòng
                if (!ext[i].Contains(".")) ext[i] = "." + ext[i];
                ext[i] = ext[i].ToLower();
                if (XPath.GetExtention(path).ToLower() == ext[i]) return true;// nếu tm 1 đuôi trong chỗ đuỗi thi thoát
            }
            return check;
        }
        #endregion
    }
}

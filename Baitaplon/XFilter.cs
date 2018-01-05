using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaplon
{

    public enum Loailoc
    {
        Loctheotungtu,
        Loctheochuoi
    }
    public class XFilter
    {
        //Chứa tên đuôi cần lọc
        public string ext;
        //Khoảng thời gian được tạo
        public DateTime? createTimeFrom;
        public DateTime? createTimeTo;
        //Khoảng kích thước file
        public long lenghtMin;
        public long lenghtMax;
        //là lọc theo từng tự hoặc lọc theo chuỗi
        public Loailoc loailoc;

        //Tạo mặc định là chỉ lọc theo theo chuỗi
        public XFilter()
        {
            ext = null;
            createTimeFrom = null;
            createTimeTo = null;
            lenghtMin = 0;
            lenghtMax = 0;
            loailoc = Loailoc.Loctheochuoi;
        }
        public XFilter(string ext, DateTime? createTimeFrom, DateTime? createTimeTo, long lenghtMin, long lenghtMax, Loailoc loailoc)
        {
            this.ext = ext.Substring(ext.IndexOf('.'));
            this.createTimeFrom = createTimeFrom;
            this.createTimeTo = createTimeTo;
            this.lenghtMax = lenghtMax;
            this.lenghtMin = lenghtMin;
            this.loailoc = loailoc;
        }
        //Kiểm tra xem path(đường dẫn) có thỏa mãn với bộ lọc có sẵn không
        public bool IsSatisfy(string path)
        {
            bool check = true;
            if (this.ext != null) if (XPath.IsEqualExt(path, this.ext)) check = true; else return false;
            if (this.createTimeFrom != null || this.lenghtMax!=0)
            {
                System.IO.FileInfo temp = new System.IO.FileInfo(path);
                if (this.createTimeFrom != null)
                    if (temp.CreationTime <= this.createTimeTo && temp.CreationTime >= this.createTimeFrom) check = true;
                    else return false;
                if(!(System.IO.File.GetAttributes(path).HasFlag(System.IO.FileAttributes.Directory)))
                if (this.lenghtMax != 0)
                    if (temp.Length <= this.lenghtMax && temp.Length >= this.lenghtMin) check = true;
                    else return false;
            }
            return check;
        }
    }
}

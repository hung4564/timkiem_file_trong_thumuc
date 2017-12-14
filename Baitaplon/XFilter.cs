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
        public string ext;
        public DateTime? createTimeFrom;
        public DateTime? createTimeTo;
        public long lenghtMin;
        public long lenghtMax;
        public Loailoc loailoc;

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
            this.ext = ext;
            this.createTimeFrom = createTimeFrom;
            this.createTimeTo = createTimeTo;
            this.lenghtMax = lenghtMax;
            this.lenghtMin = lenghtMin;
            this.loailoc = loailoc;
        }
        public bool IsSatisfy(string path)
        {
            bool check = true;
            if (this.ext != null) check = XPath.IsEqualExt(path, this.ext);
            if (this.createTimeFrom != null || this.lenghtMax!=0)
            {
                System.IO.FileInfo temp = new System.IO.FileInfo(path);
                if (this.createTimeFrom != null)
                    if (temp.CreationTime <= this.createTimeTo && temp.CreationTime >= this.createTimeFrom) check = true;
                    else return false;
                if (this.lenghtMax != 0)
                    if (temp.Length <= this.lenghtMax && temp.Length >= this.lenghtMin) check = true;
                    else return false;
            }
            return check;
        }
    }
}

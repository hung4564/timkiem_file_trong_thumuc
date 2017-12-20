using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace Baitaplon
{
    class XWord
    {
        #region Thuộc tính
        public static Queue<string> queue_result;
        private static event EventHandler timkiem;
        public static event EventHandler Timkiem
        {
            add { timkiem += value; }
            remove { timkiem -= value; }
        }
        private static event EventHandler done;
        public static event EventHandler Done
        {
            add { done += value; }
            remove { done -= value; }
        }
        private static event EventHandler chuyendoiRTF;
        public static event EventHandler ConventRTF
        {
            add { chuyendoiRTF += value; }
            remove { chuyendoiRTF -= value; }
        }
        private static event EventHandler docfile;
        public static event EventHandler Docfile
        {
            add { docfile += value; }
            remove { docfile -= value; }
        }
        #endregion
        #region Phương thức
        //đọc file có đường dấn path trả về nôi dung file dạng rtf
        public static string ReadWord(string path)
        {
            fThongbao f = new fThongbao();
            string read;
            try
            {
                f.Show();
                DocToRtf(path);
                using (StreamReader rd = new StreamReader(XPath.pathfile_rft))
                {
                    if (docfile != null)
                        docfile(null, EventArgs.Empty);
                    read = rd.ReadToEnd();
                }

            }
            catch (Exception)
            {
                read = null;
            }
            finally
            {
                f.Close();
            }
            return read;
        }

        // tìm kiếm từ trong tất cả file word có trong thư mục root chứ keyword
        public static void SearchALL(string root, string keyword)
        {
            List<string> path = XFile.GetFilebyExt_DFS(root, new string[] { ".doc", "docx" }).ToList();    //lấy toàn bộ file word;
            if (timkiem != null)
                timkiem(null, EventArgs.Empty);
            for (int i = 0; i < path.Count; i++)                                                        //load từng file word
            {
                if (SearchInWord(path[i], keyword)) queue_result.Enqueue(path[i]);                       //nếu file word tồn tại keyword thì add vào listbox
            }
            if (done != null)
                done(null, EventArgs.Empty);
        }
        

        //Chuyển file doc sang rtf để đọc
        //path là lưu đường dấn
        private static void DocToRtf(string filePath)
        {
            //Creating the instance of Word Application
            if (chuyendoiRTF != null)
            {
                chuyendoiRTF(null, EventArgs.Empty);
            }
            Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();
            object Unknown = Type.Missing;
            if (XPath.IsEqualExt(filePath, new string[] { ".doc", ".docx" }))
            {
                try
                {
                    //lấy địa chỉ file word
                    object Source = filePath;
                    //địa chỉ file rtf tạo ra tạm
                    object Target = XPath.pathfile_rft;
                    //nếu file tồn tại thì xóa đi
                    if (File.Exists(Target.ToString()))
                    {
                        File.Delete(Target.ToString());
                    }
                    // Use for the parameter whose type are not known or 
                    // say Missing
                    // Source document open here
                    // Additional Parameters are not known so that are 
                    // set as a missing type
                    newApp.Documents.Open(ref Source, ref Unknown,
                           ref Unknown, ref Unknown, ref Unknown,
                           ref Unknown, ref Unknown, ref Unknown,
                           ref Unknown, ref Unknown, ref Unknown,
                           ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                    // Specifying the format in which you want the output file
                    object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;
                    //Changing the format of the document
                    newApp.ActiveDocument.SaveAs(ref Target, ref format,
                                    ref Unknown, ref Unknown, ref Unknown,
                             ref Unknown, ref Unknown, ref Unknown,
                             ref Unknown, ref Unknown, ref Unknown,
                             ref Unknown, ref Unknown, ref Unknown,
                             ref Unknown, ref Unknown);
                    // for closing the application
                    newApp.Quit(ref Unknown, ref Unknown, ref Unknown);
                }
                catch (Exception )
                {

                }
                finally
                {
                    // for closing the application
                    newApp.Quit(ref Unknown, ref Unknown, ref Unknown);
                }
            }
            else return;
        }

        //tìm kiếm từ trong file word(có office từ 2013 trở lên?)
        //path là lưu đường dẫn của file mình cần tìm
        //findText là từ mình cần tìm kiếm trong file word đó
        public static bool SearchInWord(string filePath, string findText)
        {

            bool result = false;
            Word.Application wordApp = new Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                wordApp.Documents.Open(filePath, false, true, false, "", "");           //mở file word
                if (wordApp.ActiveWindow.View.ReadingLayout) wordApp.ActiveWindow.View.ReadingLayout = false;
                if (wordApp.Application.Selection.Find.Execute(findText))               //tìm từ trong file word
                {
                    result = true;
                }
                object nullobject = System.Reflection.Missing.Value;
                wordApp.Quit(ref nullobject, ref nullobject, ref nullobject);
            }
            catch (Exception)                                                        //báo lỗi gặp
            {
            }
            finally                                                                    //đóng file word lại
            {
                object nullobject = System.Reflection.Missing.Value;
                wordApp.Quit(ref nullobject, ref nullobject, ref nullobject);
            }
            return result;
        }
        #endregion

    }
}

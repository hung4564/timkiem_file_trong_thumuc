using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace Baitaplon
{
    class XWord
    {
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
        public static ListBox list;
        public static Label lblProgress;
        public static BackgroundWorker backgroundWorker1;
        public static ProgressBar progressBar1;
        //đọc file trả về nôi dung file dạng rtf
        public static string ReadWord(string path)
        {
            fThongbao f = new fThongbao();
            string read;
            try
            {
                f.Show();
                DocToRtf(path);
                using (StreamReader rd = new StreamReader(XPath.pathfilerft))
                {
                    if (docfile != null)
                        docfile(null, EventArgs.Empty);
                    read = rd.ReadToEnd();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Readword");
                read = "Không đọc được";
            }
            finally
            {
                f.Close();
            }
            return read;
        }
        // tìm kiếm từ trong tất cả file word có trong thư mục root
        public static void SearchALL(string root, string keyword)
        {
            lblProgress.Invoke((Action)(() => lblProgress.Text = "Đang tìm kiếm file txt trong " + root));
            List<string> path = XFile.GetFilebyExt_DFS(root, new string[] { ".doc", "docx" }).ToList();    //lấy toàn bộ file word;
            for (int i = 0; i < path.Count; i++)                                                        //load từng file word
            {
                lblProgress.Invoke((Action)(() => lblProgress.Text = path[i]));
                backgroundWorker1.ReportProgress((int)(i / path.Count * 100));
                if (backgroundWorker1.CancellationPending)
                {
                    return;
                }
                if (SearchInWord(path[i], keyword)) AddFileToListBox(path[i]);                       //nếu file word tồn tại keyword thì add vào listbox
            }
        }
        //
        static void AddFileToListBox(string path)
        {
            XInfo listitem = new XInfo(XImage.LoadImagebyExt(path), XPath.GetFileNameWithoutExtension(path), path);

            list.Invoke((Action)(() =>
            {
                list.BeginUpdate();
                list.Items.Add(listitem);
                list.EndUpdate();
            }));

        }
        //Chuyển file doc sang rtf để đọc
        //path là lưu đường dấn
        private static void DocToRtf(string filePath)
        {
            //Creating the instance of Word Application
            if(chuyendoiRTF!=null)
            {
                chuyendoiRTF(null, EventArgs.Empty);
            }
            Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();
            object Unknown = Type.Missing;
            if (XPath.GetExtention(filePath) == ".doc" || XPath.GetExtention(filePath) == ".docx")
            {
                try
                {
                    //lấy địa chỉ file word
                    object Source = filePath;   
                    //địa chỉ file rtf tạo ra tạm
                    object Target = XPath.pathfilerft;
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "docToRtf");
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

                if (wordApp.Application.Selection.Find.Execute(findText))               //tìm từ trong file word
                {
                    result = true;
                }
                object nullobject = System.Reflection.Missing.Value;
                wordApp.Quit(ref nullobject, ref nullobject, ref nullobject);
            }
            catch (Exception ex)                                                        //báo lỗi gặp
            {
                MessageBox.Show(ex.Message, "SearchInWord");
            }
            finally                                                                    //đóng file word lại
            {
                object nullobject = System.Reflection.Missing.Value;
                wordApp.Quit(ref nullobject, ref nullobject, ref nullobject);
            }
            return result;
        }
    }
}

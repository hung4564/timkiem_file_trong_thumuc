using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fTimkiemInTxt : Form
    {
        Queue<string> queue_result = new Queue<string>();
        private const int ItemHeight = 50;
        bool done=false;
        string keyword
        {
            get { return txtSearch.Text; }
        }
        Thread ts;
        public fTimkiemInTxt()
        {
            InitializeComponent();
            listBox_timkiem.DrawMode = DrawMode.OwnerDrawVariable;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            XTxt.queue_result = queue_result;
            XTxt.Timkiem += SearchFile_done;
            XTxt.Done += Search_done;
            XWord.Timkiem += SearchFile_done;
            XWord.Done += Search_done;
        }        

        private void Search_done(object sender, EventArgs e)
        {
            done = true;
        }

        private void SearchFile_done(object sender, EventArgs e)
        {
            lblProgress.Invoke((Action)(() => lblProgress.Text = "Đang tìm kiếm trong file txt"));
            if (backgroundWorker1.IsBusy) backgroundWorker1.ReportProgress(40);
        }

        void AddFileToListBox(string path)
        {
            //string lineresult = XTxt.GetLineHaveKeyWord(path, keyword);
            //XTextInfo listitem = new XTextInfo(XImage.LoadImagebyExt(path), XPath.GetFileNameWithoutExtension(path), path, lineresult);

            listBox_timkiem.Invoke((Action)(() =>
            {
                listBox_timkiem.BeginUpdate();
                listBox_timkiem.Items.Add(path);
                listBox_timkiem.EndUpdate();
            }));
        }

        void RunSearch()
        {
            if (rd_TXT.Checked)
            {
                XTxt.SearchALL(txtFolderPath.Text, txtSearch.Text);
            }
            else if (rd_word.Checked) XWord.SearchALL(txtFolderPath.Text, txtSearch.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ts = new Thread(RunSearch);
            if (backgroundWorker1.IsBusy)
            {
                done = false;
                ts.Abort();
                backgroundWorker1.CancelAsync();
            }
            else
            {
                done = false;
                progressBar1.Value = progressBar1.Minimum;
                btnSearch.Text = "Stop";
                XTxt.WriteFirstLine(XPath.pathfile_history_name, keyword);
                listBox_timkiem.Items.Clear();
                lblProgress.Text = "Đang tìm kiếm file .txt";
                ts.IsBackground = true;
                ts.Start();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 40; i < progressBar1.Maximum; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                if (queue_result.Count > 0) AddFileToListBox(queue_result.Dequeue());
                else if(done)
                {                    
                    backgroundWorker1.ReportProgress(100);
                    break;
                }
                backgroundWorker1.ReportProgress(i);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                lblPercent.Text = e.ProgressPercentage + "%";
                progressBar1.Value = e.ProgressPercentage;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            queue_result.Clear();
            lblProgress.Text = String.Format("{0} files found", listBox_timkiem.Items.Count);
            if (progressBar1.Value < progressBar1.Maximum)
            {
                lblProgress.Text = "Searching cancelled. " + lblProgress.Text;
            }
            btnSearch.Text = "Tìm kiếm";
        }

        private void btn_location_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void listBox_timkiem_DoubleClick(object sender, EventArgs e)
        {
            ListBox list = sender as ListBox;
            Loaifile a = rd_word.Checked ? Loaifile.Word : Loaifile.Txt;
            if (list.SelectedItem != null)
            {
                XTxt.WriteFirstLine(XPath.pathfile_history_file, list.SelectedItem.ToString());
                fOpenText f = new fOpenText(list.SelectedItem.ToString(), keyword, a);
                f.Show();
            }
        }

        private void listBox_timkiem_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ItemHeight;
        }

        private void listBox_timkiem_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                ListBox listBox = sender as ListBox;

                string path = listBox.Items[e.Index] as string;
                if (rd_TXT.Checked)
                {
                    string lineresult = XTxt.GetLineHaveKeyWord(path, keyword);
                    XTextInfo fileInfo = new XTextInfo(path, lineresult);

                    // Draw the background.
                    e.DrawBackground();

                    fileInfo.DrawItem(e.Graphics, e.Bounds, this.Font, false);
                }
                else if (rd_word.Checked)
                {
                    XInfo fileInfo = new XInfo(path);

                    // Draw the background.
                    e.DrawBackground();

                    fileInfo.DrawItem(e.Graphics, e.Bounds, this.Font, false);
                }
            }
        }

        private void rd_TXT_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_TXT.Checked) XTxt.queue_result = queue_result;
            else XWord.queue_result = queue_result;
        }
    }
}

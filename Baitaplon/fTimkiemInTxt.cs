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

            txtSearch.Focus();
        }       
        void Runsearch()
        {
            string[] ext;
            if (rd_TXT.Checked)
            {
                 ext= new string[] { ".txt" };
            }
            else 
                 ext = new string[] { ".doc",".docx" };
            XFile.GetbyExt_BFS(queue_result, txtFolderPath.Text, ext,check_subfolder.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ts = new Thread(Runsearch);
            if (backgroundWorker1.IsBusy)
            {
                ts.Abort();
                backgroundWorker1.CancelAsync();
            }
            else
            {
                progressBar1.Value = progressBar1.Minimum;
                btnSearch.Text = "Stop";
                XTxt.WriteFirstLine(XPath.pathfile_history_name, keyword);
                listBox_timkiem.Items.Clear();
                lblProgress.Text = "Đang tìm kiếm file";
                ts.IsBackground = true;
                ts.Start();
                backgroundWorker1.RunWorkerAsync();
            }
        }
        bool search(string root, string keyword)
        {
            if (rd_TXT.Checked) return XTxt.Search(root, keyword);
            else return XWord.SearchInWord(root, keyword);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <=progressBar1.Maximum; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                if (queue_result.Count > 0)
                {
                    string path = queue_result.Dequeue();
                    if (search(path,keyword))
                    AddFIleTOListbox(path);
                }
                backgroundWorker1.ReportProgress(i);
                System.Threading.Thread.Sleep(1000);
            }
        }

        void AddFIleTOListbox(string item)
        {
            listBox_timkiem.Invoke((Action)(() =>
            {
                listBox_timkiem.BeginUpdate();
                listBox_timkiem.Items.Add(item);
                listBox_timkiem.EndUpdate();
            }));
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

        private void fTimkiemInTxt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                button2_Click(null, EventArgs.Empty);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

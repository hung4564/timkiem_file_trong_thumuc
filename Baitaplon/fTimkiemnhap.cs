using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fTimkiemnhap : Form
    {
        XFilter filter;
        Queue<string> queue_result = new Queue<string>();
        private const int ItemHeight = 50;
        public fTimkiemnhap()
        {
            filter = new XFilter();
            InitializeComponent();
            bgW_loadfile.WorkerReportsProgress = true;
            bgW_loadfile.WorkerSupportsCancellation = true;
            listBox_timkiem.DrawMode = DrawMode.OwnerDrawVariable;
        }

        void RunSearch()
        {
            XFolder.GetAll_BFS(queue_result,txtFolderPath.Text, txtSearch.Text, filter,check_subfolder.Checked);
        }

        void AddFileToListBox(string path)
        {
            XInfo listitem = new XInfo(XImage.LoadImagebyExt(path), XPath.GetFileNameWithoutExtension(path), path);

            listBox_timkiem.Invoke((Action)(() =>
            {
                listBox_timkiem.BeginUpdate();
                listBox_timkiem.Items.Add(listitem);
                listBox_timkiem.EndUpdate();
            }));

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int n=0;
            for (int i = 0; i <= progressBar1.Maximum; i++)
            {
                n = 0;
                if (bgW_loadfile.CancellationPending)
                {
                    break;
                }
                if (queue_result.Count > 0)
                    while (queue_result.Count > 0)
                    {
                        AddFileToListBox(queue_result.Dequeue());
                        System.Threading.Thread.Sleep(1000);
                        n++;
                        if(i<50)if (n == 4) break;
                    }
                bgW_loadfile.ReportProgress(i);
                System.Threading.Thread.Sleep(1000);
            }
            bgW_loadfile.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!bgW_loadfile.CancellationPending)
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

        private void listBox_timkiem_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ItemHeight;
        }

        private void listBox_timkiem_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (e.Index >= 0)
            {
                XInfo fileInfo = listBox.Items[e.Index] as XInfo;

                // Draw the background.
                e.DrawBackground();

                fileInfo.DrawItem(e.Graphics, e.Bounds, this.Font, false);
            }
        }

        private void listBox_timkiem_DoubleClick(object sender, EventArgs e)
        {

            ListBox list = sender as ListBox;
            if (list.SelectedItem != null)
            {
                XTxt.WriteFirstLine(XPath.pathfile_history_file, list.SelectedItem.ToString());
                fDetail f = new fDetail(list.SelectedItem.ToString());
                f.Show();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {

            Thread ts;
            ts = new Thread(RunSearch);
            if (bgW_loadfile.IsBusy)
            {
                ts.Abort();
                bgW_loadfile.CancelAsync();
                progressBar1.Value = progressBar1.Maximum;
            }
            else
            {
                progressBar1.Value = progressBar1.Minimum;
                btnSearch.Text = "Stop";
                XTxt.WriteFirstLine(XPath.pathfile_history_name, txtSearch.Text);
                listBox_timkiem.Items.Clear();
                lblProgress.Text = "Đang tìm kiếm file";
                ts.IsBackground = true;
                ts.Start();
                bgW_loadfile.RunWorkerAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fBoloc f = new fBoloc(filter);
            f.ShowDialog();
        }

        private void fTimkiemnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgW_loadfile.IsBusy)
            {
                button2_Click(null, EventArgs.Empty);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

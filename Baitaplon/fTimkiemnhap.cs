using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fTimkiemnhap : Form
    {
        string timkiem
        {
            get { return txtSearch.Text; }
        }
        public fTimkiemnhap()
        {
            InitializeComponent();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            XFolder.list = listBox_timkiem;
            XFolder.lblProgress = lblProgress;
            XFolder.backgroundWorker1 = backgroundWorker1;
            //comboBox2.DataSource = XDriveInfo.LoadDrive();
           listBox_timkiem.DrawMode = DrawMode.OwnerDrawVariable;  
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                progressBar1.Value = progressBar1.Minimum;
                btnSearch.Text = "Stop";
                XTxt.WriteFirstLine(XPath.pathfile_history_name, timkiem);
                listBox_timkiem.Items.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] keyword= txtSearch.Text.Split(',');
            XFolder.GetAll_DFS(txtFolderPath.Text, keyword);
            backgroundWorker1.ReportProgress(100);
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

            lblProgress.Text = String.Format("{0} files found", listBox_timkiem.Items.Count);
            if (progressBar1.Value < progressBar1.Maximum)
            {
                lblProgress.Text = "Searching cancelled. " + lblProgress.Text;
            }
            btnSearch.Text = "Search";
        }
        
        // Indicate the amount of space needed for a ListBox item.
        private const int ItemHeight = 50;
        private void listBox_timkiem_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ItemHeight;
        }
        // Draw a ListBox item.
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
                XTxt.WriteFirstLine(XPath.pathfile_history_file,list.SelectedItem.ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {
            fBoloc f = new fBoloc();
            f.Show();
        }
    }
}

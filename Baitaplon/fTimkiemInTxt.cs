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
        string timkiem
        {
            get { return txtSearch.Text; }
        }
        public fTimkiemInTxt()
        {
            InitializeComponent();
            listBox_timkiem.DrawMode = DrawMode.OwnerDrawVariable;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            XWord.backgroundWorker1 = backgroundWorker1;
            XWord.lblProgress = lblProgress;
            XWord.list = listBox_timkiem;
            XWord.progressBar1 = progressBar1;
            XTxt.list = listBox_timkiem;
            XTxt.lblProgress = lblProgress;
            XTxt.backgroundWorker1 = backgroundWorker1;
            XTxt.progressBar1 = progressBar1;
            // comboBox2.DataSource = XDriveInfo.LoadDrive();
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
                listBox_timkiem.Items.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
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
            if (e.Index >= 0)
            {
                ListBox listBox = sender as ListBox;
                if (rd_TXT.Checked == true)
                {

                    XTextInfo fileInfo = listBox.Items[e.Index] as XTextInfo;

                    // Draw the background.
                    e.DrawBackground();

                    fileInfo.DrawItem(e.Graphics, e.Bounds, this.Font, false);
                }
                else if (rd_word.Checked == true)
                {
                    XInfo fileInfo = listBox.Items[e.Index] as XInfo;

                    // Draw the background.
                    e.DrawBackground();

                    fileInfo.DrawItem(e.Graphics, e.Bounds, this.Font, false);
                }
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (rd_TXT.Checked == true)
            {
                XTxt.SearchALL(txtFolderPath.Text, txtSearch.Text);
            }
            else if (rd_word.Checked == true) XWord.SearchALL(txtFolderPath.Text, txtSearch.Text);
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
                fOpenText f = new fOpenText(list.SelectedItem.ToString(),timkiem, a);
                f.Show();
            }
        }
    }
}

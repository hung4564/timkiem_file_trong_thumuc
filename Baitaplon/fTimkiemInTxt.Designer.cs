namespace Baitaplon
{
    partial class fTimkiemInTxt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_timkiem = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btn_location = new System.Windows.Forms.Button();
            this.rd_word = new System.Windows.Forms.RadioButton();
            this.rd_TXT = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_timkiem
            // 
            this.listBox_timkiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_timkiem.FormattingEnabled = true;
            this.listBox_timkiem.Location = new System.Drawing.Point(21, 77);
            this.listBox_timkiem.Name = "listBox_timkiem";
            this.listBox_timkiem.Size = new System.Drawing.Size(433, 212);
            this.listBox_timkiem.TabIndex = 20;
            this.listBox_timkiem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_timkiem_DrawItem);
            this.listBox_timkiem.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox_timkiem_MeasureItem);
            this.listBox_timkiem.DoubleClick += new System.EventHandler(this.listBox_timkiem_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-82, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Trạng Thái";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(21, 326);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(361, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(113, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 20);
            this.txtSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(397, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Từ tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ổ tìm kiếm";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(113, 45);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(98, 20);
            this.txtFolderPath.TabIndex = 23;
            this.txtFolderPath.Text = "C:\\\\";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(18, 292);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(35, 13);
            this.lblProgress.TabIndex = 24;
            this.lblProgress.Text = "label4";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(400, 326);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 13);
            this.lblPercent.TabIndex = 25;
            this.lblPercent.Text = "0%";
            // 
            // btn_location
            // 
            this.btn_location.Location = new System.Drawing.Point(236, 43);
            this.btn_location.Name = "btn_location";
            this.btn_location.Size = new System.Drawing.Size(44, 23);
            this.btn_location.TabIndex = 26;
            this.btn_location.Text = "...";
            this.btn_location.UseVisualStyleBackColor = true;
            this.btn_location.Click += new System.EventHandler(this.btn_location_Click);
            // 
            // rd_word
            // 
            this.rd_word.AutoSize = true;
            this.rd_word.Location = new System.Drawing.Point(421, 46);
            this.rd_word.Name = "rd_word";
            this.rd_word.Size = new System.Drawing.Size(51, 17);
            this.rd_word.TabIndex = 27;
            this.rd_word.TabStop = true;
            this.rd_word.Text = "Word";
            this.rd_word.UseVisualStyleBackColor = true;
            // 
            // rd_TXT
            // 
            this.rd_TXT.AutoSize = true;
            this.rd_TXT.Checked = true;
            this.rd_TXT.Location = new System.Drawing.Point(362, 46);
            this.rd_TXT.Name = "rd_TXT";
            this.rd_TXT.Size = new System.Drawing.Size(44, 17);
            this.rd_TXT.TabIndex = 28;
            this.rd_TXT.TabStop = true;
            this.rd_TXT.Text = "TxT";
            this.rd_TXT.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(286, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Loại file tìm";
            // 
            // fTimkiemInTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rd_TXT);
            this.Controls.Add(this.rd_word);
            this.Controls.Add(this.btn_location);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox_timkiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.button1);
            this.Name = "fTimkiemInTxt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fTimkiemText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_timkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Button btn_location;
        private System.Windows.Forms.RadioButton rd_word;
        private System.Windows.Forms.RadioButton rd_TXT;
        private System.Windows.Forms.Label label4;
    }
}
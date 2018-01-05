namespace Baitaplon
{
    partial class fTimkiemnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTimkiemnhap));
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_boloc = new System.Windows.Forms.Button();
            this.listBox_timkiem = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bgW_loadfile = new System.ComponentModel.BackgroundWorker();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btn_location = new System.Windows.Forms.Button();
            this.check_subfolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(424, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(84, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearch.Size = new System.Drawing.Size(152, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(20, 342);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(410, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ổ tìm kiếm";
            // 
            // bt_boloc
            // 
            this.bt_boloc.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bt_boloc.Location = new System.Drawing.Point(424, 22);
            this.bt_boloc.Name = "bt_boloc";
            this.bt_boloc.Size = new System.Drawing.Size(75, 23);
            this.bt_boloc.TabIndex = 10;
            this.bt_boloc.Text = "Bộ lọc";
            this.bt_boloc.UseVisualStyleBackColor = false;
            this.bt_boloc.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox_timkiem
            // 
            this.listBox_timkiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_timkiem.FormattingEnabled = true;
            this.listBox_timkiem.Location = new System.Drawing.Point(20, 112);
            this.listBox_timkiem.Name = "listBox_timkiem";
            this.listBox_timkiem.Size = new System.Drawing.Size(438, 199);
            this.listBox_timkiem.TabIndex = 14;
            this.listBox_timkiem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_timkiem_DrawItem);
            this.listBox_timkiem.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox_timkiem_MeasureItem);
            this.listBox_timkiem.DoubleClick += new System.EventHandler(this.listBox_timkiem_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ tìm kiếm";
            // 
            // bgW_loadfile
            // 
            this.bgW_loadfile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgW_loadfile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.bgW_loadfile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(436, 344);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 13);
            this.lblPercent.TabIndex = 16;
            this.lblPercent.Text = "0%";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(17, 313);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(35, 13);
            this.lblProgress.TabIndex = 17;
            this.lblProgress.Text = "label4";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(84, 22);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(250, 20);
            this.txtFolderPath.TabIndex = 18;
            this.txtFolderPath.Text = "C:\\\\";
            // 
            // btn_location
            // 
            this.btn_location.Location = new System.Drawing.Point(348, 22);
            this.btn_location.Name = "btn_location";
            this.btn_location.Size = new System.Drawing.Size(27, 23);
            this.btn_location.TabIndex = 27;
            this.btn_location.Text = "...";
            this.btn_location.UseVisualStyleBackColor = true;
            this.btn_location.Click += new System.EventHandler(this.btn_location_Click);
            // 
            // check_subfolder
            // 
            this.check_subfolder.AutoSize = true;
            this.check_subfolder.Location = new System.Drawing.Point(251, 61);
            this.check_subfolder.Name = "check_subfolder";
            this.check_subfolder.Size = new System.Drawing.Size(147, 17);
            this.check_subfolder.TabIndex = 28;
            this.check_subfolder.Text = "Tìm cả trong thư mục con";
            this.check_subfolder.UseVisualStyleBackColor = true;
            // 
            // fTimkiemnhap
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(539, 379);
            this.Controls.Add(this.check_subfolder);
            this.Controls.Add(this.btn_location);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox_timkiem);
            this.Controls.Add(this.bt_boloc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.button1);
            this.Name = "fTimkiemnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhapTIMKIEM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTimkiemnhap_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_boloc;
        private System.Windows.Forms.ListBox listBox_timkiem;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bgW_loadfile;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btn_location;
        private System.Windows.Forms.CheckBox check_subfolder;
    }
}


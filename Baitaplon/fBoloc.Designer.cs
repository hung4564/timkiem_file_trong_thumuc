namespace Baitaplon
{
    partial class fBoloc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBoloc));
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ext = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.gb_date = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.gb_lenght = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_max = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_min = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rb_tungtu = new System.Windows.Forms.RadioButton();
            this.rb_cachuoi = new System.Windows.Forms.RadioButton();
            this.gb_ext = new System.Windows.Forms.GroupBox();
            this.gb_date.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb_lenght.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_min)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.gb_ext.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đuôi mở rộng";
            // 
            // cb_ext
            // 
            this.cb_ext.FormattingEnabled = true;
            this.cb_ext.Items.AddRange(new object[] {
            "*.mp3",
            "*.mp4",
            "*.doxs",
            "*.xlxs"});
            this.cb_ext.Location = new System.Drawing.Point(136, 24);
            this.cb_ext.Name = "cb_ext";
            this.cb_ext.Size = new System.Drawing.Size(121, 24);
            this.cb_ext.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ";
            // 
            // dtp_to
            // 
            this.dtp_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(81, 55);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 22);
            this.dtp_to.TabIndex = 3;
            // 
            // dtp_from
            // 
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Location = new System.Drawing.Point(81, 27);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(200, 22);
            this.dtp_from.TabIndex = 4;
            // 
            // gb_date
            // 
            this.gb_date.Controls.Add(this.label5);
            this.gb_date.Controls.Add(this.dtp_from);
            this.gb_date.Controls.Add(this.dtp_to);
            this.gb_date.Controls.Add(this.label2);
            this.gb_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_date.Location = new System.Drawing.Point(43, 203);
            this.gb_date.Name = "gb_date";
            this.gb_date.Size = new System.Drawing.Size(296, 87);
            this.gb_date.TabIndex = 9;
            this.gb_date.TabStop = false;
            this.gb_date.Text = "Thời gian tạo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(17, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Đến";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(124, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Theo đuôi";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(20, 54);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(152, 20);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Theo thời gian tạo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(43, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 112);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại lọc";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(20, 80);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(136, 20);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Theo kích thước";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // gb_lenght
            // 
            this.gb_lenght.Controls.Add(this.label3);
            this.gb_lenght.Controls.Add(this.nud_max);
            this.gb_lenght.Controls.Add(this.label4);
            this.gb_lenght.Controls.Add(this.nud_min);
            this.gb_lenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_lenght.Location = new System.Drawing.Point(44, 296);
            this.gb_lenght.Name = "gb_lenght";
            this.gb_lenght.Size = new System.Drawing.Size(296, 81);
            this.gb_lenght.TabIndex = 10;
            this.gb_lenght.TabStop = false;
            this.gb_lenght.Text = "Kích thước";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(16, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến";
            // 
            // nud_max
            // 
            this.nud_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_max.Location = new System.Drawing.Point(81, 43);
            this.nud_max.Name = "nud_max";
            this.nud_max.Size = new System.Drawing.Size(200, 22);
            this.nud_max.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(17, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Từ";
            // 
            // nud_min
            // 
            this.nud_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_min.Location = new System.Drawing.Point(81, 16);
            this.nud_min.Name = "nud_min";
            this.nud_min.Size = new System.Drawing.Size(200, 22);
            this.nud_min.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rb_tungtu);
            this.groupBox5.Controls.Add(this.rb_cachuoi);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(223, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(117, 112);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kiểu lọc";
            // 
            // rb_tungtu
            // 
            this.rb_tungtu.AutoSize = true;
            this.rb_tungtu.Location = new System.Drawing.Point(13, 66);
            this.rb_tungtu.Name = "rb_tungtu";
            this.rb_tungtu.Size = new System.Drawing.Size(77, 20);
            this.rb_tungtu.TabIndex = 1;
            this.rb_tungtu.Text = "Từng từ";
            this.rb_tungtu.UseVisualStyleBackColor = true;
            // 
            // rb_cachuoi
            // 
            this.rb_cachuoi.AutoSize = true;
            this.rb_cachuoi.Checked = true;
            this.rb_cachuoi.Location = new System.Drawing.Point(13, 28);
            this.rb_cachuoi.Name = "rb_cachuoi";
            this.rb_cachuoi.Size = new System.Drawing.Size(86, 20);
            this.rb_cachuoi.TabIndex = 0;
            this.rb_cachuoi.TabStop = true;
            this.rb_cachuoi.Text = "Cả chuỗi";
            this.rb_cachuoi.UseVisualStyleBackColor = true;
            // 
            // gb_ext
            // 
            this.gb_ext.Controls.Add(this.cb_ext);
            this.gb_ext.Controls.Add(this.label1);
            this.gb_ext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ext.Location = new System.Drawing.Point(43, 133);
            this.gb_ext.Name = "gb_ext";
            this.gb_ext.Size = new System.Drawing.Size(296, 64);
            this.gb_ext.TabIndex = 10;
            this.gb_ext.TabStop = false;
            this.gb_ext.Text = "Đuôi mở rộng";
            // 
            // fBoloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(397, 444);
            this.Controls.Add(this.gb_ext);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gb_lenght);
            this.Controls.Add(this.gb_date);
            this.Name = "fBoloc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fBoloc";
            this.gb_date.ResumeLayout(false);
            this.gb_date.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gb_lenght.ResumeLayout(false);
            this.gb_lenght.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_min)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gb_ext.ResumeLayout(false);
            this.gb_ext.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_ext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.GroupBox gb_date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gb_lenght;
        private System.Windows.Forms.NumericUpDown nud_max;
        private System.Windows.Forms.NumericUpDown nud_min;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rb_tungtu;
        private System.Windows.Forms.RadioButton rb_cachuoi;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox gb_ext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
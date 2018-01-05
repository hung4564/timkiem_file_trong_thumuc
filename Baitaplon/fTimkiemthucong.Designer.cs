namespace Baitaplon
{
     partial class fTimkiemthucong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTimkiemthucong));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listIcon = new System.Windows.Forms.ImageList(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Forward = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.txt_current = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.listIcon;
            this.treeView1.Location = new System.Drawing.Point(12, 68);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(156, 281);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listIcon
            // 
            this.listIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.listIcon.ImageSize = new System.Drawing.Size(16, 16);
            this.listIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(175, 68);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(297, 281);
            this.treeView2.TabIndex = 1;
            this.treeView2.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView2_BeforeExpand);
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(1, 24);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Forward
            // 
            this.btn_Forward.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Forward.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Forward.Location = new System.Drawing.Point(82, 24);
            this.btn_Forward.Name = "btn_Forward";
            this.btn_Forward.Size = new System.Drawing.Size(75, 23);
            this.btn_Forward.TabIndex = 3;
            this.btn_Forward.Text = "Forward";
            this.btn_Forward.UseVisualStyleBackColor = false;
            this.btn_Forward.Click += new System.EventHandler(this.btn_Forward_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Location = new System.Drawing.Point(163, 24);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // txt_current
            // 
            this.txt_current.Location = new System.Drawing.Point(244, 24);
            this.txt_current.Name = "txt_current";
            this.txt_current.Size = new System.Drawing.Size(228, 20);
            this.txt_current.TabIndex = 5;
            // 
            // fTimkiemthucong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(485, 361);
            this.Controls.Add(this.txt_current);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Forward);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Name = "fTimkiemthucong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm Thủ Công";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ImageList listIcon;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Forward;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox txt_current;
    }
}
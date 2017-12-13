﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplon
{
    public partial class fMainform : Form
    {
        private const int ItemHeight = 50;
        string pathfile_history_name = Application.StartupPath + "\\history_name.txt";
        string pathfile_history_file = Application.StartupPath + "\\history_file.txt";
        public fMainform()
        {
            InitializeComponent();
            listBox_file.DrawMode = DrawMode.OwnerDrawVariable;
            listBox_file.DrawItem += ListBox_file_DrawItem;
            listBox_file.MeasureItem += ListBox_file_MeasureItem;
            loadLichsuTen();
            loadLichsuFile();
        }

        private void ListBox_file_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ItemHeight;
        }

        private void ListBox_file_DrawItem(object sender, DrawItemEventArgs e)
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
        void loadLichsuTen()
        {
            string[] result = XTxt.ReadLineText(pathfile_history_name).ToArray();
            foreach (string item in result)
            {
                listBox_tu.Items.Add(item);
            }
        }
        void loadLichsuFile()
        {
            string[] result = XTxt.ReadLineText(pathfile_history_file).ToArray();
            foreach (string item in result)
            {
                XInfo temp = new XInfo(item);
                listBox_file.Items.Add(temp);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fTimkiemthucong f = new fTimkiemthucong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fTimkiemnhap f = new fTimkiemnhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btn_findinfile_Click(object sender, EventArgs e)
        {
            fTimkiemInTxt f = new fTimkiemInTxt();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void fMainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ? ", "Notifications", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}

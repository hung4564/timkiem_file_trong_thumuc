using System;
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
    public partial class fBoloc : Form
    {
        XFilter boloc;
        public fBoloc(XFilter boLoc)
        {
            InitializeComponent();
            this.boloc = boLoc;
            if (boloc.ext == null) checkBox1.Checked = false;
            else
            {
                checkBox1.Checked = true;
                cb_ext.Text = boloc.ext;
            }
            if(boloc.createTimeFrom==null) checkBox2.Checked = false;
            else
            {
                checkBox2.Checked = true;
                dtp_from.Value = (DateTime)boloc.createTimeFrom;
                dtp_to.Value = (DateTime)boloc.createTimeTo;
            }
            if (boloc.lenghtMax == 0) checkBox3.Checked = false;
            else
            {
                checkBox3.Checked = true;
                nud_min.Value = boloc.lenghtMin;
                nud_max.Value = boloc.lenghtMax;
            }
            if (boloc.loailoc == Loailoc.Loctheochuoi) rb_cachuoi.Checked = true; else rb_tungtu.Checked = true;
            gb_ext.Enabled = checkBox1.Checked;
            gb_date.Enabled = checkBox2.Checked;
            gb_lenght.Enabled = checkBox3.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                boloc.ext = cb_ext.Text;
            }
            else
            {
                boloc.ext = null;
            }
            if (checkBox2.Checked)
            {
                boloc.createTimeFrom = dtp_from.Value;
                boloc.createTimeTo = dtp_to.Value;
            }
            else
            {
                boloc.createTimeFrom = null;
                boloc.createTimeTo = null;
            }
            if (checkBox3.Checked)
            {
                boloc.lenghtMin = (long)nud_min.Value;
                boloc.lenghtMax = (long)nud_max.Value;
            }
            else
            {
                boloc.lenghtMin = 0;
                boloc.lenghtMax = 0;
            }
            boloc.loailoc = (rb_cachuoi.Checked ? Loailoc.Loctheochuoi : Loailoc.Loctheotungtu);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gb_ext.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            gb_date.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            gb_lenght.Enabled = checkBox3.Checked;
        }
    }
}

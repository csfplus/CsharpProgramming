using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDemo10
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmConSQL().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmAddData().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmAddDataByProc().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmReadDataBySDR().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmEditByUCmdAndUpdate().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new frmFillDS().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new frmUseDataGridView().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new frmUseBindingSource().Show();
        }
    }
}

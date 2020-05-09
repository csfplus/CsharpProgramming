using MyFirstApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDemo9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFileStream_Click(object sender, EventArgs e)
        {
            new frmFileStream().Show();
        }

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            new frmStreamWriter().Show();
        }

        private void btnstreamReader_Click(object sender, EventArgs e)
        {
            new frmStreamReader().Show();
        }

        private void btnBinaryWriter_Click(object sender, EventArgs e)
        {
            new frmBinaryWriter().Show();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            new frmFile().Show();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            new frmDirectory().Show();
        }

        private void btnDriverInfo_Click(object sender, EventArgs e)
        {
            new frmDriveInfo().Show();
        }
    }
}

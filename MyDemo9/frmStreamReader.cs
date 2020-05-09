using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyFirstApplication
{
    public partial class frmStreamReader : Form
    {
        public frmStreamReader()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader SReader = new StreamReader("Log.txt", Encoding.UTF8);			//创建StreamReader对象
            string strLine = string.Empty;
            while ((strLine = SReader.ReadLine()) != null)//逐行读取日志文件
            {
                //获取单条日志信息
                string[] strLogs = strLine.Split(new string[] { "    " }, StringSplitOptions.RemoveEmptyEntries);
                ListViewItem li = new ListViewItem();
                li.SubItems.Clear();
                li.SubItems[0].Text = strLogs[0].Substring(strLogs[0].IndexOf('：') + 1);//显示登录用户
                li.SubItems.Add(strLogs[1].Substring(strLogs[1].IndexOf('：') + 1));//显示登录时间
                listView1.Items.Add(li);
            }
            SReader.Close();
        }
    }
}
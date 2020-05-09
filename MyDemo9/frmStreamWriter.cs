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
    public partial class frmStreamWriter : Form
    {
        public frmStreamWriter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Log.txt"))//判断日志文件是否存在
            {
                File.Create("Log.txt");//创建日志文件
            }
            string strLog = "登录用户：" + textBox1.Text + "    登录时间：" + DateTime.Now;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (StreamWriter sWriter = new StreamWriter("Log.txt", true))//创建StreamWriter对象
                {
                    sWriter.WriteLine(strLog);//写入日志
                }
                frmStreamReader frm = new frmStreamReader();//创建Form1窗体
                this.Hide();//隐藏当前窗体
                frm.Show();//显示Form1窗体
            }
        }
    }
}

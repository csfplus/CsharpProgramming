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
    public partial class frmFile : Form
    {
        public frmFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))//判断要创建的文件是否存在
            {
                MessageBox.Show("该文件已经存在，请重新输入");
            }
            else
            {
                File.Create(textBox1.Text);//创建文件
                FileInfo fInfo = new FileInfo(textBox1.Text);//创建FileInfo对象
                ListViewItem li = new ListViewItem();
                li.SubItems.Clear();
                li.SubItems[0].Text = fInfo.Name;//显示文件名称
                li.SubItems.Add(fInfo.Extension);//显示文件扩展名
                li.SubItems.Add(fInfo.Length / 1024 + "KB");//显示文件大小
                li.SubItems.Add(fInfo.LastWriteTime.ToString());//显示文件修改时间
                listView1.Items.Add(li);
            }
        }
    }
}

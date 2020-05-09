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
    public partial class frmFileStream : Form
    {
        public frmFileStream()
        {
            InitializeComponent();
        }
        FileMode fileM = FileMode.Open;//声明一个FileMode对象，用来记录要打开的方式
        //执行读写操作
        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;//获取打开文件的路径
            try
            {
                using (FileStream fs = File.Open(path, fileM))//以指定的方式打开文件
                {
                    if (fileM != FileMode.Truncate)//如果在打开文件后不清空文件
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(textBox2.Text);//将要添加的内容转换成字节
                        fs.Write(info, 0, info.Length);//向文件中写入内容
                    }
                }
                using (FileStream fs = File.Open(path, FileMode.Open))//以读/写方式打开文件
                {
                    byte[] b = new byte[1024];//定义一个字节数组
                    UTF8Encoding temp = new UTF8Encoding(true);//实现UTF-8编码
                    string pp = "";
                    while (fs.Read(b, 0, b.Length) > 0)//读取文本中的内容
                    {
                        pp += temp.GetString(b);//累加读取的结果
                    }
                    MessageBox.Show(pp);//显示文本中的内容
                }
            }
            catch//如果文件不存在，则发生异常
            {
                if (MessageBox.Show("该文件不存在，是否创建文件。", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)//显示提示框，判断是否创建文件
                {
                    FileStream fs = File.Open(path, FileMode.CreateNew);//在指定的路径下创建文件
                    fs.Dispose();//释放流
                }
            }
        }
        //选择打开方式
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)//如果单选按钮被选中
            {
                switch (Convert.ToInt32(((RadioButton)sender).Tag.ToString()))//判断单选项的选中情况
                {
                    //记录文件的打开方式
                    case 0: fileM = FileMode.Open; break;//以读/写方式打开文件
                    case 1: fileM = FileMode.Append; break;//以追加方式打开文件
                    case 2: fileM = FileMode.Truncate; break;//打开文件后清空文件内容
                    case 3: fileM = FileMode.Create; break;//以覆盖方式打开文件
                }
            }
        }
    }
}

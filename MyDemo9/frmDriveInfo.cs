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
    public partial class frmDriveInfo : Form
    {
        public frmDriveInfo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] dInfos = DriveInfo.GetDrives();//获取本地所有驱动器
            foreach (DriveInfo dInfo in dInfos)//遍历获取到的驱动器
            {
                comboBox1.Items.Add(dInfo.Name);//将驱动器名称添加到下拉列表中
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strDirs = Directory.GetDirectories(comboBox1.Text);//获取指定磁盘下的所有文件夹
            foreach (string strDir in strDirs)//遍历获取到的文件夹
            {
                ListViewItem li = new ListViewItem();
                li.SubItems.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(strDir);//使用遍历到的文件夹创建DirectoryInfo对象
                li.SubItems[0].Text = dirInfo.Name;//显示文件夹名称
                li.SubItems.Add(dirInfo.CreationTime.ToString());//显示文件夹创建时间
                listView1.Items.Add(li);
            }
        }
    }
}

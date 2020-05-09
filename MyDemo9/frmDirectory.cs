using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyFirstApplication
{
    public partial class frmDirectory : Form
    {
        public frmDirectory()
        {
            InitializeComponent();
        }
        //获取所有驱动器，并显示在ComboBox中
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] dirs = Directory.GetLogicalDrives();//获取计算上的逻辑驱动器的名称
            if (dirs.Length > 0)//如果有驱动器
            {
                for (int i = 0; i < dirs.Length; i++)//遍历驱动器
                {
                    comboBox1.Items.Add(dirs[i]);//将驱动名称添加到下拉项中
                }
            }
        }
        //选择驱动器
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text.Length > 0)//如果在下拉项中选择了值
            {
                treeView1.Nodes.Clear();//清空treeView1控件
                TreeNode TNode = new TreeNode();//实例化TreeNode
                //将驱动器下的文件夹及文件名称添加到treeView1控件上
                Folder_List(treeView1, ((ComboBox)sender).Text, TNode, 0);
            }
        }
        #region  显示文件夹下所有子文件夹及文件的名称
        /// <summary>
        /// 显示文件夹下所有子文件夹及文件的名称
        /// </summary>
        /// <param Sdir="string">文件夹的目录</param>
        /// <param TNode="TreeNode">节点</param>
        /// <param n="int">标识，判断当前是文件夹，还是文件</param>
        private void Folder_List(TreeView TV, string Sdir, TreeNode TNode, int n)
        {
            if (TNode.Nodes.Count > 0)//如果当前节点下有子节点
                if (TNode.Nodes[0].Text != "")//如果第一个子节点的文本为空
                    return;//退出本次操作
            if (TNode.Text == "")//如果当前节点的文本为空
                Sdir += "\\";//设置驱动器的根路径
            DirectoryInfo dir = new DirectoryInfo(Sdir);//实例化DirectoryInfo类
            try
            {
                if (!dir.Exists)//判断文件夹是否存在
                {
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;//如果给定参数不是文件夹，则退出
                if (dirD == null)//如果文件夹是否为空
                {
                    TNode.Nodes.Clear();//清空当前节点
                    return;
                }
                else
                {
                    if (n == 0)//如果当前是文件夹
                    {
                        if (TNode.Text == "")//如果当前节点为空
                            TNode = TV.Nodes.Add(dirD.Name);//添加文件夹的名称
                        else
                        {
                            TNode.Nodes.Clear();//清空当前节点
                        }
                        TNode.Tag = 0;//设置文件夹的标识
                    }
                }
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//获取文件夹中所有文件和文件夹
                //对单个FileSystemInfo进行判断,遍历文件和文件夹
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;//实例化FileInfo类
                    if (file != null)//如果是文件的话，将文件名添加到节点下
                    {
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);//获取文件所在路径
                        TNode.Nodes.Add(file.Name);//添加文件名
                        TNode.Tag = 0;//设置文件标识
                    }
                    else//如果是文件夹
                    {
                        TreeNode TemNode = TNode.Nodes.Add(FSys.Name);//添加文件夹名称
                        TNode.Tag = 1;//设置文件夹标识
                        TemNode.Nodes.Add("");//在该文件夹的节点下添加一个空文件夹，表示文件夹下有子文件夹或文件
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (((TreeView)sender).SelectedNode == null)//如当前节点为空
                return;
            //将指定目录下的文件夹及文件名称清加到treeView1控件的指定节点下
            Folder_List(treeView1, ((TreeView)sender).SelectedNode.FullPath.Replace("\\\\", "\\"), ((TreeView)sender).SelectedNode, 0);
        }
    }
}

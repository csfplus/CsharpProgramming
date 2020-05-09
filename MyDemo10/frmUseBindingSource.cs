using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyDemo10
{
    public partial class frmUseBindingSource : Form
    {
        public frmUseBindingSource()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //第一条
        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();//转到第一条记录
            ShowInfo();//显示信息
        }
        //上一条
        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();//转到上一条记录
            ShowInfo();//显示信息
        }
        //下一条
        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();//转到下一条记录
            ShowInfo();//显示信息
        }
        //最后一条
        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();//转到最后一条记录
            ShowInfo();//显示信息
        }
        /// <summary>
        /// 显示浏览到的记录的详细信息
        /// </summary>
        private void ShowInfo()
        {
            int index = bindingSource1.Position;//获取BindingSource数据源的当前索引
            DataRowView DRView = (DataRowView)bindingSource1[index];//获取BindingSource数据源的当前行
            label2.Text = DRView[0].ToString();//显示编号
            textBox1.Text = DRView[1].ToString();//显示版本
            textBox2.Text = DRView[2].ToString();//显示价格
            toolStripStatusLabel3.Text = "当前记录是第" + (index + 1) + "条";//显示当前记录
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strCon = txtDB.Text;//定义数据库连接字符串
            SqlConnection sqlcon = new SqlConnection(strCon);//实例化数据库连接对象
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tb_PDic", sqlcon);//实例化数据库桥接器对象
            DataSet myds = new DataSet();//实例化数据集对象
            sqlda.Fill(myds);//填充数据集中
            bindingSource1.DataSource = myds.Tables[0];//为BindingSource组件设置数据源
            bindingSource1.Sort = "ID";//设置BindingSource组件的排序列
            toolStripStatusLabel1.Text = "总记录条数：" + bindingSource1.Count;//获取总记录条数
            ShowInfo();//显示信息
        }
    }
}

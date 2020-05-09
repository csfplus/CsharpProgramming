using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//i添加命名空间
using System.Data;
using System.Data.SqlClient;

namespace MyDemo10
{
    public partial class frmConSQL : Form
    {
        public frmConSQL()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2. connection
            SqlConnection con = new SqlConnection(txtDB.Text);//实例化SqlConnection数据库连接对象
            con.Open();//打开数据库连接
            if (con.State == ConnectionState.Open)//判断连接是否打开
            {
                label1.Text = "SQL Server数据库连接开启！";
                con.Close();//关闭数据库连接
            }
            if (con.State == ConnectionState.Closed)//判断连接是否关闭
            {
                label2.Text = "SQL Server数据库连接关闭！";
            }
        }
    }
}

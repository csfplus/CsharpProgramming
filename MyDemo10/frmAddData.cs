using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management.Instrumentation;

namespace MyDemo10
{
    public partial class frmAddData : Form
    {
        public frmAddData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实例化数据库连接对象
            SqlConnection conn = new SqlConnection(txtDB.Text);

            //定义添加数据的SQL语句
            string strsql = "insert into tb_PDic(Name,Money) values('" + textBox1.Text + "'," + Convert.ToDecimal(textBox2.Text) + ")";
            /*
             * 1.
             SqlCommand comm = new SqlCommand(strsql, conn);//实例化SqlCommand对象
             */

            //2.
            /*SqlCommand comm = new SqlCommand
            {
                CommandText = strsql,
                CommandType = CommandType.Text
                Connection = conn
            };
            */

            string strsql2 = "insert into tb_PDic(Name,Money) values(@name,@money)";
            SqlCommand comm = new SqlCommand
            {
                CommandText = strsql2,
                CommandType = CommandType.Text,
                Connection = conn
            };
            comm.Parameters.AddWithValue("@name", textBox1.Text);
            comm.Parameters.AddWithValue("@money", textBox2.Text);


            if (conn.State == ConnectionState.Closed)//判断连接是否关闭
            {
                conn.Open();//打开数据库连接
            }
            //判断ExecuteNonQuery方法返回的参数是否大于0，大于0表示添加成功
            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
            {
                label3.Text = "添加成功！";
            }
            else
            {
                label3.Text = "添加失败！";
            }
            conn.Close();//关闭数据库连接
        }
    }
}

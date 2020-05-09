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
    public partial class frmReadDataBySDR : Form
    {
        public frmReadDataBySDR()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实例化数据库连接对象
            SqlConnection sqlcon = new SqlConnection(txtDB.Text);
            SqlCommand sqlcmd = new SqlCommand("select * from tb_PDic order by ID asc", sqlcon);//实例化SqlCommand对象
            if (sqlcon.State == ConnectionState.Closed)//判断连接是否关闭
            {
                sqlcon.Open();//打开数据库连接
            }
            SqlDataReader sqldr = sqlcmd.ExecuteReader();//使用ExecuteReader方法的返回值实例化SqlDataReader对象
            richTextBox1.Text = "编号       版本         价格\n";//为文本框赋初始值
            try
            {
                if (sqldr.HasRows)//判断SqlDataReader对象中是否有数据
                {
                    while (sqldr.Read())//循环读取SqlDataReader对象中的数据
                    {
                        //显示读取的详细信息
                        richTextBox1.Text += "" + sqldr[0] + "    " + sqldr["Name"] + "    " + sqldr["Money"] + "\n";
                    }
                }
            }
            catch (SqlException ex)//捕获数据库异常
            {
                MessageBox.Show(ex.ToString());//输出异常信息
            }
            finally
            {
                sqldr.Close();//关闭SqlDataReader对象
                sqlcon.Close();//关闭数据库连接
            }
        }
    }
}

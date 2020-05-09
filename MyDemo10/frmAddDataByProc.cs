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
    public partial class frmAddDataByProc : Form
    {
        public frmAddDataByProc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实例化数据库连接对象
            SqlConnection sqlcon = new SqlConnection(txtDB.Text);
            SqlCommand sqlcmd = new SqlCommand();//实例化SqlCommand对象
            sqlcmd.Connection = sqlcon;//指定数据库连接对象
            sqlcmd.CommandType = CommandType.StoredProcedure;//指定执行对象为存储过程
            sqlcmd.CommandText = "proc_AddData";//指定要执行的存储过程名称
            sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = textBox1.Text;//为@name参数赋值
            sqlcmd.Parameters.Add("@money", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox2.Text);//为@money参数赋值
            if (sqlcon.State == ConnectionState.Closed)//判断连接是否关闭
            {
                sqlcon.Open();//打开数据库连接
            }
            //判断ExecuteNonQuery方法返回的参数是否大于0，大于0表示添加成功
            if (Convert.ToInt32(sqlcmd.ExecuteNonQuery()) > 0)
            {
                label3.Text = "添加成功！";
            }
            else
            {
                label3.Text = "添加失败！";
            }
            sqlcon.Close();//关闭数据库连接
        }
    }
}

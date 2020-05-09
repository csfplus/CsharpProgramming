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
    public partial class frmFillDS : Form
    {
        public frmFillDS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = txtDB.Text;//定义数据库连接字符串
            SqlConnection sqlcon = new SqlConnection(strCon);//实例化数据库连接对象
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tb_PDic", sqlcon);//实例化数据库桥接器对象
            DataSet myds = new DataSet();//实例化数据集对象
            sqlda.Fill(myds, "tabName");//填充数据集中的指定表
            dataGridView1.DataSource = myds.Tables["tabName"];//为dataGridView1指定数据源
        }
    }
}

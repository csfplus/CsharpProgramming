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
    public partial class frmEditByUCmdAndUpdate : Form
    {
        public frmEditByUCmdAndUpdate()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon;//声明数据库连接对象
        SqlDataAdapter sqlda;//声明数据库桥接器对象
        DataSet myds;//声明数据集对象
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //执行批量更新操作
        private void button1_Click(object sender, EventArgs e)
        {
            myds.Tables.Clear();//清空数据集
            sqlcon = new SqlConnection(txtDB.Text);//实例化数据库连接对象
            sqlda = new SqlDataAdapter("select * from tb_PDic", sqlcon);//实例化数据库桥接器对象
            //给SqlDataAdapter的UpdateCommand属性指定执行更新操作的SQL语句
            sqlda.UpdateCommand = new SqlCommand("update tb_PDic set Name=@name,Money=@money where ID=@id", sqlcon);
            //添加参数并赋值
            sqlda.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 20, "Name");
            sqlda.UpdateCommand.Parameters.Add("@money", SqlDbType.VarChar, 9, "Money");
            SqlParameter prams_ID = sqlda.UpdateCommand.Parameters.Add("@id", SqlDbType.Int);
            prams_ID.SourceColumn = "id";//设置@id参数的原始列
            prams_ID.SourceVersion = DataRowVersion.Original;//设置@id参数的原始值
            sqlda.Fill(myds);//填充数据集
            //使用一个for循环更改数据集myds中的表中的值
            for (int i = 0; i < myds.Tables[0].Rows.Count; i++)
            {
                myds.Tables[0].Rows[i]["Name"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                myds.Tables[0].Rows[i]["Money"] = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
            }
            //调用Update方法提交更新后的数据集myds,并同步更新数据库数据
            sqlda.Update(myds);
            dataGridView1.DataSource = myds.Tables[0];//对DataGridView控件进行数据绑定
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(txtDB.Text);//实例化数据库连接对象
            sqlda = new SqlDataAdapter("select * from tb_PDic", sqlcon);//实例化数据库桥接器对象
            myds = new DataSet();//实例化数据集
            sqlda.Fill(myds);//填充数据集
            dataGridView1.DataSource = myds.Tables[0];//对DataGridView控件进行数据绑定
        }
    }
}

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
    public partial class frmUseDataGridView : Form
    {
        public frmUseDataGridView()
        {
            InitializeComponent();
        }

        // string strCon = "Server=MRKJ_ZHD\\EAST;User Id=sa;Pwd=111;DataBase=db_CSharp";//定义数据库连接字符串
        SqlConnection sqlcon;//声明数据库连接对象
        SqlDataAdapter sqlda;//声明数据库桥接器对象
        DataSet myds;//声明数据集对象
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)//判断选中行的索引是否大于0
            {
                int intID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;//记录选中的ID号
                sqlcon = new SqlConnection(txtDB.Text);//实例化数据库连接对象
                sqlda = new SqlDataAdapter("select * from tb_PDic where ID=" + intID + "", sqlcon);//实例化数据库桥接器对象
                myds = new DataSet();//实例化数据集对象
                sqlda.Fill(myds);//填充数据集中
                if (myds.Tables[0].Rows.Count > 0)//判断数据集中是否有记录
                {
                    textBox1.Text = myds.Tables[0].Rows[0][1].ToString();//显示版本
                    textBox2.Text = myds.Tables[0].Rows[0][2].ToString();//显示价格
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;//禁止添加行
            dataGridView1.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView1.AutoGenerateColumns = false; //s禁止自动生成列
            sqlcon = new SqlConnection(txtDB.Text);//实例化数据库连接对象
            sqlda = new SqlDataAdapter("select * from tb_PDic", sqlcon);//实例化数据库桥接器对象
            myds = new DataSet();//实例化数据集对象
            sqlda.Fill(myds);//填充数据集
            dataGridView1.DataSource = myds.Tables[0];//为dataGridView1指定数据源
            //禁用DataGridView控件的排序功能
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //设置SelectionMode属性为FullRowSelect使控件能够整行选择
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //设置DataGridView控件中的数据以各行换色的形式显示
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)//遍历所有行
            {
                if (dgvRow.Index % 2 == 0)//判断是否是偶数行
                {
                    //设置偶数行颜色
                    dataGridView1.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else//奇数行
                {
                    //设置奇数行颜色
                    dataGridView1.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
            dataGridView1.ReadOnly = true;//设置dataGridView1控件的ReadOnly属性，使其为只读
            //设置dataGridView1控件的DefaultCellStyle.SelectionBackColor属性，使选中行颜色变色
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyExper5
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadCategory();
            loadTask();
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsbtnCategoryAdd_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadCategory();
            }
        }
        private void tsbtnCategoryEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                //todo
                //弹出一个新窗体进行编辑(和添加窗体界面。)
                FrmCategory frm = new FrmCategory(treeView1.SelectedNode.Tag);
                if (frm.ShowDialog() == DialogResult.OK) loadCategory();
            }
        }
        private void tsbtnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && MessageBox.Show($"确定要删除【{treeView1.SelectedNode.Text}】吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    using (SqlCommand cmd = new SqlCommand($"delete  from tb_category where cateid={treeView1.SelectedNode.Tag}", conn))
                    {
                        conn.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("删除成功");
                            //重新加载事件
                            loadCategory();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }

            }
        }


        void loadCategory()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tb_category order by sort asc", conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        treeView1.Nodes.Clear();
                        var tn = treeView1.Nodes.Add("全部");
                        tn.Tag = 0;
                        while (dr.Read())
                        {
                            tn = treeView1.Nodes.Add(dr["catename"].ToString());
                            tn.Tag = dr["cateid"];  //将主键保存起来
                        }
                    }
                }
            }
        }

        void loadTask()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                string sql = "select * from tb_task";
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag.ToString() != "0")
                    sql = $"{sql} where cateid={treeView1.SelectedNode.Tag}";

                var da = new SqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            loadTask();
        }

        private void tsbtnTaskAdd_Click(object sender, EventArgs e)
        {
            if (new FrmTask().ShowDialog() == DialogResult.OK)
                loadTask();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            loadTask();
        }

        private void tsbtnTaskDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                if (MessageBox.Show($"确定要删除【{dataGridView1.SelectedRows[0].Cells["dgvcoltaskname"].Value}】任务吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        using (SqlCommand cmd = new SqlCommand($"delete  from tb_task where id={dataGridView1.SelectedRows[0].Cells["dgvcolid"].Value}", conn))
                        {
                            conn.Open();
                            if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                            {
                                MessageBox.Show("删除成功");
                                loadTask();
                            }
                            else
                            {
                                MessageBox.Show("删除失败！");
                            }
                        }
                    }
                }
            }
        }

        private void tsbtnTaskEdit_Click(object sender, EventArgs e)
        {

        }
    }
}

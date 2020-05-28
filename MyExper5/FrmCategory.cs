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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
            lblId.Text = "0";//给个默认值为0,表示是增加,否则是修改。
        }

        //修改类别，也可以重新做一个界面
        public FrmCategory(object id) : this()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                using (SqlCommand cmd = new SqlCommand($"select cateid,cateName,sort from tb_category  where cateid={id}", conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr["cateName"].ToString();
                        txtSort.Value = dr.GetInt32(2); //根据上面的SQL语句中的sort字段的位置
                        lblId.Text = dr["cateid"].ToString();  //赋值为当前要修改的记录所对应的ID
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    string strsql2 = string.Empty;
                    //先判断是删除还修改
                    if (lblId.Text == "0") strsql2 = "insert into tb_category(cateName,sort) values(@name,@sort)";
                    else strsql2 = "update tb_category set cateName=@name, sort=@sort where cateid=" + lblId.Text;

                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@name", txtName.Text);
                        comm.Parameters.AddWithValue("@sort", txtSort.Value);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show(lblId.Text == "0" ? "添加成功" : "修改成功");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(lblId.Text == "0" ? "添加失败！" : "修改失败");
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    string strsql2 = "insert into tb_category(cateName,sort) values(@name,@sort)";
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
                            MessageBox.Show("添加成功");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("添加失败！");
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

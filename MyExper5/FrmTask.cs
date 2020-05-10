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
    public partial class FrmTask : Form
    {
        public FrmTask()
        {
            InitializeComponent();
        }
        private void FrmTask_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                conn.Open();
                var da = new SqlDataAdapter("select * from tb_category order by sort asc", conn);
                var dt = new DataTable();
                da.Fill(dt);

                txtCate.DataSource = dt;
                txtCate.DisplayMember = "CateName";
                txtCate.ValueMember = "CateId";
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    string strsql2 = "insert into tb_task(CateId,TaskName,Description,EndTime) values(@cateid,@taskname,@desc,@time)";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@cateid", txtCate.SelectedValue);
                        comm.Parameters.AddWithValue("@taskname", txtName.Text);
                        comm.Parameters.AddWithValue("@desc", txtdesc.Text);
                        comm.Parameters.AddWithValue("@time", txtEndTime.Value);
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


    }
}

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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            var frm = new FrmSetting();
            if (frm.ShowDialog() == DialogResult.OK) AppConst.DbPath = frm.DbPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AppConst.DbPath))
            {
                MessageBox.Show("请先设置数据库连接");
                return;
            }

            using (SqlConnection sqlcon = new SqlConnection(AppConst.DbPath))
            {
                SqlCommand sqlcmd = new SqlCommand($"select userid from tb_user where username='{txtUid.Text}' and userpwd='{txtPwd.Text}'", sqlcon);
                sqlcon.Open();
                var obj = sqlcmd.ExecuteScalar();
                if (obj == null)
                {
                    MessageBox.Show("您输入的用户名或密码有误！");
                }
                else
                {
                    this.Hide();
                    new FrmMain().Show();
                }
            }
        }
    }
}

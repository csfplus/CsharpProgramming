using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotepad
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = $"{richTextBox1.Text.Length}字";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Font = richTextBox1.SelectionFont;
            fd.Color = richTextBox1.SelectionColor;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
                richTextBox1.SelectionColor = fd.Color;
            }

        }

        private void 撤消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(DateTime.Now + "");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            /*  得到光标行第一个字符的索引，
            *  即从第1个字符开始到光标行的第1个字符索引*/
            int index = richTextBox1.GetFirstCharIndexOfCurrentLine();
            /*得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            int line = richTextBox1.GetLineFromCharIndex(index) + 1;
            /*  SelectionStart得到光标所在位置的索引
             *  再减去
             *  当前行第一个字符的索引
             *  = 光标所在的列数(从0开始)  */
            int column = richTextBox1.SelectionStart - index + 1;
            toolStripStatusLabel1.Text = string.Format("第：{0}行 {1}列", line.ToString(), column.ToString());

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                /// notifyIcon1.Visible = false;
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                ///notifyIcon1.Visible = true;
                //显示BalloonTip
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示", "图标已经缩小到托盘，打开窗口请双击图标即可。", ToolTipIcon.Info);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //if (timer1.Enabled)
            //{
            //    toolStripButton8.Image = MyNotepad.Properties.Resources.闪烁_灰色;
            //    timer1.Stop();
            //    notifyIcon1.Icon = Properties.Resources.user;
            //}
            //else
            //{
            //    toolStripButton8.Image = MyNotepad.Properties.Resources.闪烁;
            //    timer1.Start();
            //}
        }

        bool isChange = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isChange)
                notifyIcon1.Icon = Properties.Resources.user;
            else notifyIcon1.Icon = Properties.Resources.rollcall;
            isChange = !isChange;
        }

        AnchorStyles StopAanhor = AnchorStyles.None;

        private void frmMain_LocationChanged(object sender, EventArgs e)
        {
            if (this.Top <= 0)
            {
                StopAanhor = AnchorStyles.Top;
            }
            else if (this.Left <= 0)
            {
                StopAanhor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                StopAanhor = AnchorStyles.Right;
            }
            else
            {
                StopAanhor = AnchorStyles.None;
            }
        }
        int displayWith = 10;
        private void timer2_Tick(object sender, EventArgs e)
        {
            TopMost = true;

            //根据窗体位置隐藏
            if (this.Bounds.Contains(Cursor.Position))
            {
                switch (this.StopAanhor)
                {
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, 0);
                        break;
                    case AnchorStyles.Left:
                        this.Location = new Point(0, this.Location.Y);
                        break;
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                        break;
                }
            }
            else
            {
                ///
                switch (this.StopAanhor)
                {
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, (this.Height - displayWith) * (-1));
                        break;
                    case AnchorStyles.Left:
                        this.Location = new Point((-1) * (this.Width - displayWith), this.Location.Y);
                        break;
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - displayWith, this.Location.Y);
                        break;
                }
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            //if (timer2.Enabled)
            //{
            //    toolStripButton12.Image = Properties.Resources.停靠;
            //    timer2.Stop();
            //}
            //else
            //{
            //    toolStripButton12.Image = Properties.Resources.停靠_红色;
            //    timer2.Start();
            //}
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.sh
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开文件";
            ofd.Filter = "Word文档|*.docx|文本格式|*.txt|富文本格式|*.rtf|专用格式|.csfx";
            ofd.DefaultExt = "rtf";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                    richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                else richTextBox1.LoadFile(ofd.FileName);

                treeView1.Nodes.Clear();
                var path = Path.GetDirectoryName(ofd.FileName);
                var allExt = new List<string> { ".txt", ".rtf", ".csfx" };
                foreach (var f in Directory.GetFiles(path).Where(a => allExt.Contains(Path.GetExtension(a).ToLower())))
                {
                    var tn = treeView1.Nodes.Add(Path.GetFileName(f));
                    tn.Tag = f;
                }

            }
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本格式|*.txt|富文本格式|*.rtf|专用格式|.csfx";
            saveFileDialog1.DefaultExt = "rtf";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog1.FileName).ToLower() == ".txt")
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                toolStripStatusLabel3.Text = "已保存";
            }
        }

        private void tssbtnSide_Click(object sender, EventArgs e)
        {
            if (treeView1.Visible)
            {
                treeView1.Visible = false;
                tssbtnSide.Image = Properties.Resources.侧栏展开;
                tssbtnSide.ToolTipText = "展开侧栏";
            }
            else
            {
                treeView1.Visible = true;
                tssbtnSide.Image = Properties.Resources.侧栏收起;
                tssbtnSide.ToolTipText = "收起侧栏";
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var f = treeView1.SelectedNode.Tag.ToString();
                if (Path.GetExtension(f).ToLower() == ".txt")
                    richTextBox1.LoadFile(f, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.LoadFile(f);
            }
        }
    }
}

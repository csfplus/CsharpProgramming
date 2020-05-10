namespace MyExper5
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCategoryAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCategoryEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCategoryDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTaskAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTaskEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTaskDel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvcoltaskname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcolid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCategoryAdd,
            this.tsbtnCategoryEdit,
            this.tsbtnCategoryDelete,
            this.toolStripSeparator1,
            this.tsbtnTaskAdd,
            this.tsbtnTaskEdit,
            this.tsbtnTaskDel,
            this.toolStripSeparator2,
            this.tsbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 43);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 43);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(159, 374);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcoltaskname,
            this.Column3,
            this.Column2,
            this.dgvcolid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(159, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(517, 374);
            this.dataGridView1.TabIndex = 2;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbtnCategoryAdd
            // 
            this.tsbtnCategoryAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCategoryAdd.Image = global::MyExper5.Properties.Resources.添加类别;
            this.tsbtnCategoryAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCategoryAdd.Name = "tsbtnCategoryAdd";
            this.tsbtnCategoryAdd.Size = new System.Drawing.Size(40, 40);
            this.tsbtnCategoryAdd.Text = "添加任务类型";
            this.tsbtnCategoryAdd.ToolTipText = "添加类别";
            this.tsbtnCategoryAdd.Click += new System.EventHandler(this.tsbtnCategoryAdd_Click);
            // 
            // tsbtnCategoryEdit
            // 
            this.tsbtnCategoryEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCategoryEdit.Image = global::MyExper5.Properties.Resources.修改类别;
            this.tsbtnCategoryEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCategoryEdit.Name = "tsbtnCategoryEdit";
            this.tsbtnCategoryEdit.Size = new System.Drawing.Size(40, 40);
            this.tsbtnCategoryEdit.Text = "修改类别";
            this.tsbtnCategoryEdit.Click += new System.EventHandler(this.tsbtnCategoryEdit_Click);
            // 
            // tsbtnCategoryDelete
            // 
            this.tsbtnCategoryDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCategoryDelete.Image = global::MyExper5.Properties.Resources.删除类别;
            this.tsbtnCategoryDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCategoryDelete.Name = "tsbtnCategoryDelete";
            this.tsbtnCategoryDelete.Size = new System.Drawing.Size(40, 40);
            this.tsbtnCategoryDelete.Text = "删除类别";
            this.tsbtnCategoryDelete.Click += new System.EventHandler(this.tsbtnCategoryDelete_Click);
            // 
            // tsbtnTaskAdd
            // 
            this.tsbtnTaskAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTaskAdd.Image = global::MyExper5.Properties.Resources.添加任务;
            this.tsbtnTaskAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTaskAdd.Name = "tsbtnTaskAdd";
            this.tsbtnTaskAdd.Size = new System.Drawing.Size(40, 40);
            this.tsbtnTaskAdd.Text = "toolStripButton2";
            this.tsbtnTaskAdd.ToolTipText = "添加任务";
            this.tsbtnTaskAdd.Click += new System.EventHandler(this.tsbtnTaskAdd_Click);
            // 
            // tsbtnTaskEdit
            // 
            this.tsbtnTaskEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTaskEdit.Image = global::MyExper5.Properties.Resources.修改任务;
            this.tsbtnTaskEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTaskEdit.Name = "tsbtnTaskEdit";
            this.tsbtnTaskEdit.Size = new System.Drawing.Size(40, 40);
            this.tsbtnTaskEdit.Text = "修改任务";
            // 
            // tsbtnTaskDel
            // 
            this.tsbtnTaskDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTaskDel.Image = global::MyExper5.Properties.Resources.删除任务;
            this.tsbtnTaskDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTaskDel.Name = "tsbtnTaskDel";
            this.tsbtnTaskDel.Size = new System.Drawing.Size(40, 40);
            this.tsbtnTaskDel.Text = "删除任务";
            this.tsbtnTaskDel.Click += new System.EventHandler(this.tsbtnTaskDel_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = global::MyExper5.Properties.Resources.刷新;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(40, 40);
            this.tsbtnRefresh.Text = "刷新列表";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // dgvcoltaskname
            // 
            this.dgvcoltaskname.DataPropertyName = "taskname";
            this.dgvcoltaskname.HeaderText = "任务名称";
            this.dgvcoltaskname.Name = "dgvcoltaskname";
            this.dgvcoltaskname.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "endtime";
            this.Column3.HeaderText = "截止时间";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "description";
            this.Column2.HeaderText = "详细说明";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // dgvcolid
            // 
            this.dgvcolid.DataPropertyName = "id";
            this.dgvcolid.HeaderText = "不可见的";
            this.dgvcolid.Name = "dgvcolid";
            this.dgvcolid.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 417);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "任务清单管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnCategoryAdd;
        private System.Windows.Forms.ToolStripButton tsbtnTaskAdd;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton tsbtnCategoryEdit;
        private System.Windows.Forms.ToolStripButton tsbtnCategoryDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnTaskEdit;
        private System.Windows.Forms.ToolStripButton tsbtnTaskDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcoltaskname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcolid;
    }
}
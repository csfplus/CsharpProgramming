namespace MyDemo9
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileStream = new System.Windows.Forms.Button();
            this.btnStreamWrite = new System.Windows.Forms.Button();
            this.btnstreamReader = new System.Windows.Forms.Button();
            this.btnBinaryWriter = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.btnDriverInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFileStream
            // 
            this.btnFileStream.Location = new System.Drawing.Point(49, 39);
            this.btnFileStream.Name = "btnFileStream";
            this.btnFileStream.Size = new System.Drawing.Size(103, 23);
            this.btnFileStream.TabIndex = 0;
            this.btnFileStream.Text = "FileStream";
            this.btnFileStream.UseVisualStyleBackColor = true;
            this.btnFileStream.Click += new System.EventHandler(this.btnFileStream_Click);
            // 
            // btnStreamWrite
            // 
            this.btnStreamWrite.Location = new System.Drawing.Point(173, 39);
            this.btnStreamWrite.Name = "btnStreamWrite";
            this.btnStreamWrite.Size = new System.Drawing.Size(103, 23);
            this.btnStreamWrite.TabIndex = 1;
            this.btnStreamWrite.Text = "StreamWrite";
            this.btnStreamWrite.UseVisualStyleBackColor = true;
            this.btnStreamWrite.Click += new System.EventHandler(this.btnStreamWrite_Click);
            // 
            // btnstreamReader
            // 
            this.btnstreamReader.Location = new System.Drawing.Point(49, 86);
            this.btnstreamReader.Name = "btnstreamReader";
            this.btnstreamReader.Size = new System.Drawing.Size(103, 23);
            this.btnstreamReader.TabIndex = 2;
            this.btnstreamReader.Text = "StreamReader";
            this.btnstreamReader.UseVisualStyleBackColor = true;
            this.btnstreamReader.Click += new System.EventHandler(this.btnstreamReader_Click);
            // 
            // btnBinaryWriter
            // 
            this.btnBinaryWriter.Location = new System.Drawing.Point(173, 86);
            this.btnBinaryWriter.Name = "btnBinaryWriter";
            this.btnBinaryWriter.Size = new System.Drawing.Size(103, 23);
            this.btnBinaryWriter.TabIndex = 3;
            this.btnBinaryWriter.Text = "BinaryWriter";
            this.btnBinaryWriter.UseVisualStyleBackColor = true;
            this.btnBinaryWriter.Click += new System.EventHandler(this.btnBinaryWriter_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(49, 133);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(103, 23);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(173, 133);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(103, 23);
            this.btnDirectory.TabIndex = 5;
            this.btnDirectory.Text = "Directory";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // btnDriverInfo
            // 
            this.btnDriverInfo.Location = new System.Drawing.Point(49, 180);
            this.btnDriverInfo.Name = "btnDriverInfo";
            this.btnDriverInfo.Size = new System.Drawing.Size(103, 23);
            this.btnDriverInfo.TabIndex = 6;
            this.btnDriverInfo.Text = "DriverInfo";
            this.btnDriverInfo.UseVisualStyleBackColor = true;
            this.btnDriverInfo.Click += new System.EventHandler(this.btnDriverInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 231);
            this.Controls.Add(this.btnDriverInfo);
            this.Controls.Add(this.btnDirectory);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnBinaryWriter);
            this.Controls.Add(this.btnstreamReader);
            this.Controls.Add(this.btnStreamWrite);
            this.Controls.Add(this.btnFileStream);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileStream;
        private System.Windows.Forms.Button btnStreamWrite;
        private System.Windows.Forms.Button btnstreamReader;
        private System.Windows.Forms.Button btnBinaryWriter;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.Button btnDriverInfo;
    }
}


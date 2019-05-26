namespace RenameTools
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFolderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.chkSubDir = new System.Windows.Forms.CheckBox();
            this.rdDel = new System.Windows.Forms.RadioButton();
            this.rdCopy = new System.Windows.Forms.RadioButton();
            this.rdLocal = new System.Windows.Forms.RadioButton();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.lbSavePath = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.txtRegexStr = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHelp2 = new System.Windows.Forms.Label();
            this.lbHelp = new System.Windows.Forms.Label();
            this.lbReplace = new System.Windows.Forms.Label();
            this.lbRegexStr = new System.Windows.Forms.Label();
            this.lbFilter = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lbFile = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picBoxHelp = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picBoxHelp);
            this.groupBox1.Controls.Add(this.chkView);
            this.groupBox1.Controls.Add(this.chkSubDir);
            this.groupBox1.Controls.Add(this.rdDel);
            this.groupBox1.Controls.Add(this.rdCopy);
            this.groupBox1.Controls.Add(this.rdLocal);
            this.groupBox1.Controls.Add(this.btnSavePath);
            this.groupBox1.Controls.Add(this.txtSavePath);
            this.groupBox1.Controls.Add(this.lbSavePath);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnRename);
            this.groupBox1.Controls.Add(this.txtReplace);
            this.groupBox1.Controls.Add(this.txtRegexStr);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbHelp2);
            this.groupBox1.Controls.Add(this.lbHelp);
            this.groupBox1.Controls.Add(this.lbReplace);
            this.groupBox1.Controls.Add(this.lbRegexStr);
            this.groupBox1.Controls.Add(this.lbFilter);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.lbFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 182);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "替换选项";
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(428, 81);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(156, 16);
            this.chkView.TabIndex = 13;
            this.chkView.Text = "预览输出(即不真正操作)";
            this.chkView.UseVisualStyleBackColor = true;
            // 
            // chkSubDir
            // 
            this.chkSubDir.AutoSize = true;
            this.chkSubDir.Location = new System.Drawing.Point(148, 81);
            this.chkSubDir.Name = "chkSubDir";
            this.chkSubDir.Size = new System.Drawing.Size(84, 16);
            this.chkSubDir.TabIndex = 13;
            this.chkSubDir.Text = "搜索子目录";
            this.chkSubDir.UseVisualStyleBackColor = true;
            // 
            // rdDel
            // 
            this.rdDel.AutoSize = true;
            this.rdDel.Location = new System.Drawing.Point(350, 81);
            this.rdDel.Name = "rdDel";
            this.rdDel.Size = new System.Drawing.Size(47, 16);
            this.rdDel.TabIndex = 22;
            this.rdDel.Text = "删除";
            this.rdDel.UseVisualStyleBackColor = true;
            this.rdDel.CheckedChanged += new System.EventHandler(this.rdDel_CheckedChanged);
            // 
            // rdCopy
            // 
            this.rdCopy.AutoSize = true;
            this.rdCopy.Location = new System.Drawing.Point(291, 81);
            this.rdCopy.Name = "rdCopy";
            this.rdCopy.Size = new System.Drawing.Size(47, 16);
            this.rdCopy.TabIndex = 22;
            this.rdCopy.Text = "拷贝";
            this.rdCopy.UseVisualStyleBackColor = true;
            this.rdCopy.CheckedChanged += new System.EventHandler(this.rdCopy_CheckedChanged);
            // 
            // rdLocal
            // 
            this.rdLocal.AutoSize = true;
            this.rdLocal.Checked = true;
            this.rdLocal.Location = new System.Drawing.Point(238, 81);
            this.rdLocal.Name = "rdLocal";
            this.rdLocal.Size = new System.Drawing.Size(47, 16);
            this.rdLocal.TabIndex = 21;
            this.rdLocal.TabStop = true;
            this.rdLocal.Text = "就地";
            this.rdLocal.UseVisualStyleBackColor = true;
            this.rdLocal.CheckedChanged += new System.EventHandler(this.rdLocal_CheckedChanged);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Enabled = false;
            this.btnSavePath.Location = new System.Drawing.Point(425, 47);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnSavePath.TabIndex = 20;
            this.btnSavePath.Text = "浏览..";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Enabled = false;
            this.txtSavePath.Location = new System.Drawing.Point(79, 47);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(340, 21);
            this.txtSavePath.TabIndex = 19;
            // 
            // lbSavePath
            // 
            this.lbSavePath.AutoSize = true;
            this.lbSavePath.Location = new System.Drawing.Point(11, 52);
            this.lbSavePath.Name = "lbSavePath";
            this.lbSavePath.Size = new System.Drawing.Size(65, 12);
            this.lbSavePath.TabIndex = 18;
            this.lbSavePath.Text = "保存目录：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(506, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 31);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "清 屏";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(506, 20);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 48);
            this.btnRename.TabIndex = 17;
            this.btnRename.Text = "重命名";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(94, 130);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(406, 21);
            this.txtReplace.TabIndex = 16;
            // 
            // txtRegexStr
            // 
            this.txtRegexStr.Location = new System.Drawing.Point(94, 105);
            this.txtRegexStr.Name = "txtRegexStr";
            this.txtRegexStr.Size = new System.Drawing.Size(406, 21);
            this.txtRegexStr.TabIndex = 16;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(79, 74);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(52, 21);
            this.txtFilter.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "3、序号：<n或N>，对齐<0|2|n>";
            this.toolTip1.SetToolTip(this.label1, "表达式如filename_<n>.txt 替换为filename_2.txt，<N>为与子目录一起排序");
            // 
            // lbHelp2
            // 
            this.lbHelp2.AutoSize = true;
            this.lbHelp2.Location = new System.Drawing.Point(208, 157);
            this.lbHelp2.Name = "lbHelp2";
            this.lbHelp2.Size = new System.Drawing.Size(137, 12);
            this.lbHelp2.TabIndex = 15;
            this.lbHelp2.Text = "2、大小写：<U或L|字串>";
            this.toolTip1.SetToolTip(this.lbHelp2, "表达式如filename_<U|a>_<L|BC>.txt 替换为filename_A_bc.txt");
            // 
            // lbHelp
            // 
            this.lbHelp.AutoSize = true;
            this.lbHelp.Location = new System.Drawing.Point(11, 157);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new System.Drawing.Size(191, 12);
            this.lbHelp.TabIndex = 15;
            this.lbHelp.Text = "1、字串对齐：<对齐符|总长|字串>";
            this.toolTip1.SetToolTip(this.lbHelp, "表达式如filename_<0|2|8>.txt 替换为filename_08.txt");
            // 
            // lbReplace
            // 
            this.lbReplace.AutoSize = true;
            this.lbReplace.Location = new System.Drawing.Point(11, 132);
            this.lbReplace.Name = "lbReplace";
            this.lbReplace.Size = new System.Drawing.Size(77, 12);
            this.lbReplace.TabIndex = 15;
            this.lbReplace.Text = "替换为字串：";
            // 
            // lbRegexStr
            // 
            this.lbRegexStr.AutoSize = true;
            this.lbRegexStr.Location = new System.Drawing.Point(11, 110);
            this.lbRegexStr.Name = "lbRegexStr";
            this.lbRegexStr.Size = new System.Drawing.Size(77, 12);
            this.lbRegexStr.TabIndex = 15;
            this.lbRegexStr.Text = "正规表达式：";
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(11, 83);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(65, 12);
            this.lbFilter.TabIndex = 15;
            this.lbFilter.Text = "过滤条件：";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(425, 20);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 14;
            this.btnOpen.Text = "浏览..";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(79, 20);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(340, 21);
            this.txtFolder.TabIndex = 13;
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Location = new System.Drawing.Point(11, 25);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(65, 12);
            this.lbFile.TabIndex = 12;
            this.lbFile.Text = "文件目录：";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(12, 203);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(596, 158);
            this.txtStatus.TabIndex = 13;
            // 
            // picBoxHelp
            // 
            this.picBoxHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxHelp.Location = new System.Drawing.Point(555, 150);
            this.picBoxHelp.Name = "picBoxHelp";
            this.picBoxHelp.Size = new System.Drawing.Size(26, 26);
            this.picBoxHelp.TabIndex = 34;
            this.picBoxHelp.TabStop = false;
            this.toolTip1.SetToolTip(this.picBoxHelp, "查看帮助文档");
            this.picBoxHelp.Click += new System.EventHandler(this.picBoxHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 374);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量重命名工具(大圣制作)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog openFolderDlg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSubDir;
        private System.Windows.Forms.RadioButton rdCopy;
        private System.Windows.Forms.RadioButton rdLocal;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label lbSavePath;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtRegexStr;
        private System.Windows.Forms.Label lbReplace;
        private System.Windows.Forms.Label lbRegexStr;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label lbHelp;
        private System.Windows.Forms.Label lbHelp2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdDel;
        private System.Windows.Forms.PictureBox picBoxHelp;
    }
}


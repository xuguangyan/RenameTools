namespace RenameTools
{
    partial class HelpForm
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
            this.components = new System.ComponentModel.Container();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.rtxtBoxHelp = new System.Windows.Forms.RichTextBox();
            this.ctxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemLower = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpper = new System.Windows.Forms.ToolStripMenuItem();
            this.stripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.lbCaption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            this.ctxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxClose
            // 
            this.picBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxClose.Location = new System.Drawing.Point(737, 6);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Size = new System.Drawing.Size(18, 18);
            this.picBoxClose.TabIndex = 33;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Click += new System.EventHandler(this.picBoxClose_Click);
            // 
            // rtxtBoxHelp
            // 
            this.rtxtBoxHelp.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtBoxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtBoxHelp.ContextMenuStrip = this.ctxMenuStrip;
            this.rtxtBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtBoxHelp.Location = new System.Drawing.Point(5, 30);
            this.rtxtBoxHelp.Name = "rtxtBoxHelp";
            this.rtxtBoxHelp.ReadOnly = true;
            this.rtxtBoxHelp.ShowSelectionMargin = true;
            this.rtxtBoxHelp.Size = new System.Drawing.Size(753, 443);
            this.rtxtBoxHelp.TabIndex = 32;
            this.rtxtBoxHelp.Text = "";
            // 
            // ctxMenuStrip
            // 
            this.ctxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nenuItemSaveAs,
            this.menuItemSelAll,
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuItemDelete,
            this.toolStripSeparator1,
            this.menuItemLower,
            this.menuItemUpper,
            this.stripTextBox});
            this.ctxMenuStrip.Name = "ctxMenuStrip";
            this.ctxMenuStrip.Size = new System.Drawing.Size(161, 204);
            this.ctxMenuStrip.Opened += new System.EventHandler(this.ctxMenuStrip_Opened);
            // 
            // nenuItemSaveAs
            // 
            this.nenuItemSaveAs.Name = "nenuItemSaveAs";
            this.nenuItemSaveAs.Size = new System.Drawing.Size(160, 22);
            this.nenuItemSaveAs.Text = "另存为(&S)";
            this.nenuItemSaveAs.Click += new System.EventHandler(this.nenuItemSaveAs_Click);
            // 
            // menuItemSelAll
            // 
            this.menuItemSelAll.Name = "menuItemSelAll";
            this.menuItemSelAll.Size = new System.Drawing.Size(160, 22);
            this.menuItemSelAll.Text = "全选(&A)";
            this.menuItemSelAll.Click += new System.EventHandler(this.menuItemSelAll_Click);
            // 
            // menuItemCut
            // 
            this.menuItemCut.Name = "menuItemCut";
            this.menuItemCut.Size = new System.Drawing.Size(160, 22);
            this.menuItemCut.Text = "剪切(&T)";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.Size = new System.Drawing.Size(160, 22);
            this.menuItemCopy.Text = "复制(&C)";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.Size = new System.Drawing.Size(160, 22);
            this.menuItemPaste.Text = "粘贴(&P)";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(160, 22);
            this.menuItemDelete.Text = "删除(&D)";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // menuItemLower
            // 
            this.menuItemLower.Name = "menuItemLower";
            this.menuItemLower.Size = new System.Drawing.Size(160, 22);
            this.menuItemLower.Text = "转为小写(&L)";
            this.menuItemLower.Click += new System.EventHandler(this.menuItemLower_Click);
            // 
            // menuItemUpper
            // 
            this.menuItemUpper.Name = "menuItemUpper";
            this.menuItemUpper.Size = new System.Drawing.Size(160, 22);
            this.menuItemUpper.Text = "转为大写(&U)";
            this.menuItemUpper.Click += new System.EventHandler(this.menuItemUpper_Click);
            // 
            // stripTextBox
            // 
            this.stripTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.stripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stripTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stripTextBox.Name = "stripTextBox";
            this.stripTextBox.ReadOnly = true;
            this.stripTextBox.Size = new System.Drawing.Size(100, 16);
            this.stripTextBox.Text = "[大圣制作@2014]";
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCaption.Location = new System.Drawing.Point(8, 8);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(71, 12);
            this.lbCaption.TabIndex = 34;
            this.lbCaption.Text = ">>操作说明";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(763, 478);
            this.ControlBox = false;
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.picBoxClose);
            this.Controls.Add(this.rtxtBoxHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HelpForm";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Resize += new System.EventHandler(this.HelpForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.ctxMenuStrip.ResumeLayout(false);
            this.ctxMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxClose;
        private System.Windows.Forms.RichTextBox rtxtBoxHelp;
        private System.Windows.Forms.ContextMenuStrip ctxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCut;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemLower;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpper;
        private System.Windows.Forms.ToolStripTextBox stripTextBox;
        private System.Windows.Forms.ToolStripMenuItem nenuItemSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.Label lbCaption;


    }
}
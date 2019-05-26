using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RenameTools
{
    public partial class HelpForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private const int WM_SYSCOMMAND = 0x0112;//点击窗口左上角那个图标时的系统信息
        private const int WM_MOVING = 0x0216;//鼠标移动消息
        private const int HTCAPTION = 0x0002;//表示鼠标在窗口标题栏时的系统信息
        private const int WM_NCHITTEST = 0x0084;//鼠标在窗体客户区（除了标题栏和边框以外的部分）时发送的消息
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 0x10;
        private const int HTBOTTOMRIGHT = 17;

        private ctxMenu4RichText ctxMenu;

        public HelpForm()
        {
            InitializeComponent();

            ResourceManager rs = new ResourceManager("RenameTools.Resource", typeof(Resource).Assembly);
            rtxtBoxHelp.Rtf = rs.GetString("txt_help");

            picBoxClose.Image = (Image)rs.GetObject("img_close");

            ctxMenu = new ctxMenu4RichText(this.ctxMenuStrip);
        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);//调用基类的窗口过程进行处理
            switch (m.Msg)
            {
                //case WM_MOVING:
                case WM_NCHITTEST: //如果                 
                    Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    ;
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    else if (vPoint.Y < 30)
                        m.Result = (IntPtr)HTCAPTION;//把它改为HTCAPTION
                    break;
            }
        }

        //窗口尺寸调整
        private void HelpForm_Resize(object sender, EventArgs e)
        {
            picBoxClose.Left = ClientSize.Width - picBoxClose.Width - 3;
        }

        //呈现菜单
        private void ctxMenuStrip_Opened(object sender, EventArgs e)
        {
            //获取文档框并设置焦点
            RichTextBox txtBox = ((RichTextBox)ctxMenuStrip.SourceControl);
            txtBox.Focus();

            //获取文档框中的文本和选中文本
            string selectText = txtBox.SelectedText;
            string currentText = txtBox.Text;

            if (currentText != "")
            {
                menuItemSelAll.Enabled = true;
            }
            else
            {
                menuItemSelAll.Enabled = false;
            }
            menuItemCut.Visible = false;
            menuItemLower.Visible = false;
            menuItemUpper.Visible = false;
            menuItemDelete.Visible = false;
            menuItemPaste.Visible = false;

            //没有选择文本时，禁用复制、大小写转换菜单
            if (selectText != "")
            {
                menuItemCopy.Enabled = true;
            }
            else
            {
                menuItemCopy.Enabled = false;
            }
        }

        //全选
        private void menuItemSelAll_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemSelAll();
        }

        //剪切
        private void menuItemCut_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemCut();
        }

        //复制
        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemCopy();
        }

        //粘贴
        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemPaste();
        }

        //删除
        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemDelete();
        }

        //转换小写
        private void menuItemLower_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemLower();
        }

        //转换大写
        private void menuItemUpper_Click(object sender, EventArgs e)
        {
            ctxMenu.menuItemUpper();
        }

        //另存为
        private void nenuItemSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDlg.Filter = "rtf文档(*.rtf)|*.rtf|所有类型(*.*)|*.*";
            saveFileDlg.FileName = "help.rtf";
            DialogResult dlgResult = saveFileDlg.ShowDialog();
            if (DialogResult.OK == dlgResult)
            {
                string descFile = saveFileDlg.FileName;
                using (FileStream file = File.Open(descFile, FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.Default.GetBytes(rtxtBoxHelp.Rtf);
                    file.Write(buffer, 0, buffer.Length);
                }
                MessageBox.Show("保存成功！");
            }
        }
    }
}

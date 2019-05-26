using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RenameTools
{
    public class ctxMenu4RichText
    {
        private ContextMenuStrip ctxMenu;
        public ctxMenu4RichText(ContextMenuStrip ctxMenu)
        {
            this.ctxMenu = ctxMenu;
        }

        //全选
        public void menuItemSelAll()
        {
            RichTextBox txtBox = ((RichTextBox)ctxMenu.SourceControl);
            string text = txtBox.Text;
            txtBox.SelectionStart = 0;
            txtBox.SelectionLength = text.Length;
        }

        //剪切
        public void menuItemCut()
        {
            RichTextBox txtBox = (RichTextBox)ctxMenu.SourceControl;
            Clipboard.SetText(txtBox.SelectedText);

            int index = txtBox.SelectionStart;  //记录操作前的光标位置
            string text = txtBox.Text;
            text = text.Remove(txtBox.SelectionStart, txtBox.SelectionLength);
            txtBox.Text = text;
            //重设光标位置
            txtBox.SelectionStart = index;
        }

        //复制
        public void menuItemCopy()
        {
            RichTextBox txtBox = ((RichTextBox)ctxMenu.SourceControl);
            string selectText = txtBox.SelectedText;
            if (selectText != "")
            {
                Clipboard.SetText(selectText);
            }
        }

        //粘贴
        public void menuItemPaste()
        {
            if (Clipboard.ContainsText())
            {
                RichTextBox txtBox = (RichTextBox)ctxMenu.SourceControl;
                int index = txtBox.SelectionStart;  //记录操作前的光标位置
                string text = txtBox.Text;
                //删除选中的文本
                text = text.Remove(txtBox.SelectionStart, txtBox.SelectionLength);
                //替换文字
                string repText = Clipboard.GetText();
                //在当前光标输入点插入剪切板内容
                text = text.Insert(txtBox.SelectionStart, repText);
                txtBox.Text = text;
                //重设光标位置
                txtBox.SelectionStart = index + repText.Length;
                txtBox.SelectionColor = Color.Black;
                txtBox.SelectionFont = new Font("宋体",12,FontStyle.Regular);
            }
        }

        //删除
        public void menuItemDelete()
        {
            RichTextBox txtBox = (RichTextBox)ctxMenu.SourceControl;

            int index = txtBox.SelectionStart;  //记录操作前的光标位置
            string text = txtBox.Text;
            text = text.Remove(txtBox.SelectionStart, txtBox.SelectionLength);
            txtBox.Text = text;
            //重设光标位置
            txtBox.SelectionStart = index;
        }

        //转换小写
        public void menuItemLower()
        {
            RichTextBox txtBox = (RichTextBox)ctxMenu.SourceControl;
            int index = txtBox.SelectionStart;  //记录操作前的光标位置
            string text = txtBox.Text;
            //删除选中的文本
            text = text.Remove(txtBox.SelectionStart, txtBox.SelectionLength);
            //替换文字
            string repText = txtBox.SelectedText.ToLower();
            //在当前光标输入点插入剪切板内容
            text = text.Insert(txtBox.SelectionStart, repText);
            txtBox.Text = text;
            //重设光标位置
            txtBox.SelectionStart = index;
            txtBox.SelectionLength = repText.Length;
        }

        //转换大写
        public void menuItemUpper()
        {
            RichTextBox txtBox = (RichTextBox)ctxMenu.SourceControl;
            int index = txtBox.SelectionStart;  //记录操作前的光标位置
            string text = txtBox.Text;
            //删除选中的文本
            text = text.Remove(txtBox.SelectionStart, txtBox.SelectionLength);
            //替换文字
            string repText = txtBox.SelectedText.ToUpper();
            //在当前光标输入点插入剪切板内容
            text = text.Insert(txtBox.SelectionStart, repText);
            txtBox.Text = text;
            //重设光标位置
            txtBox.SelectionStart = index;
            txtBox.SelectionLength = repText.Length;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Resources;

namespace RenameTools
{
    public partial class MainForm : Form
    {
        //ini配置结点名
        private string iniSession = "DS_RenameTools";
        private int count = 0, index = 0;

        public MainForm()
        {
            InitializeComponent();

            ResourceManager rs = new ResourceManager("RenameTools.Resource", typeof(Resource).Assembly);
            picBoxHelp.Image = (Image)rs.GetObject("img_help");

            //读取配置文件
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string strFileName = path + "Config.ini";
            IniFiles ini = new IniFiles(strFileName);

            txtFolder.Text = ini.ReadString(iniSession, "folder", path);
            txtSavePath.Text = ini.ReadString(iniSession, "savePath", path.TrimEnd('\\')+"\\output");
            txtFilter.Text = ini.ReadString(iniSession, "filter", "*.png");
            txtRegexStr.Text = ini.ReadString(iniSession, "regexStr", "");
            txtReplace.Text = ini.ReadString(iniSession, "replace", "");

            chkSubDir.Checked = ini.ReadBool(iniSession, "subDir", false);
            chkView.Checked = ini.ReadBool(iniSession, "view", false);
            rdLocal.Checked = ini.ReadBool(iniSession, "local", true);
            rdCopy.Checked = ini.ReadBool(iniSession, "copy", false);
            rdDel.Checked = ini.ReadBool(iniSession, "delete", false);
        }

        //选择文件目录
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = txtFolder.Text.Trim();
            if (path == "")
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }

            openFolderDlg.SelectedPath = path;
            DialogResult dlgResult = openFolderDlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtFolder.Text = openFolderDlg.SelectedPath;
            }
        }

        //选择保存目录
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            string path = txtFolder.Text.Trim();
            if (path == "")
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }

            openFolderDlg.SelectedPath = path;
            DialogResult dlgResult = openFolderDlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtSavePath.Text = openFolderDlg.SelectedPath;
            }
        }

        //重命名按钮
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text == "")
            { 
                MessageBox.Show("请选择文件目录！");
                return;
            }

            string path = txtFolder.Text;
            string newPath = path;

            if (rdCopy.Checked)
            {
                if (txtSavePath.Text == "")
                {
                    MessageBox.Show("请选择保存目录！");
                    return;
                }
                newPath = txtSavePath.Text;
            }

            if (txtFilter.Text == "")
            {
                MessageBox.Show("请输入过滤条件(如：*.*表示所有类型文件)");
                return;
            }

            if (txtRegexStr.Text == "")
            {
                MessageBox.Show("请输入替换正式表达式！");
                return;
            }

            if (txtReplace.Text == "" && !rdDel.Checked)
            {
                MessageBox.Show("请输入要替换成的字串！");
                return;
            }

            //物理删除文件
            if (rdDel.Checked && !chkView.Checked)
            {
                DialogResult dlgResult = MessageBox.Show("你选择的是批量删除文件，操作不可撤消，确定要执行吗？", "警告", MessageBoxButtons.YesNo);
                if (dlgResult == DialogResult.No)
                {
                    txtStatus.AppendText("已取消操作！\r\n");
                    return;
                }
            }
            else if (rdLocal.Checked && !chkView.Checked)
            {
                DialogResult dlgResult = MessageBox.Show("你选择的是就地重命名文件，操作不可撤消，确定要执行吗？", "警告", MessageBoxButtons.YesNo);
                if (dlgResult == DialogResult.No)
                {
                    txtStatus.AppendText("已取消操作！\r\n");
                    return;
                }
            }

            count = 0;
            index = 0;
            renameFile(path, newPath);

            txtStatus.AppendText("操作完成！\r\n");
        }

        //重命名文件(递归)
        private void renameFile(string path, string newPath)
        {
            string[] files = Directory.GetFiles(path, txtFilter.Text);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                count++;
                index++;
                string filename = file.Substring(file.LastIndexOf("\\") + 1);

                string regexStr = txtRegexStr.Text;
                string replaceStr = txtReplace.Text;

                Regex regEx = new Regex(regexStr);
                if (rdDel.Checked)
                {
                    if (regEx.IsMatch(regexStr))
                    {
                        if (chkView.Checked)
                        {
                            //do nothing
                        }
                        else
                        {
                            File.Delete(file);
                        }
                        txtStatus.AppendText("删除:" + cutLongPath(file) + "\r\n");
                    }
                }
                else
                {

                    filename = regEx.Replace(filename, replaceStr);

                    //数字序号 处理：
                    //表达式如filename_<n>.txt 替换为filename_2.txt
                    Regex regEx1 = new Regex(@"<([n|N])>");
                    filename = regEx1.Replace(filename, "<0|0|$1>");
                    regEx1 = new Regex(@"<([^|])\|(\d+)\|([n|N])>");
                    MatchEvaluator evaluator1 = new MatchEvaluator(numOrder);
                    filename = regEx1.Replace(filename, evaluator1);

                    //字串对齐 处理：
                    //表达式如filename_<2|8>.txt 替换为filename_08.txt
                    Regex regEx2 = new Regex(@"<([^|])\|(\d+)\|([^>]+)>");
                    MatchEvaluator evaluator2 = new MatchEvaluator(strPadLeft);
                    filename = regEx2.Replace(filename, evaluator2);

                    //字串大小写 处理：
                    //表达式如filename_<U|a>_<L|BC>.txt 替换为filename_A_bc.txt
                    Regex regEx3 = new Regex(@"<([U|L])\|([^>]+)>");
                    MatchEvaluator evaluator3 = new MatchEvaluator(strUpperLower);
                    filename = regEx3.Replace(filename, evaluator3);

                    string newFile = newPath.TrimEnd('\\') + "\\" + filename;


                    if (chkView.Checked)
                    {
                        //do nothing
                    }
                    else if (rdLocal.Checked)
                    {
                        if (!Directory.Exists(newPath))
                        {
                            Directory.CreateDirectory(newPath);
                        }
                        File.Move(file, newFile);
                    }
                    else if (rdCopy.Checked)
                    {
                        if (!Directory.Exists(newPath))
                        {
                            Directory.CreateDirectory(newPath);
                        }
                        File.Copy(file, newFile);
                    }

                    txtStatus.AppendText("来源:" + cutLongPath(file) + "\r\n");
                    txtStatus.AppendText((rdCopy.Checked ? "拷贝:" : "替换:") + cutLongPath(newFile) + "\r\n");
                }
            }

            if (!chkSubDir.Checked)
                return;

            foreach (string dir in dirs)
            {
                index = 0;
                renameFile(dir, newPath.TrimEnd('\\') + dir.Substring(dir.LastIndexOf("\\")));
            }
        }

        //数字序号
        private string numOrder(Match match)
        {
            string chr = match.Groups[1].Value;//补齐字符
            string len = match.Groups[2].Value;//字串总长
            string str = match.Groups[3].Value;//序号标识符（n|N）
            if (str.Equals("n"))
            {
                str = index.ToString();
            }
            else if (str.Equals("N"))
            {
                str = count.ToString();
            }

            return "<" + chr + "|" + len + "|" + str + ">";
        }

        //字串对齐
        private string strPadLeft(Match match)
        {
            string chr = match.Groups[1].Value;//补齐字符
            string len = match.Groups[2].Value;//字串总长
            string str = match.Groups[3].Value;//源字符串
            try
            {
                str = str.PadLeft(int.Parse(len),char.Parse(chr));
            }
            catch { }
            return str;
        }

        //字串大小写
        private string strUpperLower(Match match)
        {
            string chr = match.Groups[1].Value;//大小写标识
            string str = match.Groups[2].Value;//源字符串
            if (chr.Equals("U")) {
                str = str.ToUpper();
            }
            else if (chr.Equals("L")) {
                str = str.ToLower();
            }
            return str;
        }

        //就地重命名
        private void rdLocal_CheckedChanged(object sender, EventArgs e)
        {
            txtSavePath.Enabled = false;
            btnSavePath.Enabled = false;
        }

        //拷贝重命名
        private void rdCopy_CheckedChanged(object sender, EventArgs e)
        {
            txtSavePath.Enabled = true;
            btnSavePath.Enabled = true;
        }

        //删除文件
        private void rdDel_CheckedChanged(object sender, EventArgs e)
        {
            txtSavePath.Enabled = false;
            btnSavePath.Enabled = false;
        }

        //截取长路径(省略中间部分)
        private string cutLongPath(string path)
        {
            if (path.Length <= 50)
                return path;

            return path.Substring(0, 25) + "..." + path.Substring(path.Length - 25);
        }

        //清屏
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
        }

        ////窗体关闭时
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //写入配置文件
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string strFileName = path + "Config.ini";
            IniFiles ini = new IniFiles(strFileName);
            ini.WriteString(iniSession, "folder", txtFolder.Text);
            ini.WriteString(iniSession, "savePath", txtSavePath.Text);
            ini.WriteString(iniSession, "filter", txtFilter.Text);
            ini.WriteString(iniSession, "regexStr", txtRegexStr.Text);
            ini.WriteString(iniSession, "replace", txtReplace.Text);

            ini.WriteBool(iniSession, "subDir", chkSubDir.Checked);
            ini.WriteBool(iniSession, "view", chkView.Checked);
            ini.WriteBool(iniSession, "local", rdLocal.Checked);
            ini.WriteBool(iniSession, "copy", rdCopy.Checked);
            ini.WriteBool(iniSession, "delete", rdDel.Checked);
        }

        //帮助文档
        private void picBoxHelp_Click(object sender, EventArgs e)
        {
            (new HelpForm()).Show();
        }
    }
}

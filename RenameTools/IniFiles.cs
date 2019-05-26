﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace RenameTools
{
    /// <summary>
    /// IniFiles的类
    /// </summary>
    public class IniFiles
    {
        //INI文件名
        public string FileName; 

        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="AFileName">传递INI文件名</param>
        public IniFiles(string AFileName)
        {
            // 判断文件是否存在
            FileInfo fileInfo = new FileInfo(AFileName);

            if ((!fileInfo.Exists))
            { 
                //文件不存在，建立文件
                System.IO.StreamWriter sw = new System.IO.StreamWriter(AFileName, false, System.Text.Encoding.Default);
                try
                {
                    sw.Write("#表格配置档案");
                    sw.Close();
                }

                catch
                {
                    throw (new ApplicationException("Ini文件不存在"));
                }
            }
            //必须是完全路径，不能是相对路径
            FileName = fileInfo.FullName;
        }

        /// <summary>
        /// 写字符串
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <param name="Value"></param>
        public void WriteString(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, Value, FileName))
            {

                throw (new ApplicationException("写Ini文件出错"));
            }
        }

        /// <summary>
        /// 读字符串
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public string ReadString(string Section, string Ident, string Default)
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName);

            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim();
        }

        /// <summary>
        /// 读整数
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public int ReadInteger(string Section, string Ident, int Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 写整数
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <param name="Value"></param>
        public void WriteInteger(string Section, string Ident, int Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }

        /// <summary>
        /// 读布尔值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public bool ReadBool(string Section, string Ident, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 写布尔值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <param name="Value"></param>
        public void WriteBool(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }

        /// <summary>
        /// 将指定Section中的所有Ident添加到列表
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Idents"></param>
        public void ReadSection(string Section, StringCollection Idents)
        {
            Byte[] Buffer = new Byte[16384];
            //Idents.Clear();

            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
             FileName);
            //对Section进行解析
            GetStringsFromBuffer(Buffer, bufLen, Idents);
        }

        private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }

        /// <summary>
        /// 读取所有Sections的名称
        /// </summary>
        /// <param name="SectionList"></param>
        public void ReadSections(StringCollection SectionList)
        {
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
            byte[] Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer,
             Buffer.GetUpperBound(0), FileName);
            GetStringsFromBuffer(Buffer, bufLen, SectionList);
        }

        /// <summary>
        /// 读取指定的Section的所有Value到列表中
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Values"></param>
        public void ReadSectionValues(string Section, NameValueCollection Values)
        {
            StringCollection KeyList = new StringCollection();
            ReadSection(Section, KeyList);
            Values.Clear();
            foreach (string key in KeyList)
            {
                Values.Add(key, ReadString(Section, key, ""));

            }
        }

        /// <summary>
        /// 清除某个Section
        /// </summary>
        /// <param name="Section"></param>
        public void EraseSection(string Section)
        {
            //
            if (!WritePrivateProfileString(Section, null, null, FileName))
            {

                throw (new ApplicationException("无法清除Ini文件中的Section"));
            }
        }

        /// <summary>
        /// 删除某个Section下的键
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, FileName);
        }

        /// <summary>
        ///Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
        ///在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile
        ///执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
        /// </summary>
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }

        /// <summary>
        /// 检查某个Section下的某个键值是否存在
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Ident"></param>
        /// <returns></returns>
        public bool ValueExists(string Section, string Ident)
        {
            //
            StringCollection Idents = new StringCollection();
            ReadSection(Section, Idents);
            return Idents.IndexOf(Ident) > -1;
        }

        /// <summary>
        /// 确保资源的释放
        /// </summary>
        ~IniFiles()
        {
            UpdateFile();
        }
    }
}

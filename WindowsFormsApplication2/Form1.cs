﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections;
using System.IO;
using System.Management.Automation.Runspaces;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        int counts = 0, MostFrequentlyID_System = 0, MostFrequentlyID_Application = 0, counts_system = 0;
        ArrayList bugCheckDay, stopCode;
        ArrayList code_1000 = new ArrayList();
        Form3 form3;

        string taskApp;
        string taskSystem;

        int nowItem;

        public Form1()
        {
            InitializeComponent();

            Form2 form2 = new Form2();
            form2.Show();

            form3 = new Form3();

            ArrayList info = new ArrayList();
            ArrayList application_ids = new ArrayList();
            ArrayList system_ids = new ArrayList();
            bugCheckDay = new ArrayList();
            stopCode = new ArrayList();

            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //var writer = new StreamWriter(path + "\\tbugChecks.csv", false, UTF8Encoding.UTF8);

            string id = "0";
            string noMessageId = "0";
            string tmpTime = "0";

            try
            {

                using (var tmp = new RunspaceInvoke())
                {
                    Label label = testLabel;

                    setTask();                                   

                    form2.Update();

                    var systemLog = tmp.Invoke(taskSystem, new object[] { });

                    form2.label = "SystemLog読み込み完了！\nApplicationLog読み込み中・・・";
                    form2.Update();

                    var appLog = tmp.Invoke(taskApp, new object[] { });
                    form2.label = "SystemLog読み込み完了！\nApplicationLog読み込み完了！\n解析中…・";
                    form2.Update();

                    string time = "0";

                    foreach (var r in systemLog)
                    {
                        id = r.Properties["Id"].Value.ToString();
                        if (id == "1001")
                        {

                            time = r.Properties["TimeCreated"].Value.ToString().Remove(10);

                            if (time != tmpTime)
                            {
                                info.Add("--------(" + time + ")----------");
                                info.Add("--------ApplicationLog----------");

                                string[] row_1 = {"", "", "("  + time + ")", "--------ApplicationLog----------" };

                                ErrorListView.Items.Add(new ListViewItem(row_1));

                                foreach (var m in appLog)
                                {
                                    if (m.Properties["TimeCreated"].Value.ToString().Remove(10) == time)
                                    {
                                        //同じ時間が見つかった場合の処理
                                        if (!m.Properties["Level"].Value.ToString().Equals("4"))
                                        {

                                            var level = m.Properties["Level"].Value.ToString();
                                            var appTime = m.Properties["TimeCreated"].Value.ToString();

                                            if (!level.Equals("0") &&
                                                !m.Properties["Id"].Value.ToString().Equals("0") &&
                                                !m.Properties["Id"].Value.ToString().Equals("41"))
                                            {
                                                level = setlevel(level);
                                                noMessageId = m.Properties["Id"].Value.ToString();
                                                info.Add(m.Properties["Id"].Value.ToString() +
                                                ","
                                                + m.Properties["Message"].Value.ToString());

                                                //ID:1000番はカウントせずに検出されたことだけを記録する
                                                if (m.Properties["Id"].Value.ToString().Equals("1000"))
                                                {
                                                    var name_1000 = m.Properties["Message"].Value.ToString();
                                                    var name_fast = name_1000.IndexOf("名:") + 2;
                                                    var name_last = name_1000.IndexOf(".exe") - (name_fast - 4);
                                                    if (name_last < 0)
                                                        name_last = name_1000.IndexOf(".EXE") - (name_fast - 4);
                                                    name_1000 = name_1000.Substring(name_fast, name_last);

                                                    var dll_1000 = m.Properties["Message"].Value.ToString();
                                                    var dll_first = dll_1000.IndexOf("モジュール名:") + 7;
                                                    var dll_end = dll_1000.IndexOf("dll") + 3 - dll_first;
                                                    if(dll_end < 0)
                                                        dll_end = dll_1000.IndexOf("DLL") + 3 - dll_first;
                                                    if (dll_end < 0)
                                                        dll_end = dll_1000.IndexOf(name_1000) + name_1000.Length
                                                            - dll_first;

                                                    if (dll_end > 0)
                                                    {
                                                        dll_1000 = dll_1000.Substring(dll_first, dll_end);
                                                        string[] row_3 = { level, m.Properties["Id"].Value.ToString(),
                                                                         m.Properties["TimeCreated"].Value.ToString(),
                                                                         "クラッシュしたアプリは[" + name_1000 + 
                                                                         " ]です。障害モジュール名は[" + dll_1000 + "]です。"};
                                                        ErrorListView.Items.Add(new ListViewItem(row_3));
                                                    }
                                                    else
                                                    {
                                                        string[] row_3 = { level,
                                                                         m.Properties["Id"].Value.ToString(),
                                                                         m.Properties["TimeCreated"].Value.ToString(),
                                                                         "クラッシュしたアプリは[" + name_1000 + 
                                                                         "]です 。障害モジュール名は不明です。 "};
                                                        ErrorListView.Items.Add(new ListViewItem(row_3));
                                                    }
                                                    
                                                    

                                                    if (code_1000.Count != 0)
                                                    {
                                                        //同じ名前がなければ追加
                                                        if (dll_end > 0)
                                                        {
                                                            if (code_1000.IndexOf(name_1000 + "," + dll_1000) == -1)
                                                            {
                                                                code_1000.Add(name_1000 + "," + dll_1000) ;
                                                            }
                                                        }
                                                    }
                                                    else if(dll_end > 0)
                                                        code_1000.Add(name_1000 + "," + dll_1000 );

                                                }
                                                else //ID1000番以外の場合，検出回数を記録し，リストに表示する
                                                {
                                                    string[] row_3 = { level, m.Properties["Id"].Value.ToString(),
                                                                         m.Properties["TimeCreated"].Value.ToString(),
                                                                         m.Properties["Message"].Value.ToString() };

                                                    ErrorListView.Items.Add(new ListViewItem(row_3));
                                                    application_ids.Add(m.Properties["Id"].Value.ToString());
                                                }
                                            }

                                        }

                                    }
                                }

                                info.Add("---------SystemLog-----------");

                                string[] row_4 = { "","", "(" + time + ")", "---------SystemLog-----------" };

                                ErrorListView.Items.Add(new ListViewItem(row_4));
                            }
                        }

                        tmpTime = time;

                        if (id != "1001" && id != "41" && r.Properties["TimeCreated"].Value.ToString().Remove(10) == time)
                        {
                            var level = r.Properties["Level"].Value.ToString();
                            //ここで，イベントIDとメッセージを受け取る
                            if (!level.Equals("4") &&
                                !r.Properties["Id"].Value.ToString().Equals("6") &&
                                !r.Properties["Id"].Value.ToString().Equals("4115") &&
                                !r.Properties["Id"].Value.ToString().Equals("10005"))
                            {
                                level = setlevel(level);
                                noMessageId = r.Properties["Id"].Value.ToString();
                                info.Add(r.Properties["Id"].Value.ToString() +
                                    ","
                                    + r.Properties["Message"].Value.ToString());

                                string[] row_3 = {level , r.Properties["Id"].Value.ToString(),
                                                     r.Properties["TimeCreated"].Value.ToString(),
                                                     r.Properties["Message"].Value.ToString() };

                                ErrorListView.Items.Add(new ListViewItem(row_3));
                                system_ids.Add(r.Properties["Id"].Value.ToString());

                            }
                        }else if(id == "1001")
                        {
                            bugCheckDay.Add(r.Properties["TimeCreated"].Value.ToString());
                            var code = r.Properties["Message"].Value.ToString();
                            int codeStart = code.IndexOf("0x");
                            int codeLast = code.IndexOf("(") - codeStart;
                            if(codeStart >0 && codeLast > 0)
                                stopCode.Add(code.Substring(codeStart,codeLast));
                            else
                                Console.WriteLine("code-SubStringError");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n以下のIDの情報が存在しない可能性あり\nID：" + noMessageId);
            }

            char[] removeCharas = new char[] { '\r', '\n' };
            //string[] str = new string[info.Count];
            //writer.WriteLine("EventID,Message");
            //int count = 0;
            //foreach (var i in info)
            //{
            //    str[count] = i.ToString();
            //    ++count;
            //}

            //for (int i = 0; i < str.Length; ++i)
            //{
            //    foreach (char c in removeCharas)
            //        str[i] = str[i].Replace(c.ToString(), "");
            //    writer.WriteLine(str[i]);
            //}
            //writer.Close();

            while (application_ids.Count != 0)
            {
                var tmpID = application_ids[0].ToString();
                int idCount = 0;

                foreach (var i in application_ids)
                {
                    if (i.ToString() == tmpID)
                        ++idCount;
                }

                if (counts < idCount)
                {
                    counts = idCount;
                    MostFrequentlyID_Application = int.Parse(tmpID);
                }

                application_ids.Remove(tmpID);

            }

            while (system_ids.Count != 0)
            {
                var tmpID = system_ids[0].ToString();
                int idCount = 0;

                foreach (var i in system_ids)
                {
                    if (i.ToString() == tmpID)
                        ++idCount;
                }

                if (counts_system < idCount)
                {
                    counts_system = idCount;
                    MostFrequentlyID_System = int.Parse(tmpID);
                }

                system_ids.Remove(tmpID);

            }

            ErrorListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            form2.Close();
            callSetList();
            nowItem = 0;

        }

        private void setTask()
        {
            var sr = new StreamReader(@"sampleApplication.txt", System.Text.Encoding.GetEncoding("shift-jis"));
            taskApp = sr.ReadLine();
            sr.Close();
            sr = new StreamReader(@"sampleSystem.txt", System.Text.Encoding.GetEncoding("shift-jis"));
            taskSystem = sr.ReadLine();
            sr.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setText();
        }

        private void setText()
        {
            var text = "システムで最も多かったエラー：\nID：[" + MostFrequentlyID_System + "]\n回数：[" + counts_system + "]回\n\n" +
                       "アプリケーションで最も多かったエラー：\nID：[" + MostFrequentlyID_Application + "]\n回数：[" + counts + "]回\n\n" +
                       "以上のIDのメッセージを参照してみてください.\n[ Error　ID ]で調べると情報が見つかりやすいです．\n検索例 : [ Error 109 ]";

            if (code_1000.Count > 0)
            {

                text += "\n\nまた，以下のアプリケーションはクラッシュ情報及びモジュール名が確認できました．"+
                    "\n(アプリケーション名，障害発生モジュール名)\n";
                foreach (var c in code_1000)
                {
                    text += "・" + c.ToString() + "\n";
                }
                text += "ストップコードの検索情報と照らし合わせてみると，解決手掛かりになるかもしれません．";
            }
            MessageBox.Show(text, "最も検出されたID",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (form3.IsDisposed)
            {
                form3 = new Form3();
                callSetList();
            }
        }

        private void callSetList()
        {
            try
            {
                for (int i = 0; i < bugCheckDay.Count; ++i)
                {
                    form3.setList(bugCheckDay[i].ToString(), stopCode[i].ToString());
                    form3.setDataGrid(bugCheckDay[i].ToString(), stopCode[i].ToString());
                }
                form3.Show();
            }
            catch (Exception errorMessage)
            {
                MessageBox.Show(errorMessage.ToString());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void setTask(string app,string sys)
        {
            taskApp = app;
            taskSystem = sys;
        }

        private string setlevel( string level)
        {
            if (level.Equals("1"))
                return "重大";
            else if (level.Equals("2"))
                return "エラー";
            else
                return "警告";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("アプリがクラッシュした際に呼び出されていたシステムです．\n" +
                "ストップコードと併せて調べることで，解決の糸口になるかもしれません．\n" +
                "・頻繁にクラッシュしているアプリケーションの再インストール\n" + 
                "・頻繁にクラッシュしているdllの修復\n" +
                "以上のことを試してみると，症状が改善する場合があります．",
                "モジュールって？",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ErrorListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ErrorListView.SelectedItems.Count > 0)
            {
                var message = ErrorListView.SelectedItems[0].SubItems[3].Text;
                var form5 = new Form5();
                form5.LABEL1.Text = message;
                form5.Text = "ID:" + ErrorListView.SelectedItems[0].SubItems[1].Text;
                form5.Show();
                form5.Activate();
            }
        }

    }
}

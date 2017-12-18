using System;
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
        ArrayList code_1000 = new ArrayList();

        public Form1()
        {
            InitializeComponent();

            ArrayList info = new ArrayList();
            ArrayList application_ids = new ArrayList();
            ArrayList system_ids = new ArrayList();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var writer = new StreamWriter(path + "\\timeKP41.csv", false, UTF8Encoding.UTF8);

            string id = "0";

            try
            {

                using (var tmp = new RunspaceInvoke())
                {
                    Label label = testLabel;

                    var sr = new StreamReader(@"sampleApplication.txt", System.Text.Encoding.GetEncoding("shift-jis"));
                    var taskApp = sr.ReadLine();
                    sr.Close();

                    sr = new StreamReader(@"sampleSystem.txt", System.Text.Encoding.GetEncoding("shift-jis"));
                    var taskSytem = sr.ReadLine();
                    sr.Close();

                    var systemLog = tmp.Invoke(taskSytem, new object[] { });
                    var appLog = tmp.Invoke(taskApp, new object[] { });

                    string time = "0";

                    foreach (var r in systemLog)
                    {
                        id = r.Properties["Id"].Value.ToString();
                        if (id == "41")
                        {
                            time = r.Properties["TimeCreated"].Value.ToString().Remove(10);

                            info.Add("--------(" + time + ")----------");
                            info.Add("--------ApplicationLog----------");

                            string[] row_1 = { "日時", "--------(" + time + ")----------" };
                            string[] row_2 = { "LogName", "--------ApplicationLog----------" };

                            ErrorListView.Items.Add(new ListViewItem(row_1));
                            ErrorListView.Items.Add(new ListViewItem(row_2));

                            foreach (var m in appLog)
                            {
                                if (m.Properties["TimeCreated"].Value.ToString().Remove(10) == time)
                                {
                                    //同じ時間が見つかった場合の処理
                                    if (!m.Properties["Level"].Value.ToString().Equals("4"))
                                    {

                                        if (!m.Properties["Level"].Value.ToString().Equals("0") &&
                                            !m.Properties["Id"].Value.ToString().Equals("0"))
                                        {
                                            info.Add(m.Properties["Id"].Value.ToString() +
                                            ","
                                            + m.Properties["Message"].Value.ToString());

                                            //ID:1000番はカウントせずに検出されたことだけを記録する
                                            if (m.Properties["Id"].Value.ToString().Equals("1000"))
                                            {
                                                var name_1000 = m.Properties["Message"].Value.ToString();
                                                var name_fast = name_1000.IndexOf("名:") + 2;
                                                var name_last = name_1000.IndexOf(".exe") - (name_fast - 4);
                                                name_1000 = name_1000.Substring(name_fast, name_last);
                                                if(code_1000.Count != 0)
                                                {
                                                    //同じ名前がなければ追加
                                                    if(code_1000.IndexOf(name_1000) == -1 )
                                                    {
                                                        code_1000.Add(name_1000);
                                                    }
                                                }
                                                else
                                                    code_1000.Add(name_1000);
                                                
                                            }
                                            else //ID1000番以外の場合，検出回数を記録し，リストに表示する
                                            {
                                                string[] row_3 = { m.Properties["Id"].Value.ToString(),
                                                         m.Properties["Message"].Value.ToString() };

                                                ErrorListView.Items.Add(new ListViewItem(row_3));
                                                application_ids.Add(m.Properties["Id"].Value.ToString());
                                            }
                                        }

                                    }

                                }
                            }

                            info.Add("---------SystemLog-----------");

                            string[] row_4 = { "LogName", "---------SystemLog-----------" };

                            ErrorListView.Items.Add(new ListViewItem(row_4));


                        }

                        if (id != "41" && r.Properties["TimeCreated"].Value.ToString().Remove(10) == time)
                        {
                            //ここで，イベントIDとメッセージを受け取る
                            if (!r.Properties["Level"].Value.ToString().Equals("4") &&
                                !r.Properties["Id"].Value.ToString().Equals("6") &&
                                !r.Properties["Id"].Value.ToString().Equals("4115"))
                            {
                                info.Add(r.Properties["Id"].Value.ToString() +
                                    ","
                                    + r.Properties["Message"].Value.ToString());

                                string[] row_3 = { r.Properties["Id"].Value.ToString(),
                                                         r.Properties["Message"].Value.ToString() };

                                ErrorListView.Items.Add(new ListViewItem(row_3));
                                system_ids.Add(r.Properties["Id"].Value.ToString());

                            }
                        }


                    }
                    
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "id:" + id);
            }

            char[] removeCharas = new char[] { '\r', '\n' };
            string[] str = new string[info.Count];
            writer.WriteLine("EventID,Message");
            int count = 0;
            foreach (var i in info)
            {
                str[count] = i.ToString();
                ++count;
            }

            for (int i = 0; i < str.Length; ++i)
            {
                foreach (char c in removeCharas)
                    str[i] = str[i].Replace(c.ToString(), "");
                writer.WriteLine(str[i]);
            }
            writer.Close();

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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var text = "最も検出されたErrorID(System):" + MostFrequentlyID_System + "," + counts_system + "回検出されました.\n" +
                "最も検出されたErrorID(Application):" + MostFrequentlyID_Application + "," + counts + "回検出されました.\n\n" +
                "このIDで検索すると，解決のヒントが見つかるかもしれません．\n\n" +
                "また，以下のアプリケーションはID1000番が検出されました．\n製造元に問い合わせてみてください．\n";
            foreach (var c in code_1000)
            {
                text += "・" + c.ToString() + "\n";
            }
            MessageBox.Show(text);
        }
    }
}

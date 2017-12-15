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

        public Form1()
        {
            InitializeComponent();

            try
            {

                using (var tmp = new RunspaceInvoke())
                {
                    Label label = testLabel;

                    string getSytemLog = @"Get-EventLog System";
                    string getAppLog = @"Get-EventLog Application";

                    var systemLog = tmp.Invoke(getSytemLog, new object[] { });
                    var appLog = tmp.Invoke(getAppLog, new object[] { });

                    var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var writer = new StreamWriter(path + "\\timeKP41.csv", false, UTF8Encoding.UTF8);

                    ArrayList info = new ArrayList();
                    ArrayList application_ids = new ArrayList();
                    ArrayList system_ids = new ArrayList();

                    string time = "0";

                    foreach (var r in systemLog)
                    {
                        var id = r.Properties["EventID"].Value.ToString();
                        if (id == "41")
                        {
                            time = r.Properties["TimeGenerated"].Value.ToString().Remove(10);

                            info.Add("--------(" + time + ")----------");
                            info.Add("--------ApplicationLog----------");

                            string[] row_1 = { "日時", "--------(" + time + ")----------" };
                            string[] row_2 = { "LogName", "--------ApplicationLog----------" };

                            ErrorListView.Items.Add(new ListViewItem(row_1));
                            ErrorListView.Items.Add(new ListViewItem(row_2));

                            foreach (var m in appLog)
                            {
                                if (m.Properties["TimeGenerated"].Value.ToString().Remove(10) == time)
                                {
                                    //同じ時間が見つかった場合の処理
                                    if (!m.Properties["EntryType"].Value.ToString().Equals("Information"))
                                    {

                                        if (!m.Properties["EntryType"].Value.ToString().Equals("0"))
                                        {
                                            info.Add(m.Properties["EventID"].Value.ToString() +
                                            ","
                                            + m.Properties["Message"].Value.ToString());

                                            string[] row_3 = { m.Properties["EventID"].Value.ToString(),
                                                         m.Properties["Message"].Value.ToString() };

                                            ErrorListView.Items.Add(new ListViewItem(row_3));
                                            application_ids.Add(m.Properties["EventID"].Value.ToString());
                                        }

                                    }

                                }
                            }

                            info.Add("---------SystemLog-----------");

                            string[] row_4 = { "LogName", "---------SystemLog-----------" };

                            ErrorListView.Items.Add(new ListViewItem(row_4));


                        }

                        if (id != "41" && r.Properties["TimeGenerated"].Value.ToString().Remove(10) == time)
                        {
                            //ここで，イベントIDとメッセージを受け取る
                            if (!r.Properties["EntryType"].Value.ToString().Equals("Information"))
                            {
                                info.Add(r.Properties["EventID"].Value.ToString() +
                                    ","
                                    + r.Properties["Message"].Value.ToString());

                                string[] row_3 = { r.Properties["EventID"].Value.ToString(),
                                                         r.Properties["Message"].Value.ToString() };

                                ErrorListView.Items.Add(new ListViewItem(row_3));
                                system_ids.Add(r.Properties["EventID"].Value.ToString());

                            }
                        }


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

                    while(application_ids.Count != 0)
                    {
                        var tmpID = application_ids[0].ToString();
                        int idCount = 0;

                        foreach(var i in application_ids)
                        {
                            if(i.ToString() == tmpID )
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

                    
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            ErrorListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("最も検出されたErrorID(System):" + MostFrequentlyID_System + "," + counts_system + "回検出されました.\n" +
                "最も検出されたErrorID(Application):" + MostFrequentlyID_Application + "," + counts + "回検出されました.\n"+
                "このIDで検索すると，解決のヒントが見つかるかもしれません．");
        }
    }
}

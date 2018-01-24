using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class suisokuClass
    {
        public suisokuClass(ArrayList bugCheckDay , ArrayList stopCode ,  ListView listView)
        {
            ArrayList hoge = new ArrayList();
            ArrayList nearBug = new ArrayList();

            var listViewItems = listView.Items;
            var pos = 0;

            foreach(var bugday in bugCheckDay)
            {
                var day = bugday.ToString().Remove(10);
                for(var i = 0;i<listView.Items.Count;++i)
                {
                    if (listViewItems[i].SubItems[2].Text.IndexOf(day) != -1 &&
                        listViewItems[i].SubItems[0].Text != "")
                    {
                        //エラー情報の時間を取得
                        var time = listViewItems[i].SubItems[2].Text;
                        time = time.Substring(day.Length+1);
                        
                        //時間情報から区切りを削除
                        time = time.Replace(":", "");

                        //各時間を変数に格納
                        string sHour;
                        if (time.Length == 6)
                            sHour = time.Substring(0, 2);
                        else
                            sHour = time.Substring(0, 1);
                        var sSec = time.Substring(time.Length-2, 2);
                        var sMin = time.Substring(sHour.Length, 2);

                        var hour =int.Parse(sHour);
                        var min = int.Parse(sMin);
                        var sec = int.Parse(sSec);

                        var bugTime = bugday.ToString().Replace(day, "");
                        bugTime = bugTime.Substring(1);
                        bugTime = bugTime.Replace(":", "");
                        string sbugHour; 
                        
                        if (bugTime.Length == 6)
                            sbugHour = bugTime.Substring(0, 2);
                        else
                            sbugHour = bugTime.Substring(0, 1);
                        var bugHour = int.Parse(sbugHour);
                        var bugMin = int.Parse(bugTime.Substring(sbugHour.Length, 2));

                        //BSOD発生1分前のログを確認する
                        if (Math.Abs(min - bugMin) <= 1 && min - bugMin <= 0 )
                        {
                            bool flag = true;

                            //重複情報チェック
                            for (int n = 0; n < hoge.Count; ++n)
                            {
                                if (hoge[n].ToString().IndexOf(bugday.ToString()) != -1)
                                {
                                    flag = false;
                                    break;
                                }
                            }

                            if (flag)
                                hoge.Add("ブルースクリーン発生日:" + bugday.ToString() +
                                    "\nストップコード:" + stopCode[pos] +
                                    "\n推測原因エラーID:" + listViewItems[i].SubItems[1].Text +
                                    "\nエラー発生時間:" + listViewItems[i].SubItems[2].Text + "\n");
                        }
                        
                    }
                }
                //ストップコードの情報を一つ進める
                ++pos;

            }

            var text = "";

            for (int i = 0; i < hoge.Count; ++i)
            {
                //Console.WriteLine(hoge[i].ToString().Substring(day.Length + 1));
                text += hoge[i].ToString() + "\n";
            }
            //MessageBox.Show("Day" + day + " , hoge:" + hoge.Count + " , listView" + listView.Items.Count);
            MessageBox.Show(text);


        }
        ~suisokuClass()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setList(string time,string code)
        {

        }

        public void setDataGrid(string time, string code)
        {
            /*データグリッドにカラムを追加する*/
            dataGridView1.Rows.Add();
            var idx = dataGridView1.Rows.Count-1;
            dataGridView1.Rows[idx].Cells[0].Value = time;
            dataGridView1.Rows[idx].Cells[1].Value = code;
        }

        private void BSOD_STOP_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int idx = 0;
            //if (BSOD_STOP_LIST.SelectedItems.Count > 0)
            //{
            //    idx = BSOD_STOP_LIST.SelectedItems[0].Index;
                
            //    MessageBox.Show(
            //        (idx + 1).ToString() + "番目が選択されました。",
            //        "選択されたインデックス",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.None
            //    );
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void onMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            var column = dataGridView1.SelectedCells[0].ColumnIndex;
            var row = dataGridView1.SelectedCells[0].RowIndex;

            var data = dataGridView1[column, row].Value.ToString();
            if (column == 1)
            {
                var result = MessageBox.Show(
                    "ストップコード:" + data + "\nで,グーグル検索を行いますか？",
                    "検索しますか？",
                    MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {
                    Process.Start("https://www.google.co.jp/search?q=" + HttpUtility.UrlEncode(data));
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showMessage();
        }

        public void showMessage()
        {
            MessageBox.Show("ブルースクリーン発生時にWindowsが認識したエラーの名前です．(16進数表記)\n" +
                "検索して意味を調べることで，解決の手掛かりが見つかる場合があります．\n" +
                "また，リストからストップコード発生時間の前後１時間を目安に調べてみると原因の特定が楽になる場合があります．",
                "ストップコードって？",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

    }
}

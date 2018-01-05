using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setList(string time,string code)
        {
            string[] row = { time, code};
            BSOD_STOP_LIST.Items.Add(new ListViewItem(row));
        }

        private void BSOD_STOP_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = 0;
            if (BSOD_STOP_LIST.SelectedItems.Count > 0)
            {
                idx = BSOD_STOP_LIST.SelectedItems[0].Index;
                
                MessageBox.Show(
                    (idx + 1).ToString() + "番目が選択されました。",
                    "選択されたインデックス",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

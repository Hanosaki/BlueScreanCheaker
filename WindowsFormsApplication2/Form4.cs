using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {

        string appTask;
        string systemTask;

        public Form4()
        {
            InitializeComponent();
            this.listBox1.DragDrop += new 
                System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new 
                System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            listBox1.Items.Clear();
            for (i = 0; i < s.Length; i++)
                listBox1.Items.Add(s[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SetSelected(0, true);
            string appLog = listBox1.SelectedItem.ToString();
            listBox2.SetSelected(0, true);
            string systemLog = listBox2.SelectedItem.ToString();

            var sr = new StreamReader(@"command1.txt", System.Text.Encoding.GetEncoding("shift-jis"));
            var before = sr.ReadLine();
            sr.Close();
            sr = new StreamReader(@"command2.txt", System.Text.Encoding.GetEncoding("shift-jis"));
            var after = sr.ReadLine();
            sr.Close();

            appTask = before + appLog + after;
            systemTask = before + systemLog + after;

            var sw = new StreamWriter(@"sampleApplication.txt", false, System.Text.Encoding.GetEncoding("shift-jis"));
            sw.WriteLine(appTask);
            sw.Close();
            sw = new StreamWriter(@"sampleSystem.txt", false, System.Text.Encoding.GetEncoding("shift-jis"));
            sw.WriteLine(systemTask);
            sw.Close();

            Form1 form1 = new Form1();
            form1.Show();

        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            listBox2.Items.Clear();
            for (i = 0; i < s.Length; i++)
                listBox2.Items.Add(s[i]);
        }

        public string taskApp
        {
            get { return appTask; }
        }

        public string taskSystem
        {
            get { return systemTask; }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
           
        }
    }
}

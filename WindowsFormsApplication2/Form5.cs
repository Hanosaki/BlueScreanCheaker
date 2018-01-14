using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public Label LABEL1
        {
            set { label1 = value; }
            get { return label1; }
        }

        private void Form5_Shown(object sender, EventArgs e)
        {

            var message = label1.Text;
            ArrayList messages = new ArrayList();
            while(message.IndexOf("。") != -1)
            {
                var split = message.IndexOf("。");
                messages.Add(message.Substring(0,split+1));
                message = message.Remove(0,split+1);
            }

            message = "";
            
            foreach(var i in messages)
            {
                message += i + "\r\n"; 
            }

            label1.Text = message;

            textBox1.Text = label1.Text;
            textBox1.Size = label1.Size + new Size((int)textBox1.Font.Size, (int)textBox1.Font.Size);
            textBox1.Visible = true;
            label1.Visible = false;

            this.Width = textBox1.Width + button1.Width +50;
            this.Height = textBox1.Height + button1.Height + 50;
            button1.Location = new Point(this.Width - button1.Width, this.Height - button1.Height - 20);
            this.Size += button1.Size;

            this.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

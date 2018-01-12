namespace WindowsFormsApplication2
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.seriousBox = new System.Windows.Forms.CheckBox();
            this.warningBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "アプリケーションログのevtxファイルをドラッグしてください"});
            this.listBox1.Location = new System.Drawing.Point(109, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(553, 40);
            this.listBox1.TabIndex = 0;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ApplicationLog：";
            // 
            // listBox2
            // 
            this.listBox2.AllowDrop = true;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Items.AddRange(new object[] {
            "システムログのevtxファイルをドラッグしてください"});
            this.listBox2.Location = new System.Drawing.Point(109, 105);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(553, 40);
            this.listBox2.TabIndex = 2;
            this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
            this.listBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "SystemLog：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "解析開始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // seriousBox
            // 
            this.seriousBox.AutoSize = true;
            this.seriousBox.Location = new System.Drawing.Point(253, 177);
            this.seriousBox.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.seriousBox.Name = "seriousBox";
            this.seriousBox.Size = new System.Drawing.Size(48, 16);
            this.seriousBox.TabIndex = 6;
            this.seriousBox.Text = "重大";
            this.seriousBox.UseVisualStyleBackColor = true;
            // 
            // warningBox
            // 
            this.warningBox.AutoSize = true;
            this.warningBox.Location = new System.Drawing.Point(394, 177);
            this.warningBox.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.warningBox.Name = "warningBox";
            this.warningBox.Size = new System.Drawing.Size(48, 16);
            this.warningBox.TabIndex = 7;
            this.warningBox.Text = "警告";
            this.warningBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(186, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(186, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 9;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.warningBox);
            this.Controls.Add(this.seriousBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form4";
            this.Text = "解析したいログを選択してください";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox seriousBox;
        private System.Windows.Forms.CheckBox warningBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

    }
}
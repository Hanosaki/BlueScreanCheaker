namespace WindowsFormsApplication2
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.systemLogLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.applicationLogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "現在ログの取得中です";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "ログの量によっては時間がかかる場合があります．";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "SystemLog:";
            // 
            // systemLogLabel
            // 
            this.systemLogLabel.AutoSize = true;
            this.systemLogLabel.Location = new System.Drawing.Point(107, 64);
            this.systemLogLabel.Name = "systemLogLabel";
            this.systemLogLabel.Size = new System.Drawing.Size(35, 12);
            this.systemLogLabel.TabIndex = 3;
            this.systemLogLabel.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "ApplicationLog:";
            // 
            // applicationLogLabel
            // 
            this.applicationLogLabel.AutoSize = true;
            this.applicationLogLabel.Location = new System.Drawing.Point(107, 76);
            this.applicationLogLabel.Name = "applicationLogLabel";
            this.applicationLogLabel.Size = new System.Drawing.Size(35, 12);
            this.applicationLogLabel.TabIndex = 5;
            this.applicationLogLabel.Text = "label5";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 120);
            this.Controls.Add(this.applicationLogLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.systemLogLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label systemLogLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label applicationLogLabel;
    }
}
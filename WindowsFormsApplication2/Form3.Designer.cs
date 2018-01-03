namespace WindowsFormsApplication2
{
    partial class Form3
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
            this.Anotation = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Anotation
            // 
            this.Anotation.AutoSize = true;
            this.Anotation.Cursor = System.Windows.Forms.Cursors.Default;
            this.Anotation.Location = new System.Drawing.Point(5, 9);
            this.Anotation.Name = "Anotation";
            this.Anotation.Size = new System.Drawing.Size(35, 12);
            this.Anotation.TabIndex = 0;
            this.Anotation.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(445, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Anotation);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Anotation;
        private System.Windows.Forms.Button button1;
    }
}
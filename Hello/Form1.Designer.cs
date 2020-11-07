namespace Hello
{
    partial class Form1
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
            this.aatextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.setTextBbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.aatextBox1.Location = new System.Drawing.Point(81, 21);
            this.aatextBox1.Name = "textBox1";
            this.aatextBox1.Size = new System.Drawing.Size(100, 20);
            this.aatextBox1.TabIndex = 0;
            this.aatextBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setTextBbutton
            // 
            this.setTextBbutton.Location = new System.Drawing.Point(123, 89);
            this.setTextBbutton.Name = "setTextBbutton";
            this.setTextBbutton.Size = new System.Drawing.Size(75, 23);
            this.setTextBbutton.TabIndex = 2;
            this.setTextBbutton.UseVisualStyleBackColor = true;
            this.setTextBbutton.Click += new System.EventHandler(this.setTextBbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 156);
            this.Controls.Add(this.setTextBbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aatextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox aatextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button setTextBbutton;
    }
}


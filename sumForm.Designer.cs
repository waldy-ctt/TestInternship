namespace TestInternship
{
    partial class sumForm
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
            this.txt_a = new System.Windows.Forms.Label();
            this.txt_b = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.txt_c = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_a
            // 
            this.txt_a.AutoSize = true;
            this.txt_a.Location = new System.Drawing.Point(155, 38);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(50, 16);
            this.txt_a.TabIndex = 0;
            this.txt_a.Text = "Input A:";
            // 
            // txt_b
            // 
            this.txt_b.AutoSize = true;
            this.txt_b.Location = new System.Drawing.Point(155, 192);
            this.txt_b.Name = "txt_b";
            this.txt_b.Size = new System.Drawing.Size(50, 16);
            this.txt_b.TabIndex = 0;
            this.txt_b.Text = "Input B:";
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(40, 301);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 23);
            this.btn_calc.TabIndex = 2;
            this.btn_calc.Text = "sum";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // txt_c
            // 
            this.txt_c.AutoSize = true;
            this.txt_c.Location = new System.Drawing.Point(176, 304);
            this.txt_c.Name = "txt_c";
            this.txt_c.Size = new System.Drawing.Size(44, 16);
            this.txt_c.TabIndex = 3;
            this.txt_c.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(777, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(288, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(635, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(288, 125);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(635, 96);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // sumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 460);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_c);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.txt_b);
            this.Controls.Add(this.txt_a);
            this.Name = "sumForm";
            this.Text = "sumForm";
            this.Load += new System.EventHandler(this.sumForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_a;
        private System.Windows.Forms.Label txt_b;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Label txt_c;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}


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
            this.txtBox_a = new System.Windows.Forms.TextBox();
            this.txtBox_b = new System.Windows.Forms.TextBox();
            this.btn_calc = new System.Windows.Forms.Button();
            this.txt_c = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_a
            // 
            this.txt_a.AutoSize = true;
            this.txt_a.Location = new System.Drawing.Point(30, 47);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(50, 16);
            this.txt_a.TabIndex = 0;
            this.txt_a.Text = "Input A:";
            // 
            // txt_b
            // 
            this.txt_b.AutoSize = true;
            this.txt_b.Location = new System.Drawing.Point(30, 97);
            this.txt_b.Name = "txt_b";
            this.txt_b.Size = new System.Drawing.Size(50, 16);
            this.txt_b.TabIndex = 0;
            this.txt_b.Text = "Input B:";
            // 
            // txtBox_a
            // 
            this.txtBox_a.Location = new System.Drawing.Point(100, 40);
            this.txtBox_a.Name = "txtBox_a";
            this.txtBox_a.Size = new System.Drawing.Size(146, 22);
            this.txtBox_a.TabIndex = 1;
            this.txtBox_a.TextChanged += new System.EventHandler(this.txtBox_b_TextChanged);
            this.txtBox_a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_a_KeyPress);
            // 
            // txtBox_b
            // 
            this.txtBox_b.Location = new System.Drawing.Point(100, 91);
            this.txtBox_b.Name = "txtBox_b";
            this.txtBox_b.Size = new System.Drawing.Size(146, 22);
            this.txtBox_b.TabIndex = 1;
            this.txtBox_b.TextChanged += new System.EventHandler(this.txtBox_b_TextChanged);
            this.txtBox_b.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_a_KeyPress);
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(33, 159);
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
            this.txt_c.Location = new System.Drawing.Point(169, 162);
            this.txt_c.Name = "txt_c";
            this.txt_c.Size = new System.Drawing.Size(44, 16);
            this.txt_c.TabIndex = 3;
            this.txt_c.Text = "label1";
            // 
            // sumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 460);
            this.Controls.Add(this.txt_c);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.txtBox_b);
            this.Controls.Add(this.txtBox_a);
            this.Controls.Add(this.txt_b);
            this.Controls.Add(this.txt_a);
            this.Name = "sumForm";
            this.Text = "sumForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_a;
        private System.Windows.Forms.Label txt_b;
        private System.Windows.Forms.TextBox txtBox_a;
        private System.Windows.Forms.TextBox txtBox_b;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Label txt_c;
    }
}


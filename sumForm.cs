using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInternship
{
    public partial class sumForm : Form
    {
        public sumForm()
        {
            InitializeComponent();
            txt_c.Visible = false;
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            int aDigit = richTextBox1.Text.Length, bDigit = richTextBox2.Text.Length;

            int amountArrayA = 0, amountArrayB = 0;

            if (aDigit % 19 == 0)
            {
                amountArrayA = aDigit / 19;
            }
            else
            {
                amountArrayA = (aDigit / 19) + 1;
            }

            if (bDigit % 19 == 0)
            {
                amountArrayB = (bDigit / 19);
            }
            else
            {
                amountArrayB = (bDigit / 19) + 1;
            }

            BigInteger[] a = new BigInteger[amountArrayA];
            BigInteger[] b = new BigInteger[amountArrayB];

            StringBuilder stringA = new StringBuilder(richTextBox1.Text);
            StringBuilder stringB = new StringBuilder(richTextBox2.Text);

            for (int s = 0; s < amountArrayA; s++)
            {
                for (int i = 0; i < 19; i++)
                {
                    a[s] = BigInteger.Parse(stringA.ToString());
                }
            }
        }

        private void txtBox_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBox_b_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength == 0)
            {
                richTextBox1.Text = "0";
            }
            if (richTextBox2.TextLength == 0)
            {
                richTextBox2.Text = "0";
            }
        }

        private void sumForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder numA = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                numA.Append("1");
            }

            richTextBox1.Text = numA.ToString();

            Console.WriteLine(richTextBox1.Text.Length + " A");

            StringBuilder numB = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                numB.Append("2");
            }

            richTextBox2.Text = numB.ToString();
            Console.WriteLine(richTextBox2.Text.Length + " B");
        }
    }
}
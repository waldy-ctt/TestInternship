using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
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
            txtBox_a.Text = "0";
            txtBox_b.Text = "0";
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            BigInteger a = BigInteger.Parse(txtBox_a.Text);
            BigInteger b = BigInteger.Parse(txtBox_b.Text);
            BigInteger c = a + b;

            txt_c.Text = c.ToString();

            txt_c.Visible = true;
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
            if (txtBox_a.TextLength == 0)
            {
                txtBox_a.Text = "0";
            }
            if (txtBox_b.TextLength == 0)
            {
                txtBox_b.Text = "0";
            }
        }
    }
}
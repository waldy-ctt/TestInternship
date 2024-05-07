using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            txt_c.Text = (int.Parse(txtBox_a.Text) + int.Parse(txtBox_b.Text)).ToString();
            txt_c.Visible = true;
        }

        private void txtBox_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
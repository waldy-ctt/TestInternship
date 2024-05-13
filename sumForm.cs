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
        }

        private List<string> convertStringToList(string str, int gap)
        {
            List<string> listOfString = new List<string>();

            for (int i = str.Length; i > 0; i -= gap)
            {
                if (i - gap < 0)
                {
                    gap = i;
                }

                listOfString.Insert(0, str.Substring(i - gap, gap)); // Insert at the beginning to maintain order
            }

            return listOfString;
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            Console.WriteLine("starting to calculate");
            //get amount of digit in both textbox
            int aDigit = richTextBox1.Text.Length, bDigit = richTextBox2.Text.Length;

            //bigint can handle 19 digits, make 18 as usage and the very first digits is to parse value
            int amountOfNumberFromArrayToString = 18;

            //checking the amount of array needed to store
            int amountArrayA = 0, amountArrayB = 0;

            if (aDigit % 18 == 0)
            {
                amountArrayA = aDigit / 18;
            }
            else
            {
                amountArrayA = (aDigit / 18) + 1;
            }

            if (bDigit % 18 == 0)
            {
                amountArrayB = (bDigit / 18);
            }
            else
            {
                amountArrayB = (bDigit / 18) + 1;
            }

            BigInteger[] a = new BigInteger[amountArrayA];
            BigInteger[] b = new BigInteger[amountArrayB];

            //Making everything in array to zero for format of calculating, prevent error might cause
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = BigInteger.Zero;
            }
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = BigInteger.Zero;
            }

            //Make amount of arrayC = to the array of the biggest number
            int amountArrayC = amountArrayA > amountArrayB ? amountArrayA : amountArrayB;

            BigInteger[] c = new BigInteger[amountArrayC];

            StringBuilder stringA = new StringBuilder(richTextBox1.Text);
            StringBuilder stringB = new StringBuilder(richTextBox2.Text);

            //convert each string to each clump of value in array with each value hold 18 digits of number
            string[] arrayOfStringA = convertStringToList(stringA.ToString(), 18).ToArray();
            string[] arrayOfStringB = convertStringToList(stringB.ToString(), 18).ToArray();

            //looping through every single clump in array to turn every clumps of string to every clumps of big integer with 18 digits max and 1 digit to parse
            for (int s = 0; s < amountArrayA; s++)
            {
                a[s] = BigInteger.Parse(arrayOfStringA[s]);
            }

            for (int s = 0; s < amountArrayB; s++)
            {
                b[s] = BigInteger.Parse(arrayOfStringB[s]);
            }

            //create index of two array to loop through
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;
            for (int s = amountArrayC - 1; s >= 0; s--)
            {
                //handle if on of the array reach the end but the other still have element to loop through, treat it as zero
                BigInteger valueA = indexA >= 0 ? a[indexA] : BigInteger.Zero;
                BigInteger valueB = indexB >= 0 ? b[indexB] : BigInteger.Zero;
                BigInteger tempSum = BigInteger.Zero;
                tempSum = BigInteger.Add(valueA, valueB);

                if (s > 0)
                {
                    if (tempSum.ToString().Length == 19)
                    {
                        //if the chunk of number is 19 digit, take 18 digit and the last digit will be 1 so convert it to 0 and bring that one to next chunk like basic math
                        string temp = tempSum.ToString();

                        temp = "0" + temp.Substring(1);
                        tempSum = BigInteger.Parse(temp);
                        c[s] = tempSum;
                        c[s - 1] = BigInteger.Add(c[s - 1], BigInteger.One);
                    }
                    else
                    {
                        c[s] = tempSum;
                    }
                }
                else
                {
                    c[s] = tempSum;
                }
                indexA--;
                indexB--;
            }

            StringBuilder result = new StringBuilder();

            foreach (BigInteger d in c)
            {
                result.Append(d.ToString());
            }

            richTextBox3.Text = result.ToString();
            Console.WriteLine("calculate done");
            Console.WriteLine(result);
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
            if (richTextBox1.TextLength == 0)
            {
                richTextBox1.Text = "0";
            }
            if (richTextBox2.TextLength == 0)
            {
                richTextBox2.Text = "0";
            }

            richTextBox3.ReadOnly = true;
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

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
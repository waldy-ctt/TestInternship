using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal.Auth;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInternship.mySQL;

namespace TestInternship
{
    public partial class insertDataForm : Form
    {
        private MySqlConnection conn;
        private string sqlConnectionString = "server=localhost;user=root;database=interntest;port=3306;password=sieunhan1234aB!";

        public insertDataForm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private async void loadData()
        {
            List<userInfo> userList = new List<userInfo>();

            try
            {
                conn = new MySqlConnection(sqlConnectionString);
                conn.Open();

                string sql = "select * from userdata";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userInfo newUserInfo = new userInfo() { id = reader[0].ToString(), username = reader[1].ToString() };

                    userList.Add(newUserInfo);
                }

                reader.Close();

                dataGridView1.DataSource = userList;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.Refresh();
        }

        private void insertDataForm_Load(object sender, EventArgs e)
        {
            loadData();
            dataGridView1.Refresh();
            label1.Visible = false;
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Timer Start!");
            Console.WriteLine(DateTime.Now);
            if (txtBox_times.Text.Length == 0) return;
            BigInteger times = BigInteger.Parse(txtBox_times.Text);

            try
            {
                conn = new MySqlConnection(sqlConnectionString);
                conn.Open();

                StringBuilder sql = new StringBuilder("insert into userdata (id, username) values ");
                for (BigInteger d = 0; d < times; d++)
                {
                    if (d == times - 1)
                    {
                        sql.Append("(\"\", \"\")");
                    }
                    else
                    {
                        sql.Append("(\"\", \"\"),");
                    }
                }
                MySqlCommand command = new MySqlCommand(sql.ToString(), conn);
                command.ExecuteNonQuery();

                string sql2 = "select count(username) from userdata";
                command = new MySqlCommand(sql2, conn);
                object result = command.ExecuteScalar();
                Console.WriteLine("amount of item in db: " + result);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            Console.WriteLine("Timer End!");
            Console.WriteLine(DateTime.Now);
            conn.Close();
            label1.Text = "done";
            loadData();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtBox_times_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
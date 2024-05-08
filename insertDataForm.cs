using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal.Auth;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tortuga.Chain.MySql;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInternship.mySQL;
using Tortuga.Chain.DataSources;
using Tortuga.Chain;
using System.IO;

namespace TestInternship
{
    public partial class insertDataForm : Form
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        private string sqlConnectionString = "server=localhost;user=root;database=interntest;port=3306;password=sieunhan1234aB!;AllowLoadLocalInfile=true;";
        private string tempFilePath = "D:\\bin\\OneDrive\\C# project\\TestInternship\\userdata.txt";

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
                conn = new MySql.Data.MySqlClient.MySqlConnection(sqlConnectionString);
                conn.Open();

                string sql = "select * from userdata";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userInfo newUserInfo = new userInfo() { id = reader[0].ToString(), username = reader[1].ToString() };

                    userList.Add(newUserInfo);
                }

                reader.Close();

                dataGridView1.DataSource = userList;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
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
            DateTime start = DateTime.Now;
            Console.WriteLine(start);

            if (txtBox_times.Text.Length == 0) return;
            int times = int.Parse(txtBox_times.Text);

            try
            {
                conn = new MySqlConnection(sqlConnectionString);
                conn.Open();

                List<userInfo> listOfUser = new List<userInfo>();

                DateTime createList = DateTime.Now;
                for (int i = 0; i < times; i++)
                {
                    listOfUser.Add(new userInfo() { id = "", username = "" });
                }
                DateTime endList = DateTime.Now;
                TimeSpan listTime = endList.Subtract(createList);
                Console.WriteLine("time to create list: " + listTime.TotalSeconds.ToString() + "s");

                MySqlCommand cmd;

                DateTime startWriter = DateTime.Now;
                StreamWriter file = File.CreateText(tempFilePath);
                file.WriteLine("Table\tuserdata\tin\tinterntest\tDatabase");
                file.WriteLine("id\tusername");
                file.WriteLine();
                for (int i = 0; i < times; i++)
                {
                    file.WriteLine($"{listOfUser[i].id}\t{listOfUser[i].username}");
                }
                file.Close();
                DateTime endWriter = DateTime.Now;
                TimeSpan writeTime = endWriter.Subtract(startWriter);
                Console.WriteLine("time to write file: " + writeTime.TotalSeconds.ToString() + "s");

                //var dataSource = new MySqlDataSource("InternTest DB", "Server=localhost;User=root;Database=interntest;Password=sieunhan1234aB!;AllowLoadLocalInfile=true;");
                //await dataSource.InsertBulk(listOfUser).ExecuteAsync();

                MySqlBulkLoader bl = new MySqlBulkLoader(conn);
                bl.Local = true;
                bl.TableName = "userdata";
                bl.FieldTerminator = "\t";
                bl.LineTerminator = "\n";
                bl.FileName = "D:\\bin\\OneDrive\\C# project\\TestInternship\\userdata.txt";
                bl.NumberOfLinesToSkip = 3;

                int count = bl.Load();
                Console.WriteLine(count.ToString() + "line loaded from file");

                string sql2 = "select count(username) from userdata";

                cmd = new MySqlCommand(sql2, conn);

                object result = cmd.ExecuteScalar();
                Console.WriteLine("amount of item in db: " + result);
            }
            catch (MySqlConnector.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            Console.WriteLine("Timer End!");
            DateTime end = DateTime.Now;
            Console.WriteLine(end);

            Console.WriteLine("Total Time Cost:");
            TimeSpan cost = end.Subtract(start);
            Console.WriteLine(cost.TotalSeconds + "s");

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
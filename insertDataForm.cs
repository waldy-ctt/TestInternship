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
using System.Threading;
using Tortuga.Anchor;

namespace TestInternship
{
    public class ThreadParam
    {
        public int times { get; set; }
    }

    public partial class insertDataForm : Form
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        private string sqlConnectionString = "server=localhost;user=root;database=interntest;port=3306;password=sieunhan1234aB!;AllowLoadLocalInfile=true;";
        private string tempFilePath1 = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\userdata1.txt";
        private string tempFilePath2 = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\userdata2.txt";

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

        //private static void loadDataFromFile1()
        //{
        //    string tempFilePath1 = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\userdata1.txt";
        //    MySqlConnection conn;
        //    string sqlConnectionString = "server=localhost;user=root;database=interntest;port=3306;password=sieunhan1234aB!;AllowLoadLocalInfile=true;";

        //    conn = new MySqlConnection(sqlConnectionString);
        //    conn.Open();

        //    MySqlBulkLoader bl = new MySqlBulkLoader(conn);
        //    bl.Local = true;
        //    bl.TableName = "userdata";
        //    bl.FieldTerminator = "\t";
        //    bl.LineTerminator = "\n";
        //    bl.FileName = tempFilePath1;
        //    bl.NumberOfLinesToSkip = 3;

        //    int count = bl.Load();
        //    Console.WriteLine("ended loaddata1");
        //    Console.WriteLine(count.ToString() + " line loaded from file");
        //}

        //private static void loadDataFromFile2()
        //{
        //    string tempFilePath2 = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\userdata2.txt";
        //    MySqlConnection conn;
        //    string sqlConnectionString = "server=localhost;user=root;database=interntest;port=3306;password=sieunhan1234aB!;AllowLoadLocalInfile=true;";

        //    conn = new MySqlConnection(sqlConnectionString);
        //    conn.Open();

        //    MySqlBulkLoader bl = new MySqlBulkLoader(conn);
        //    bl.Local = true;
        //    bl.TableName = "userdata";
        //    bl.FieldTerminator = "\t";
        //    bl.LineTerminator = "\n";
        //    bl.FileName = tempFilePath2;
        //    bl.NumberOfLinesToSkip = 3;

        //    int count = bl.Load();
        //    Console.WriteLine("ended loaddata2");
        //    Console.WriteLine(count.ToString() + " line loaded from file");
        //}

        /*Bulk loader (load bulk from file to sql)
         * Console.WriteLine("Timer Start!");
            DateTime start = DateTime.Now;
            Console.WriteLine(start);

            if (txtBox_times.Text.Length == 0) return;
            int times = int.Parse(txtBox_times.Text);

            try
            {
                conn = new MySqlConnection(sqlConnectionString);
                conn.Open();

                List<userInfo> listOfUser = new List<userInfo>();

                int timeA = 0, timeB = 0, indexA = 0, indexB = 0;

                DateTime createList = DateTime.Now;
                for (int i = 0; i < times; i++)
                {
                    listOfUser.Add(new userInfo() { id = "", username = "" });
                }
                DateTime endList = DateTime.Now;
                TimeSpan listTime = endList.Subtract(createList);
                Console.WriteLine("time to create list: " + listTime.TotalSeconds.ToString() + "s");

                MySqlCommand cmd;

                if (times == 1)
                {
                    timeA = 1;
                    timeB = 0;

                    indexA = 0;
                    indexB = 0;
                }

                if (times % 2 == 0 && times > 1)
                {
                    timeA = times / 2;
                    timeB = times - timeA;
                }
                else
                {
                    timeA = (times + 1) / 2;
                    timeB = times - timeA - 1;
                }

                if (times % 2 == 0 && times > 1)
                {
                    indexA = 0;
                    indexB = times / 2;
                }
                else
                {
                    indexA = 0;
                    indexB = times / 2;
                }

                Console.WriteLine("Time A: " + timeA + " Time B: " + timeB);
                Console.WriteLine("Index A: " + indexA + " Index B: " + indexB);

                DateTime startWriter1 = DateTime.Now;

                StreamWriter file1 = File.CreateText(tempFilePath1);
                file1.WriteLine("Table\tuserdata\tin\tinterntest\tDatabase");
                file1.WriteLine("id\tusername");
                file1.WriteLine();

                for (int i = indexA; i < timeA; i++)
                {
                    file1.WriteLine($"{listOfUser[i].id}\t{listOfUser[i].username}");
                }
                file1.Close();

                DateTime endWriter1 = DateTime.Now;
                TimeSpan writeTime1 = endWriter1.Subtract(startWriter1);
                Console.WriteLine("time to write file 1: " + writeTime1.TotalSeconds.ToString() + "s");

                DateTime startWriter2 = DateTime.Now;

                StreamWriter file2 = File.CreateText(tempFilePath2);
                file2.WriteLine("Table\tuserdata\tin\tinterntest\tDatabase");
                file2.WriteLine("id\tusername");
                file2.WriteLine();

                for (int i = 0; i < timeB; i++)
                {
                    file2.WriteLine($"{listOfUser[indexB].id}\t{listOfUser[indexB].username}");
                    indexB++;
                }
                file2.Close();

                DateTime endWriter2 = DateTime.Now;
                TimeSpan writeTime2 = endWriter1.Subtract(startWriter2);
                Console.WriteLine("time to write file 2: " + writeTime2.TotalSeconds.ToString() + "s");

                ThreadStart loadData1st = new ThreadStart(loadDataFromFile1);
                Thread loadData1 = new Thread(loadData1st);
                loadData1.Name = "loadData1";

                ThreadStart loadData2nd = new ThreadStart(loadDataFromFile2);
                Thread loadData2 = new Thread(loadData2nd);
                loadData2.Name = "loadData2";

                loadData1.Start();
                loadData2.Start();

                loadData1.Join();
                loadData2.Join();

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

            Console.Write("Total Time Cost: ");
            TimeSpan cost = end.Subtract(start);
            Console.WriteLine(cost.TotalSeconds + "s");

            conn.Close();
            label1.Text = "done";
            loadData();
        }Console.WriteLine("Timer Start!");
                    DateTime start = DateTime.Now;
                    Console.WriteLine(start);

                    if (txtBox_times.Text.Length == 0) return;
                    int times = int.Parse(txtBox_times.Text);

                    try
                    {
                        conn = new MySqlConnection(sqlConnectionString);
                        conn.Open();

                        List<userInfo> listOfUser = new List<userInfo>();

                        int timeA = 0, timeB = 0, indexA = 0, indexB = 0;

                        DateTime createList = DateTime.Now;
                        for (int i = 0; i < times; i++)
                        {
                            listOfUser.Add(new userInfo() { id = "", username = "" });
                        }
                        DateTime endList = DateTime.Now;
                        TimeSpan listTime = endList.Subtract(createList);
                        Console.WriteLine("time to create list: " + listTime.TotalSeconds.ToString() + "s");

                        MySqlCommand cmd;

                        if (times == 1)
                        {
                            timeA = 1;
                            timeB = 0;

                            indexA = 0;
                            indexB = 0;
                        }

                        if (times % 2 == 0 && times > 1)
                        {
                            timeA = times / 2;
                            timeB = times - timeA;
                        }
                        else
                        {
                            timeA = (times + 1) / 2;
                            timeB = times - timeA - 1;
                        }

                        if (times % 2 == 0 && times > 1)
                        {
                            indexA = 0;
                            indexB = times / 2;
                        }
                        else
                        {
                            indexA = 0;
                            indexB = times / 2;
                        }

                        Console.WriteLine("Time A: " + timeA + " Time B: " + timeB);
                        Console.WriteLine("Index A: " + indexA + " Index B: " + indexB);

                        DateTime startWriter1 = DateTime.Now;

                        StreamWriter file1 = File.CreateText(tempFilePath1);
                        file1.WriteLine("Table\tuserdata\tin\tinterntest\tDatabase");
                        file1.WriteLine("id\tusername");
                        file1.WriteLine();

                        for (int i = indexA; i < timeA; i++)
                        {
                            file1.WriteLine($"{listOfUser[i].id}\t{listOfUser[i].username}");
                        }
                        file1.Close();

                        DateTime endWriter1 = DateTime.Now;
                        TimeSpan writeTime1 = endWriter1.Subtract(startWriter1);
                        Console.WriteLine("time to write file 1: " + writeTime1.TotalSeconds.ToString() + "s");

                        DateTime startWriter2 = DateTime.Now;

                        StreamWriter file2 = File.CreateText(tempFilePath2);
                        file2.WriteLine("Table\tuserdata\tin\tinterntest\tDatabase");
                        file2.WriteLine("id\tusername");
                        file2.WriteLine();

                        for (int i = 0; i < timeB; i++)
                        {
                            file2.WriteLine($"{listOfUser[indexB].id}\t{listOfUser[indexB].username}");
                            indexB++;
                        }
                        file2.Close();

                        DateTime endWriter2 = DateTime.Now;
                        TimeSpan writeTime2 = endWriter1.Subtract(startWriter2);
                        Console.WriteLine("time to write file 2: " + writeTime2.TotalSeconds.ToString() + "s");

                        ThreadStart loadData1st = new ThreadStart(loadDataFromFile1);
                        Thread loadData1 = new Thread(loadData1st);
                        loadData1.Name = "loadData1";

                        ThreadStart loadData2nd = new ThreadStart(loadDataFromFile2);
                        Thread loadData2 = new Thread(loadData2nd);
                        loadData2.Name = "loadData2";

                        loadData1.Start();
                        loadData2.Start();

                        loadData1.Join();
                        loadData2.Join();

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

                    Console.Write("Total Time Cost: ");
                    TimeSpan cost = end.Subtract(start);
                    Console.WriteLine(cost.TotalSeconds + "s");

                    conn.Close();
                    label1.Text = "done";
                    loadData();

        */

        private void InsertEmptyIntoMySQL(object p)
        {
            ThreadParam tp = p as ThreadParam;

            MySqlConnection conn = new MySqlConnection(sqlConnectionString);

            conn.Open();

            StringBuilder sql = new StringBuilder("insert into userdata(id, username) values ");

            for (int i = 0; i < tp.times; i++)
            {
                sql.Append($"(\"\", \"\"),");
            }

            char[] trim = { ',' };

            MySqlCommand cmd = new MySqlCommand(sql.ToString().TrimEnd(trim), conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            Console.WriteLine("added " + tp.times);
            Console.WriteLine("ended thread!!");
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

                //Function

                int timeA = times / 20, timeB = timeA + (times % 20);

                //if (times % 10 == 0)
                //{
                //    timeA = times / 10;
                //    timeB = times / 10;
                //}
                //else
                //{
                //    timeA = times / 10;
                //    timeB = ((times / 10) + (times % 10));
                //}

                List<Task> tasks = new List<Task>();

                ThreadParam tp;
                tp = new ThreadParam();
                tp.times = timeA;

                for (int l = 0; l < 9; l++)
                {
                    tasks.Add(Task.Run(() => InsertEmptyIntoMySQL(tp)));
                }

                //Thread load1 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load2 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load3 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load4 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load5 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load6 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load7 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load8 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //Thread load9 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                //load1.Start(tp);
                //load2.Start(tp);
                //load3.Start(tp);
                //load4.Start(tp);
                //load5.Start(tp);
                //load6.Start(tp);
                //load7.Start(tp);
                //load8.Start(tp);
                //load9.Start(tp);

                //Thread load10 = new Thread(new ParameterizedThreadStart(InsertEmptyIntoMySQL));
                tp = new ThreadParam();
                tp.times = timeB;

                tasks.Add(Task.Run(() => InsertEmptyIntoMySQL(tp)));

                Task.WhenAll(tasks).Wait();

                //load10.Start(tp);

                //load1.Join();
                //load2.Join();
                //load3.Join();
                //load4.Join();
                //load5.Join();
                //load6.Join();
                //load7.Join();
                //load8.Join();
                //load9.Join();
                //load10.Join();

                //Function.end

                string sql2 = "select count(username) from userdata";

                cmd = new MySqlCommand(sql2, conn);

                object result = cmd.ExecuteScalar();
                Console.WriteLine("amount of item in db: " + result);

                conn.Close();
            }
            catch (MySqlConnector.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            Console.WriteLine("Timer End!");
            DateTime end = DateTime.Now;
            Console.WriteLine(end);

            Console.Write("Total Time Cost: ");
            TimeSpan cost = end.Subtract(start);
            Console.WriteLine(cost.TotalSeconds + "s");

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
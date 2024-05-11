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
using System.Diagnostics;
using System.Security.AccessControl;

namespace TestInternship
{
    public class ThreadParam
    {
        public int times { get; set; }
        public string index { get; set; }
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

        private void InsertEmptyIntoMySQL(object p)
        {
            DateTime threadStart = DateTime.Now;
            ThreadParam tp = p as ThreadParam;

            Stopwatch taskStopwatch = new Stopwatch();
            taskStopwatch.Start();

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

            taskStopwatch.Stop();

            DateTime threadEnd = DateTime.Now;
            TimeSpan threadTime = threadEnd.Subtract(threadStart);

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("time execute thread = " + threadTime.TotalSeconds.ToString() + "s");
            Console.WriteLine("Task waiting time: " + taskStopwatch.Elapsed.TotalSeconds.ToString() + "s");
            Console.WriteLine("added " + tp.times);
            Console.WriteLine("ended thread!! " + tp.index.ToString());
            Console.WriteLine("------------------------------------------------------");
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

                int threadAmount = 4;
                int timeA = times / threadAmount, timeB = timeA + (times % threadAmount);

                //List<Task> tasks = new List<Task>();
                //Task[] tasks = new Task[threadAmount];
                CountdownEvent cd = new CountdownEvent(threadAmount);

                ThreadParam tp;
                tp = new ThreadParam();
                tp.times = timeA;

                //ThreadPool.SetMaxThreads(1500, 1500);
                //ThreadPool.SetMinThreads(1000000, 1000000);

                for (int l = 0; l < threadAmount; l++)
                {
                    tp.index = l.ToString();
                    ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                    {
                        InsertEmptyIntoMySQL(tp);
                        cd.Signal();
                    }
                    ), tp);
                    //tasks.Add(Task.Run(() => InsertEmptyIntoMySQL(tp)));
                    //tasks[l] = Task.Run(() => InsertEmptyIntoMySQL(tp));
                }

                cd.Wait();

                //tp = new ThreadParam();
                //tp.times = timeB;
                //tp.index = "last";

                //tasks.Add(Task.Run(() => InsertEmptyIntoMySQL(tp)));
                //tasks[threadAmount - 1] = Task.Run(() => InsertEmptyIntoMySQL(tp));
                //ThreadPool.QueueUserWorkItem(new WaitCallback(InsertEmptyIntoMySQL), tp);

                //Task.WhenAll(tasks).Wait();
                //Task.WaitAll(tasks);

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

            int coreCount = 0;
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }
            Console.WriteLine("Number Of Cores: {0}", coreCount);

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

        private void InsertEmptyIntoMySQLAsync()
        {
            int times = 250000;
            Stopwatch taskStopwatch = new Stopwatch();

            MySqlConnection conn = new MySqlConnection(sqlConnectionString);

            try
            {
                conn.Open();
                taskStopwatch.Start();

                StringBuilder sql = new StringBuilder("INSERT INTO userdata(id, username) VALUES ");
                for (int i = 0; i < times; i++)
                {
                    sql.Append($"(\"\", \"\"),");
                }

                char[] trim = { ',' };
                MySqlCommand cmd = new MySqlCommand(sql.ToString().TrimEnd(trim), conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

            taskStopwatch.Stop();
            TimeSpan taskTime = taskStopwatch.Elapsed;

            Console.WriteLine("Task waiting time: " + taskTime.TotalSeconds + "s");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //test get blocking coefficient
            DateTime start = DateTime.Now;
            int time = 8;
            CountdownEvent cd = new CountdownEvent(time);
            for (int l = 0; l < time; l++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    InsertEmptyIntoMySQLAsync();
                    cd.Signal();
                }
                ));
            }

            cd.Wait();

            DateTime end = DateTime.Now;
            TimeSpan cost = end.Subtract(start);

            Console.WriteLine("total time: " + cost.TotalSeconds.ToString() + "s");
        }
    }
}
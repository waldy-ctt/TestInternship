using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInternship
{
    public partial class inserData2 : Form
    {
        public inserData2()
        {
            InitializeComponent();
        }

        private async void query(object obj)
        {
            DateTime start = DateTime.Now;
            string connectionString = "server=localhost;user=root;database=interntest;port=3306;password=sieunhan1234aB!;AllowLoadLocalInfile=true;Max Pool Size=300;";
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                await conn.OpenAsync();

                DateTime startString = DateTime.Now;
                StringBuilder sql = new StringBuilder("insert into userdata() values ");

                for (int i = 0; i < 1000000 / 80; i++)
                {
                    sql.Append("(),");
                }

                char[] trim = { ',' };

                string query = sql.ToString().TrimEnd(trim);

                DateTime endString = DateTime.Now;
                TimeSpan timeString = endString.Subtract(startString);
                await Console.Out.WriteLineAsync("time string: " + timeString.TotalSeconds);

                DateTime startQuery = DateTime.Now;

                MySqlCommand cmd = new MySqlCommand(query, conn);
                await cmd.ExecuteNonQueryAsync();

                DateTime endQuery = DateTime.Now;
                TimeSpan timeQuery = endQuery.Subtract(startQuery);
                await Console.Out.WriteLineAsync("time query: " + timeQuery.TotalSeconds + "s");

                await Console.Out.WriteLineAsync("done add line");

                await conn.CloseAsync();
            }
            catch (Exception ex)
            {
            }

            DateTime end = DateTime.Now;
            TimeSpan time = end.Subtract(start);
            await Console.Out.WriteLineAsync("-------------Total thread time cost: " + time.TotalSeconds.ToString());
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            Stopwatch time = new Stopwatch();

            //CountdownEvent cd = new CountdownEvent(30);

            time.Start();

            for (int i = 0; i < 80; i++)
            {
                ThreadPool.QueueUserWorkItem(query);
            }

            //cd.Wait();

            time.Stop();

            await Console.Out.WriteLineAsync("+++++++Total time cost: " + time.ElapsedMilliseconds);
        }
    }
}
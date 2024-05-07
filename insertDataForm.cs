using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal.Auth;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestInternship.Database;

namespace TestInternship
{
    public partial class insertDataForm : Form
    {
        private String connectionString = "mongodb://localhost:27017/";
        private String databaseName = "test1";

        private string collectionName = "testcol";

        public insertDataForm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private async void loadData()
        {
            var dbClient = new MongoClient(connectionString);
            var database = dbClient.GetDatabase(databaseName);
            var userDataCollection = database.GetCollection<userData>(collectionName);

            var filter = Builders<userData>.Filter.Empty;
            var allUser = await userDataCollection.Find(filter).ToListAsync();

            dataGridView1.DataSource = allUser;

            dataGridView1.Columns["_id"].Visible = false;

            dataGridView1.Columns["id"].HeaderText = "ID";

            dataGridView1.Columns["username"].HeaderText = "UserName";
        }

        private void insertDataForm_Load(object sender, EventArgs e)
        {
            loadData();
            dataGridView1.Refresh();
            label1.Visible = false;
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            Console.WriteLine("timer start!");
            Console.WriteLine(DateTime.Now.ToString());
            if (string.IsNullOrEmpty(txtBox_times.Text)) return;

            var dbClient = new MongoClient(connectionString);
            var database = dbClient.GetDatabase(databaseName);
            var userDataCollection = database.GetCollection<userData>(collectionName);

            var newUserList = new List<userData>();
            for (int i = 0; i < int.Parse(txtBox_times.Text); i++)
            {
                userData newUserData = new userData() { id = "", username = "" };
                newUserList.Add(newUserData);
            }

            var tempFilter = Builders<userData>.Filter.Empty;

            await userDataCollection.InsertManyAsync(newUserList);
            Console.WriteLine("new user list lenght:" + userDataCollection.CountDocuments(tempFilter));
            Console.WriteLine("timer end!!");
            Console.WriteLine(DateTime.Now.ToString());
            loadData();
            dataGridView1.Refresh();
            label1.Text = "done";
            label1.Show();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            loadData();
            dataGridView1.Refresh();
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
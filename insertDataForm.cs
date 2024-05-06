using Amazon.Runtime.CredentialManagement.Internal;
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

namespace TestInternship
{
    public partial class insertDataForm : Form
    {
        String connectionString = "mongodb+srv://clocktoktok:y6ghz1WDOJPOW5d9@cluster0.zfuy4lv.mongodb.net/";
        String databaseName = "sample_mflix";
        public insertDataForm()
        {
            
            InitializeComponent();
        }

        private void insertDataForm_Load(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient(connectionString);
            IMongoDatabase database = dbClient.GetDatabase(databaseName);
            IMongoCollection <TDocument> = database.GetCollection<>("users");
            label1.Text = database;
        }
    }
}

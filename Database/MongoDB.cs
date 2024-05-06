using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInternship.Database
{
    internal class MongoDB
    {
        public MongoClient connectMongoDB(string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            return client;
        }

        public IMongoDatabase connectMongoDBDataBase(MongoClient client, string dataBaseName)
        {
            IMongoDatabase database = client.GetDatabase(dataBaseName);
            return database;
        }

        public IMongoCollection<userData> connectMongoDBCollectionUserData(IMongoDatabase database, string collectionName)
        {
            IMongoCollection<userData> collection = database.GetCollection<userData>(collectionName);
            return collection;
        }

        public string[] getUserDataCollectionValueToString(IMongoCollection<userData> mongoCollection)
        {
            long collectionCount = mongoCollection.CountDocuments(null);
            string[] user = new string[collectionCount];

            IFindFluent<userData, userData> finder = mongoCollection.Find(null);

            for (data: finder)
            {
            }
        }
    }
}
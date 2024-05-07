using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInternship.Database
{
    [BsonIgnoreExtraElements]
    internal class userData
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("id")]
        public string id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        public userData()
        {
        }

        public userData(string id, string username)
        {
            this.id = id;
            this.username = username;
        }
    }
}
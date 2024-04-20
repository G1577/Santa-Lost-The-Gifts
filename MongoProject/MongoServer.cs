using MongoProject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MongoDB.Driver;
//using MongoDB.Bson;

namespace MongoProject
{
    public static class MongoServer
    {
        private static string connectionString;
        public static Level GetLevel(int index)
        {
            //var client = new MongoClient(connectionString);
            //var collection = client.GetDatabase("SantaLostTheGifts").GetCollection<BsonDocument>("Level");
            //var filter = Builders<BsonDocument>.Filter.Eq("index", index);
            //var level = collection.Find(filter).First();
            //Console.WriteLine(level);
            //return null;

        }
    }
}
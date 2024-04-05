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
    public static class Server
    {
        private static string connectionString;
        public static Level GetLevel(int levelId)
        {
            //var client = new MongoClient(connectionString);
            //var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
            //var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
            //var document = collection.Find(filter).First();
            //Console.WriteLine(document);
            return null;

        }
    }
}

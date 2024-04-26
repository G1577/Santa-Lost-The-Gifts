using MongoProject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoProject
{
    public static class MongoServer
    {
        private static string connectionString = Constants.connectionString;
        private static IMongoCollection<Level> _levelsCollection;

        public static Level GetLevel(int index, LevelEnvironment levelEnvironment)
        {
            var client = new MongoClient(connectionString);
            _levelsCollection = client.GetDatabase(Constants.datebase).GetCollection<Level>(Constants.collection);
            var builder = Builders<Level>.Filter;
            var filter = builder.Eq("index", index); //& builder.Eq("levelEnvironment", levelEnvironment);
            Level level = _levelsCollection.Find(filter).First();
            return level;

        }
    }
}
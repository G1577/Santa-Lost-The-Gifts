using MongoProject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using MongoDB.Driver.Core.Operations;
using System.Collections;

namespace MongoProject
{
    public static class MongoServer
    {
        private static string connectionString = Constants.connectionString;
        private static IMongoCollection<Level> _levelsCollection;

        public static Level GetLevel(int index)
        {
            var client = new MongoClient(connectionString);
            _levelsCollection = client.GetDatabase(Constants.datebase).GetCollection<Level>(Constants.collection);
            var builder = Builders<Level>.Filter;
            var filter = Builders<Level>.Filter.And(Builders<Level>.Filter.Eq("index", index));
            Level level = _levelsCollection.Find(filter).FirstOrDefault();
            return level;
        }
    }
}
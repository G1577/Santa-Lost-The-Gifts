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
using Windows.UI.StartScreen;

namespace MongoProject
{
    public static class MongoServer
    {
        private static string connectionString = Constants.connectionString;//מקבל את הקישור לשלב
        private static IMongoCollection<Level> _levelsCollection;//מתאים את מה שהיתקבל למחלקה Level

        public static Level GetLevel(int index, string levelEnvironment)//מחזיר את הדלב לפי הסוג והאימדק שלו
        {
            var client = new MongoClient(connectionString);
            _levelsCollection = client.GetDatabase(Constants.datebase).GetCollection<Level>(Constants.collection);
            var filter = Builders<Level>.Filter.And(Builders<Level>.Filter.Eq("index", index),
                Builders<Level>.Filter.Eq("levelEnvironment", levelEnvironment));
            Level level = _levelsCollection.Find(filter).FirstOrDefault();
            return level;
        }

        public static long GetNumberOfLevelsPerEnv(string levelEnvironment)//מחזיר כמה שללבים יש באזור מסויים
        {
            var client = new MongoClient(connectionString);
            _levelsCollection = client.GetDatabase(Constants.datebase).GetCollection<Level>(Constants.collection);
            var filter = Builders<Level>.Filter.And(Builders<Level>.Filter.Eq("levelEnvironment", levelEnvironment));
            long count = _levelsCollection.CountDocuments(filter);
            return count;
        }
    }
}
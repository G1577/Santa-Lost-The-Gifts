﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using MongoProject.Modules;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoProject.Modules
{
    public enum LevelEnvironment
    {
        NorthPole,
        Forest,
        Desert
    }
    public class Level
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int index;
        [BsonRepresentation(BsonType.String)]
        public LevelEnvironment levelEnvironment; 
        public TileInfo[] tiles;
        public DecorationInfo[] decorations;
        public EnemyInfo[] enemies;
        public int playerFirstPositionX;
        public int playerFirstPositionY;
        public int giftPositionX;
        public int giftPositionY;
        // We will have enemies array in the future;

    }
}
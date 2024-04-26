using GameEngine.GameServices;
using Santa_Lost_The_Gifts.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using MongoProject;
using MongoProject.Modules;
using Windows.UI.StartScreen;

namespace Santa_Lost_The_Gifts.GameServices
{
    public class GameManager : Manager
    {
        //public static GameUser player = new GameUser();
        
        public GameManager(Scene scene):
            base(scene)
        {
            scene.Ground = scene.ActualHeight - 60;
            Init();
        }

        public void Init()
        {
            Level level = MongoServer.GetLevel(1, LevelEnvironment.NorthPole);
            Scene.RemoveAllObject();
            Tile tile;
            //Decoration decoration;
            int tileWidth = 64, tileHeight = 64;

            for (int i = 0; i < level.tiles.Length; i++)
            {
                TileInfo tileInfo = level.tiles[i];
                tile = new Tile(Scene, $"LevelDesign/Tiles/NorthPole/{tileInfo.name}.png", tileWidth * tileInfo.column, tileHeight * tileInfo.row, tileWidth, tileHeight);
                Scene.AddObject(tile);

            }

            Santa santa = new Santa(Scene, "Characters/Santa/santa_idle_right.gif", level.playerFirstPositionX , level.playerFirstPositionY, Santa.SantaType.idleRight, 55, 80);
            Scene.AddObject(santa);
            Scene.Init();
        }
    }
}
